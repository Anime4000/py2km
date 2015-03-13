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
			this.Text = String.Format("py2km build {0} ( '{1}' )", Globals.Version, Properties.Resources.CodeName);

			cboSource.SelectedIndex = Properties.Settings.Default.convSrc;

			frmSplashScreen SS = new frmSplashScreen();
			SS.ShowDialog();
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			Properties.Settings.Default.Save();
		}

		private void btnConvert_Click(object sender, EventArgs e)
		{
			List<object> something = new List<object>
			{
				chkPinyinRules.Checked,
				cboSource.SelectedIndex,
				rtfInput.Text
			};

			rtfOutput.Text = "Loading...";
			BGThread.RunWorkerAsync(something);
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			rtfInput.Text = "";
			rtfOutput.Text = "";
		}

		private void cboSource_SelectedIndexChanged(object sender, EventArgs e)
		{
			int i = cboSource.SelectedIndex;
			if (i == 2)
			{
				chkPinyinRules.Checked = true;
				chkPinyinRules.Enabled = false;
			}
			else
			{
				chkPinyinRules.Checked = Properties.Settings.Default.pyRules;
				chkPinyinRules.Enabled = true;
			}
		}

		private void chkPinyinRules_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.pyRules = chkPinyinRules.Checked;
		}

		private void BGThread_DoWork(object sender, DoWorkEventArgs e)
		{
			List<object> argsList = e.Argument as List<object>;
			bool x = (bool)argsList[0];
			int i = (int)argsList[1];
			string input = (string)argsList[2];
			string output = "";

			switch (i)
			{
				case 0:
					output = x ? Converter.RulesOfPinyin(Converter.ToneToPinyin(input)) : Converter.ToneToPinyin(input);
					break;
				case 1:
					output = x ? Converter.PinyinToKwikMandarin(Converter.RulesOfPinyin(Converter.ToneToPinyin(input))) : Converter.PinyinToKwikMandarin(Converter.ToneToPinyin(input));
					break;
				case 2:
					output = x ? Converter.RulesOfPinyin(output) : Converter.RulesOfPinyin(output);
					break;
				case 3:
					output = x ? Converter.RulesOfPinyin(Converter.PinyinToKwikMandarin(input)) : Converter.PinyinToKwikMandarin(input);
					break;
				case 4:
					output = x ? Converter.RulesOfPinyin(Converter.HanziToPinyin(input)) : Converter.HanziToPinyin(input);
					break;
				case 5:
					output = x ? Converter.PinyinToKwikMandarin(Converter.RulesOfPinyin(Converter.HanziToPinyin(input))) : Converter.PinyinToKwikMandarin(Converter.HanziToPinyin(input));
					break;
				default:
					break;
			}

			if (this.InvokeRequired)
				BeginInvoke(new MethodInvoker(() => rtfOutput.Text = output));
			else
				rtfOutput.Text = output;
		}

		private void BGThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			Clipboard.SetText(rtfOutput.Rtf, TextDataFormat.Rtf);
		}

		private void btnSendLeft_Click(object sender, EventArgs e)
		{
			rtfInput.Text = rtfOutput.Text;
			rtfOutput.Text = "";
		}

	}
}