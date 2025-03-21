namespace VAWC_Recording_System
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.minimize_button = new System.Windows.Forms.Button();
            this.close_button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.systemManagement_btn = new System.Windows.Forms.Button();
            this.inTakeForm_btn = new System.Windows.Forms.Button();
            this.manageCaselist_btn = new System.Windows.Forms.Button();
            this.logout_btn = new System.Windows.Forms.Button();
            this.reports_btn = new System.Windows.Forms.Button();
            this.caseList_btn = new System.Windows.Forms.Button();
            this.home_btn = new System.Windows.Forms.Button();
            this.newCase_btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(261, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(906, 884);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 32);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(906, 852);
            this.panel4.TabIndex = 2;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.minimize_button);
            this.panel3.Controls.Add(this.close_button);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(906, 32);
            this.panel3.TabIndex = 1;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(336, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 20);
            this.label6.TabIndex = 306;
            this.label6.Text = "00:00:00 am/pm";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 20);
            this.label4.TabIndex = 305;
            this.label4.Text = "dddd, MM dd, yyyy";
            // 
            // minimize_button
            // 
            this.minimize_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimize_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimize_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimize_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimize_button.Location = new System.Drawing.Point(777, 0);
            this.minimize_button.Margin = new System.Windows.Forms.Padding(2);
            this.minimize_button.Name = "minimize_button";
            this.minimize_button.Size = new System.Drawing.Size(38, 32);
            this.minimize_button.TabIndex = 304;
            this.minimize_button.Text = "🗕";
            this.minimize_button.UseVisualStyleBackColor = true;
            this.minimize_button.Click += new System.EventHandler(this.minimize_button_Click);
            // 
            // close_button
            // 
            this.close_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.close_button.BackColor = System.Drawing.Color.Red;
            this.close_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_button.ForeColor = System.Drawing.Color.White;
            this.close_button.Location = new System.Drawing.Point(820, 0);
            this.close_button.Margin = new System.Windows.Forms.Padding(2);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(86, 32);
            this.close_button.TabIndex = 301;
            this.close_button.Text = "CLOSE";
            this.close_button.UseVisualStyleBackColor = false;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(64)))), ((int)(((byte)(107)))));
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.systemManagement_btn);
            this.panel2.Controls.Add(this.inTakeForm_btn);
            this.panel2.Controls.Add(this.manageCaselist_btn);
            this.panel2.Controls.Add(this.logout_btn);
            this.panel2.Controls.Add(this.reports_btn);
            this.panel2.Controls.Add(this.caseList_btn);
            this.panel2.Controls.Add(this.home_btn);
            this.panel2.Controls.Add(this.newCase_btn);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 884);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(78, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "label5";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::VAWC_Recording_System.Properties.Resources.adminoutline;
            this.pictureBox2.Location = new System.Drawing.Point(21, 110);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 51);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(112, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 60);
            this.label3.TabIndex = 13;
            this.label3.Text = "VAWC\r\nRECORDING\r\nSYSTEM";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.ForeColor = System.Drawing.SystemColors.Control;
            this.panel5.Location = new System.Drawing.Point(21, 274);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(215, 2);
            this.panel5.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(78, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(76, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // systemManagement_btn
            // 
            this.systemManagement_btn.FlatAppearance.BorderSize = 0;
            this.systemManagement_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.systemManagement_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemManagement_btn.ForeColor = System.Drawing.Color.White;
            this.systemManagement_btn.Image = global::VAWC_Recording_System.Properties.Resources.tdesign_system_log;
            this.systemManagement_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.systemManagement_btn.Location = new System.Drawing.Point(25, 591);
            this.systemManagement_btn.Name = "systemManagement_btn";
            this.systemManagement_btn.Size = new System.Drawing.Size(205, 50);
            this.systemManagement_btn.TabIndex = 9;
            this.systemManagement_btn.Text = "             SYSTEM\r\n             MANAGEMENT";
            this.systemManagement_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.systemManagement_btn.UseVisualStyleBackColor = true;
            this.systemManagement_btn.Click += new System.EventHandler(this.systemManagement_btn_Click);
            // 
            // inTakeForm_btn
            // 
            this.inTakeForm_btn.FlatAppearance.BorderSize = 0;
            this.inTakeForm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inTakeForm_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inTakeForm_btn.ForeColor = System.Drawing.Color.White;
            this.inTakeForm_btn.Image = global::VAWC_Recording_System.Properties.Resources.material_symbols_light_edit_document_sharp;
            this.inTakeForm_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.inTakeForm_btn.Location = new System.Drawing.Point(21, 475);
            this.inTakeForm_btn.Name = "inTakeForm_btn";
            this.inTakeForm_btn.Size = new System.Drawing.Size(216, 43);
            this.inTakeForm_btn.TabIndex = 8;
            this.inTakeForm_btn.Text = "             INTAKE FORM";
            this.inTakeForm_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.inTakeForm_btn.UseVisualStyleBackColor = true;
            this.inTakeForm_btn.Click += new System.EventHandler(this.inTakeForm_btn_Click);
            // 
            // manageCaselist_btn
            // 
            this.manageCaselist_btn.FlatAppearance.BorderSize = 0;
            this.manageCaselist_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manageCaselist_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageCaselist_btn.ForeColor = System.Drawing.Color.White;
            this.manageCaselist_btn.Image = global::VAWC_Recording_System.Properties.Resources.ri_list_check_3;
            this.manageCaselist_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.manageCaselist_btn.Location = new System.Drawing.Point(21, 417);
            this.manageCaselist_btn.Name = "manageCaselist_btn";
            this.manageCaselist_btn.Size = new System.Drawing.Size(216, 43);
            this.manageCaselist_btn.TabIndex = 7;
            this.manageCaselist_btn.Text = "             MANAGE CASE LIST";
            this.manageCaselist_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.manageCaselist_btn.UseVisualStyleBackColor = true;
            this.manageCaselist_btn.Click += new System.EventHandler(this.manageCaselist_btn_Click);
            // 
            // logout_btn
            // 
            this.logout_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logout_btn.FlatAppearance.BorderSize = 0;
            this.logout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout_btn.ForeColor = System.Drawing.Color.White;
            this.logout_btn.Image = global::VAWC_Recording_System.Properties.Resources.ic_sharp_logout;
            this.logout_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logout_btn.Location = new System.Drawing.Point(21, 816);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(216, 43);
            this.logout_btn.TabIndex = 6;
            this.logout_btn.Text = "             LOG OUT";
            this.logout_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logout_btn.UseVisualStyleBackColor = true;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // reports_btn
            // 
            this.reports_btn.FlatAppearance.BorderSize = 0;
            this.reports_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reports_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reports_btn.ForeColor = System.Drawing.Color.White;
            this.reports_btn.Image = global::VAWC_Recording_System.Properties.Resources.gridicons_pages;
            this.reports_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reports_btn.Location = new System.Drawing.Point(21, 533);
            this.reports_btn.Name = "reports_btn";
            this.reports_btn.Size = new System.Drawing.Size(216, 43);
            this.reports_btn.TabIndex = 4;
            this.reports_btn.Text = "             REPORTS";
            this.reports_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reports_btn.UseVisualStyleBackColor = true;
            this.reports_btn.Click += new System.EventHandler(this.reports_btn_Click);
            // 
            // caseList_btn
            // 
            this.caseList_btn.FlatAppearance.BorderSize = 0;
            this.caseList_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.caseList_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caseList_btn.ForeColor = System.Drawing.Color.White;
            this.caseList_btn.Image = global::VAWC_Recording_System.Properties.Resources.ep_list;
            this.caseList_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.caseList_btn.Location = new System.Drawing.Point(21, 358);
            this.caseList_btn.Name = "caseList_btn";
            this.caseList_btn.Size = new System.Drawing.Size(216, 43);
            this.caseList_btn.TabIndex = 3;
            this.caseList_btn.Text = "             CASE LIST";
            this.caseList_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.caseList_btn.UseVisualStyleBackColor = true;
            this.caseList_btn.Click += new System.EventHandler(this.caseList_btn_Click);
            // 
            // home_btn
            // 
            this.home_btn.FlatAppearance.BorderSize = 0;
            this.home_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.home_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.home_btn.ForeColor = System.Drawing.Color.White;
            this.home_btn.Image = global::VAWC_Recording_System.Properties.Resources.material_symbols_light_home;
            this.home_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.home_btn.Location = new System.Drawing.Point(21, 300);
            this.home_btn.Name = "home_btn";
            this.home_btn.Size = new System.Drawing.Size(216, 43);
            this.home_btn.TabIndex = 2;
            this.home_btn.Text = "             HOME";
            this.home_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.home_btn.UseVisualStyleBackColor = true;
            this.home_btn.Click += new System.EventHandler(this.home_btn_Click);
            // 
            // newCase_btn
            // 
            this.newCase_btn.BackgroundImage = global::VAWC_Recording_System.Properties.Resources.GreenRectangle;
            this.newCase_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.newCase_btn.FlatAppearance.BorderSize = 0;
            this.newCase_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newCase_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newCase_btn.ForeColor = System.Drawing.Color.White;
            this.newCase_btn.Location = new System.Drawing.Point(21, 206);
            this.newCase_btn.Name = "newCase_btn";
            this.newCase_btn.Size = new System.Drawing.Size(216, 49);
            this.newCase_btn.TabIndex = 1;
            this.newCase_btn.Text = "FILE A CASE";
            this.newCase_btn.UseVisualStyleBackColor = true;
            this.newCase_btn.Click += new System.EventHandler(this.newCase_btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VAWC_Recording_System.Properties.Resources._20240518_100404;
            this.pictureBox1.Location = new System.Drawing.Point(21, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1167, 884);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "VAWC Barangay Camanga";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button newCase_btn;
        private System.Windows.Forms.Button reports_btn;
        private System.Windows.Forms.Button caseList_btn;
        private System.Windows.Forms.Button logout_btn;
        private System.Windows.Forms.Button manageCaselist_btn;
        private System.Windows.Forms.Button systemManagement_btn;
        private System.Windows.Forms.Button inTakeForm_btn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Button minimize_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button home_btn;
    }
}