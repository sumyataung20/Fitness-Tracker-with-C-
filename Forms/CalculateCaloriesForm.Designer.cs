namespace FitnessTracker.Forms
{
    partial class CalculateCaloriesForm
    {
        private System.ComponentModel.IContainer components = null;

        private ComboBox comboBoxActivity;
        private ComboBox comboBoxDescription;
        private TextBox textBoxDuration;
        private TextBox textBoxMetric1;
        private TextBox textBoxMetric2;
        private TextBox textBoxMetric3;
        private TextBox textBoxWeight;
        private Label labelMetric1;
        private Label labelMetric2;
        private Label labelMetric3;
        private Label labelWeight;
        private Label labelMET;
        private Button buttonCalculate;
        private Label labelResult;

        // New labels for ComboBoxes and Duration
        private Label labelActivity;
        private Label labelDescription;
        private Label labelDuration;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboBoxActivity = new ComboBox();
            this.comboBoxDescription = new ComboBox();
            this.textBoxDuration = new TextBox();
            this.textBoxMetric1 = new TextBox();
            this.textBoxMetric2 = new TextBox();
            this.textBoxMetric3 = new TextBox();
            this.textBoxWeight = new TextBox();
            this.labelMetric1 = new Label();
            this.labelMetric2 = new Label();
            this.labelMetric3 = new Label();
            this.labelWeight = new Label();
            this.labelMET = new Label();
            this.buttonCalculate = new Button();
            this.labelResult = new Label();

            // New labels
            this.labelActivity = new Label();
            this.labelDescription = new Label();
            this.labelDuration = new Label();

            this.SuspendLayout();

            // Activity Label
            this.labelActivity.Location = new System.Drawing.Point(50, 0);
            this.labelActivity.Size = new System.Drawing.Size(200, 20);
            this.labelActivity.Text = "Activity";

            // Description Label
            this.labelDescription.Location = new System.Drawing.Point(50, 40);
            this.labelDescription.Size = new System.Drawing.Size(200, 20);
            this.labelDescription.Text = "Description";

            // comboBoxActivity
            this.comboBoxActivity.Location = new System.Drawing.Point(50, 20);
            this.comboBoxActivity.Size = new System.Drawing.Size(200, 30);
            this.comboBoxActivity.SelectedIndexChanged += ComboBoxActivity_SelectedIndexChanged;

            // comboBoxDescription
            this.comboBoxDescription.Location = new System.Drawing.Point(50, 60);
            this.comboBoxDescription.Size = new System.Drawing.Size(200, 30);
            this.comboBoxDescription.SelectedIndexChanged += ComboBoxDescription_SelectedIndexChanged;

            // Duration Label
            this.labelDuration.Location = new System.Drawing.Point(50, 80);
            this.labelDuration.Size = new System.Drawing.Size(200, 20);
            this.labelDuration.Text = "Duration (minutes)";

            // Duration TextBox
            this.textBoxDuration.Location = new System.Drawing.Point(50, 100);
            this.textBoxDuration.PlaceholderText = "Duration (minutes)";

            // Weight
            this.labelWeight.Location = new System.Drawing.Point(50, 130);
            this.labelWeight.Size = new System.Drawing.Size(150, 20);
            this.labelWeight.Text = "Body Weight (kg):";
            this.textBoxWeight.Location = new System.Drawing.Point(50, 150);
            this.textBoxWeight.Size = new System.Drawing.Size(100, 25);

            // Metric 1
            this.labelMetric1.Location = new System.Drawing.Point(50, 180);
            this.labelMetric1.Size = new System.Drawing.Size(200, 20);
            this.textBoxMetric1.Location = new System.Drawing.Point(50, 200);
            this.textBoxMetric1.Size = new System.Drawing.Size(100, 25);

            // Metric 2
            this.labelMetric2.Location = new System.Drawing.Point(50, 230);
            this.labelMetric2.Size = new System.Drawing.Size(200, 20);
            this.textBoxMetric2.Location = new System.Drawing.Point(50, 250);
            this.textBoxMetric2.Size = new System.Drawing.Size(100, 25);

            // Metric 3
            this.labelMetric3.Location = new System.Drawing.Point(50, 280);
            this.labelMetric3.Size = new System.Drawing.Size(200, 20);
            this.textBoxMetric3.Location = new System.Drawing.Point(50, 300);
            this.textBoxMetric3.Size = new System.Drawing.Size(100, 25);

            // MET Label
            this.labelMET.Location = new System.Drawing.Point(50, 330);
            this.labelMET.Size = new System.Drawing.Size(200, 20);
            this.labelMET.Text = "MET: 0";

            // Calculate Button
            this.buttonCalculate.Location = new System.Drawing.Point(50, 360);
            this.buttonCalculate.Size = new System.Drawing.Size(120, 30);
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.Click += ButtonCalculate_Click;

            // Result Label
            this.labelResult.Location = new System.Drawing.Point(50, 400);
            this.labelResult.Size = new System.Drawing.Size(300, 30);

            // Add controls
            this.Controls.Add(labelActivity);
            this.Controls.Add(labelDescription);
            this.Controls.Add(labelDuration);
            this.Controls.Add(comboBoxActivity);
            this.Controls.Add(comboBoxDescription);
            this.Controls.Add(textBoxDuration);
            this.Controls.Add(labelWeight);
            this.Controls.Add(textBoxWeight);
            this.Controls.Add(labelMetric1);
            this.Controls.Add(textBoxMetric1);
            this.Controls.Add(labelMetric2);
            this.Controls.Add(textBoxMetric2);
            this.Controls.Add(labelMetric3);
            this.Controls.Add(textBoxMetric3);
            this.Controls.Add(labelMET);
            this.Controls.Add(buttonCalculate);
            this.Controls.Add(labelResult);

            // Form
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Name = "CalculateCaloriesForm";
            this.Text = "Calculate Calories";
            this.ResumeLayout(false);
        }
    }
}
