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
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			this.Icon = Properties.Resources.py2km;
		}

		private void btnConvert_Click(object sender, EventArgs e)
		{
			rtfOutput.Text = Converter.PinyinToKwikMandarin(txtInput.Text);
		}
	}
}
