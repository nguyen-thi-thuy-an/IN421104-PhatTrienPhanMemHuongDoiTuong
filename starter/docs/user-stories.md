# User Stories — EduHub

Viết ít nhất 5 User Story, đủ 3 vai trò (Sinh viên, Ban CLB, Admin).
Mỗi story có ít nhất 2 tiêu chí nghiệm thu (Given/When/Then hoặc gạch đầu dòng).

## US-01 · Sinh viên: Đánh giá và phản hồi sau sự kiện
Là Sinh viên, tôi muốn gửi đánh giá (1-5 sao) và nhận xét sau khi tham gia sự kiện, để đóng góp ý kiến giúp Ban CLB nâng cao chất lượng các chương trình tiếp theo.
- Tiêu chí 1: Given sinh viên đã có CheckIn thành công tại sự kiện, When gửi đánh giá với số sao từ 1 đến 5 và lời nhắn, Then hệ thống lưu đánh giá thành công.
- Tiêu chí 2: Given sinh viên chưa điểm danh hoặc sự kiện chưa diễn ra, When cố gắng gửi đánh giá, Then hệ thống báo lỗi không cho phép.

## US-02 · Sinh viên: Hủy phiếu đăng ký sự kiện
Là Sinh viên, tôi muốn hủy phiếu đăng ký sự kiện khi bận lịch đột xuất, để giải phóng suất tham dự cho các sinh viên khác.
- Tiêu chí 1: Given phiếu đăng ký đang ở trạng thái Pending hoặc Confirmed và chưa đến giờ sự kiện, When sinh viên bấm hủy đăng ký, Then trạng thái chuyển thành Cancelled và tăng chỗ trống khả dụng của sự kiện.
- Tiêu chí 2: Given sự kiện đã bắt đầu hoặc đã kết thúc, When sinh viên bấm hủy, Then hệ thống từ chối yêu cầu và giữ nguyên trạng thái.

## US-03 · Sinh viên: Đăng ký danh sách chờ (Waitlist)
Là Sinh viên, tôi muốn đăng ký vào danh sách chờ khi sự kiện đã hết chỗ, để có cơ hội nhận vé tự động nếu có người khác hủy.
- Tiêu chí 1: Given sự kiện đã hết chỗ (Capacity = 0), When sinh viên bấm đăng ký chờ, Then phiếu được tạo ở trạng thái Waitlist kèm số thứ tự ưu tiên.
- Tiêu chí 2: Given một sinh viên khác hủy vé thành công, When hệ thống duyệt danh sách chờ, Then người đầu tiên trong Waitlist được tự động chuyển sang Pending.

## US-04 · Sinh viên: Tải chứng nhận tham gia sự kiện
Là Sinh viên, tôi muốn tải file chứng nhận (Certificate) điện tử, để minh chứng tích lũy điểm rèn luyện cá nhân.
- Tiêu chí 1: Given sinh viên đã check-in và sự kiện đã kết thúc, When sinh viên vào trang cá nhân bấm tải chứng nhận, Then hệ thống xuất file PDF chứa tên sinh viên và mã sự kiện.
- Tiêu chí 2: Given sinh viên vắng mặt (chưa check-in), When bấm nhận chứng nhận, Then hệ thống từ chối và thông báo không đủ điều kiện.

## US-05 · Ban CLB: Cập nhật địa điểm và thời gian sự kiện
Là Ban CLB, tôi muốn chỉnh sửa lại thời gian hoặc địa điểm tổ chức sự kiện, để cập nhật kịp thời khi có thay đổi từ Ban giám hiệu.
- Tiêu chí 1: Given sự kiện ở trạng thái sắp diễn ra, When Ban CLB cập nhật thời gian/địa điểm hợp lệ, Then hệ thống lưu thông tin mới và chuyển trạng thái thông báo cho người tham ký.
- Tiêu chí 2: Given thời gian mới nằm trong quá khứ hoặc địa điểm để trống, When nhấn lưu, Then hệ thống báo lỗi validation và giữ nguyên dữ liệu cũ.

## US-06 · Ban CLB: Duyệt yêu cầu gia nhập CLB
Là Ban CLB, tôi muốn duyệt hoặc từ chối đơn xin vào CLB của sinh viên, để đảm bảo thành viên mới phù hợp với định hướng hoạt động.
- Tiêu chí 1: Given sinh viên gửi đơn đăng ký gia nhập CLB, When Ban CLB nhấn chấp thuận, Then sinh viên được chuyển thành thành viên chính thức.
- Tiêu chí 2: Given đơn đăng ký gia nhập, When Ban CLB nhấn từ chối kèm lý do, Then đơn chuyển sang trạng thái Rejected.

## US-07 · Ban CLB: Phân công ban tổ chức cho sự kiện
Là Ban CLB, tôi muốn gán vai trò Ban tổ chức sự kiện cho các thành viên trong CLB, để phân công trách nhiệm quản lý điểm danh và hỗ trợ.
- Tiêu chí 1: Given sinh viên đã là thành viên chính thức của CLB, When Ban CLB thêm người đó vào danh sách Ban tổ chức sự kiện, Then tài khoản đó nhận được quyền quét mã check-in.
- Tiêu chí 2: Given người được chọn chưa gia nhập CLB, When thực hiện phân công, Then hệ thống ngăn chặn và thông báo yêu cầu gia nhập CLB trước.

## US-08 · Admin: Phê duyệt thành lập Câu lạc bộ mới
Là Admin, tôi muốn duyệt hồ sơ đề xuất thành lập CLB từ sinh viên, để đảm bảo CLB mới tuân thủ quy định chung của nhà trường.
- Tiêu chí 1: Given hồ sơ thành lập CLB đầy đủ tên, mô tả và sinh viên chủ nhiệm, When Admin chấp thuận, Then CLB được khởi tạo ở trạng thái Active.
- Tiêu chí 2: Given tên CLB bị trùng hoặc thiếu thông tin Chủ nhiệm, When Admin nhấn duyệt, Then hệ thống báo lỗi trùng lặp và chặn thao tác.

## US-09 · Admin: Đóng băng / Tạm ngưng hoạt động CLB
Là Admin, tôi muốn chuyển trạng thái CLB sang Inactive khi vi phạm quy chế, để ngăn chặn CLB tiếp tục tạo sự kiện hay tuyển thành viên.
- Tiêu chí 1: Given CLB đang Active, When Admin thực hiện tạm ngưng, Then CLB chuyển sang Inactive và mọi sự kiện đang chờ duyệt của CLB này bị khóa.
- Tiêu chí 2: Given CLB đang Inactive, When sinh viên tìm cách gửi đơn gia nhập, Then hệ thống hiển thị thông báo CLB đang tạm ngưng.

## US-10 · Admin: Cấu hình hạn mức tạo sự kiện theo học kỳ
Là Admin, tôi muốn thiết lập số lượng sự kiện tối đa mà mỗi CLB được phép tổ chức trong một học kỳ, để quản lý quỹ thời gian và tài nguyên trường.
- Tiêu chí 1: Given Admin đặt hạn mức là N sự kiện/kỳ, When CLB tạo sự kiện thứ N+1 trong cùng kỳ, Then hệ thống tự động từ chối.
- Tiêu chí 2: Given hạn mức nhập vào là số âm hoặc bằng 0, When Admin bấm lưu cấu hình, Then hệ thống báo lỗi tham số không hợp lệ.