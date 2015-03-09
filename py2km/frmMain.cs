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
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			this.Icon = Properties.Resources.py2km;
			this.Text = String.Format("py2km build {0} ( '{1}' )", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version, Properties.Resources.CodeName);

			if (!File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ArialKwikMandarinModified.ttf")))
				MessageBox.Show("Font \"ArialKwikMandarinModified.ttf\" not installed on this system!", "Missing Font", MessageBoxButtons.OK, MessageBoxIcon.Warning);

			cboConversionType.SelectedIndex = Properties.Settings.Default.convType;

			CedictProcessor.CedictLoad();
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			Properties.Settings.Default.convType = cboConversionType.SelectedIndex;
			Properties.Settings.Default.Save();
		}

		private void btnConvert_Click(object sender, EventArgs e)
		{
			int x = cboConversionType.SelectedIndex;
			bool rule = chkPinyinRules.Checked;

			if (x == 0)
				rtfOutput.Text = rule ? Converter.PinyinToKwikMandarin(Converter.RulesOfPinyin(txtInput.Text)) : Converter.PinyinToKwikMandarin(txtInput.Text);
			else if (x == 1)
				rtfOutput.Text = rule ? Converter.RulesOfPinyin(txtInput.Text) : txtInput.Text;
			else if (x == 2)
				rtfOutput.Text = rule ? Converter.RulesOfPinyin(Converter.PinyinToKwikMandarin(Converter.ToneToPinyin(txtInput.Text))) : Converter.PinyinToKwikMandarin(Converter.ToneToPinyin(txtInput.Text));
			else if (x == 3)
				rtfOutput.Text = rule ? Converter.RulesOfPinyin(Converter.ToneToPinyin(txtInput.Text)) : Converter.ToneToPinyin(txtInput.Text);
			else
				rtfOutput.Text = CedictProcessor.Search(txtInput.Text);
			Clipboard.SetText(rtfOutput.Rtf, TextDataFormat.Rtf);
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			txtInput.Text = "";
			rtfOutput.Text = "";
		}

	}
}