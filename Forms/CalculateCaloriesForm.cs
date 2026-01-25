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

        // Adding predefined metrics 
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

        //    Calculate Calories Form 
        public CalculateCaloriesForm(User user)
        {
            InitializeComponent();
            currentUser = user;

            textBoxWeight.Text = currentUser.WeightKg.ToString("F2");

            comboBoxActivity.Text = "Select an activity";
            comboBoxDescription.Text = "Select description";

            LoadActivities();
        }


        //    Select an activity 
        private void LoadActivities()
        {
            activities = Database.GetActivities();
            comboBoxActivity.DataSource = activities;
            comboBoxActivity.DisplayMember = "Name";
            comboBoxActivity.ValueMember = "Id";

            comboBoxActivity.SelectedIndex = -1;
            comboBoxActivity.Text = "Select an activity";
        }

        //    Select description according to the selected activity 
        private void ComboBoxActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxActivity.SelectedItem is not Activity activity)
                return;

            descriptions = Database.GetActivityDescriptions(activity.Id);
            comboBoxDescription.DataSource = descriptions;
            comboBoxDescription.DisplayMember = "Description";
            comboBoxDescription.ValueMember = "Id";

            comboBoxDescription.SelectedIndex = -1;
            comboBoxDescription.Text = "Select description";

            if (activityMetrics.TryGetValue(activity.Id, out var metrics))
            {
                labelMetric1.Text = metrics[0];
                labelMetric2.Text = metrics[1];
                labelMetric3.Text = metrics[2];
            }

            labelMET.Text = "MET: 0";
        }

        private void ComboBoxDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDescription.SelectedItem is not ActivityDescription desc)
                return;

            labelMET.Text = $"MET: {desc.MET}";
        }


        private void ButtonCalculate_Click(object sender, EventArgs e)
        {
            if (comboBoxActivity.SelectedItem is not Activity activity ||
                comboBoxDescription.SelectedItem is not ActivityDescription desc)
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

            double.TryParse(textBoxMetric1.Text, out double metric1);
            double.TryParse(textBoxMetric2.Text, out double metric2);
            double.TryParse(textBoxMetric3.Text, out double metric3);

            double MET = desc.MET;

            // Formula to calculate the calories burned 
            double totalCalories = duration * (MET * 3.5 * weight) / 200;
            TotalCaloriesBurned = totalCalories;

            labelResult.Text = $"Total Calories Burned: {totalCalories:F2} kcal";

            Database.InsertActivityRecord(
                currentUser.UserId,
                activity.Id,
                desc.Id,
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
