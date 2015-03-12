using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using py2km.api;

namespace py2km
{
	public partial class frmSplashScreen : Form
	{
		public frmSplashScreen()
		{
			InitializeComponent();
			lblWho.Parent = pictSplashScreen;
		}

		private void SplashScreen_Load(object sender, EventArgs e)
		{
			this.Opacity = 0.0;
			tmrFadeIn.Start();
		}

		private void tmrFadeIn_Tick(object sender, EventArgs e)
		{
			this.Opacity += 0.04;
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
			tmrFadeOut.Start();
		}
	}
}
