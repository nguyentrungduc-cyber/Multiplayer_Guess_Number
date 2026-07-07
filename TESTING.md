# 🧪 Lộ trình Test — Multiplayer Guess Number

![Status](https://img.shields.io/badge/type-Manual%20Testing-blue?style=flat-square)

Tài liệu này mô tả lộ trình kiểm thử thủ công cho ứng dụng, từ các luồng cơ bản (happy path), các case bám sát những lỗi logic đã được fix, đến test biên và stress test.

---

## Giai đoạn 0 — Chuẩn bị

- Build lại project trên Visual Studio (Debug config) để bắt lỗi compile trước khi test.
- Chạy nhiều instance `Lab06.exe` cùng lúc trên 1 máy (giả lập nhiều người chơi qua `localhost`), rồi test lại qua LAN thật (2-3 máy) nếu có điều kiện.
- Chuẩn bị ít nhất **4 người chơi + 1 Server** để test được các case đông người.

---

## Giai đoạn 1 — Test cơ bản (Happy path)

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

## Giai đoạn 2 — Test theo đúng các lỗi đã fix (quan trọng nhất)

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

## Giai đoạn 3 — Test biên & trường hợp bất thường

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

## Giai đoạn 4 — Stress test (tùy chọn, nếu có thời gian)

- Cho 8-10 client cùng vào 1 phòng, chơi full game — theo dõi CPU/memory server có tăng bất thường không (kiểm tra leak thread do các thread xử lý client không được join/dispose).
- Lặp lại 1 ván chơi (start → end → start lại) **10 lần liên tiếp** không restart app → đảm bảo state (điểm số, danh sách sẵn sàng, số round) reset sạch mỗi lần, không bị "rác" từ ván trước.

---

## ✅ Checklist tổng hợp nhanh

- [ ] Build không lỗi compile
- [ ] Happy path (Giai đoạn 1) — 10 case
- [ ] Case bug đã fix (Giai đoạn 2) — 6 case
- [ ] Test biên (Giai đoạn 3) — 7 case
- [ ] Stress test (Giai đoạn 4, tùy chọn)
