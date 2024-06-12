namespace VAWC_Recording_System.NewForms
{
    partial class CustomPrintPreviewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomPrintPreviewForm));
            this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            this.Print_Button = new System.Windows.Forms.Button();
            this.SavePDF_Button = new System.Windows.Forms.Button();
            this.Copies_NumUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Copies_NumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // printPreviewControl1
            // 
            this.printPreviewControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.printPreviewControl1.Location = new System.Drawing.Point(38, 67);
            this.printPreviewControl1.Name = "printPreviewControl1";
            this.printPreviewControl1.Size = new System.Drawing.Size(1213, 710);
            this.printPreviewControl1.TabIndex = 0;
            this.printPreviewControl1.Click += new System.EventHandler(this.printPreviewControl1_Click);
            // 
            // Print_Button
            // 
            this.Print_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Print_Button.Location = new System.Drawing.Point(1176, 28);
            this.Print_Button.Name = "Print_Button";
            this.Print_Button.Size = new System.Drawing.Size(75, 23);
            this.Print_Button.TabIndex = 1;
            this.Print_Button.Text = "PRINT";
            this.Print_Button.UseVisualStyleBackColor = true;
            this.Print_Button.Click += new System.EventHandler(this.Print_Button_Click);
            // 
            // SavePDF_Button
            // 
            this.SavePDF_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SavePDF_Button.Location = new System.Drawing.Point(1050, 28);
            this.SavePDF_Button.Name = "SavePDF_Button";
            this.SavePDF_Button.Size = new System.Drawing.Size(106, 23);
            this.SavePDF_Button.TabIndex = 2;
            this.SavePDF_Button.Text = "SAVE AS PDF";
            this.SavePDF_Button.UseVisualStyleBackColor = true;
            this.SavePDF_Button.Click += new System.EventHandler(this.SavePDF_Button_Click);
            // 
            // Copies_NumUpDown
            // 
            this.Copies_NumUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Copies_NumUpDown.Location = new System.Drawing.Point(907, 28);
            this.Copies_NumUpDown.Name = "Copies_NumUpDown";
            this.Copies_NumUpDown.Size = new System.Drawing.Size(120, 22);
            this.Copies_NumUpDown.TabIndex = 3;
            this.Copies_NumUpDown.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // CustomPrintPreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 789);
            this.Controls.Add(this.Copies_NumUpDown);
            this.Controls.Add(this.SavePDF_Button);
            this.Controls.Add(this.Print_Button);
            this.Controls.Add(this.printPreviewControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomPrintPreviewForm";
            this.Text = "CustomPrintPreviewForm";
            ((System.ComponentModel.ISupportInitialize)(this.Copies_NumUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
        private System.Windows.Forms.Button Print_Button;
        private System.Windows.Forms.Button SavePDF_Button;
        private System.Windows.Forms.NumericUpDown Copies_NumUpDown;
    }
}