using System;
using System.Windows.Forms;
using FitnessTracker.Models;

namespace FitnessTracker.Forms
{
    public partial class MainForm : Form
    {
        private User currentUser;
        private int caloriesBurned; // you can update this as user records activities

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
            int remaining = currentUser.CalorieGoal - caloriesBurned;
            if (remaining < 0) remaining = 0;

            lblCaloriesLeft.Text = $"You have left {remaining} calories to burn.";

            int progress = 0;
            if (currentUser.CalorieGoal > 0)
                progress = (int)((double)caloriesBurned / currentUser.CalorieGoal * 100);

            if (progress > 100) progress = 100;
            progressCalories.Value = progress;
        }

        private void btnCalculateCalories_Click(object sender, EventArgs e)
        {
            // Open the CalculateCaloriesForm
            CalculateCaloriesForm calcForm = new CalculateCaloriesForm(currentUser);
            calcForm.ShowDialog();

            // After closing, update calories burned and progress
            caloriesBurned = calcForm.TotalCaloriesBurned; // assuming this is returned
            UpdateCaloriesProgress();
        }
    }
}
