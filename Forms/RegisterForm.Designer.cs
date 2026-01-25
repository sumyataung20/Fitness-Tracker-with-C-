namespace FitnessTracker.Forms
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblCalorieGoal;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblTimeTaken;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtCalorieGoal;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.TextBox txtTimeTakenDays;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.LinkLabel linkLogin;

        // New label for password toggle
        private System.Windows.Forms.Label lblTogglePassword;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblCalorieGoal = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblTimeTaken = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtCalorieGoal = new System.Windows.Forms.TextBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.txtTimeTakenDays = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.linkLogin = new System.Windows.Forms.LinkLabel();
            this.lblTogglePassword = new System.Windows.Forms.Label(); // password toggle
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(120, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(160, 25);
            this.lblTitle.Text = "User Registration";

            // lblUsername
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(50, 70);
            this.lblUsername.Text = "Username:";

            // txtUsername
            this.txtUsername.Location = new System.Drawing.Point(200, 67);
            this.txtUsername.Size = new System.Drawing.Size(180, 23);

            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(50, 110);
            this.lblPassword.Text = "Password:";

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(200, 107);
            this.txtPassword.Size = new System.Drawing.Size(180, 23);
            // this.txtPassword.PasswordChar = '*';

            // lblTogglePassword
            this.lblTogglePassword.AutoSize = true;
            this.lblTogglePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTogglePassword.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.lblTogglePassword.Location = new System.Drawing.Point(390, 107); // adjust position
            this.lblTogglePassword.Name = "lblTogglePassword";
            this.lblTogglePassword.Size = new System.Drawing.Size(24, 28);
            this.lblTogglePassword.TabIndex = 20;
            this.lblTogglePassword.Text = "👁";
            this.lblTogglePassword.Click += new System.EventHandler(this.lblTogglePassword_Click);

            // lblCalorieGoal
            this.lblCalorieGoal.AutoSize = true;
            this.lblCalorieGoal.Location = new System.Drawing.Point(50, 150);
            this.lblCalorieGoal.Text = "Calorie Goal:";

            // txtCalorieGoal
            this.txtCalorieGoal.Location = new System.Drawing.Point(200, 147);
            this.txtCalorieGoal.Size = new System.Drawing.Size(180, 23);

            // lblWeight
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(50, 190);
            this.lblWeight.Text = "Weight (kg):";

            // txtWeight
            this.txtWeight.Location = new System.Drawing.Point(200, 187);
            this.txtWeight.Size = new System.Drawing.Size(180, 23);

            // lblTimeTaken
            this.lblTimeTaken.AutoSize = true;
            this.lblTimeTaken.Location = new System.Drawing.Point(50, 230);
            this.lblTimeTaken.Text = "Time to achieve goal (days):";

            // txtTimeTakenDays
            this.txtTimeTakenDays.Location = new System.Drawing.Point(200, 227);
            this.txtTimeTakenDays.Size = new System.Drawing.Size(180, 23);

            // btnRegister
            this.btnRegister.Location = new System.Drawing.Point(150, 270);
            this.btnRegister.Size = new System.Drawing.Size(120, 35);
            this.btnRegister.Text = "Register";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // linkLogin
            this.linkLogin.AutoSize = true;
            this.linkLogin.Location = new System.Drawing.Point(120, 320);
            this.linkLogin.Name = "linkLogin";
            this.linkLogin.Size = new System.Drawing.Size(180, 17);
            this.linkLogin.TabIndex = 5;
            this.linkLogin.TabStop = true;
            this.linkLogin.Text = "Already have an account? Login";
            this.linkLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLogin_LinkClicked);

            // RegisterForm
            this.ClientSize = new System.Drawing.Size(450, 360);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblTogglePassword);
            this.Controls.Add(this.lblCalorieGoal);
            this.Controls.Add(this.txtCalorieGoal);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.lblTimeTaken);
            this.Controls.Add(this.txtTimeTakenDays);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.linkLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
