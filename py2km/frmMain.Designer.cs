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
			this.btnClear = new System.Windows.Forms.Button();
			this.rtfInput = new System.Windows.Forms.RichTextBox();
			this.cboSource = new System.Windows.Forms.ComboBox();
			this.chkPinyinRules = new System.Windows.Forms.CheckBox();
			this.BGThread = new System.ComponentModel.BackgroundWorker();
			this.webView = new System.Windows.Forms.WebBrowser();
			this.btnPrint = new System.Windows.Forms.Button();
			this.lblInsertSample = new System.Windows.Forms.Label();
			this.btnCopyTo = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnConvert
			// 
			this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnConvert.Location = new System.Drawing.Point(937, 12);
			this.btnConvert.Name = "btnConvert";
			this.btnConvert.Size = new System.Drawing.Size(75, 23);
			this.btnConvert.TabIndex = 2;
			this.btnConvert.Text = "&Convert";
			this.btnConvert.UseVisualStyleBackColor = true;
			this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
			// 
			// btnClear
			// 
			this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClear.Location = new System.Drawing.Point(856, 12);
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
			this.rtfInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtfInput.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtfInput.Location = new System.Drawing.Point(12, 41);
			this.rtfInput.Name = "rtfInput";
			this.rtfInput.Size = new System.Drawing.Size(387, 546);
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
            "Hanzi to Kwik Mandarin",
            "Dictionary Mode (Hanzi)"});
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
			this.chkPinyinRules.CheckedChanged += new System.EventHandler(this.chkPinyinRules_CheckedChanged);
			// 
			// BGThread
			// 
			this.BGThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGThread_DoWork);
			this.BGThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGThread_RunWorkerCompleted);
			// 
			// webView
			// 
			this.webView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.webView.Location = new System.Drawing.Point(401, 41);
			this.webView.MinimumSize = new System.Drawing.Size(20, 20);
			this.webView.Name = "webView";
			this.webView.Size = new System.Drawing.Size(611, 546);
			this.webView.TabIndex = 12;
			// 
			// btnPrint
			// 
			this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPrint.Location = new System.Drawing.Point(775, 12);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(75, 23);
			this.btnPrint.TabIndex = 13;
			this.btnPrint.Text = "&Print";
			this.btnPrint.UseVisualStyleBackColor = true;
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// lblInsertSample
			// 
			this.lblInsertSample.AutoSize = true;
			this.lblInsertSample.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblInsertSample.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInsertSample.ForeColor = System.Drawing.Color.Blue;
			this.lblInsertSample.Location = new System.Drawing.Point(238, 17);
			this.lblInsertSample.Name = "lblInsertSample";
			this.lblInsertSample.Size = new System.Drawing.Size(72, 13);
			this.lblInsertSample.TabIndex = 14;
			this.lblInsertSample.Text = "Insert sample";
			this.lblInsertSample.Click += new System.EventHandler(this.lblInsertSample_Click);
			// 
			// btnCopyTo
			// 
			this.btnCopyTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCopyTo.Location = new System.Drawing.Point(694, 12);
			this.btnCopyTo.Name = "btnCopyTo";
			this.btnCopyTo.Size = new System.Drawing.Size(75, 23);
			this.btnCopyTo.TabIndex = 15;
			this.btnCopyTo.Text = "< &Send";
			this.btnCopyTo.UseVisualStyleBackColor = true;
			this.btnCopyTo.Click += new System.EventHandler(this.btnCopyTo_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1024, 600);
			this.Controls.Add(this.btnCopyTo);
			this.Controls.Add(this.lblInsertSample);
			this.Controls.Add(this.btnPrint);
			this.Controls.Add(this.webView);
			this.Controls.Add(this.chkPinyinRules);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.cboSource);
			this.Controls.Add(this.rtfInput);
			this.Controls.Add(this.btnConvert);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinimumSize = new System.Drawing.Size(1024, 600);
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
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.RichTextBox rtfInput;
		private System.Windows.Forms.ComboBox cboSource;
		private System.Windows.Forms.CheckBox chkPinyinRules;
		private System.ComponentModel.BackgroundWorker BGThread;
		private System.Windows.Forms.WebBrowser webView;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.Label lblInsertSample;
		private System.Windows.Forms.Button btnCopyTo;
	}
}

