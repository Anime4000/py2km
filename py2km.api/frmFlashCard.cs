using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace py2km.api
{
    public partial class frmFlashCard : Form
    {
        Random rnd = new Random();
        int sent;
        int cc = 0;

        public frmFlashCard()
        {
            InitializeComponent();
        }

        private void frmFlashCard_Load(object sender, EventArgs e)
        {
            btnNext.PerformClick();
        }

        private void frmFlashCard_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            sent = rnd.Next(Cedict.COUNT_SC);
            string[] gg = Cedict.ToFlashCard(sent);

            lblHanzi.Text = gg[0];
            lblPinyin.Text = Converter.ToneToPinyin2(gg[1]);
            lblKm.Text = Converter.PinyinToKwikMandarin(Converter.ToneToPinyin2(gg[1]));
            lblEnglish.Text = gg[2].Replace('/', '\n');

            ShowSomething(false, cc = 0);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowSomething(true, ++cc);
        }

        void ShowSomething(bool show, int click)
        {
            lblPinyin.Visible = cc > 0 ? true : false;
            lblKm.Visible = cc > 1 ? true : false;
            lblEnglish.Visible = cc > 2 ? true : false;
            btnShow.Enabled = cc > 2 ? false : true;
        }
    }
}
