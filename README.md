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

> 💡 **Ghi chú:** Chụp màn hình thực tế và thay thế vào đây sau khi chạy thử ứng dụng.

| Giao diện Server | Giao diện Client |
| :---: | :---: |
| *(Chưa có ảnh — xem hướng dẫn bên dưới để chạy thử)* | *(Chưa có ảnh — xem hướng dẫn bên dưới để chạy thử)* |
| *Hiển thị Log, trạng thái, người chơi online* | *Nhập số, đồng hồ cooldown 3s, Auto-play* |

<!-- Để thêm ảnh: chụp màn hình → upload lên repo → thay đường dẫn bên dưới
| <img src="docs/server-screenshot.png" alt="Server UI" width="100%"> | <img src="docs/client-screenshot.png" alt="Client UI" width="100%"> |
-->

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



