namespace Lab06
{
    partial class indexForm
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
            this.joinPort     = new System.Windows.Forms.TextBox();
            this.joinIP       = new System.Windows.Forms.TextBox();
            this.hostPort     = new System.Windows.Forms.TextBox();
            this.label2       = new System.Windows.Forms.Label();
            this.label3       = new System.Windows.Forms.Label();
            this.label4       = new System.Windows.Forms.Label();
            this.label5       = new System.Windows.Forms.Label();
            this.lblJoinSec   = new System.Windows.Forms.Label();
            this.lblHostSec   = new System.Windows.Forms.Label();
            this.lblVersion   = new System.Windows.Forms.Label();
            this.divider      = new System.Windows.Forms.Panel();
            this.btnClient    = new Guna.UI2.WinForms.Guna2Button();
            this.btnServer    = new Guna.UI2.WinForms.Guna2Button();
            this.joinUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.joinIPBox    = new Guna.UI2.WinForms.Guna2TextBox();
            this.joinPortBox  = new Guna.UI2.WinForms.Guna2TextBox();
            this.hostPortBox  = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();

            // ── Form ────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor           = System.Drawing.Color.FromArgb(18, 18, 30);
            this.ClientSize          = new System.Drawing.Size(820, 480);
            this.Font                = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor           = System.Drawing.Color.White;
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox         = false;
            this.Name                = "indexForm";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Multiplayer Guess Number";

            // ── Tiêu đề ─────────────────────────────────────
            this.label5.AutoSize  = true;
            this.label5.Font      = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(99, 202, 183);
            this.label5.Location  = new System.Drawing.Point(0, 36);
            this.label5.Name      = "label5";
            this.label5.Size      = new System.Drawing.Size(820, 48);
            this.label5.TabIndex  = 0;
            this.label5.Text      = "🎯  Multiplayer Guess Number";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Version label ────────────────────────────────
            this.lblVersion.AutoSize  = false;
            this.lblVersion.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(100, 100, 130);
            this.lblVersion.Location  = new System.Drawing.Point(0, 82);
            this.lblVersion.Name      = "lblVersion";
            this.lblVersion.Size      = new System.Drawing.Size(820, 20);
            this.lblVersion.TabIndex  = 0;
            this.lblVersion.Text      = "Đoán đúng số bí mật — người nhanh nhất thắng!";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Đường kẻ ngang ──────────────────────────────
            this.divider.BackColor = System.Drawing.Color.FromArgb(45, 45, 65);
            this.divider.Location  = new System.Drawing.Point(40, 118);
            this.divider.Name      = "divider";
            this.divider.Size      = new System.Drawing.Size(740, 1);
            this.divider.TabIndex  = 0;

            // ════════════════════════════════════════════════
            //  CỘT TRÁI — Tham gia game
            // ════════════════════════════════════════════════
            this.lblJoinSec.AutoSize  = false;
            this.lblJoinSec.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblJoinSec.ForeColor = System.Drawing.Color.FromArgb(99, 202, 183);
            this.lblJoinSec.Location  = new System.Drawing.Point(60, 138);
            this.lblJoinSec.Name      = "lblJoinSec";
            this.lblJoinSec.Size      = new System.Drawing.Size(300, 28);
            this.lblJoinSec.Text      = "👤  Tham gia phòng";

            // Label tên
            this.label2.AutoSize  = false;
            this.label2.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(170, 170, 200);
            this.label2.Location  = new System.Drawing.Point(60, 180);
            this.label2.Name      = "label2";
            this.label2.Size      = new System.Drawing.Size(300, 20);
            this.label2.Text      = "Tên người chơi";

            // Ô tên
            this.joinUsername.BorderRadius = 8;
            this.joinUsername.Cursor       = System.Windows.Forms.Cursors.IBeam;
            this.joinUsername.DefaultText  = "";
            this.joinUsername.FillColor    = System.Drawing.Color.FromArgb(30, 30, 50);
            this.joinUsername.BorderColor  = System.Drawing.Color.FromArgb(60, 60, 90);
            this.joinUsername.FocusedState.BorderColor  = System.Drawing.Color.FromArgb(99, 202, 183);
            this.joinUsername.HoverState.BorderColor    = System.Drawing.Color.FromArgb(99, 202, 183);
            this.joinUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.joinUsername.DisabledState.FillColor   = System.Drawing.Color.FromArgb(25, 25, 40);
            this.joinUsername.DisabledState.ForeColor   = System.Drawing.Color.FromArgb(100, 100, 130);
            this.joinUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(80, 80, 110);
            this.joinUsername.Font              = new System.Drawing.Font("Segoe UI", 10.5F);
            this.joinUsername.ForeColor         = System.Drawing.Color.White;
            this.joinUsername.PlaceholderText   = "Nhập tên của bạn...";
            this.joinUsername.PlaceholderForeColor = System.Drawing.Color.FromArgb(90, 90, 120);
            this.joinUsername.Location          = new System.Drawing.Point(60, 204);
            this.joinUsername.Name              = "joinUsername";
            this.joinUsername.PasswordChar      = '\0';
            this.joinUsername.SelectedText      = "";
            this.joinUsername.Size              = new System.Drawing.Size(300, 40);
            this.joinUsername.TabIndex          = 1;
            this.joinUsername.TextAlign         = System.Windows.Forms.HorizontalAlignment.Left;

            // Label địa chỉ IP
            this.label3.AutoSize  = false;
            this.label3.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(170, 170, 200);
            this.label3.Location  = new System.Drawing.Point(60, 260);
            this.label3.Name      = "label3";
            this.label3.Size      = new System.Drawing.Size(300, 20);
            this.label3.Text      = "Địa chỉ IP server";

            // Ô IP (Guna2)
            this.joinIPBox.BorderRadius = 8;
            this.joinIPBox.Cursor       = System.Windows.Forms.Cursors.IBeam;
            this.joinIPBox.DefaultText  = "";
            this.joinIPBox.FillColor    = System.Drawing.Color.FromArgb(30, 30, 50);
            this.joinIPBox.BorderColor  = System.Drawing.Color.FromArgb(60, 60, 90);
            this.joinIPBox.FocusedState.BorderColor  = System.Drawing.Color.FromArgb(99, 202, 183);
            this.joinIPBox.HoverState.BorderColor    = System.Drawing.Color.FromArgb(99, 202, 183);
            this.joinIPBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.joinIPBox.DisabledState.FillColor   = System.Drawing.Color.FromArgb(25, 25, 40);
            this.joinIPBox.DisabledState.ForeColor   = System.Drawing.Color.FromArgb(100, 100, 130);
            this.joinIPBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(80, 80, 110);
            this.joinIPBox.Font              = new System.Drawing.Font("Segoe UI", 10.5F);
            this.joinIPBox.ForeColor         = System.Drawing.Color.White;
            this.joinIPBox.PlaceholderText   = "localhost";
            this.joinIPBox.PlaceholderForeColor = System.Drawing.Color.FromArgb(90, 90, 120);
            this.joinIPBox.Location          = new System.Drawing.Point(60, 284);
            this.joinIPBox.Name              = "joinIPBox";
            this.joinIPBox.PasswordChar      = '\0';
            this.joinIPBox.SelectedText      = "";
            this.joinIPBox.Size              = new System.Drawing.Size(186, 40);
            this.joinIPBox.TabIndex          = 2;
            this.joinIPBox.Text              = "localhost";
            this.joinIPBox.TextAlign         = System.Windows.Forms.HorizontalAlignment.Left;

            // Ô Port join (Guna2)
            this.joinPortBox.BorderRadius = 8;
            this.joinPortBox.Cursor       = System.Windows.Forms.Cursors.IBeam;
            this.joinPortBox.DefaultText  = "";
            this.joinPortBox.FillColor    = System.Drawing.Color.FromArgb(30, 30, 50);
            this.joinPortBox.BorderColor  = System.Drawing.Color.FromArgb(60, 60, 90);
            this.joinPortBox.FocusedState.BorderColor  = System.Drawing.Color.FromArgb(99, 202, 183);
            this.joinPortBox.HoverState.BorderColor    = System.Drawing.Color.FromArgb(99, 202, 183);
            this.joinPortBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.joinPortBox.DisabledState.FillColor   = System.Drawing.Color.FromArgb(25, 25, 40);
            this.joinPortBox.DisabledState.ForeColor   = System.Drawing.Color.FromArgb(100, 100, 130);
            this.joinPortBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(80, 80, 110);
            this.joinPortBox.Font              = new System.Drawing.Font("Segoe UI", 10.5F);
            this.joinPortBox.ForeColor         = System.Drawing.Color.White;
            this.joinPortBox.PlaceholderText   = "Port";
            this.joinPortBox.PlaceholderForeColor = System.Drawing.Color.FromArgb(90, 90, 120);
            this.joinPortBox.Location          = new System.Drawing.Point(254, 284);
            this.joinPortBox.Name              = "joinPortBox";
            this.joinPortBox.PasswordChar      = '\0';
            this.joinPortBox.SelectedText      = "";
            this.joinPortBox.Size              = new System.Drawing.Size(106, 40);
            this.joinPortBox.TabIndex          = 3;
            this.joinPortBox.Text              = "8080";
            this.joinPortBox.TextAlign         = System.Windows.Forms.HorizontalAlignment.Center;

            // Nút Tham gia
            this.btnClient.BorderRadius = 8;
            this.btnClient.FillColor    = System.Drawing.Color.FromArgb(99, 202, 183);
            this.btnClient.HoverState.FillColor = System.Drawing.Color.FromArgb(75, 175, 158);
            this.btnClient.DisabledState.BorderColor    = System.Drawing.Color.DarkGray;
            this.btnClient.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClient.DisabledState.FillColor      = System.Drawing.Color.FromArgb(50, 50, 70);
            this.btnClient.DisabledState.ForeColor      = System.Drawing.Color.FromArgb(100, 100, 130);
            this.btnClient.Font      = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnClient.ForeColor = System.Drawing.Color.FromArgb(18, 18, 30);
            this.btnClient.Location  = new System.Drawing.Point(60, 348);
            this.btnClient.Name      = "btnClient";
            this.btnClient.Size      = new System.Drawing.Size(300, 44);
            this.btnClient.TabIndex  = 5;
            this.btnClient.Text      = "▶  Tham gia phòng";
            this.btnClient.Click    += new System.EventHandler(this.btnClient_Click);

            // ════════════════════════════════════════════════
            //  CỘT PHẢI — Tạo game
            // ════════════════════════════════════════════════
            this.lblHostSec.AutoSize  = false;
            this.lblHostSec.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblHostSec.ForeColor = System.Drawing.Color.FromArgb(255, 183, 77);
            this.lblHostSec.Location  = new System.Drawing.Point(460, 138);
            this.lblHostSec.Name      = "lblHostSec";
            this.lblHostSec.Size      = new System.Drawing.Size(300, 28);
            this.lblHostSec.Text      = "🖥️  Tạo phòng mới";

            // Label Host port
            this.label4.AutoSize  = false;
            this.label4.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(170, 170, 200);
            this.label4.Location  = new System.Drawing.Point(460, 180);
            this.label4.Name      = "label4";
            this.label4.Size      = new System.Drawing.Size(300, 20);
            this.label4.Text      = "Cổng lắng nghe (Port)";

            // Ô Port host (Guna2)
            this.hostPortBox.BorderRadius = 8;
            this.hostPortBox.Cursor       = System.Windows.Forms.Cursors.IBeam;
            this.hostPortBox.DefaultText  = "";
            this.hostPortBox.FillColor    = System.Drawing.Color.FromArgb(30, 30, 50);
            this.hostPortBox.BorderColor  = System.Drawing.Color.FromArgb(60, 60, 90);
            this.hostPortBox.FocusedState.BorderColor  = System.Drawing.Color.FromArgb(255, 183, 77);
            this.hostPortBox.HoverState.BorderColor    = System.Drawing.Color.FromArgb(255, 183, 77);
            this.hostPortBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.hostPortBox.DisabledState.FillColor   = System.Drawing.Color.FromArgb(25, 25, 40);
            this.hostPortBox.DisabledState.ForeColor   = System.Drawing.Color.FromArgb(100, 100, 130);
            this.hostPortBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(80, 80, 110);
            this.hostPortBox.Font              = new System.Drawing.Font("Segoe UI", 10.5F);
            this.hostPortBox.ForeColor         = System.Drawing.Color.White;
            this.hostPortBox.PlaceholderText   = "Port";
            this.hostPortBox.PlaceholderForeColor = System.Drawing.Color.FromArgb(90, 90, 120);
            this.hostPortBox.Location          = new System.Drawing.Point(460, 204);
            this.hostPortBox.Name              = "hostPortBox";
            this.hostPortBox.PasswordChar      = '\0';
            this.hostPortBox.SelectedText      = "";
            this.hostPortBox.Size              = new System.Drawing.Size(300, 40);
            this.hostPortBox.TabIndex          = 4;
            this.hostPortBox.Text              = "8080";
            this.hostPortBox.TextAlign         = System.Windows.Forms.HorizontalAlignment.Center;

            // Nút Tạo game
            this.btnServer.BorderRadius = 8;
            this.btnServer.FillColor    = System.Drawing.Color.FromArgb(255, 183, 77);
            this.btnServer.HoverState.FillColor = System.Drawing.Color.FromArgb(230, 158, 50);
            this.btnServer.DisabledState.BorderColor    = System.Drawing.Color.DarkGray;
            this.btnServer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnServer.DisabledState.FillColor      = System.Drawing.Color.FromArgb(50, 50, 70);
            this.btnServer.DisabledState.ForeColor      = System.Drawing.Color.FromArgb(100, 100, 130);
            this.btnServer.Font      = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnServer.ForeColor = System.Drawing.Color.FromArgb(18, 18, 30);
            this.btnServer.Location  = new System.Drawing.Point(460, 348);
            this.btnServer.Name      = "btnServer";
            this.btnServer.Size      = new System.Drawing.Size(300, 44);
            this.btnServer.TabIndex  = 6;
            this.btnServer.Text      = "🖥️  Tạo phòng && bắt đầu";
            this.btnServer.Click    += new System.EventHandler(this.btnServer_Click);

            // ── Ẩn textbox cũ (giữ để code backend dùng) ───
            this.joinIP.Location = new System.Drawing.Point(-500, -500);
            this.joinIP.Size     = new System.Drawing.Size(1, 1);
            this.joinPort.Location = new System.Drawing.Point(-500, -500);
            this.joinPort.Size     = new System.Drawing.Size(1, 1);
            this.hostPort.Location = new System.Drawing.Point(-500, -500);
            this.hostPort.Size     = new System.Drawing.Size(1, 1);

            // ── Add controls ─────────────────────────────────
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.divider);
            this.Controls.Add(this.lblJoinSec);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.joinUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.joinIPBox);
            this.Controls.Add(this.joinPortBox);
            this.Controls.Add(this.btnClient);
            this.Controls.Add(this.lblHostSec);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.hostPortBox);
            this.Controls.Add(this.btnServer);
            this.Controls.Add(this.joinIP);
            this.Controls.Add(this.joinPort);
            this.Controls.Add(this.hostPort);

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox joinPort;
        private System.Windows.Forms.TextBox joinIP;
        private System.Windows.Forms.TextBox hostPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblJoinSec;
        private System.Windows.Forms.Label lblHostSec;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel divider;
        private Guna.UI2.WinForms.Guna2Button btnClient;
        private Guna.UI2.WinForms.Guna2Button btnServer;
        private Guna.UI2.WinForms.Guna2TextBox joinUsername;
        private Guna.UI2.WinForms.Guna2TextBox joinIPBox;
        private Guna.UI2.WinForms.Guna2TextBox joinPortBox;
        private Guna.UI2.WinForms.Guna2TextBox hostPortBox;
    }
}
