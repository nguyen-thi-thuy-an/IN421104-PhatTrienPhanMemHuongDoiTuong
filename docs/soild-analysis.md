# Phân tích vi phạm SOLID trong ClubManager (God Class)

## 1. Single Responsibility Principle (Nguyên tắc Trách nhiệm Đơn - SRP)
Vị trí vi phạm: Các phương thức `CreateClub`, `AddMemberToClub`, `CreateEvent`, `PrintClubReport`.
Nguyên tắc: Một class chỉ nên có một lý do duy nhất để thay đổi, nghĩa là nó chỉ đảm nhận một trách nhiệm cốt lõi.
Hậu quả: `ClubManager` đang ôm đồm quá nhiều việc: kiểm tra logic nghiệp vụ (validation), quản lý trạng thái bộ nhớ, thao tác ghi tệp trực tiếp (file I/O), định dạng thông báo console và sinh báo cáo. Bất kỳ thay đổi nào về định dạng log, cách gửi thông báo hay cấu trúc báo cáo đều buộc phải sửa đổi trực tiếp class quản lý nghiệp vụ này.

## 2. Open/Closed Principle (Nguyên tắc Đóng/Mở - OCP)
Vị trí vi phạm: Các khối `if/else` kiểm tra loại email trong `CreateClub` và việc in thông báo cứng trong `AddMemberToClub`.
Nguyên tắc: Các thực thể phần mềm phải mở để mở rộng nhưng đóng để sửa đổi.
Hậu quả: Khi muốn thêm một kênh thông báo mới (ví dụ: SMS, Push Notification), nhà phát triển phải sửa đổi trực tiếp code bên trong các phương thức hiện có, làm tăng nguy cơ phát sinh lỗi (regression) ở những phần code đang chạy ổn định.

## 3. Dependency Inversion Principle (Nguyên tắc Đảo phụ thuộc - DIP)
Vị trí vi phạm: Gọi trực tiếp `File.AppendAllText(_logFilePath, ...)` ở tất cả các phương thức.
Nguyên tắc: Các module cấp cao không được phụ thuộc vào module cấp thấp; cả hai phải phụ thuộc vàoabstraction (interface).
Hậu quả: Logic nghiệp vụ bị gắn chặt (tight coupling) với tầng lưu trữ tệp vật lý cụ thể. Việc này làm cho việc viết Unit Test trở nên rất khó khăn vì test bắt buộc phải thao tác với ổ đĩa thực, đồng thời ngăn cản việc thay đổi cơ chế ghi log (ví dụ đổi sang Database hoặc Cloud Logger).

## 4. Interface Segregation Principle & High Coupling (Nguyên tắc Phân tách Giao diện - ISP)
Vị trí vi phạm: Thiếu các giao diện (interface) trung gian cho kho dữ liệu (repository) và các dịch vụ.
Nguyên tắc: Khách hàng (clients) không nên bị ép phải phụ thuộc vào những interface mà họ không dùng đến.
Hậu quả: Các đoạn code gọi tới bị phụ thuộc vào một class quản lý nguyên khối thay vì các hợp đồng dịch vụ tinh gọn, chuyên biệt.