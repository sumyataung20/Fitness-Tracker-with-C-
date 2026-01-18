namespace FitnessTracker.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblWelcome;
        private ProgressBar progressCalories;
        private Label lblCaloriesLeft;
        private Button btnCalculateCalories;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.progressCalories = new System.Windows.Forms.ProgressBar();
            this.lblCaloriesLeft = new System.Windows.Forms.Label();
            this.btnCalculateCalories = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(30, 30);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(200, 30);
            this.lblWelcome.Text = "Welcome, User!";

            // 
            // progressCalories
            // 
            this.progressCalories.Location = new System.Drawing.Point(35, 80);
            this.progressCalories.Name = "progressCalories";
            this.progressCalories.Size = new System.Drawing.Size(320, 25);
            this.progressCalories.Maximum = 100; // percentage
            this.progressCalories.Value = 0;

            // 
            // lblCaloriesLeft
            // 
            this.lblCaloriesLeft.AutoSize = true;
            this.lblCaloriesLeft.Location = new System.Drawing.Point(35, 115);
            this.lblCaloriesLeft.Name = "lblCaloriesLeft";
            this.lblCaloriesLeft.Size = new System.Drawing.Size(200, 17);
            this.lblCaloriesLeft.Text = "You have left 0 calories to burn.";

            // 
            // btnCalculateCalories
            // 
            this.btnCalculateCalories.Location = new System.Drawing.Point(35, 150);
            this.btnCalculateCalories.Name = "btnCalculateCalories";
            this.btnCalculateCalories.Size = new System.Drawing.Size(150, 35);
            this.btnCalculateCalories.Text = "Calculate Calories";
            this.btnCalculateCalories.Click += new System.EventHandler(this.btnCalculateCalories_Click);

            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 220);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.progressCalories);
            this.Controls.Add(this.lblCaloriesLeft);
            this.Controls.Add(this.btnCalculateCalories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "MainForm";
            this.Text = "Fitness Tracker";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
