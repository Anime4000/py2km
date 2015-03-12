namespace py2km
{
	partial class frmMain
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
			this.btnConvert = new System.Windows.Forms.Button();
			this.rtfOutput = new System.Windows.Forms.RichTextBox();
			this.btnClear = new System.Windows.Forms.Button();
			this.rtfInput = new System.Windows.Forms.RichTextBox();
			this.cboSource = new System.Windows.Forms.ComboBox();
			this.chkPinyinRules = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// btnConvert
			// 
			this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnConvert.Location = new System.Drawing.Point(713, 12);
			this.btnConvert.Name = "btnConvert";
			this.btnConvert.Size = new System.Drawing.Size(75, 23);
			this.btnConvert.TabIndex = 2;
			this.btnConvert.Text = "&Convert";
			this.btnConvert.UseVisualStyleBackColor = true;
			this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
			// 
			// rtfOutput
			// 
			this.rtfOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtfOutput.Font = new System.Drawing.Font("Arial Kwik Mandarin Modified", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtfOutput.Location = new System.Drawing.Point(400, 41);
			this.rtfOutput.Name = "rtfOutput";
			this.rtfOutput.Size = new System.Drawing.Size(388, 547);
			this.rtfOutput.TabIndex = 3;
			this.rtfOutput.Text = "";
			// 
			// btnClear
			// 
			this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClear.Location = new System.Drawing.Point(632, 12);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 4;
			this.btnClear.Text = "&Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// rtfInput
			// 
			this.rtfInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.rtfInput.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtfInput.Location = new System.Drawing.Point(12, 41);
			this.rtfInput.Name = "rtfInput";
			this.rtfInput.Size = new System.Drawing.Size(388, 547);
			this.rtfInput.TabIndex = 9;
			this.rtfInput.Text = "";
			// 
			// cboSource
			// 
			this.cboSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboSource.FormattingEnabled = true;
			this.cboSource.Items.AddRange(new object[] {
            "Number to Pinyin",
            "Number to Kwik Mandarin",
            "Pinyin to Pinyin",
            "Pinyin to Kwik Mandarin",
            "Hanzi to Pinyin",
            "Hanzi to Kwik Mandarin"});
			this.cboSource.Location = new System.Drawing.Point(12, 14);
			this.cboSource.Name = "cboSource";
			this.cboSource.Size = new System.Drawing.Size(220, 21);
			this.cboSource.TabIndex = 10;
			this.cboSource.SelectedIndexChanged += new System.EventHandler(this.cboSource_SelectedIndexChanged);
			// 
			// chkPinyinRules
			// 
			this.chkPinyinRules.AutoSize = true;
			this.chkPinyinRules.Location = new System.Drawing.Point(400, 16);
			this.chkPinyinRules.Name = "chkPinyinRules";
			this.chkPinyinRules.Size = new System.Drawing.Size(113, 17);
			this.chkPinyinRules.TabIndex = 11;
			this.chkPinyinRules.Text = "&Apply Pinyin Rules";
			this.chkPinyinRules.UseVisualStyleBackColor = true;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 600);
			this.Controls.Add(this.chkPinyinRules);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.cboSource);
			this.Controls.Add(this.rtfInput);
			this.Controls.Add(this.btnConvert);
			this.Controls.Add(this.rtfOutput);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinimumSize = new System.Drawing.Size(816, 639);
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "py2km";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnConvert;
		private System.Windows.Forms.RichTextBox rtfOutput;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.RichTextBox rtfInput;
		private System.Windows.Forms.ComboBox cboSource;
		private System.Windows.Forms.CheckBox chkPinyinRules;
	}
}

