using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace Lab06
{
    public partial class mainForm : Form
    {
        private TcpClient client = null;
        private Thread thread = null;
        private indexForm parent;
        private Random rand;
        private String joinUsername, joinIP, joinPort, time;
        private int timeLeft = -1, valRange, lastSubmitTime, startRange, endRange;
        public bool isIngame = false, isServer = false, isAuto = false;
        private List<int> ansList = null;

        public mainForm(indexForm parent, string joinUsername, string joinIP, string joinPort, String time)
        {
            InitializeComponent();
            rand = new Random();
            this.joinPort = joinPort;
            this.time = time;
            this.joinUsername = joinUsername;
            this.joinIP = joinIP;
            this.MaximizeBox = false;
            this.parent = parent;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            answer.AutoSize = true;
            string username = joinUsername;
            IPAddress ip = null;
            int port = 0;
            if (username == "Username" || username == "") username = " ";
            try
            {
                ip = Dns.Resolve(joinIP).AddressList[0];
                port = Int32.Parse(joinPort);
            }
            catch
            {
                MessageBox.Show("Sai địa chỉ IP!");
                this.Close();
                return;
            }
            client = new TcpClient();
            try
            {
                client.Connect(ip, port);
            }
            catch
            {
                MessageBox.Show("Không có game nào đang diễn ra!");
                this.Close();
                return;
            }


            NetworkStream stream = client.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(username);
            stream.Write(buffer, 0, buffer.Length);

            buffer = new byte[1024];
            int bytesCount = stream.Read(buffer, 0, buffer.Length);
            string res = Encoding.UTF8.GetString(buffer, 0, bytesCount);
            String[] ress = res.Split('\t');

            if (ress[0] == "Server")
            {
                isServer = true;
                btnReady.Enabled = btnSubmit.Enabled = btnAutoplayWholeGame.Enabled = btnAutoPlaySingleTurn.Enabled = btnClear.Enabled = false;
                answer.BorderStyle = (System.Drawing.Drawing2D.DashStyle)BorderStyle.None;
            }
            else if (ress[0] == "@@@Ingame!@@@")
            {
                MessageBox.Show("Trò chơi đã bắt đầu, không thể vào!", "Error");
                this.Close();
                return;
            }
            else if (ress[0] == " ")
            {
                MessageBox.Show($"{username} không thể dùng được", "Error");
                this.Close();
                return;
            }

            if (!isServer)
            {
                MessageBox.Show($"{ress[0]} là tên của bạn", "Success");
                time = DateTime.Now.ToString("h:mm:ss tt");
            }

            this.Text = ress[0];
            if (ress.Length > 1) playerNum.Text = $"{ress[1].Trim('\n')} người chơi đã tham gia";

            thread = new Thread(o => ReceiveData((TcpClient)o));
            thread.Start(client);
        }

        private readonly object sendLock = new object();

        private void send(String message)
        {
            // FIX: submit() tạo 1 Thread mới riêng cho mỗi lần gửi (new Thread(() => send(...))).
            // Nếu người chơi bấm Submit nhiều lần liên tiếp nhanh, nhiều Thread có thể cùng lúc
            // ghi vào chung 1 NetworkStream -> dữ liệu bị ghi chồng/lẫn lộn byte (interleaving),
            // server nhận được gói tin hỏng, parse sai/không nhận diện được số đã gửi dù đúng đáp án.
            // Thêm lock để đảm bảo tại 1 thời điểm chỉ có 1 thread được ghi vào stream.
            lock (sendLock)
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = Encoding.UTF8.GetBytes($"{message}\n");
                stream.Write(buffer, 0, buffer.Length);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            if (timeLeft > -1)
            {
                timerCnt.Text = timeLeft.ToString("D2");

                // Đổi màu timer: xanh → vàng (≤7s) → đỏ (≤3s)
                if (timeLeft <= 3)
                    timerCnt.ForeColor = System.Drawing.Color.FromArgb(255, 80, 80);
                else if (timeLeft <= 7)
                    timerCnt.ForeColor = System.Drawing.Color.FromArgb(255, 183, 77);
                else
                    timerCnt.ForeColor = System.Drawing.Color.FromArgb(99, 202, 183);

                if (timeLeft == 0)
                {
                    btnSubmit.Enabled = btnAutoplayWholeGame.Enabled = btnAutoPlaySingleTurn.Enabled = answer.Enabled = label3.Enabled = label4.Enabled = range.Enabled = ansNumber.Enabled = false;
                    send("@@@Timeup!@@@");
                }
                else if (isAuto && lastSubmitTime - timeLeft >= 3)
                {
                    new Thread(() => autoSubmit()).Start();
                }
                else if (!isAuto && lastSubmitTime - timeLeft >= 3)
                {
                    btnSubmit.Enabled = btnAutoPlaySingleTurn.Enabled = answer.Enabled = true;
                    answer.Focus();
                    answer.Select();
                }
            }
            else
            {
                timerCnt.Text      = "--";
                timerCnt.ForeColor = System.Drawing.Color.FromArgb(80, 80, 110);
                timer.Stop();
            }
        }

        private void answer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSubmit.PerformClick();
            }
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            btnReady.Enabled   = false;
            btnReady.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            btnReady.ForeColor = System.Drawing.Color.FromArgb(100, 100, 130);
            btnReady.Text      = "✅  Đã sẵn sàng";
            send("@@@Ready!@@@");
        }

        private void message_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend.PerformClick();
            }
        }

        private void submit(int val)
        {
            if (timeLeft <= 0)
            {
                // Người dùng bấm Submit ngay lúc/sau khi hết giờ. Trước đây sẽ im lặng bỏ qua
                // khiến người chơi tưởng bị bug. Giờ báo rõ lý do để họ biết cần bấm nhanh hơn.
                conversation.AppendText("⏱ Đã hết giờ, không thể gửi đáp án cho round này.\n");
                conversation.ScrollToCaret();
                return;
            }

            if (lastSubmitTime - timeLeft < 3)
            {
                // Đang trong thời gian cooldown chống spam (3 giây/lần), báo cho người chơi biết còn phải chờ.
                int waitMore = 3 - (lastSubmitTime - timeLeft);
                conversation.AppendText($"⏳ Vui lòng chờ thêm ~{waitMore}s trước khi gửi đáp án tiếp theo.\n");
                conversation.ScrollToCaret();
                return;
            }

            new Thread(() => send($"s{val}")).Start();

            lastSubmitTime = timeLeft;

            if (!this.InvokeRequired)
            {
                btnSubmit.Enabled = btnAutoPlaySingleTurn.Enabled = answer.Enabled = false;
            }

            int index = ansList.IndexOf(val);

            if (index != -1 && index <= valRange)
            {
                int temp = ansList[valRange];
                ansList[valRange] = ansList[index];
                ansList[index] = temp;
                valRange--;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void playerNum_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Int32.TryParse(answer.Text, out int val))
            {
                MessageBox.Show("Vui lòng nhập một con số hợp lệ.", "Lỗi nhập liệu");
                return;
            }
            submit(val);
            answer.Clear();
        }

        private void autoSubmit()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(delegate ()
                {
                    autoSubmit();
                }));
            else
            {
                btnSubmit.Enabled = btnAutoPlaySingleTurn.Enabled = answer.Enabled = false;
                if (isAuto)
                {
                    btnAutoplayWholeGame.Enabled = false;
                }
                int val = rand.Next(0, valRange + 1);
                submit(ansList[val]);
            }
        }

        private void autoTurn_Click(object sender, EventArgs e)
        {
            autoSubmit();
        }

        private void autoAllGame_Click(object sender, EventArgs e)
        {
            isAuto = true;
            autoSubmit();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            send($"m{message.Text}");
            message.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            conversation.Clear();
        }


        private void ReceiveData(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] receivedBytes = new byte[1024];
            int bytesCount;
            // Xem giải thích tương tự bên server (indexForm.cs / clientCheck): TCP là stream,
            // 1 lần Read() có thể trả về message bị cắt dở hoặc nhiều message dính liền, nên cần
            // tích lũy dữ liệu và chỉ xử lý các dòng đã kết thúc bằng '\n'.
            StringBuilder recvBuffer = new StringBuilder();

            while (Thread.CurrentThread.IsAlive)
            {
                try
                {
                    if ((bytesCount = stream.Read(receivedBytes, 0, receivedBytes.Length)) <= 0) break;
                }
                catch { break; }

                recvBuffer.Append(Encoding.UTF8.GetString(receivedBytes, 0, bytesCount));

                string accumulated = recvBuffer.ToString();
                int lastNewline = accumulated.LastIndexOf('\n');
                if (lastNewline == -1) continue; // Chưa có dòng nào hoàn chỉnh, chờ đọc thêm

                string completePart = accumulated.Substring(0, lastNewline);
                recvBuffer.Clear();
                recvBuffer.Append(accumulated.Substring(lastNewline + 1));

                var dataListRaw = completePart.Split(new String[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                bool shouldBreak = false;

                // FIX RACE CONDITION: khi server gửi cả dòng chat ("m...") và lệnh điều khiển
                // ("@@@Nextround!@@@...") trong CÙNG 1 gói tin, xử lý tuần tự theo thứ tự gốc sẽ
                // hiện chữ "Round X: Đoán một số..." TRƯỚC khi nút Submit/answer kịp Enable (2 lệnh
                // Invoke() riêng biệt). Giữa 2 Invoke đó, UI thread có thể xử lý luôn cú click chuột
                // đang chờ sẵn trong hàng đợi -> click "rơi" vào đúng lúc nút còn disable -> bị nuốt
                // hoàn toàn, không lỗi, không log gì (đúng hiện tượng "bấm Submit không nhận").
                //
                // Fix: ưu tiên xử lý các dòng lệnh điều khiển (bắt đầu bằng "@@@" hoặc "\t") TRƯỚC,
                // để UI (bật nút, set range...) sẵn sàng ngay, rồi mới hiện dòng chat text sau.
                var dataList = dataListRaw
                    .OrderByDescending(d => d.Length > 0 && (d[0] == '\t' || d.StartsWith("@@@")))
                    .ToArray();

                foreach (String data in dataList)
                {
                    if (data.Length == 0) continue;
                    if (data[0] == 'm')
                        conversation.Invoke(new MethodInvoker(delegate ()
                        {
                            string msg = data.Substring(1);
                            // Màu theo loại thông báo
                            System.Drawing.Color color;
                            if (msg.StartsWith("🏆") || msg.StartsWith("✅"))
                                color = System.Drawing.Color.FromArgb(99, 202, 183);  // Xanh ngọc — đoán đúng
                            else if (msg.StartsWith("❌") || msg.StartsWith("⚠️"))
                                color = System.Drawing.Color.FromArgb(255, 100, 100); // Đỏ — đoán sai
                            else if (msg.StartsWith("🎮") || msg.StartsWith("━"))
                                color = System.Drawing.Color.FromArgb(255, 183, 77);  // Vàng — round mới
                            else if (msg.StartsWith("🏁") || msg.StartsWith("👑") || msg.StartsWith("🥇") || msg.StartsWith("📊"))
                                color = System.Drawing.Color.FromArgb(200, 160, 255); // Tím — kết game
                            else if (msg.StartsWith("⏱") || msg.StartsWith("⏳"))
                                color = System.Drawing.Color.FromArgb(150, 150, 180); // Xám — hệ thống
                            else
                                color = System.Drawing.Color.FromArgb(210, 210, 230); // Trắng xám — mặc định

                            conversation.SelectionStart  = conversation.TextLength;
                            conversation.SelectionLength = 0;
                            conversation.SelectionColor  = color;
                            conversation.AppendText($"{msg}\n");
                            conversation.SelectionColor  = conversation.ForeColor;
                            conversation.ScrollToCaret();
                        }));
                    else if (data[0] == '\t')
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            playerNum.Text = $"{data.Substring(1)} người chơi đã tham gia";
                        }));

                    else if (data.StartsWith("@@@Nextround!@@@"))
                    {
                        if (!isIngame) isIngame = true;

                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            label3.Enabled = range.Enabled = true;
                        }));

                        var rand = data.Substring(16).Split(new String[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                        startRange = Int32.Parse(rand[1]);
                        endRange = Int32.Parse(rand[2]);
                        valRange = endRange - startRange;
                        ansList = Enumerable.Range(startRange, valRange + 1).ToList();
                        range.Invoke(new MethodInvoker(delegate ()
                        {
                            range.Text = $"[{startRange}, {endRange}]";
                        }));

                        if (isServer) ansNumber.Invoke(new MethodInvoker(delegate ()
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                label4.Enabled = ansNumber.Enabled = true;
                            }));
                            ansNumber.Text = rand[3];
                        }));
                        else
                        {
                            lastSubmitTime = 100;
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                btnSubmit.Enabled = btnAutoplayWholeGame.Enabled = btnAutoPlaySingleTurn.Enabled = answer.Enabled = true;
                                answer.Focus();
                                answer.Select();
                            }));
                        }

                        timeLeft = int.Parse(rand[0]);
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            timerCnt.Text      = timeLeft.ToString("D2");
                            timerCnt.ForeColor = System.Drawing.Color.FromArgb(99, 202, 183);
                            timer.Start();
                        }));
                    }\n                    else if (!isServer && data == \"@@@Newgame!@@@\")
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            btnReady.Enabled  = true;
                            btnReady.BackColor = System.Drawing.Color.FromArgb(99, 202, 183);
                            btnSubmit.Enabled = btnAutoplayWholeGame.Enabled = btnAutoPlaySingleTurn.Enabled = answer.Enabled = false;
                        }));
                        isIngame = isAuto = false;
                    }
                    else if (data == "@@@Exit!@@@")
                    {
                        closeWhenServerDown();
                        shouldBreak = true;
                        break;
                    }
                }
                if (shouldBreak) break;
            }
            if (isIngame)
            {
                isIngame = false;
                closeWhenServerDown();
            }
            stream.Close();
        }

        private void closeWhenServerDown()
        {
            MessageBox.Show("Game hiện tại đã kết thúc");
            (new Thread(() => this.Invoke(new MethodInvoker(delegate ()
            {
                this.Close();
            })))).Start();
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isServer)
            {
                this.Hide();
                parent.Show();
                e.Cancel = true;
                return;
            }
            else if (isIngame)
            {
                e.Cancel = true;
                new Thread(() => MessageBox.Show("Vui lòng chờ round hiện tại kết thúc", "Error")).Start();
                return;
            }

            if (this.Text != "Anonymous")
            {
                try
                {
                    String path = Path.Combine(
                        Path.GetDirectoryName(Application.ExecutablePath),
                        $"History_{this.Text}.txt"
                    );
                    StreamWriter sw;
                    if (!File.Exists(path))
                    {
                        sw = File.CreateText(path);
                    }
                    else
                    {
                        sw = File.AppendText(path);
                    }
                    String hostOrJoin;
                    if (this.Text == "Server")
                    {
                        hostOrJoin = $">>> {time} - Server hosted a connection... <<<";
                    }
                    else
                    {
                        hostOrJoin = $">>> {time} - {this.Text} connected to Server... <<<";
                    }
                    conversation.Text = $"{hostOrJoin}\n\n{conversation.Text}\n>>> Connection closed <<<\n\n\n\n";
                    foreach (String line in conversation.Lines)
                    {
                        sw.WriteLine(line);
                    }
                    sw.Close();
                }
                catch
                {
                    MessageBox.Show("Không thể lưu lịch sử", "Error");
                }
            }

            thread?.Abort();

            if (client != null)
            {
                try
                {
                    client.Client.Shutdown(SocketShutdown.Send);
                }
                catch { }
                client.Close();
            }

            parent.Show();
        }
    }
}
