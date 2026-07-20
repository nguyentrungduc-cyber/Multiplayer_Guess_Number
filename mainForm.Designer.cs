namespace Lab06
{
    partial class mainForm
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
            this.components           = new System.ComponentModel.Container();
            this.btnSend              = new System.Windows.Forms.Button();
            this.btnClear             = new System.Windows.Forms.Button();
            this.btnPauseResume       = new System.Windows.Forms.Button();
            this.btnStopServer        = new System.Windows.Forms.Button();
            this.message              = new System.Windows.Forms.TextBox();
            this.conversation         = new System.Windows.Forms.RichTextBox();
            this.btnReady             = new System.Windows.Forms.Button();
            this.playerNum            = new System.Windows.Forms.Label();
            this.btnAutoPlaySingleTurn = new System.Windows.Forms.Button();
            this.btnAutoplayWholeGame = new System.Windows.Forms.Button();
            this.timer                = new System.Windows.Forms.Timer(this.components);
            this.label3               = new System.Windows.Forms.Label();
            this.range                = new System.Windows.Forms.Label();
            this.label4               = new System.Windows.Forms.Label();
            this.ansNumber            = new System.Windows.Forms.Label();
            this.timerCnt             = new System.Windows.Forms.Label();
            this.label2               = new System.Windows.Forms.Label();
            this.label5               = new System.Windows.Forms.Label();
            this.pnlTop               = new System.Windows.Forms.Panel();
            this.pnlInfo              = new System.Windows.Forms.Panel();
            this.pnlSide              = new System.Windows.Forms.Panel();
            this.pnlChat              = new System.Windows.Forms.Panel();
            this.pnlInput             = new System.Windows.Forms.Panel();
            this.answer               = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSubmit            = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();

            // ── Timer ────────────────────────────────────────
            this.timer.Interval = 1000;
            this.timer.Tick    += new System.EventHandler(this.timer_Tick);

            // ════════════════════════════════════════════════
            //  FORM
            // ════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor           = System.Drawing.Color.FromArgb(18, 18, 30);
            this.ClientSize          = new System.Drawing.Size(980, 640);
            this.Font                = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor           = System.Drawing.Color.White;
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox         = false;
            this.Name                = "mainForm";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Player";
            this.FormClosing        += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Load               += new System.EventHandler(this.mainForm_Load);

            // ════════════════════════════════════════════════
            //  THANH TRÊN CÙNG — Tên game + số người
            // ════════════════════════════════════════════════
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(24, 24, 40);
            this.pnlTop.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location  = new System.Drawing.Point(0, 0);
            this.pnlTop.Name      = "pnlTop";
            this.pnlTop.Size      = new System.Drawing.Size(980, 52);
            this.pnlTop.TabIndex  = 0;

            this.label5.AutoSize  = false;
            this.label5.Dock      = System.Windows.Forms.DockStyle.Left;
            this.label5.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(99, 202, 183);
            this.label5.Location  = new System.Drawing.Point(0, 0);
            this.label5.Name      = "label5";
            this.label5.Padding   = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.label5.Size      = new System.Drawing.Size(340, 52);
            this.label5.TabIndex  = 0;
            this.label5.Text      = "🎯  Number Magic Game";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pnlTop.Controls.Add(this.label5);

            this.playerNum.AutoSize  = false;
            this.playerNum.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.playerNum.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.playerNum.ForeColor = System.Drawing.Color.FromArgb(190, 190, 210);
            this.playerNum.Name      = "playerNum";
            this.playerNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.playerNum.Padding   = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.playerNum.TabIndex  = 0;
            this.playerNum.Click    += new System.EventHandler(this.playerNum_Click);
            this.pnlTop.Controls.Add(this.playerNum);

            // ════════════════════════════════════════════════
            //  PANEL TRÁI — Chat conversation
            // ════════════════════════════════════════════════
            this.pnlChat.BackColor = System.Drawing.Color.FromArgb(22, 22, 38);
            this.pnlChat.Location  = new System.Drawing.Point(0, 52);
            this.pnlChat.Name      = "pnlChat";
            this.pnlChat.Size      = new System.Drawing.Size(648, 588);
            this.pnlChat.TabIndex  = 0;

            this.conversation.BackColor  = System.Drawing.Color.FromArgb(22, 22, 38);
            this.conversation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.conversation.Font       = new System.Drawing.Font("Segoe UI", 10F);
            this.conversation.ForeColor  = System.Drawing.Color.FromArgb(220, 220, 240);
            this.conversation.Location   = new System.Drawing.Point(12, 12);
            this.conversation.Name       = "conversation";
            this.conversation.ReadOnly   = true;
            this.conversation.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.conversation.Size       = new System.Drawing.Size(624, 524);
            this.conversation.TabIndex   = 0;
            this.conversation.TabStop    = false;
            this.conversation.Text       = "";
            this.pnlChat.Controls.Add(this.conversation);

            // Input chat
            this.pnlInput.BackColor = System.Drawing.Color.FromArgb(28, 28, 46);
            this.pnlInput.Location  = new System.Drawing.Point(0, 548);
            this.pnlInput.Name      = "pnlInput";
            this.pnlInput.Size      = new System.Drawing.Size(648, 40);
            this.pnlInput.TabIndex  = 0;

            this.message.BackColor    = System.Drawing.Color.FromArgb(35, 35, 55);
            this.message.BorderStyle  = System.Windows.Forms.BorderStyle.None;
            this.message.Font         = new System.Drawing.Font("Segoe UI", 10F);
            this.message.ForeColor    = System.Drawing.Color.White;
            this.message.Location     = new System.Drawing.Point(10, 10);
            this.message.Name         = "message";
            this.message.Text = "";
            this.message.Size         = new System.Drawing.Size(540, 22);
            this.message.TabIndex     = 1;
            this.message.KeyDown     += new System.Windows.Forms.KeyEventHandler(this.message_KeyDown);
            this.pnlInput.Controls.Add(this.message);

            this.btnSend.BackColor    = System.Drawing.Color.Transparent;
            this.btnSend.FlatStyle    = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.Font         = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor    = System.Drawing.Color.FromArgb(99, 202, 183);
            this.btnSend.Location     = new System.Drawing.Point(556, 6);
            this.btnSend.Name         = "btnSend";
            this.btnSend.Size         = new System.Drawing.Size(80, 28);
            this.btnSend.TabIndex     = 2;
            this.btnSend.TabStop      = false;
            this.btnSend.Text         = "Gửi  ▶";
            this.btnSend.Click       += new System.EventHandler(this.btnSend_Click);
            this.pnlInput.Controls.Add(this.btnSend);

            this.pnlChat.Controls.Add(this.pnlInput);

            // ════════════════════════════════════════════════
            //  PANEL PHẢI — Info + Controls
            // ════════════════════════════════════════════════
            this.pnlSide.BackColor = System.Drawing.Color.FromArgb(24, 24, 40);
            this.pnlSide.Location  = new System.Drawing.Point(648, 52);
            this.pnlSide.Name      = "pnlSide";
            this.pnlSide.Size      = new System.Drawing.Size(332, 588);
            this.pnlSide.TabIndex  = 0;

            // ── Timer display ───────────────────────────────
            this.label2.AutoSize  = false;
            this.label2.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(200, 200, 220);
            this.label2.Location  = new System.Drawing.Point(20, 16);
            this.label2.Name      = "label2";
            this.label2.Size      = new System.Drawing.Size(292, 20);
            this.label2.Text      = "⏱  Thời gian còn lại";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlSide.Controls.Add(this.label2);

            this.timerCnt.Font      = new System.Drawing.Font("Segoe UI", 52F, System.Drawing.FontStyle.Bold);
            this.timerCnt.ForeColor = System.Drawing.Color.FromArgb(99, 202, 183);
            this.timerCnt.Location  = new System.Drawing.Point(20, 36);
            this.timerCnt.Name      = "timerCnt";
            this.timerCnt.Size      = new System.Drawing.Size(292, 96);
            this.timerCnt.TabIndex  = 0;
            this.timerCnt.Text      = "--";
            this.timerCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlSide.Controls.Add(this.timerCnt);

            // ── Info panel (range / đáp án) ─────────────────
            this.pnlInfo.BackColor  = System.Drawing.Color.FromArgb(30, 30, 50);
            this.pnlInfo.Location   = new System.Drawing.Point(16, 150);
            this.pnlInfo.Name       = "pnlInfo";
            this.pnlInfo.Size       = new System.Drawing.Size(300, 74);
            this.pnlInfo.TabIndex   = 0;

            this.label3.AutoSize  = false;
            this.label3.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(190, 190, 210);
            this.label3.Location  = new System.Drawing.Point(12, 10);
            this.label3.Name      = "label3";
            this.label3.Size      = new System.Drawing.Size(80, 18);
            this.label3.Text      = "Khoảng:";
            this.pnlInfo.Controls.Add(this.label3);

            this.range.AutoSize  = false;
            this.range.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.range.ForeColor = System.Drawing.Color.FromArgb(99, 202, 183);
            this.range.Location  = new System.Drawing.Point(92, 9);
            this.range.Name      = "range";
            this.range.Size      = new System.Drawing.Size(196, 20);
            this.range.TabIndex  = 0;
            this.pnlInfo.Controls.Add(this.range);

            this.label4.AutoSize  = false;
            this.label4.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(190, 190, 210);
            this.label4.Location  = new System.Drawing.Point(12, 40);
            this.label4.Name      = "label4";
            this.label4.Size      = new System.Drawing.Size(80, 18);
            this.label4.Text      = "Đáp án:";
            this.pnlInfo.Controls.Add(this.label4);

            this.ansNumber.AutoSize  = false;
            this.ansNumber.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.ansNumber.ForeColor = System.Drawing.Color.FromArgb(255, 183, 77);
            this.ansNumber.Location  = new System.Drawing.Point(92, 39);
            this.ansNumber.Name      = "ansNumber";
            this.ansNumber.Size      = new System.Drawing.Size(196, 20);
            this.ansNumber.TabIndex  = 0;
            this.pnlInfo.Controls.Add(this.ansNumber);

            this.pnlSide.Controls.Add(this.pnlInfo);

            // ── Ô nhập đáp án ───────────────────────────────
            this.answer.BorderRadius = 8;
            this.answer.Cursor       = System.Windows.Forms.Cursors.IBeam;
            this.answer.DefaultText  = "";
            this.answer.FillColor    = System.Drawing.Color.FromArgb(30, 30, 50);
            this.answer.BorderColor  = System.Drawing.Color.FromArgb(60, 60, 90);
            this.answer.FocusedState.BorderColor  = System.Drawing.Color.FromArgb(99, 202, 183);
            this.answer.HoverState.BorderColor    = System.Drawing.Color.FromArgb(99, 202, 183);
            this.answer.DisabledState.BorderColor = System.Drawing.Color.FromArgb(40, 40, 60);
            this.answer.DisabledState.FillColor   = System.Drawing.Color.FromArgb(25, 25, 40);
            this.answer.DisabledState.ForeColor   = System.Drawing.Color.FromArgb(80, 80, 110);
            this.answer.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(60, 60, 90);
            this.answer.Font              = new System.Drawing.Font("Segoe UI", 12F);
            this.answer.ForeColor         = System.Drawing.Color.White;
            this.answer.PlaceholderText   = "Số của bạn...";
            this.answer.PlaceholderForeColor = System.Drawing.Color.FromArgb(90, 90, 120);
            this.answer.Location          = new System.Drawing.Point(16, 242);
            this.answer.Name              = "answer";
            this.answer.PasswordChar      = '\0';
            this.answer.SelectedText      = "";
            this.answer.Size              = new System.Drawing.Size(194, 44);
            this.answer.TabIndex          = 3;
            this.answer.KeyDown          += new System.Windows.Forms.KeyEventHandler(this.answer_KeyDown);
            this.pnlSide.Controls.Add(this.answer);

            // ── Nút Submit ──────────────────────────────────
            this.btnSubmit.BorderRadius = 8;
            this.btnSubmit.FillColor    = System.Drawing.Color.FromArgb(99, 202, 183);
            this.btnSubmit.HoverState.FillColor = System.Drawing.Color.FromArgb(75, 175, 158);
            this.btnSubmit.DisabledState.BorderColor    = System.Drawing.Color.DarkGray;
            this.btnSubmit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSubmit.DisabledState.FillColor      = System.Drawing.Color.FromArgb(40, 40, 60);
            this.btnSubmit.DisabledState.ForeColor      = System.Drawing.Color.FromArgb(80, 80, 110);
            this.btnSubmit.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.FromArgb(18, 18, 30);
            this.btnSubmit.Location  = new System.Drawing.Point(218, 242);
            this.btnSubmit.Name      = "btnSubmit";
            this.btnSubmit.Size      = new System.Drawing.Size(98, 44);
            this.btnSubmit.TabIndex  = 4;
            this.btnSubmit.Text      = "✔  Gửi";
            this.btnSubmit.Click    += new System.EventHandler(this.btnSubmit_Click);
            this.pnlSide.Controls.Add(this.btnSubmit);

            // ── Nút Ready ───────────────────────────────────
            this.btnReady.BackColor    = System.Drawing.Color.FromArgb(99, 202, 183);
            this.btnReady.FlatStyle    = System.Windows.Forms.FlatStyle.Flat;
            this.btnReady.FlatAppearance.BorderSize = 0;
            this.btnReady.Font         = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReady.ForeColor    = System.Drawing.Color.FromArgb(18, 18, 30);
            this.btnReady.Location     = new System.Drawing.Point(16, 302);
            this.btnReady.Name         = "btnReady";
            this.btnReady.Size         = new System.Drawing.Size(300, 44);
            this.btnReady.TabIndex     = 5;
            this.btnReady.TabStop      = false;
            this.btnReady.Text         = "✋  Sẵn sàng!";
            this.btnReady.UseVisualStyleBackColor = false;
            this.btnReady.Click       += new System.EventHandler(this.btnReady_Click);
            this.pnlSide.Controls.Add(this.btnReady);

            // ── Autoplay ────────────────────────────────────
            this.btnAutoPlaySingleTurn.BackColor    = System.Drawing.Color.FromArgb(35, 35, 58);
            this.btnAutoPlaySingleTurn.Enabled      = false;
            this.btnAutoPlaySingleTurn.FlatStyle    = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoPlaySingleTurn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 90);
            this.btnAutoPlaySingleTurn.FlatAppearance.BorderSize  = 1;
            this.btnAutoPlaySingleTurn.Font         = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAutoPlaySingleTurn.ForeColor    = System.Drawing.Color.FromArgb(170, 170, 210);
            this.btnAutoPlaySingleTurn.Location     = new System.Drawing.Point(16, 362);
            this.btnAutoPlaySingleTurn.Name         = "btnAutoPlaySingleTurn";
            this.btnAutoPlaySingleTurn.Size         = new System.Drawing.Size(300, 38);
            this.btnAutoPlaySingleTurn.TabIndex     = 6;
            this.btnAutoPlaySingleTurn.TabStop      = false;
            this.btnAutoPlaySingleTurn.Text         = "🤖  Tự động (1 lượt)";
            this.btnAutoPlaySingleTurn.UseVisualStyleBackColor = false;
            this.btnAutoPlaySingleTurn.Click       += new System.EventHandler(this.autoTurn_Click);
            this.pnlSide.Controls.Add(this.btnAutoPlaySingleTurn);

            this.btnAutoplayWholeGame.BackColor    = System.Drawing.Color.FromArgb(35, 35, 58);
            this.btnAutoplayWholeGame.Enabled      = false;
            this.btnAutoplayWholeGame.FlatStyle    = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoplayWholeGame.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 90);
            this.btnAutoplayWholeGame.FlatAppearance.BorderSize  = 1;
            this.btnAutoplayWholeGame.Font         = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAutoplayWholeGame.ForeColor    = System.Drawing.Color.FromArgb(170, 170, 210);
            this.btnAutoplayWholeGame.Location     = new System.Drawing.Point(16, 408);
            this.btnAutoplayWholeGame.Name         = "btnAutoplayWholeGame";
            this.btnAutoplayWholeGame.Size         = new System.Drawing.Size(300, 38);
            this.btnAutoplayWholeGame.TabIndex     = 7;
            this.btnAutoplayWholeGame.TabStop      = false;
            this.btnAutoplayWholeGame.Text         = "🤖  Tự động (cả game)";
            this.btnAutoplayWholeGame.UseVisualStyleBackColor = false;
            this.btnAutoplayWholeGame.Click       += new System.EventHandler(this.autoAllGame_Click);
            this.pnlSide.Controls.Add(this.btnAutoplayWholeGame);

            // ── Nút Clear ───────────────────────────────────
            this.btnClear.BackColor    = System.Drawing.Color.Transparent;
            this.btnClear.FlatStyle    = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 80, 110);
            this.btnClear.FlatAppearance.BorderSize  = 1;
            this.btnClear.Font         = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClear.ForeColor    = System.Drawing.Color.FromArgb(150, 150, 180);
            this.btnClear.Location     = new System.Drawing.Point(16, 464);
            this.btnClear.Name         = "btnClear";
            this.btnClear.Size         = new System.Drawing.Size(300, 34);
            this.btnClear.TabIndex     = 8;
            this.btnClear.TabStop      = false;
            this.btnClear.Text         = "🗑  Xóa lịch sử chat";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click       += new System.EventHandler(this.btnClear_Click);
            this.pnlSide.Controls.Add(this.btnClear);

            // ── Nút Tạm dừng / Tiếp tục (chỉ hiện với Server) ──
            this.btnPauseResume.BackColor = System.Drawing.Color.FromArgb(255, 183, 77);
            this.btnPauseResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPauseResume.FlatAppearance.BorderSize = 0;
            this.btnPauseResume.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPauseResume.ForeColor = System.Drawing.Color.FromArgb(18, 18, 30);
            this.btnPauseResume.Location  = new System.Drawing.Point(16, 506);
            this.btnPauseResume.Name      = "btnPauseResume";
            this.btnPauseResume.Size      = new System.Drawing.Size(300, 36);
            this.btnPauseResume.TabIndex  = 9;
            this.btnPauseResume.TabStop   = false;
            this.btnPauseResume.Text      = "⏸  Tạm dừng ván chơi";
            this.btnPauseResume.UseVisualStyleBackColor = false;
            this.btnPauseResume.Visible   = false;
            this.btnPauseResume.Click    += new System.EventHandler(this.btnPauseResume_Click);
            this.pnlSide.Controls.Add(this.btnPauseResume);

            // ── Nút Dừng Server ngay lập tức (chỉ hiện với Server) ──
            this.btnStopServer.BackColor = System.Drawing.Color.FromArgb(220, 70, 70);
            this.btnStopServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopServer.FlatAppearance.BorderSize = 0;
            this.btnStopServer.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnStopServer.ForeColor = System.Drawing.Color.White;
            this.btnStopServer.Location  = new System.Drawing.Point(16, 546);
            this.btnStopServer.Name      = "btnStopServer";
            this.btnStopServer.Size      = new System.Drawing.Size(300, 36);
            this.btnStopServer.TabIndex  = 10;
            this.btnStopServer.TabStop   = false;
            this.btnStopServer.Text      = "⏹  Dừng Server ngay";
            this.btnStopServer.UseVisualStyleBackColor = false;
            this.btnStopServer.Visible   = false;
            this.btnStopServer.Click    += new System.EventHandler(this.btnStopServer_Click);
            this.pnlSide.Controls.Add(this.btnStopServer);

            // ── Add top-level controls ───────────────────────
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlChat);
            this.Controls.Add(this.pnlSide);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnPauseResume;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.TextBox message;
        public System.Windows.Forms.RichTextBox conversation;
        private System.Windows.Forms.Button btnReady;
        private System.Windows.Forms.Label playerNum;
        private System.Windows.Forms.Button btnAutoPlaySingleTurn;
        private System.Windows.Forms.Button btnAutoplayWholeGame;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label range;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ansNumber;
        private System.Windows.Forms.Label timerCnt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Panel pnlChat;
        private System.Windows.Forms.Panel pnlInput;
        private Guna.UI2.WinForms.Guna2TextBox answer;
        private Guna.UI2.WinForms.Guna2Button btnSubmit;
    }
}
