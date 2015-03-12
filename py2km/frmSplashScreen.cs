using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using py2km.api;

namespace py2km
{
	public partial class frmSplashScreen : Form
	{
		public frmSplashScreen()
		{
			InitializeComponent();
		}

		private void SplashScreen_Load(object sender, EventArgs e)
		{
			if (OS.IsLinux)
			{
				this.Width = 600;
				this.Height = 400;
				BGThread.RunWorkerAsync();
			}
			else
			{
				lblWho.Parent = pictSplashScreen;
				this.Opacity = 0.0;
				tmrFadeIn.Start();
			}
		}

		private void tmrFadeIn_Tick(object sender, EventArgs e)
		{
			this.Opacity += 0.035;
			if (this.Opacity >= 1)
			{
				BGThread.RunWorkerAsync();
				tmrFadeIn.Stop();
			} 
		}

		private void tmrFadeOut_Tick(object sender, EventArgs e)
		{
			this.Opacity -= 0.04;
			if (this.Opacity <= 0)
			{
				this.Close();
			} 
		}

		private void BGThread_DoWork(object sender, DoWorkEventArgs e)
		{
			Cedict.Load();
			Converter.Load();
		}

		private void BGThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (OS.IsLinux)
				this.Close();
			else
				tmrFadeOut.Start();

			if (!File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ArialKwikMandarinModified.ttf")))
				MessageBox.Show("Font \"ArialKwikMandarinModified.ttf\" not installed on this system!", "Missing Font", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
	}
}
