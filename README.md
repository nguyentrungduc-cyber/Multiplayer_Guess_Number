# 🎲 Trò Chơi Đoán Số Đa Người Chơi (Multiplayer Guess Number)

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![Architecture](https://img.shields.io/badge/architecture-Client%2FServer-orange.svg)
![Status](https://img.shields.io/badge/status-Completed-success.svg)

Một ứng dụng trò chơi đoán số trực tuyến hỗ trợ nhiều người chơi cùng lúc dựa trên mô hình **Server - Clients** giao tiếp qua Socket (TCP/IP). Trò chơi đòi hỏi sự nhanh nhạy và may mắn, kết hợp cùng hệ thống tính điểm và bot tự động chơi thông minh!

---

## 📑 Mục lục
- [Giới thiệu chung](#-giới-thiệu-chung)
- [Tính năng nổi bật](#-tính-năng-nổi-bật)
  - [Phía Server](#phía-server)
  - [Phía Client](#phía-client)
- [Tính năng mở rộng (Nâng cao)](#-tính-năng-mở-rộng-nâng-cao)
- [Giao diện ứng dụng](#-giao-diện-ứng-dụng)
- [Luồng trò chơi (Gameplay Flow)](#-luồng-trò-chơi-gameplay-flow)
- [Cài đặt và Chạy ứng dụng](#-cài-đặt-và-chạy-ứng-dụng)
- [Kiểm thử (Testing)](#-kiểm-thử-testing)

---

## 🚀 Giới thiệu chung

Trò chơi bắt đầu khi Server tạo ngẫu nhiên một con số bí mật $x$ nằm trong khoảng $a < x < b$. Nhiệm vụ của các Clients là đoán chính xác con số này nhanh nhất có thể.
Người đoán đúng và nhanh nhất sẽ giành chiến thắng vòng đó. Các đáp án gửi sau sẽ bị bỏ qua và Server ngay lập tức bắt đầu một vòng chơi mới.

---

## ✨ Tính năng nổi bật

### Phía Server
- **Quản lý trung tâm:** Giao diện trực quan hiển thị các thông tin: số đang tìm (ẩn/hiện tuỳ chọn), phạm vi số, lịch sử trò chơi, số người đang online, và số lượt chơi hiện tại.
- **Tự động điều hành:** Tự quyết định số vòng chơi (tối thiểu 5 vòng). Thông báo kết quả và vòng mới tức thì đến toàn bộ người chơi.
- **Báo cáo đám mây:** Khi đóng cửa sổ Server/Client, lịch sử trò chơi được tự động đẩy lên [ctxt.io](https://ctxt.io) để lưu trữ và chia sẻ.
- **Tự khởi động lại vòng chờ:** Sau khi kết thúc game (đủ số round), Server tự reset điểm số và trạng thái Ready, quay về chờ người chơi mới sẵn sàng cho ván tiếp theo — không cần khởi động lại Server.

### Phía Client
- **Giao diện tương tác:** Cho phép nhập tên người chơi, số dự đoán và hiển thị log thông báo real-time từ Server (Vòng mới, người thắng, dải số hiện tại...).
- **Cơ chế Cooldown (Chống Spam):** Giới hạn thời gian giữa 2 lần gửi kết quả tối thiểu là **3 giây**. Có đồng hồ đếm ngược (Countdown timer) hiển thị trực tiếp trên giao diện.
- **Tính năng Auto-Play (Bot):** Tự động sinh số ngẫu nhiên thông minh:
  - Sinh số nằm trong phạm vi yêu cầu của Server.
  - Loại trừ các số đã đoán trước đó.
  - Tự động đếm ngược và gửi kết quả.
- **Lưu lịch sử Local:** Tự động xuất toàn bộ lịch sử thông báo ra file `history.txt` và tự động đóng ứng dụng khi Server tuyên bố kết thúc trò chơi.

---

## 🌟 Tính năng mở rộng (Nâng cao)

Dự án đã được tích hợp thêm các tính năng nâng cao sau nhằm tăng tính cạnh tranh:
- 🏆 **Vinh danh chung cuộc:** Sau khi hoàn thành tất cả các vòng, hệ thống sẽ phân tích và tìm ra nhà vô địch dựa trên tiêu chí:
  1. Số lượt trả lời đúng nhiều nhất.
  2. Nếu hòa, người có tổng số lần dự đoán sai ít nhất sẽ thắng.
- 💯 **Hệ thống tính điểm (Scoring System):**
  - Cộng điểm (+X) cho mỗi lần đoán trúng và nhanh nhất.
  - Trừ điểm (-Y) cho mỗi lần đoán sai.
  - Bảng xếp hạng điểm số (Leaderboard) được cập nhật liên tục.

---

## 📸 Giao diện ứng dụng
*(Bạn có thể thay thế các link ảnh dưới đây bằng ảnh chụp màn hình thực tế của ứng dụng)*

| Giao diện Server | Giao diện Client |
| :---: | :---: |
| <img src="https://via.placeholder.com/400x250.png?text=Server+GUI" alt="Server UI" width="100%"> | <img src="https://via.placeholder.com/400x250.png?text=Client+GUI" alt="Client UI" width="100%"> |
| *Hiển thị Log, trạng thái, người chơi online* | *Nhập số, đồng hồ cooldown 3s, Auto-play* |

---

## 🔄 Luồng trò chơi (Gameplay Flow)

1. **Khởi động:** Bật Server -> Bật các Clients và kết nối (nhập tên).
2. **Vào trận:** Server sinh số $x$ trong khoảng $(a, b)$ và broadcast dải số cho mọi người.
3. **Cạnh tranh:** Clients thi nhau đoán. Đồng hồ cooldown 3s kích hoạt sau mỗi lần gửi.
4. **Kết quả vòng:** Client nào đúng và nhanh nhất -> Thắng vòng. Cộng điểm/Trừ điểm.
5. **Lặp lại:** Server reset dải số mới và bắt đầu vòng tiếp theo.
6. **Kết thúc:** Đạt số vòng tối đa -> Server chốt sổ -> Đăng kết quả lên web -> Client lưu `history.txt` -> Tự động thoát.

---

## 🛠 Cài đặt và Chạy ứng dụng

### Yêu cầu hệ thống
- **Windows** (ứng dụng WinForms, không chạy được trên Linux/macOS)
- **.NET Framework 4.7.2** trở lên
- **Visual Studio 2019/2022** (khuyến nghị, để mở file `Lab06.sln`)
- Mạng LAN hoặc `localhost` để test nhiều client cùng lúc

### Hướng dẫn khởi chạy

1. Clone repository này về máy:
   ```bash
   git clone https://github.com/nguyentrungduc-cyber/Multiplayer_Guess_Number.git
   ```

2. Mở file `Lab06.sln` bằng Visual Studio.

3. Restore NuGet packages nếu được yêu cầu (chuột phải vào Solution → **Restore NuGet Packages**).

4. Build project (Ctrl+Shift+B), đảm bảo không có lỗi compile.

5. Chạy thử với nhiều "người chơi" trên cùng 1 máy:
   - F5 để chạy 1 instance đầu tiên → bấm **"Tạo Game"** để làm Server (nhập port, VD: `5000`).
   - Vào thư mục `bin/Debug`, chạy trực tiếp file `Lab06.exe` thêm nhiều lần (mỗi lần là 1 "Client" riêng) → bấm **"Tham Gia"**, nhập IP `localhost` và đúng port vừa tạo.
   - Bấm **"Sẵn sàng"** ở các client để bắt đầu round chơi.

6. Để test qua mạng LAN thật (nhiều máy khác nhau): máy chủ chạy Server, các máy khác nhập đúng địa chỉ IP LAN của máy chủ (kiểm tra bằng `ipconfig`) thay vì `localhost`.

---

## 🧪 Kiểm thử (Testing)

Tài liệu này mô tả lộ trình kiểm thử thủ công cho ứng dụng, từ các luồng cơ bản (happy path), các case bám sát những lỗi logic đã được fix, đến test biên và stress test.

---

### Giai đoạn 0 — Chuẩn bị

- Build lại project trên Visual Studio (Debug config) để bắt lỗi compile trước khi test.
- Chạy nhiều instance `Lab06.exe` cùng lúc trên 1 máy (giả lập nhiều người chơi qua `localhost`), rồi test lại qua LAN thật (2-3 máy) nếu có điều kiện.
- Chuẩn bị ít nhất **4 người chơi + 1 Server** để test được các case đông người.

---

### Giai đoạn 1 — Test cơ bản (Happy path)

| # | Kịch bản | Kết quả mong đợi |
|---|---|---|
| 1.1 | Tạo Server với port hợp lệ (VD: `5000`) | Hiện "Tạo game mới thành công", tự động join với tên "Server" |
| 1.2 | Client nhập đúng IP/Port join vào | Nhận đúng username, thấy số người chơi tăng |
| 1.3 | 2-3 client cùng bấm "Sẵn sàng" | Server broadcast "Hiện có N người chơi", round 1 bắt đầu sau 5s |
| 1.4 | Nhập số đúng trong khoảng cho phép | +10 điểm, thông báo "đã tìm thấy người chơi chiến thắng" |
| 1.5 | Nhập số sai | -1 điểm, thông báo "đoán sai" |
| 1.6 | Hết giờ không ai đoán đúng | Thông báo "Không ai có đáp án chính xác", hiện đáp án đúng |
| 1.7 | Chơi hết số round | Hiện bảng điểm cao nhất, quay về trạng thái chờ Ready |
| 1.8 | Gửi tin nhắn chat | Mọi người trong phòng nhận được đúng nội dung |
| 1.9 | Chức năng Auto-play (1 lượt / cả game) | Tự động chọn số hợp lệ chưa dùng, không lặp lại số cũ |
| 1.10 | Đóng app → xem file `History_<tên>.txt` | Lịch sử chat được lưu đúng, đúng định dạng thời gian |

---

### Giai đoạn 2 — Test theo đúng các lỗi đã fix (quan trọng nhất)

### 🔴 NullReferenceException khi Accept lỗi
- **Test:** Server đang chạy, dùng công cụ (VD: `netcat`/`telnet`) mở rồi ngắt kết nối TCP đột ngột nhiều lần liên tục tới port server trước khi handshake hoàn tất.
- **Kỳ vọng:** Server **không crash**, tiếp tục accept các kết nối hợp lệ tiếp theo bình thường.

### 🔴 readyCheck() restart round giữa chừng
- **Test:** 3 người chơi Ready, vào round 1, đang giữa round → 1 trong 3 người **thoát app đột ngột** (giữa lúc game đang diễn ra).
- **Kỳ vọng:** Round hiện tại **không bị restart**, vẫn tiếp tục đếm giờ như bình thường cho 2 người còn lại. Kiểm tra kỹ log/chat xem có bị nhân đôi round hay không.

### 🔴 Race condition Dictionary (scoreBoard/readyPlayers)
- **Test:** Dùng ≥5 client, cho **tất cả cùng bấm "Sẵn sàng" gần như đồng thời**.
- **Kỳ vọng:** Không có Exception phía Server, tất cả người chơi đều được ghi nhận Ready đúng.
- **Test thêm:** Nhiều client cùng gửi đáp án đúng/sai trong cùng 1 khoảnh khắc (auto-play toàn bộ 5+ client cùng lúc) → điểm cộng/trừ phải chính xác, không bị mất update.

### 🔴 Input không hợp lệ
- **Test:** Gõ chữ cái (`abc`), ký tự đặc biệt, để trống, rồi bấm Submit hoặc Enter.
- **Kỳ vọng:** Hiện MessageBox "Vui lòng nhập một con số hợp lệ", **không crash** app.

### 🔴 TCP framing (message bị cắt)
- **Test:** Gửi tin nhắn chat **rất dài** (vượt 1024 byte buffer, VD: 2000 ký tự) → kiểm tra tin nhắn hiển thị đầy đủ, không bị cắt/lỗi ký tự phía người nhận.
- **Test:** Chạy qua mạng WiFi kém ổn định hoặc dùng công cụ giả lập độ trễ mạng (Clumsy, NetLimiter) trong lúc chơi nhiều round liên tục → không thấy lỗi parse/crash bất thường.

### 🔴 HTML Injection
- **Test:** Trong khung chat, gõ một tin nhắn chứa thẻ HTML, ví dụ:
  ```
  <script>alert('test')</script> hoặc <b>bold</b><img src=x>
  ```
- **Kỳ vọng:** Khi đóng game và mở trang lưu lịch sử (`ctxt.io`), nội dung phải hiển thị **nguyên văn dạng text** (thấy cả dấu `<`, `>`), không bị hiểu thành thẻ HTML thật, không phá layout trang, không có popup/script chạy.

---

### Giai đoạn 3 — Test biên & trường hợp bất thường

| # | Kịch bản | Kỳ vọng |
|---|---|---|
| 3.1 | Join với tên trùng người đã có trong phòng | Bị từ chối, không crash |
| 3.2 | Nhập IP/Port sai định dạng khi join | Hiện "Sai địa chỉ IP!" |
| 3.3 | Join khi game đang diễn ra | Hiện "Trò chơi đã bắt đầu, không thể vào!" |
| 3.4 | Tất cả người chơi thoát hết khi đang giữa game | Server tự reset về trạng thái chờ, không đơ |
| 3.5 | Đóng Server (form `indexForm`) khi đang diễn ra game | Bị chặn đóng, hiện "Chờ game hiện tại kết thúc" |
| 3.6 | Chạy 2 Server trên cùng 1 port | Hiện lỗi port chi tiết, nút "Tạo Game" bật lại được để thử port khác |
| 3.7 | Client rời phòng rồi join lại ngay với tên khác | Vào lại bình thường, số người chơi cập nhật đúng |

---

### Giai đoạn 4 — Stress test (tùy chọn, nếu có thời gian)

- Cho 8-10 client cùng vào 1 phòng, chơi full game — theo dõi CPU/memory server có tăng bất thường không (kiểm tra leak thread do các thread xử lý client không được join/dispose).
- Lặp lại 1 ván chơi (start → end → start lại) **10 lần liên tiếp** không restart app → đảm bảo state (điểm số, danh sách sẵn sàng, số round) reset sạch mỗi lần, không bị "rác" từ ván trước.

---

### ✅ Checklist tổng hợp nhanh

- [ ] Build không lỗi compile
- [ ] Happy path (Giai đoạn 1) — 10 case
- [ ] Case bug đã fix (Giai đoạn 2) — 6 case
- [ ] Test biên (Giai đoạn 3) — 7 case
- [ ] Stress test (Giai đoạn 4, tùy chọn)


