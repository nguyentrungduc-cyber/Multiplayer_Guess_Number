using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Lab06
{
    public partial class indexForm : Form
    {
        private Thread thread = null; // Luồng chạy chính của Server
        private TcpListener serverSocket; // Đối tượng dùng để mở cổng và lắng nghe kết nối

        private mainForm serverForm = null; // Biến lưu giao diện Form chơi game của chính người host

        // Các biến lưu thông tin trò chơi
        private int clientsCount = 0, currentRound, timeupCount, startRange, endRange, ansNumber, round = 0;
        private String correctPlayer, time = "";
        private Random rand; // Đối tượng dùng để sinh số ngẫu nhiên
        private bool ingame = false; // Cờ đánh dấu xem game đã bắt đầu chưa

        private readonly object _lock = new object(); // Đối tượng dùng để khóa (lock) khi thao tác với dữ liệu dùng chung giữa các luồng, tránh xung đột.

        // Các bộ từ điển (Dictionary) lưu trữ thông tin:
        private Dictionary<String, int> scoreBoard = new Dictionary<string, int>(); // Lưu Điểm số (Tên -> Điểm)
        private Dictionary<String, bool> readyPlayers = new Dictionary<string, bool>(); // Lưu trạng thái Sẵn sàng
        private readonly Dictionary<String, TcpClient> clientsList = new Dictionary<string, TcpClient>(); // Lưu các luồng kết nối mạng của từng Client
        public indexForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            rand = new Random();
        }


        // Xử lý nút "Tham Gia" (Dành cho Client)
        private void btnClient_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (serverForm != null)
            {
                serverForm.Show();
                return;
            }

            serverForm = new mainForm(this, joinUsername.Text, joinIP.Text, joinPort.Text, time);
            serverForm.Show();

            // Client -> thread(Luồng máy chủ) không có
            if (thread == null)
            {
                serverForm = null; // Nếu Crash hay Disconnect thì sẽ cho phép tạo lại ServerForm mới
            }
        }

        // Xử lý nút "Tạo Game" (Khởi động Server)
        private void btnServer_Click(object sender, EventArgs e)
        {
            btnServer.Enabled = false; 
            thread = new Thread(serverThread);
            thread.Start();
        }

        // Luồng hoạt động chính của Server, sẽ chạy song song với giao diện người dùng và đảm nhiệm việc lắng nghe kết nối, quản lý trò chơi, v.v.
        private void serverThread()
        {
            int port;
            try
            {
                port = Int32.Parse(hostPort.Text);
                // Thay vì chỉ khởi tạo bình thường, hãy thiết lập cho phép tái sử dụng cổng
                serverSocket = new TcpListener(IPAddress.Any, port);
                // cho phép tái sử dụng lại cổng này ngay lập tức nếu Server bị tắt đột ngột, tránh lỗi "Address already in use".
                serverSocket.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                serverSocket.Start();
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi thật sự để biết tại sao
                MessageBox.Show("Lỗi port chi tiết: " + ex.Message);
                // Mở lại nút bấm btnServer để người dùng có thể thử lại với cổng khác
                btnServer.Invoke(new MethodInvoker(delegate () { btnServer.Enabled = true; }));
                return;
            }

            time = DateTime.Now.ToString("h:mm:ss tt");

            // Tự động điền thông tin Client cho Server vào giao diện để chủ phòng cũng vào xem được
            this.Invoke(new MethodInvoker(delegate ()
            {
                joinUsername.Text = "Server";
                joinIP.Text = "localhost";
                joinPort.Text = hostPort.Text;
                joinUsername.Enabled = joinIP.Enabled = joinPort.Enabled = hostPort.Enabled = false;
            }));

            // Tạo một luồng click hộ vào nút "Tham gia" cho máy chủ
            (new Thread(() => this.Invoke(new MethodInvoker(delegate ()
            {
                btnClient.PerformClick();
            })))).Start();

            MessageBox.Show("Tạo game mới thành công");

            // Vòng lặp vô hạn để chờ các Client khác kết nối vào trong khi Server vẫn đang chạy, sẽ chỉ dừng lại khi Server bị tắt hoặc có lỗi xảy ra.
            while (Thread.CurrentThread.IsAlive)
            {
                TcpClient client = null;
                try
                {
                    // // Chấp nhận một kết nối đến từ Client, nếu không có sẽ chờ ở đây
                    client = serverSocket.AcceptTcpClient(); // Không tốn CPU khi chờ, vì đây là một phương thức blocking (chặn) cho đến khi có kết nối đến. 
                }
                catch (SocketException e)
                {
                    // Nếu Server bị tắt đột ngột, sẽ ném SocketException với mã lỗi Interrupted
                    if ((e.SocketErrorCode == SocketError.Interrupted))
                    {
                        // Lúc đó sẽ thoát khỏi vòng lặp và kết thúc luồng.
                        break;
                    }
                    // Với các lỗi khác (VD: mạng chập chờn), bỏ qua kết nối lỗi này và tiếp tục chờ client tiếp theo,
                    // tránh crash toàn bộ server do client bị null ở bước dưới.
                    continue;
                }

                if (client == null) continue; // An toàn: nếu vì lý do nào đó client vẫn null thì bỏ qua

                NetworkStream stream = client.GetStream(); // Tạo kết nối mạng với Client vừa kết nối
                byte[] buffer = new byte[1024]; 
                int bytesCount = stream.Read(buffer, 0, buffer.Length); 
                String username = Encoding.UTF8.GetString(buffer, 0, bytesCount);

                if (thread != null && ingame)
                {
                    buffer = Encoding.UTF8.GetBytes("@@@Ingame!@@@");
                    stream.Write(buffer, 0, buffer.Length);
                    continue; // Bỏ qua Client này
                }
                // Nếu người dùng không nhập tên, tự động cấp tên "Player X"
                if (username == " ")
                {
                    username = $"Player {clientsCount}";
                }

                // Nếu tên đã tồn tại trong phòng, từ chối kết nối
                if (clientsList.ContainsKey(username))
                {
                    buffer = Encoding.UTF8.GetBytes(" ");
                    stream.Write(buffer, 0, buffer.Length);
                    continue;
                }
                buffer = Encoding.UTF8.GetBytes(username);
                stream.Write(buffer, 0, buffer.Length);

                // Lưu người chơi này vào danh sách clientsList, dùng lock để an toàn luồng nếu nhiều Client cùng kết nối vào cùng lúc
                lock (_lock) clientsList.Add(username, client);

                if (username != "Server")
                {
                    broadcast($"m👋 {username} vừa vào phòng chơi", username);
                    lock (_lock) scoreBoard.Add(username, 0);
                }

                clientsCount++;

                Thread handlingThread = new Thread(o => clientCheck((string)o));
                handlingThread.Start(username);
                broadcast($"\t{clientsList.Count - 1}"); // Trừ 1 do Server cũng được tính vào clientsList nhưng không phải người chơi thực sự, chỉ để hiển thị số người chơi đang tham gia.
            }

            // Khi Server ngừng chạy thì sẽ kích hoạt lại nút bấm btnServer để người dùng có thể tạo lại Server mới nếu muốn.
            btnServer.Invoke(new MethodInvoker(delegate ()
            {
                btnServer.Enabled = true;
                btnServer.ResetText();
            }));
        }

        // Set số round cho mỗi game và khoảng số cần đoán
        private void roundStart()
        {
            // Đợi 5 giây trước khi bắt đầu round mới để mọi người kịp chuẩn bị, nếu có người chơi nào chưa sẵn sàng thì vẫn có thể tham gia vào round này.
            Thread.Sleep(5000);
            // Reset lại biến đếm số người chơi đã hết giờ để chờ round mới
            timeupCount = 0;

            // Nếu chưa có số round nào được thiết lập cho game này thì sẽ sinh ngẫu nhiên một số round từ 3 đến 10, và thông báo cho mọi người biết.
            if (round == 0)
            {
                round = rand.Next(5, 7);
                broadcast($"m🎯 Trò chơi gồm {round} round. Chúc may mắn!"); 
                currentRound = 1;
            }

            startRange = rand.Next(0, 50);
            endRange = startRange + rand.Next(1, 50); // Đảm bảo khoảng số hợp lệ, endRange phải lớn hơn startRange ít nhất 1 đơn vị
            ansNumber = rand.Next(startRange, endRange + 1);
            broadcast($"m━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\nm🎮 Round {currentRound}/{round} — Đoán số trong khoảng [{startRange}, {endRange}]\n@@@Nextround!@@@{rand.Next(15, 21)}\t{startRange}\t{endRange}\t{ansNumber}");
            currentRound++;
            correctPlayer = "";
        }

        private void timeUp()
        {
            string message;
            if (correctPlayer == "")
                message = $"m⏱ Hết giờ — Không ai đoán đúng.\nmĐáp án là: {ansNumber}.";
            else
                message = $"m✅ {correctPlayer} đoán đúng nhanh nhất (+10 điểm).\nmĐáp án là: {ansNumber}.";
            broadcast(message);
            if (currentRound > round) (new Thread(endGame)).Start();
            else if (ingame) (new Thread(roundStart)).Start();
        }

        public void clientCheck(string username)
        {
            TcpClient client;
            lock (_lock) client = clientsList[username];
            // Buffer tích lũy dữ liệu thô nhận được, vì TCP là giao thức stream:
            // 1 lần Read() có thể nhận được message bị cắt dở (chưa đủ 1 dòng) hoặc nhiều message dính liền nhau.
            // Trước đây code xử lý luôn mỗi lần Read() như thể luôn là các dòng hoàn chỉnh, có thể gây lỗi
            // parse (data[0] rác, Int32.Parse thất bại...) khi mạng chậm/gói tin bị chia nhỏ.
            StringBuilder recvBuffer = new StringBuilder();
            while (thread.IsAlive)
            {
                int bytesCount = 0;
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                try
                {
                    bytesCount = stream.Read(buffer, 0, buffer.Length);
                }
                catch { }
                if (bytesCount == 0) break;

                recvBuffer.Append(Encoding.UTF8.GetString(buffer, 0, bytesCount));

                // Chỉ tách và xử lý những dòng đã kết thúc bằng '\n'; phần còn lại (chưa có '\n')
                // được giữ lại trong recvBuffer để nối tiếp với dữ liệu nhận được ở lần Read() sau.
                string accumulated = recvBuffer.ToString();
                int lastNewline = accumulated.LastIndexOf('\n');
                if (lastNewline == -1) continue; // Chưa có dòng nào hoàn chỉnh, chờ đọc thêm

                string completePart = accumulated.Substring(0, lastNewline);
                recvBuffer.Clear();
                recvBuffer.Append(accumulated.Substring(lastNewline + 1));

                var dataList = completePart.Split(new String[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String data in dataList)
                {
                    if (data.Length == 0) continue;
                    if (data[0] == 's')
                    {
                        lock (_lock)
                        {
                            if (correctPlayer == "" && timeupCount < readyPlayers.Count)
                                try
                                {
                                    int ans = Int32.Parse(data.Substring(1));
                                    if (ans == ansNumber)
                                    {
                                        correctPlayer = username;
                                        scoreBoard[username] += 10;
                                        broadcast($"m🏆 {username} đoán đúng! +10 điểm");
                                    }
                                    if (ans != ansNumber)
                                    {
                                        broadcast($"m❌ {username} đoán sai ({ans}) — -1 điểm");
                                        scoreBoard[username]--;
                                    }
                                }
                                catch
                                {
                                    broadcast($"m⚠️ {username} nhập không hợp lệ — -1 điểm");
                                    scoreBoard[username]--;
                                }
                        }
                    }
                    else if (data[0] == 'm')
                    {
                        broadcast($"m{username}: {data.Substring(1)}");
                    }
                    else if (data == "@@@Timeup!@@@")
                    {
                        bool shouldTimeUp = false;
                        lock (_lock)
                        {
                            timeupCount++;
                            if (timeupCount == readyPlayers.Count) shouldTimeUp = true;
                        }
                        if (shouldTimeUp) (new Thread(() => timeUp())).Start();
                    }
                    else if (data == "@@@Ready!@@@")
                    {
                        broadcast($"m>>> {username} đã sẵn sàng!");
                        lock (_lock) readyPlayers.Add(username, true);
                        readyCheck();
                    }
                }
            }

            lock (_lock) clientsList.Remove(username);
            try
            {
                client.Client.Shutdown(SocketShutdown.Both);
            }
            catch { /* Socket có thể đã đóng từ phía client, bỏ qua để không crash thread */ }
            client.Close();

            if (username == "Server")
            {
                broadcast("@@@Exit!@@@");
            }
            else
            {
                broadcast($"m>>> {username} đã thoát khỏi game");
                if (clientsList.Count == 1)
                {
                    broadcast($"m>>> Tất cả người chơi đã thoát khỏi game");
                    if (ingame)
                    {
                        ingame = false;
                        endGame();
                    }
                }
                broadcast($"\t{clientsList.Count - 1}");
                lock (_lock)
                {
                    scoreBoard.Remove(username);
                    if (readyPlayers.ContainsKey(username)) readyPlayers.Remove(username);
                }
                readyCheck();
            }
        }

        private void readyCheck()
        {
            bool shouldStart = false;
            int readyCount = 0;
            lock (_lock)
            {
                // Chỉ được phép khởi động round mới nếu game CHƯA đang diễn ra (!ingame).
                // Trước đây thiếu điều kiện này nên khi 1 người chơi đã Ready rời phòng giữa game,
                // readyPlayers.Count và clientsList.Count cùng giảm 1 → điều kiện vẫn đúng → vô tình
                // start lại 1 round mới đè lên round đang chạy dở.
                if (!ingame && readyPlayers.Count != 0 && readyPlayers.Count == clientsList.Count - 1)
                {
                    ingame = true;
                    readyCount = readyPlayers.Count;
                    shouldStart = true;
                }
            }
            if (shouldStart)
            {
                broadcast($"mHiện có {readyCount} người chơi");
                (new Thread(roundStart)).Start();
            }
        }

        private void endGame()
        {
            if (ingame)
            {
                ingame = false;
                int highscore = int.MinValue;
                lock (_lock)
                {
                    foreach (var i in scoreBoard)
                    {
                        if (i.Value > highscore)
                        {
                            highscore = i.Value;
                        }
                    }
                }

                string message = $"m\nm🏁 Kết thúc game! Điểm cao nhất: {highscore}\nm👑 Người thắng:\n";
                lock (_lock)
                {
                    foreach (var i in scoreBoard)
                    {
                        if (i.Value == highscore)
                        {
                            message += $"m    🥇 {i.Key}\n";
                        }
                    }
                }

                foreach (var i in clientsList)
                {
                    try
                    {
                        NetworkStream stream = i.Value.GetStream();
                        byte[] buffer;
                        if (i.Key == "Server")
                        {
                            buffer = Encoding.UTF8.GetBytes($"{message}\n");
                        }
                        else
                        {
                            buffer = Encoding.UTF8.GetBytes($"{message}\nm📊 Điểm của bạn: {scoreBoard[i.Key]}\n");
                        }
                        stream.Write(buffer, 0, buffer.Length);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"Lỗi: {e.Message}");
                    }
                }
            }

            broadcast($"m\nm━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\nmTạo game mới... Chờ người chơi tham gia...\n@@@Newgame!@@@");
            lock (_lock)
            {
                scoreBoard = scoreBoard.ToDictionary(p => p.Key, p => 0);
                readyPlayers.Clear();
            }
            round = 0;
        }

        public void broadcast(string data, String except = "")
        {
            byte[] buffer = Encoding.UTF8.GetBytes($"{data}\n");
            lock (_lock)
            {
                foreach (var c in clientsList)
                {
                    if (c.Key != except)
                    {
                        NetworkStream stream = c.Value.GetStream();
                        stream.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ingame)
            {
                MessageBox.Show("Chờ game hiện tại kết thúc");
                e.Cancel = true;
                return;
            }

            if (serverForm != null)
            {
                this.Hide();

                String text = $">>> {time} - Server hosted a connection... <<<\n\n{serverForm.conversation.Text}\n>>> Connection closed <<<\n\n\n\n";
                (new saveHistory(text)).ShowDialog();
                serverForm.isServer = serverForm.isIngame = false;
                serverForm.Close();
            }

            if (serverSocket != null)
            {
                serverSocket.Stop();
            }

            if (thread != null)
            {
                thread.Abort();
            }
        }
    }
}

