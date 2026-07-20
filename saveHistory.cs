using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Lab06
{
    public partial class saveHistory : Form
    {
        private readonly string _text;

        // Màu theo loại dòng — nhất quán với mainForm
        private static readonly Color C_Default  = Color.FromArgb(210, 210, 230);
        private static readonly Color C_Correct  = Color.FromArgb(99, 202, 183);
        private static readonly Color C_Wrong    = Color.FromArgb(255, 100, 100);
        private static readonly Color C_Round    = Color.FromArgb(255, 183, 77);
        private static readonly Color C_End      = Color.FromArgb(200, 160, 255);
        private static readonly Color C_System   = Color.FromArgb(150, 150, 180);
        private static readonly Color C_Divider  = Color.FromArgb(70, 70, 100);

        public saveHistory(string text)
        {
            InitializeComponent();
            _text = text;
        }

        private void saveHistory_Load(object sender, EventArgs e)
        {
            RenderHistory();
        }

        // Render lịch sử với màu sắc nhất quán với mainForm
        private void RenderHistory()
        {
            rtbHistory.Clear();

            string[] lines = _text.Split('\n');
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line)) continue;

                Color color;
                if (line.StartsWith("🏆") || line.StartsWith("✅"))
                    color = C_Correct;
                else if (line.StartsWith("❌") || line.StartsWith("⚠️"))
                    color = C_Wrong;
                else if (line.StartsWith("🎮") || line.StartsWith("━"))
                    color = C_Round;
                else if (line.StartsWith("🏁") || line.StartsWith("👑") || line.StartsWith("🥇") || line.StartsWith("📊"))
                    color = C_End;
                else if (line.StartsWith("⏱") || line.StartsWith("⏳") || line.StartsWith("👥") || line.StartsWith("✋") || line.StartsWith("🚪") || line.StartsWith("💨"))
                    color = C_System;
                else if (line.StartsWith("━"))
                    color = C_Divider;
                else
                    color = C_Default;

                rtbHistory.SelectionStart  = rtbHistory.TextLength;
                rtbHistory.SelectionLength = 0;
                rtbHistory.SelectionColor  = color;
                rtbHistory.AppendText(line + "\n");
            }

            rtbHistory.SelectionColor = C_Default;
            rtbHistory.SelectionStart = 0;
            rtbHistory.ScrollToCaret();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(_text);
                btnCopy.Text      = "✅  Đã sao chép!";
                btnCopy.BackColor = Color.FromArgb(75, 175, 158);

                // Reset lại sau 1.5 giây
                var t = new System.Windows.Forms.Timer { Interval = 1500 };
                t.Tick += (s, _) =>
                {
                    btnCopy.Text      = "📋  Sao chép";
                    btnCopy.BackColor = Color.FromArgb(99, 202, 183);
                    t.Stop();
                    t.Dispose();
                };
                t.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể sao chép: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog
            {
                Title           = "Lưu lịch sử game",
                Filter          = "Text file (*.txt)|*.txt|Tất cả|*.*",
                FileName        = $"game_history_{DateTime.Now:yyyyMMdd_HHmm}.txt",
                DefaultExt      = "txt",
                OverwritePrompt = true,
            })
            {
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                try
                {
                    File.WriteAllText(dlg.FileName, _text, System.Text.Encoding.UTF8);
                    btnSaveFile.Text      = "✅  Đã lưu!";
                    btnSaveFile.BackColor = Color.FromArgb(75, 175, 158);

                    var t = new System.Windows.Forms.Timer { Interval = 1500 };
                    t.Tick += (s, _) =>
                    {
                        btnSaveFile.Text      = "💾  Lưu file .txt";
                        btnSaveFile.BackColor = Color.FromArgb(255, 183, 77);
                        t.Stop();
                        t.Dispose();
                    };
                    t.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể lưu file: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}
