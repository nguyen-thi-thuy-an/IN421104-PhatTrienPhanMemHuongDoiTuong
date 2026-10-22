namespace EduHub.Ch01.Domain;

/// <summary>Phiếu đăng ký của Member cho Event (bảng nối M:N).</summary>
public class Registration
{
    // TODO: Guid Id, Guid MemberId, Guid EventId, DateTime RegisteredAt, string Status (private set)
    // TODO: hằng số cho Status: "Pending" / "Confirmed" / "Cancelled" (static class hoặc const) — không dùng magic string
    public static class Statuses
    {
        public const string Pending = "Pending";
        public const string Confirmed = "Confirmed";
        public const string Cancelled = "Cancelled";
    }

    public Guid Id { get; private set; }
    public Guid MemberId { get; private set; }
    public Guid EventId { get; private set; }
    public DateTime RegisteredAt { get; private set; }
    public string Status { get; private set; }
    // TODO: constructor PRIVATE + public static Registration Create(Guid memberId, Guid eventId)
    //       → Status khởi tạo = Pending
    private Registration(Guid memberId, Guid eventId)
    {
        Id = Guid.NewGuid();
        MemberId = memberId;
        EventId = eventId;
        RegisteredAt = DateTime.UtcNow;
        Status = Statuses.Pending;
    }

    public static Registration Create(Guid memberId, Guid eventId)
    {
        if (memberId == Guid.Empty)
            throw new ArgumentException("MemberId không hợp lệ.", nameof(memberId));
        if (eventId == Guid.Empty)
            throw new ArgumentException("EventId không hợp lệ.", nameof(eventId));

        return new Registration(memberId, eventId);
    }
    // TODO: public void Confirm() — chỉ hợp lệ khi Pending, sai thì throw InvalidOperationException
   public void Confirm()
    {
        if (Status != Statuses.Pending)
            throw new InvalidOperationException("Chỉ có thể xác nhận đăng ký khi trạng thái đang là Pending.");

        Status = Statuses.Confirmed;
    }
    // TODO: public void Cancel()  — hợp lệ khi Pending/Confirmed; đã Cancelled thì throw
    public void Cancel()
    {
        if (Status == Statuses.Cancelled)
            throw new InvalidOperationException("Đăng ký này đã bị hủy trước đó.");

        Status = Statuses.Cancelled;
    }
}
