using EduHub.Ch01.Domain;

// ═══════════════════════════════════════════════════════════════
//  EduHub Ch01 — Console demo (luồng nghiệp vụ đầy đủ)
//  Dùng hằng số cho separator, KHÔNG hardcode chuỗi lặp lại.
// ═══════════════════════════════════════════════════════════════
const string Separator = "--------------------------------------------------";
Console.WriteLine("=== EduHub — Club & Event Management ===");
Console.WriteLine(Separator);
// TODO 1: Tạo CLB "Tech Club" với mô tả phù hợp         → Club.Create(...)
var techClub = Club.Create("Tech Club", "Câu lạc bộ công nghệ thông tin dành cho sinh viên đam mê lập trình và AI.");
Console.WriteLine($"Đã tạo CLB: {techClub.Name} - Mô tả: {techClub.Description}");
Console.WriteLine(Separator);
// TODO 2: Tạo 3 Member, thêm vào CLB                      → Member.Create(...), club.AddMember(...)
var member1 = Member.Create("Nguyễn Văn An", "an.nv@edu.vn", "B21DCCN001");
var member2 = Member.Create("Trần Thị Bình", "binh.tt@edu.vn", "B21DCCN002");
var member3 = Member.Create("Lê Hoàng Cường", "cuong.lh@edu.vn", "B21DCCN003");

techClub.AddMember(member1);
techClub.AddMember(member2);
techClub.AddMember(member3);

Console.WriteLine($"Danh sách thành viên của CLB ({techClub.MemberCount()} thành viên):");
foreach (var member in techClub.Members)
{
    Console.WriteLine($"- {member}");
}
Console.WriteLine(Separator);
// TODO 3: Tạo sự kiện "Workshop AI", capacity = 50        → Event.Create(club.Id, ...)
var aiEvent = Event.Create(techClub.Id, "Workshop AI", DateTime.UtcNow.AddDays(7), 50, isOnline: true);
Console.WriteLine($"Đã tạo sự kiện: {aiEvent.Title} (Sức chứa: {aiEvent.Capacity}) vào lúc {aiEvent.Date:dd/MM/yyyy}");
Console.WriteLine(Separator);
// TODO 4: 2 Member đăng ký (kiểm tra HasCapacity) → Pending → gọi Confirm()
List<Registration> registrations = new();

if (aiEvent.HasCapacity(registrations.Count))
{
    var reg1 = Registration.Create(member1.Id, aiEvent.Id);
    reg1.Confirm(); // Chuyển từ Pending sang Confirmed
    registrations.Add(reg1);
    Console.WriteLine($"Thành viên {member1.Name} đã đăng ký và được xác nhận thành công.");
}

if (aiEvent.HasCapacity(registrations.Count))
{
    var reg2 = Registration.Create(member2.Id, aiEvent.Id);
    reg2.Confirm(); // Chuyển từ Pending sang Confirmed
    registrations.Add(reg2);
    Console.WriteLine($"Thành viên {member2.Name} đã đăng ký và được xác nhận thành công.");
}
Console.WriteLine(Separator);
// TODO 5: 1 Member check-in                               → CheckIn.Create(registration, ...)
var regOfMember1 = registrations.First(r => r.MemberId == member1.Id);
var checkIn1 = CheckIn.Create(regOfMember1, "QrCode");
Console.WriteLine(checkIn1.Summary());
Console.WriteLine(Separator);
// TODO 6: In báo cáo tham dự: số đăng ký, số check-in, danh sách tên
Console.WriteLine("=== BÁO CÁO THAM DỰ SỰ KIỆN ===");
Console.WriteLine($"Tổng số lượt đăng ký: {registrations.Count}");
Console.WriteLine($"Tổng số lượt check-in: 1");
Console.WriteLine("Danh sách thành viên tham gia đã check-in:");
Console.WriteLine($"- {member1}");

Console.WriteLine(Separator);
Console.WriteLine("\n✅ Demo complete!");
