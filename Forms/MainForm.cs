using System;
using System.Text;
using System.Windows.Forms;
using FitnessTracker.Models;
using MySql.Data.MySqlClient;
using FitnessTracker.Class;

namespace FitnessTracker.Forms
{
    public partial class MainForm : Form
    {
        private User currentUser;
        private double caloriesBurned;

        public MainForm(User user)
        {
            InitializeComponent();
            currentUser = user;

            lblWelcome.Text = $"Welcome, {currentUser.Username}!";

            LoadCaloriesFromDatabase();
            LoadActivityRecords();
            UpdateCaloriesProgress();
        }

        // 🔹 Load total burned calories from DB
        private void LoadCaloriesFromDatabase()
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT IFNULL(SUM(total_calories), 0)
                    FROM activityrecords
                    WHERE user_id = @userId";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", currentUser.UserId);

                caloriesBurned = Convert.ToDouble(cmd.ExecuteScalar());
            }
        }

        // 🔹 Show activity records text
        private void LoadActivityRecords()
        {
            lstRecords.Items.Clear();

            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT total_calories, record_date
                    FROM activityrecords
                    WHERE user_id = @userId
                    ORDER BY record_date DESC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", currentUser.UserId);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    double calories = reader.GetDouble("total_calories");
                    DateTime date = reader.GetDateTime("record_date");

                    lstRecords.Items.Add(
                        $"You burned {calories:F2} calories on {date:yyyy-MM-dd}"
                    );
                }
            }
        }

        // 🔹 Progress bar + remaining calories
        private void UpdateCaloriesProgress()
        {
            double remaining = currentUser.CalorieGoal - caloriesBurned;
            if (remaining < 0) remaining = 0;

            lblCaloriesLeft.Text = $"You have left {remaining:F2} calories to burn.";

            int progress = 0;
            if (currentUser.CalorieGoal > 0)
                progress = (int)(caloriesBurned / currentUser.CalorieGoal * 100);

            if (progress > 100) progress = 100;
            progressCalories.Value = progress;

            // ✅ Show goal achieved message
            if (caloriesBurned >= currentUser.CalorieGoal && progress > 0)
            {
                MessageBox.Show("🎉 You have successfully achieved your calorie goal!", "Congratulations");
            }
        }

        private void btnCalculateCalories_Click(object sender, EventArgs e)
        {
            CalculateCaloriesForm calcForm =
                new CalculateCaloriesForm(currentUser);

            calcForm.ShowDialog();

            // 🔹 Reload after new record is added
            LoadCaloriesFromDatabase();
            LoadActivityRecords();
            UpdateCaloriesProgress();
        }
    }


}
