using System;
using System.Windows.Forms;
using FitnessTracker.Class;
using FitnessTracker.Models;

namespace FitnessTracker.Forms
{
    public partial class RegisterForm : Form
    {
        private bool isPasswordVisible = false;

        private const string EyeOpen = "👁";
        private const string EyeClosed = "🙈";

        public RegisterForm()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true; // default masked
            lblTogglePassword.Text = EyeOpen;
        }

        // Handle password hide or show 
        // password hidden at initial 
        private void lblTogglePassword_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            txtPassword.UseSystemPasswordChar = !isPasswordVisible;
            lblTogglePassword.Text = isPasswordVisible ? EyeClosed : EyeOpen;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string goalText = txtCalorieGoal.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(goalText))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validator.ValidateUsername(username))
            {
                MessageBox.Show("Username can only contain letters and numbers.", "Invalid Username");
                return;
            }

            if (!Validator.ValidatePassword(password))
            {
                MessageBox.Show(
                    "Password must be exactly 12 characters long and contain at least one uppercase and one lowercase letter.",
                    "Invalid Password");
                return;
            }

            if (!int.TryParse(goalText, out int calorieGoal))
            {
                MessageBox.Show("Calorie goal must be a valid number.", "Invalid Input");
                return;
            }

            if (!decimal.TryParse(txtWeight.Text.Trim(), out decimal weight))
            {
                MessageBox.Show("Please enter a valid weight in kg.", "Invalid Input");
                return;
            }

            if (!int.TryParse(txtTimeTakenDays.Text.Trim(), out int timeTakenDays))
            {
                MessageBox.Show("Please enter valid number of days.", "Invalid Input");
                return;
            }

            if (UserService.UsernameExists(username))
            {
                MessageBox.Show("Username already exists. Please choose another.", "Duplicate Username");
                return;
            }

            User user = new User
            {
                Username = username,
                PasswordHash = password,
                CalorieGoal = calorieGoal,
                WeightKg = weight,
                TimeTakenDays = timeTakenDays
            };

            bool success = UserService.RegisterUser(user);

            if (success)
            {
                MessageBox.Show("Registration successful!", "Success");

                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.", "Error");
            }
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Show();
        }
    }
}
