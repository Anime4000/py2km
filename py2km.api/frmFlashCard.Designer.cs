namespace py2km.api
{
    partial class frmFlashCard
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
            this.lblHanzi = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.lblPinyin = new System.Windows.Forms.Label();
            this.lblKm = new System.Windows.Forms.Label();
            this.lblEnglish = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHanzi
            // 
            this.lblHanzi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHanzi.Font = new System.Drawing.Font("Tahoma", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHanzi.Location = new System.Drawing.Point(12, 12);
            this.lblHanzi.Name = "lblHanzi";
            this.lblHanzi.Size = new System.Drawing.Size(560, 140);
            this.lblHanzi.TabIndex = 0;
            this.lblHanzi.Text = "nimen";
            this.lblHanzi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNext.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btnNext.Location = new System.Drawing.Point(295, 325);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "&Next >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnShow
            // 
            this.btnShow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnShow.Location = new System.Drawing.Point(214, 325);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 2;
            this.btnShow.Text = "&Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // lblPinyin
            // 
            this.lblPinyin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPinyin.Font = new System.Drawing.Font("Arial Kwik Mandarin Modified", 14F);
            this.lblPinyin.Location = new System.Drawing.Point(12, 152);
            this.lblPinyin.Name = "lblPinyin";
            this.lblPinyin.Size = new System.Drawing.Size(560, 30);
            this.lblPinyin.TabIndex = 3;
            this.lblPinyin.Text = "label1";
            this.lblPinyin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKm
            // 
            this.lblKm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKm.Font = new System.Drawing.Font("Arial Kwik Mandarin Modified", 14F);
            this.lblKm.ForeColor = System.Drawing.Color.Red;
            this.lblKm.Location = new System.Drawing.Point(12, 182);
            this.lblKm.Name = "lblKm";
            this.lblKm.Size = new System.Drawing.Size(560, 30);
            this.lblKm.TabIndex = 4;
            this.lblKm.Text = "label1";
            this.lblKm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEnglish
            // 
            this.lblEnglish.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEnglish.Location = new System.Drawing.Point(12, 212);
            this.lblEnglish.Name = "lblEnglish";
            this.lblEnglish.Size = new System.Drawing.Size(560, 110);
            this.lblEnglish.TabIndex = 5;
            this.lblEnglish.Text = "label1";
            this.lblEnglish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmFlashCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.lblEnglish);
            this.Controls.Add(this.lblKm);
            this.Controls.Add(this.lblPinyin);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblHanzi);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "frmFlashCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flash Card";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFlashCard_FormClosing);
            this.Load += new System.EventHandler(this.frmFlashCard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHanzi;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label lblPinyin;
        private System.Windows.Forms.Label lblKm;
        private System.Windows.Forms.Label lblEnglish;
    }
}