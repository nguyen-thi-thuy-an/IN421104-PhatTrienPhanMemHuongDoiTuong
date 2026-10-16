namespace EduHub.Ch01.Domain;

/// <summary>Ghi nhận sự hiện diện thực tế của một Registration (quan hệ 1–1).</summary>
public class CheckIn
{
    // TODO: Guid Id, Guid RegistrationId, DateTime CheckedInAt, string Method ("Manual" hoặc "QrCode") (private set)
    public Guid Id { get; private set; }
    public Guid RegistrationId { get; private set; }
    public DateTime CheckedInAt { get; private set; }
    public string Method { get; private set; }
    // TODO: constructor PRIVATE + public static CheckIn Create(Registration registration, string method)
    //       → chỉ cho phép khi registration.Status == Confirmed
    private CheckIn(Guid registrationId, string method)
    {
        Id = Guid.NewGuid();
        RegistrationId = registrationId;
        CheckedInAt = DateTime.UtcNow;
        Method = method;
    }

    public static CheckIn Create(Registration registration, string method)
    {
        if (registration == null)
            throw new ArgumentNullException(nameof(registration));

        if (registration.Status != RegistrationStatus.Confirmed)
            throw new InvalidOperationException("Chỉ cho phép check-in khi đăng ký đã được xác nhận (Confirmed).");

        if (string.IsNullOrWhiteSpace(method) || (method != "Manual" && method != "QrCode"))
            throw new ArgumentException("Phương thức check-in phải là 'Manual' hoặc 'QrCode'.", nameof(method));

        return new CheckIn(registration.Id, method);
    }
    // TODO: public string Summary() — chuỗi mô tả để in báo cáo
    public string Summary()
    {
        return $"CheckIn [{Id}] - Registration: {RegistrationId} - Time: {CheckedInAt:dd/MM/yyyy HH:mm:ss} - Method: {Method}";
    }
}
