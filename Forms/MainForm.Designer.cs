namespace FitnessTracker.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblWelcome;
        private ProgressBar progressCalories;
        private Label lblCaloriesLeft;
        private Button btnCalculateCalories;
        private ListBox lstRecords;

        private Button btnResetGoal;




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
            this.lstRecords = new System.Windows.Forms.ListBox();
            this.SuspendLayout();

            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(30, 20);

            // progressCalories
            this.progressCalories.Location = new System.Drawing.Point(35, 65);
            this.progressCalories.Size = new System.Drawing.Size(320, 25);
            this.progressCalories.Maximum = 100;

            // lblCaloriesLeft
            this.lblCaloriesLeft.AutoSize = true;
            this.lblCaloriesLeft.Location = new System.Drawing.Point(35, 100);

            // btnCalculateCalories
            this.btnCalculateCalories.Location = new System.Drawing.Point(35, 130);
            this.btnCalculateCalories.Size = new System.Drawing.Size(150, 35);
            this.btnCalculateCalories.Text = "Calculate Calories";
            this.btnCalculateCalories.Click += new System.EventHandler(this.btnCalculateCalories_Click);

            // lstRecords
            this.lstRecords.Location = new System.Drawing.Point(35, 180);
            this.lstRecords.Size = new System.Drawing.Size(320, 120);

            // MainForm
            this.ClientSize = new System.Drawing.Size(400, 330);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.progressCalories);
            this.Controls.Add(this.lblCaloriesLeft);
            this.Controls.Add(this.btnCalculateCalories);
            this.Controls.Add(this.lstRecords);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fitness Tracker";

            this.ResumeLayout(false);
            this.PerformLayout();


        }




    }

}
