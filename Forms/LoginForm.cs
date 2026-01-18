using System;
using System.Windows.Forms;
using FitnessTracker.Class;
using FitnessTracker.Models;

namespace FitnessTracker.Forms
{
    public partial class LoginForm : Form
    {
        private int failedAttempts = 0;
        private const int MAX_ATTEMPTS = 3;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text; // plaintext for now

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Use your existing UserService.Login method
            User? user = UserService.Login(username, password);

            if (user != null)
            {
                MessageBox.Show($"Login successful! Your calorie goal: {user.CalorieGoal}", "Success");

                this.Hide(); // hide login form
                MainForm mainForm = new MainForm(user); // open main tracker
                mainForm.ShowDialog();
                this.Close(); // close login form after main form closes
            }
            else
            {
                HandleFailedLogin();
            }
        }

        private void HandleFailedLogin()
        {
            failedAttempts++;
            if (failedAttempts >= MAX_ATTEMPTS)
            {
                MessageBox.Show("Too many failed login attempts. Application will close.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else
            {
                MessageBox.Show($"Invalid username or password. Attempts left: {MAX_ATTEMPTS - failedAttempts}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
