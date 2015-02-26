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
			this.txtInput = new System.Windows.Forms.TextBox();
			this.btnClear = new System.Windows.Forms.Button();
			this.chkPinyinRules = new System.Windows.Forms.CheckBox();
			this.cboConversionType = new System.Windows.Forms.ComboBox();
			this.lblConversionType = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnConvert
			// 
			this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnConvert.Location = new System.Drawing.Point(697, 527);
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
			this.rtfOutput.Font = new System.Drawing.Font("Arial Kwik Mandarin Modified", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtfOutput.Location = new System.Drawing.Point(12, 128);
			this.rtfOutput.Name = "rtfOutput";
			this.rtfOutput.Size = new System.Drawing.Size(760, 393);
			this.rtfOutput.TabIndex = 3;
			this.rtfOutput.Text = "";
			// 
			// txtInput
			// 
			this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtInput.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtInput.Location = new System.Drawing.Point(12, 12);
			this.txtInput.Multiline = true;
			this.txtInput.Name = "txtInput";
			this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.txtInput.Size = new System.Drawing.Size(760, 83);
			this.txtInput.TabIndex = 0;
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(12, 527);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 4;
			this.btnClear.Text = "&Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// chkPinyinRules
			// 
			this.chkPinyinRules.AutoSize = true;
			this.chkPinyinRules.Location = new System.Drawing.Point(578, 531);
			this.chkPinyinRules.Name = "chkPinyinRules";
			this.chkPinyinRules.Size = new System.Drawing.Size(113, 17);
			this.chkPinyinRules.TabIndex = 6;
			this.chkPinyinRules.Text = "Apply Pinyin &Rules";
			this.chkPinyinRules.UseVisualStyleBackColor = true;
			// 
			// cboConversionType
			// 
			this.cboConversionType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cboConversionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboConversionType.FormattingEnabled = true;
			this.cboConversionType.Items.AddRange(new object[] {
            "Pinyin to Kwik Mandarin",
            "Pinyin to Pinyin Rules",
            "Number to Kwik Mandarin",
            "Number to Pinyin"});
			this.cboConversionType.Location = new System.Drawing.Point(472, 101);
			this.cboConversionType.Name = "cboConversionType";
			this.cboConversionType.Size = new System.Drawing.Size(300, 21);
			this.cboConversionType.TabIndex = 7;
			// 
			// lblConversionType
			// 
			this.lblConversionType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblConversionType.AutoSize = true;
			this.lblConversionType.Location = new System.Drawing.Point(374, 104);
			this.lblConversionType.Name = "lblConversionType";
			this.lblConversionType.Size = new System.Drawing.Size(92, 13);
			this.lblConversionType.TabIndex = 8;
			this.lblConversionType.Text = "Conversion Type:";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Controls.Add(this.lblConversionType);
			this.Controls.Add(this.cboConversionType);
			this.Controls.Add(this.chkPinyinRules);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.rtfOutput);
			this.Controls.Add(this.btnConvert);
			this.Controls.Add(this.txtInput);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinimumSize = new System.Drawing.Size(800, 600);
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
		private System.Windows.Forms.TextBox txtInput;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.CheckBox chkPinyinRules;
		private System.Windows.Forms.ComboBox cboConversionType;
		private System.Windows.Forms.Label lblConversionType;
	}
}

