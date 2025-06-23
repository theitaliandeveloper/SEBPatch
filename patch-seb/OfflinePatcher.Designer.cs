namespace patch_seb
{
	partial class OfflinePatcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OfflinePatcher));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.partitionComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.x86 = new System.Windows.Forms.RadioButton();
            this.x64 = new System.Windows.Forms.RadioButton();
            this.autodetect = new System.Windows.Forms.RadioButton();
            this.selectedinstallation = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(215, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Safe Exam Browser Offline Patch";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.partitionComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Safe Exam Browser installations";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(583, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "USE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Installation to patch:";
            // 
            // partitionComboBox
            // 
            this.partitionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.partitionComboBox.FormattingEnabled = true;
            this.partitionComboBox.Location = new System.Drawing.Point(178, 44);
            this.partitionComboBox.Name = "partitionComboBox";
            this.partitionComboBox.Size = new System.Drawing.Size(381, 29);
            this.partitionComboBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.x86);
            this.groupBox2.Controls.Add(this.x64);
            this.groupBox2.Controls.Add(this.autodetect);
            this.groupBox2.Controls.Add(this.selectedinstallation);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(12, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(716, 222);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Patch settings";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(25, 152);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(467, 25);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "Install custom certificate on the offline system (recommended)";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(25, 110);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 25);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Backup";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // x86
            // 
            this.x86.AutoSize = true;
            this.x86.Location = new System.Drawing.Point(605, 73);
            this.x86.Name = "x86";
            this.x86.Size = new System.Drawing.Size(60, 25);
            this.x86.TabIndex = 4;
            this.x86.Text = "x86";
            this.x86.UseVisualStyleBackColor = true;
            // 
            // x64
            // 
            this.x64.AutoSize = true;
            this.x64.Location = new System.Drawing.Point(525, 73);
            this.x64.Name = "x64";
            this.x64.Size = new System.Drawing.Size(60, 25);
            this.x64.TabIndex = 3;
            this.x64.Text = "x64";
            this.x64.UseVisualStyleBackColor = true;
            // 
            // autodetect
            // 
            this.autodetect.AutoSize = true;
            this.autodetect.Checked = true;
            this.autodetect.Location = new System.Drawing.Point(260, 73);
            this.autodetect.Name = "autodetect";
            this.autodetect.Size = new System.Drawing.Size(233, 25);
            this.autodetect.TabIndex = 2;
            this.autodetect.TabStop = true;
            this.autodetect.Text = "Auto-Detect (recommended)";
            this.autodetect.UseVisualStyleBackColor = true;
            // 
            // selectedinstallation
            // 
            this.selectedinstallation.AutoSize = true;
            this.selectedinstallation.Location = new System.Drawing.Point(21, 38);
            this.selectedinstallation.Name = "selectedinstallation";
            this.selectedinstallation.Size = new System.Drawing.Size(190, 21);
            this.selectedinstallation.TabIndex = 1;
            this.selectedinstallation.Text = "Selected Installation: none";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Safe Exam Browser Architecture:";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(220, 679);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(270, 62);
            this.button2.TabIndex = 3;
            this.button2.Text = "PATCH";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Location = new System.Drawing.Point(12, 414);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(716, 245);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Patch logs";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 25);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(707, 204);
            this.textBox1.TabIndex = 0;
            // 
            // OfflinePatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 753);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OfflinePatcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Safe Exam Browser Offline Patcher";
            this.Load += new System.EventHandler(this.OfflinePatcher_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox partitionComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton x86;
        private System.Windows.Forms.RadioButton x64;
        private System.Windows.Forms.RadioButton autodetect;
        private System.Windows.Forms.Label selectedinstallation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox1;
    }
}