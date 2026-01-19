using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FitnessTracker.Models;
using FitnessTracker.Class;

namespace FitnessTracker.Forms
{
    public partial class CalculateCaloriesForm : Form
    {
        private User currentUser;
        private List<Activity> activities = new List<Activity>();
        private List<ActivityDescription> descriptions = new List<ActivityDescription>();

        // Mapping activity -> metric labels
        private Dictionary<int, string[]> activityMetrics = new Dictionary<int, string[]>
        {
            {1, new string[]{"Steps", "Distance (km)", "Average heart rate"}},
            {2, new string[]{"Time per lap (min)", "Number of laps", "Average heart rate"}},
            {3, new string[]{"Distance (km)", "Pace (min/km)", "Average heart rate"}},
            {4, new string[]{"Distance (km)", "Speed (km/h)", "Average heart rate"}},
            {5, new string[]{"Duration (min)", "Calories burned", "Average heart rate"}},
            {6, new string[]{"Sets", "Reps", "Weight lifted (kg)"}}
        };

        public double TotalCaloriesBurned { get; private set; } = 0;

        public CalculateCaloriesForm(User user)
        {
            InitializeComponent();
            currentUser = user;

            // Pre-fill body weight
            textBoxWeight.Text = currentUser.WeightKg.ToString("F2");

            LoadActivities();
        }

        private void LoadActivities()
        {
            activities = Database.GetActivities();
            comboBoxActivity.DataSource = activities;
            comboBoxActivity.DisplayMember = "Name";
            comboBoxActivity.ValueMember = "Id";
        }

        private void ComboBoxActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxActivity.SelectedItem == null) return;
            var activity = (Activity)comboBoxActivity.SelectedItem;

            descriptions = Database.GetActivityDescriptions(activity.Id);
            comboBoxDescription.DataSource = descriptions;
            comboBoxDescription.DisplayMember = "Description";
            comboBoxDescription.ValueMember = "Id";

            // Set metric labels
            if (activityMetrics.ContainsKey(activity.Id))
            {
                labelMetric1.Text = activityMetrics[activity.Id][0];
                labelMetric2.Text = activityMetrics[activity.Id][1];
                labelMetric3.Text = activityMetrics[activity.Id][2];
            }

            labelMET.Text = "MET: 0";
        }

        private void ComboBoxDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDescription.SelectedItem == null) return;
            var desc = (ActivityDescription)comboBoxDescription.SelectedItem;
            labelMET.Text = $"MET: {desc.MET}";
        }

        private void ButtonCalculate_Click(object sender, EventArgs e)
        {
            if (comboBoxActivity.SelectedItem == null || comboBoxDescription.SelectedItem == null)
            {
                MessageBox.Show("Please select an activity and description.");
                return;
            }

            if (!double.TryParse(textBoxDuration.Text, out double duration) || duration <= 0)
            {
                MessageBox.Show("Please enter a valid duration in minutes.");
                return;
            }

            if (!double.TryParse(textBoxWeight.Text, out double weight) || weight <= 0)
            {
                MessageBox.Show("Please enter a valid weight in kg.");
                return;
            }

            double metric1 = double.TryParse(textBoxMetric1.Text, out metric1) ? metric1 : 0;
            double metric2 = double.TryParse(textBoxMetric2.Text, out metric2) ? metric2 : 0;
            double metric3 = double.TryParse(textBoxMetric3.Text, out metric3) ? metric3 : 0;

            double MET = ((ActivityDescription)comboBoxDescription.SelectedItem).MET;

            // Total calories formula
            double totalCalories = duration * (MET * 3.5 * weight) / 200;
            TotalCaloriesBurned = totalCalories;

            labelResult.Text = $"Total Calories Burned: {totalCalories:F2} kcal";

            // Save record to DB
            Database.InsertActivityRecord(
                currentUser.UserId,
                ((Activity)comboBoxActivity.SelectedItem).Id,
                ((ActivityDescription)comboBoxDescription.SelectedItem).Id,
                duration,
                metric1,
                metric2,
                metric3,
                totalCalories,
                DateTime.Today
            );

            MessageBox.Show("Activity recorded successfully!");
        }
    }
}
