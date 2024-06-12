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
            this.label1 = new System.Windows.Forms.Label();
            this.intakeFormprintLayout1 = new VAWC_Recording_System.NewForms.IntakeFormprintLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bakbak One", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 68);
            this.label1.TabIndex = 2;
            this.label1.Text = "INTAKE FORM";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // intakeFormprintLayout1
            // 
            this.intakeFormprintLayout1.BackColor = System.Drawing.Color.White;
            this.intakeFormprintLayout1.Location = new System.Drawing.Point(32, 85);
            this.intakeFormprintLayout1.Margin = new System.Windows.Forms.Padding(4);
            this.intakeFormprintLayout1.Name = "intakeFormprintLayout1";
            this.intakeFormprintLayout1.Size = new System.Drawing.Size(1500, 1600);
            this.intakeFormprintLayout1.TabIndex = 3;
            // 
            // IntakeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1600, 1102);
            this.Controls.Add(this.intakeFormprintLayout1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "IntakeForm";
            this.Text = "IntakeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private IntakeFormprintLayout intakeFormprintLayout1;
    }
}