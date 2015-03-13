namespace py2km
{
	partial class frmSplashScreen
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
			this.components = new System.ComponentModel.Container();
			this.pictSplashScreen = new System.Windows.Forms.PictureBox();
			this.lblWho = new System.Windows.Forms.Label();
			this.tmrFadeIn = new System.Windows.Forms.Timer(this.components);
			this.tmrFadeOut = new System.Windows.Forms.Timer(this.components);
			this.BGThread = new System.ComponentModel.BackgroundWorker();
			this.lblVersion = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictSplashScreen)).BeginInit();
			this.SuspendLayout();
			// 
			// pictSplashScreen
			// 
			this.pictSplashScreen.Image = global::py2km.Properties.Resources.SplashScreen;
			this.pictSplashScreen.Location = new System.Drawing.Point(0, 0);
			this.pictSplashScreen.Name = "pictSplashScreen";
			this.pictSplashScreen.Size = new System.Drawing.Size(600, 400);
			this.pictSplashScreen.TabIndex = 0;
			this.pictSplashScreen.TabStop = false;
			// 
			// lblWho
			// 
			this.lblWho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblWho.BackColor = System.Drawing.Color.Transparent;
			this.lblWho.ForeColor = System.Drawing.Color.White;
			this.lblWho.Location = new System.Drawing.Point(288, 365);
			this.lblWho.Name = "lblWho";
			this.lblWho.Size = new System.Drawing.Size(300, 26);
			this.lblWho.TabIndex = 1;
			this.lblWho.Text = "Programmed by Ilham (Anime4000)\r\nCopyright © 2015 Kwik Mandarin. All rights reser" +
    "ved.";
			this.lblWho.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// tmrFadeIn
			// 
			this.tmrFadeIn.Interval = 1;
			this.tmrFadeIn.Tick += new System.EventHandler(this.tmrFadeIn_Tick);
			// 
			// tmrFadeOut
			// 
			this.tmrFadeOut.Interval = 1;
			this.tmrFadeOut.Tick += new System.EventHandler(this.tmrFadeOut_Tick);
			// 
			// BGThread
			// 
			this.BGThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGThread_DoWork);
			this.BGThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGThread_RunWorkerCompleted);
			// 
			// lblVersion
			// 
			this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblVersion.BackColor = System.Drawing.Color.Transparent;
			this.lblVersion.ForeColor = System.Drawing.Color.White;
			this.lblVersion.Location = new System.Drawing.Point(255, 267);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(260, 13);
			this.lblVersion.TabIndex = 2;
			this.lblVersion.Text = "ver.: {0}";
			this.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// frmSplashScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(600, 400);
			this.Controls.Add(this.lblVersion);
			this.Controls.Add(this.lblWho);
			this.Controls.Add(this.pictSplashScreen);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmSplashScreen";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SplashScreen";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.SplashScreen_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictSplashScreen)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictSplashScreen;
		private System.Windows.Forms.Label lblWho;
		private System.Windows.Forms.Timer tmrFadeIn;
		private System.Windows.Forms.Timer tmrFadeOut;
		private System.ComponentModel.BackgroundWorker BGThread;
		private System.Windows.Forms.Label lblVersion;
	}
}