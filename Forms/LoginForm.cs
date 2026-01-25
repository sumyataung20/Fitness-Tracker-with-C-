using System;
using System.Drawing;
using System.Windows.Forms;
using FitnessTracker.Class;
using FitnessTracker.Models;

namespace FitnessTracker.Forms
{
    public partial class LoginForm : Form
    {
        private bool isPasswordVisible = false;

        // Unicode icons
        private const string EyeOpen = "👁";
        private const string EyeClosed = "🙈";

        //  Login attempt handling
        private int failedAttempts = 0;
        private const int MaxAttempts = 3;
        private DateTime? lockUntil = null;
        private readonly TimeSpan lockDuration = TimeSpan.FromSeconds(30);

        public LoginForm()
        {
            InitializeComponent();

            // Ensure password is hidden at initial
            txtPassword.UseSystemPasswordChar = true;
            lblTogglePassword.Text = EyeOpen;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //  Check if account is locked
            if (lockUntil.HasValue && DateTime.Now < lockUntil.Value)
            {
                int remainingSeconds = (int)(lockUntil.Value - DateTime.Now).TotalSeconds;
                MessageBox.Show(
                    $"Too many failed attempts.\nPlease wait {remainingSeconds} seconds before trying again.",
                    "Login Locked",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show(
                    "Please enter both username and password.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            User? user = UserService.Login(username, password);

            if (user != null)
            {
                // Reset attempts on success
                failedAttempts = 0;
                lockUntil = null;

                MessageBox.Show(
                    $"Login successful! Your calorie goal: {user.CalorieGoal}",
                    "Success"
                );

                this.Hide();
                MainForm mainForm = new MainForm(user);
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                failedAttempts++;

                if (failedAttempts >= MaxAttempts)
                {
                    lockUntil = DateTime.Now.Add(lockDuration);
                    MessageBox.Show(
                        "Too many failed login attempts.\nLogin is locked for 30 seconds.",
                        "Login Locked",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                else
                {
                    MessageBox.Show(
                        $"Invalid username or password.\nAttempts remaining: {MaxAttempts - failedAttempts}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
        }

        private void lblTogglePassword_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            txtPassword.UseSystemPasswordChar = !isPasswordVisible;
            lblTogglePassword.Text = isPasswordVisible ? EyeClosed : EyeOpen;
        }
    }
}
