namespace VAWC_Recording_System.NewForms
{
    partial class IntakeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.intakeFormprintLayout1 = new VAWC_Recording_System.NewForms.IntakeFormprintLayout();
            this.SuspendLayout();
            // 
            // intakeFormprintLayout1
            // 
            this.intakeFormprintLayout1.BackColor = System.Drawing.Color.White;
            this.intakeFormprintLayout1.Location = new System.Drawing.Point(-2, 46);
            this.intakeFormprintLayout1.Margin = new System.Windows.Forms.Padding(4);
            this.intakeFormprintLayout1.Name = "intakeFormprintLayout1";
            this.intakeFormprintLayout1.Size = new System.Drawing.Size(2288, 1390);
            this.intakeFormprintLayout1.TabIndex = 0;
            // 
            // IntakeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1557, 939);
            this.Controls.Add(this.intakeFormprintLayout1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "IntakeForm";
            this.Text = "IntakeForm";
            this.ResumeLayout(false);

        }

        #endregion

        private IntakeFormprintLayout intakeFormprintLayout1;
    }
}