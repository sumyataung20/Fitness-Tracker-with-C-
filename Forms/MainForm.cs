using System;
using System.Windows.Forms;
using FitnessTracker.Models;
using MySql.Data.MySqlClient;
using FitnessTracker.Forms;

namespace FitnessTracker.Forms
{
    public partial class MainForm : Form
    {
        private User currentUser;
        private double caloriesBurned; // Keep as double to match TotalCaloriesBurned

        public MainForm(User user)
        {
            InitializeComponent();
            currentUser = user;

            lblWelcome.Text = $"Welcome, {currentUser.Username}!";
            UpdateCaloriesProgress();
        }

        // Updates progress bar and label
        private void UpdateCaloriesProgress()
        {
            // Remaining calories (can have decimals)
            double remaining = currentUser.CalorieGoal - caloriesBurned;
            if (remaining < 0) remaining = 0;

            // Display remaining calories with 2 decimal places
            lblCaloriesLeft.Text = $"You have left {remaining:F2} calories to burn.";

            // Calculate progress as percentage for progress bar
            int progress = 0;
            if (currentUser.CalorieGoal > 0)
                progress = (int)(caloriesBurned / currentUser.CalorieGoal * 100);

            if (progress > 100) progress = 100;
            progressCalories.Value = progress;
        }

        private void btnCalculateCalories_Click(object sender, EventArgs e)
        {
            // Open the CalculateCaloriesForm
            CalculateCaloriesForm calcForm = new CalculateCaloriesForm(currentUser);
            calcForm.ShowDialog();

            // After closing, update calories burned and progress
            caloriesBurned = calcForm.TotalCaloriesBurned; // double -> double, no cast needed
            UpdateCaloriesProgress();
        }
    }
}
