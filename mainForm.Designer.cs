namespace Lab06
{
    partial class mainForm
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
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.TextBox();
            this.conversation = new System.Windows.Forms.RichTextBox();
            this.btnReady = new System.Windows.Forms.Button();
            this.playerNum = new System.Windows.Forms.Label();
            this.btnAutoPlaySingleTurn = new System.Windows.Forms.Button();
            this.btnAutoplayWholeGame = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.range = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ansNumber = new System.Windows.Forms.Label();
            this.timerCnt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.answer = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSubmit = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Turquoise;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.Black;
            this.btnSend.Location = new System.Drawing.Point(643, 580);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(81, 34);
            this.btnSend.TabIndex = 1;
            this.btnSend.TabStop = false;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Red;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(801, 512);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(115, 45);
            this.btnClear.TabIndex = 1;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // message
            // 
            this.message.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message.ForeColor = System.Drawing.Color.Black;
            this.message.Location = new System.Drawing.Point(12, 580);
            this.message.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(632, 34);
            this.message.TabIndex = 0;
            this.message.KeyDown += new System.Windows.Forms.KeyEventHandler(this.message_KeyDown);
            // 
            // conversation
            // 
            this.conversation.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.conversation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conversation.ForeColor = System.Drawing.Color.Black;
            this.conversation.Location = new System.Drawing.Point(12, 188);
            this.conversation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.conversation.Name = "conversation";
            this.conversation.ReadOnly = true;
            this.conversation.Size = new System.Drawing.Size(712, 371);
            this.conversation.TabIndex = 0;
            this.conversation.TabStop = false;
            this.conversation.Text = "Are you ready???";
            // 
            // btnReady
            // 
            this.btnReady.BackColor = System.Drawing.Color.LimeGreen;
            this.btnReady.FlatAppearance.BorderSize = 0;
            this.btnReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReady.ForeColor = System.Drawing.Color.Black;
            this.btnReady.Location = new System.Drawing.Point(801, 318);
            this.btnReady.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReady.Name = "btnReady";
            this.btnReady.Size = new System.Drawing.Size(115, 45);
            this.btnReady.TabIndex = 0;
            this.btnReady.TabStop = false;
            this.btnReady.Text = "Ready";
            this.btnReady.UseVisualStyleBackColor = false;
            this.btnReady.Click += new System.EventHandler(this.btnReady_Click);
            // 
            // playerNum
            // 
            this.playerNum.BackColor = System.Drawing.Color.WhiteSmoke;
            this.playerNum.Dock = System.Windows.Forms.DockStyle.Top;
            this.playerNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerNum.Location = new System.Drawing.Point(0, 0);
            this.playerNum.Name = "playerNum";
            this.playerNum.Size = new System.Drawing.Size(982, 33);
            this.playerNum.TabIndex = 7;
            this.playerNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAutoPlaySingleTurn
            // 
            this.btnAutoPlaySingleTurn.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAutoPlaySingleTurn.Enabled = false;
            this.btnAutoPlaySingleTurn.FlatAppearance.BorderSize = 0;
            this.btnAutoPlaySingleTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoPlaySingleTurn.ForeColor = System.Drawing.Color.Black;
            this.btnAutoPlaySingleTurn.Location = new System.Drawing.Point(747, 378);
            this.btnAutoPlaySingleTurn.Margin = new System.Windows.Forms.Padding(0);
            this.btnAutoPlaySingleTurn.Name = "btnAutoPlaySingleTurn";
            this.btnAutoPlaySingleTurn.Size = new System.Drawing.Size(216, 45);
            this.btnAutoPlaySingleTurn.TabIndex = 9;
            this.btnAutoPlaySingleTurn.TabStop = false;
            this.btnAutoPlaySingleTurn.Text = "Autoplay a turn";
            this.btnAutoPlaySingleTurn.UseVisualStyleBackColor = false;
            this.btnAutoPlaySingleTurn.Click += new System.EventHandler(this.autoTurn_Click);
            // 
            // btnAutoplayWholeGame
            // 
            this.btnAutoplayWholeGame.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAutoplayWholeGame.Enabled = false;
            this.btnAutoplayWholeGame.FlatAppearance.BorderSize = 0;
            this.btnAutoplayWholeGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoplayWholeGame.ForeColor = System.Drawing.Color.Black;
            this.btnAutoplayWholeGame.Location = new System.Drawing.Point(747, 438);
            this.btnAutoplayWholeGame.Margin = new System.Windows.Forms.Padding(0);
            this.btnAutoplayWholeGame.Name = "btnAutoplayWholeGame";
            this.btnAutoplayWholeGame.Size = new System.Drawing.Size(216, 45);
            this.btnAutoplayWholeGame.TabIndex = 10;
            this.btnAutoplayWholeGame.TabStop = false;
            this.btnAutoplayWholeGame.Text = "Autoplay all rounds";
            this.btnAutoplayWholeGame.UseVisualStyleBackColor = false;
            this.btnAutoplayWholeGame.Click += new System.EventHandler(this.autoAllGame_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(82, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Khoảng:";
            // 
            // range
            // 
            this.range.AutoSize = true;
            this.range.Enabled = false;
            this.range.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.range.Location = new System.Drawing.Point(172, 121);
            this.range.Name = "range";
            this.range.Size = new System.Drawing.Size(0, 20);
            this.range.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(82, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Đáp án:";
            // 
            // ansNumber
            // 
            this.ansNumber.AutoSize = true;
            this.ansNumber.Enabled = false;
            this.ansNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ansNumber.Location = new System.Drawing.Point(185, 152);
            this.ansNumber.Name = "ansNumber";
            this.ansNumber.Size = new System.Drawing.Size(0, 20);
            this.ansNumber.TabIndex = 15;
            // 
            // timerCnt
            // 
            this.timerCnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerCnt.Location = new System.Drawing.Point(790, 33);
            this.timerCnt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timerCnt.Name = "timerCnt";
            this.timerCnt.Size = new System.Drawing.Size(153, 140);
            this.timerCnt.TabIndex = 16;
            this.timerCnt.Text = "0";
            this.timerCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(754, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Time left:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.DarkGreen;
            this.label5.Location = new System.Drawing.Point(100, 44);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(502, 48);
            this.label5.TabIndex = 18;
            this.label5.Text = "NUMBER MAGIC GAME";
            // 
            // answer
            // 
            this.answer.BorderRadius = 23;
            this.answer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.answer.DefaultText = "Enter your answer";
            this.answer.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.answer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.answer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.answer.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.answer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.answer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.answer.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.answer.Location = new System.Drawing.Point(506, 138);
            this.answer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.answer.Name = "answer";
            this.answer.PasswordChar = '\0';
            this.answer.PlaceholderText = "";
            this.answer.SelectedText = "";
            this.answer.Size = new System.Drawing.Size(138, 36);
            this.answer.TabIndex = 19;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BorderRadius = 22;
            this.btnSubmit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSubmit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSubmit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSubmit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(651, 138);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(81, 35);
            this.btnSubmit.TabIndex = 20;
            this.btnSubmit.Text = "Submit";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(982, 632);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.answer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.timerCnt);
            this.Controls.Add(this.btnAutoPlaySingleTurn);
            this.Controls.Add(this.ansNumber);
            this.Controls.Add(this.btnAutoplayWholeGame);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.range);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.playerNum);
            this.Controls.Add(this.btnReady);
            this.Controls.Add(this.conversation);
            this.Controls.Add(this.message);
            this.Controls.Add(this.btnClear);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClear;
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
        private Guna.UI2.WinForms.Guna2TextBox answer;
        private Guna.UI2.WinForms.Guna2Button btnSubmit;
    }
}