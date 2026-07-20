namespace Lab06
{
    partial class saveHistory
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTop       = new System.Windows.Forms.Panel();
            this.lblTitle     = new System.Windows.Forms.Label();
            this.lblSub       = new System.Windows.Forms.Label();
            this.pnlButtons   = new System.Windows.Forms.Panel();
            this.btnCopy      = new System.Windows.Forms.Button();
            this.btnSaveFile  = new System.Windows.Forms.Button();
            this.btnClose     = new System.Windows.Forms.Button();
            this.rtbHistory   = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();

            // ── Form ─────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor           = System.Drawing.Color.FromArgb(18, 18, 30);
            this.ClientSize          = new System.Drawing.Size(720, 540);
            this.Font                = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor           = System.Drawing.Color.White;
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox         = false;
            this.Name                = "saveHistory";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text                = "Lịch sử game";
            this.Load               += new System.EventHandler(this.saveHistory_Load);

            // ── Panel top ────────────────────────────────────
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(24, 24, 40);
            this.pnlTop.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Size      = new System.Drawing.Size(720, 64);
            this.pnlTop.TabIndex  = 0;

            this.lblTitle.AutoSize  = false;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(99, 202, 183);
            this.lblTitle.Location  = new System.Drawing.Point(16, 10);
            this.lblTitle.Size      = new System.Drawing.Size(688, 26);
            this.lblTitle.Text      = "📋  Lịch sử trò chơi";
            this.pnlTop.Controls.Add(this.lblTitle);

            this.lblSub.AutoSize  = false;
            this.lblSub.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(120, 120, 150);
            this.lblSub.Location  = new System.Drawing.Point(16, 36);
            this.lblSub.Size      = new System.Drawing.Size(688, 18);
            this.lblSub.Text      = "Toàn bộ diễn biến của game vừa kết thúc";
            this.pnlTop.Controls.Add(this.lblSub);

            // ── RichTextBox lịch sử ──────────────────────────
            this.rtbHistory.BackColor   = System.Drawing.Color.FromArgb(22, 22, 38);
            this.rtbHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbHistory.Font        = new System.Drawing.Font("Consolas", 10F);
            this.rtbHistory.ForeColor   = System.Drawing.Color.FromArgb(210, 210, 230);
            this.rtbHistory.Location    = new System.Drawing.Point(0, 64);
            this.rtbHistory.Name        = "rtbHistory";
            this.rtbHistory.ReadOnly    = true;
            this.rtbHistory.ScrollBars  = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbHistory.Size        = new System.Drawing.Size(720, 416);
            this.rtbHistory.TabIndex    = 0;
            this.rtbHistory.TabStop     = false;
            this.rtbHistory.Text        = "";
            this.rtbHistory.Padding     = new System.Windows.Forms.Padding(12);

            // ── Panel nút ────────────────────────────────────
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(24, 24, 40);
            this.pnlButtons.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location  = new System.Drawing.Point(0, 480);
            this.pnlButtons.Name      = "pnlButtons";
            this.pnlButtons.Size      = new System.Drawing.Size(720, 60);
            this.pnlButtons.TabIndex  = 0;

            this.btnCopy.BackColor    = System.Drawing.Color.FromArgb(99, 202, 183);
            this.btnCopy.FlatStyle    = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.Font         = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCopy.ForeColor    = System.Drawing.Color.FromArgb(18, 18, 30);
            this.btnCopy.Location     = new System.Drawing.Point(16, 12);
            this.btnCopy.Name         = "btnCopy";
            this.btnCopy.Size         = new System.Drawing.Size(160, 36);
            this.btnCopy.TabIndex     = 1;
            this.btnCopy.Text         = "📋  Sao chép";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click       += new System.EventHandler(this.btnCopy_Click);
            this.pnlButtons.Controls.Add(this.btnCopy);

            this.btnSaveFile.BackColor    = System.Drawing.Color.FromArgb(255, 183, 77);
            this.btnSaveFile.FlatStyle    = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveFile.FlatAppearance.BorderSize = 0;
            this.btnSaveFile.Font         = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSaveFile.ForeColor    = System.Drawing.Color.FromArgb(18, 18, 30);
            this.btnSaveFile.Location     = new System.Drawing.Point(188, 12);
            this.btnSaveFile.Name         = "btnSaveFile";
            this.btnSaveFile.Size         = new System.Drawing.Size(160, 36);
            this.btnSaveFile.TabIndex     = 2;
            this.btnSaveFile.Text         = "💾  Lưu file .txt";
            this.btnSaveFile.UseVisualStyleBackColor = false;
            this.btnSaveFile.Click       += new System.EventHandler(this.btnSaveFile_Click);
            this.pnlButtons.Controls.Add(this.btnSaveFile);

            this.btnClose.BackColor    = System.Drawing.Color.FromArgb(35, 35, 58);
            this.btnClose.FlatStyle    = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(70, 70, 100);
            this.btnClose.FlatAppearance.BorderSize  = 1;
            this.btnClose.Font         = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnClose.ForeColor    = System.Drawing.Color.FromArgb(170, 170, 200);
            this.btnClose.Location     = new System.Drawing.Point(544, 12);
            this.btnClose.Name         = "btnClose";
            this.btnClose.Size         = new System.Drawing.Size(160, 36);
            this.btnClose.TabIndex     = 3;
            this.btnClose.Text         = "✕  Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click       += new System.EventHandler(this.btnClose_Click);
            this.pnlButtons.Controls.Add(this.btnClose);

            // ── Add controls ─────────────────────────────────
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.rtbHistory);
            this.Controls.Add(this.pnlButtons);

            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel    pnlTop;
        private System.Windows.Forms.Label    lblTitle;
        private System.Windows.Forms.Label    lblSub;
        private System.Windows.Forms.Panel    pnlButtons;
        private System.Windows.Forms.Button   btnCopy;
        private System.Windows.Forms.Button   btnSaveFile;
        private System.Windows.Forms.Button   btnClose;
        private System.Windows.Forms.RichTextBox rtbHistory;
    }
}
