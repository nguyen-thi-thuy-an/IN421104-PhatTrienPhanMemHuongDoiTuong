using EduHub.Ch02.Domain;
using EduHub.Ch02.Logging;
using EduHub.Ch02.Notifications;
using EduHub.Ch02.Repositories;

namespace EduHub.Ch02.Services;

public class ClubService
{
    private readonly IClubRepository _clubRepository;
    private readonly List<Member> _members = new();
    private readonly IAppLogger _logger;
    private readonly INotificationServiceFactory _notificationFactory;

    public ClubService(
        IClubRepository clubRepository, 
        IAppLogger logger, 
        INotificationServiceFactory notificationFactory)
    {
        _clubRepository = clubRepository;
        _logger = logger;
        _notificationFactory = notificationFactory;
    }

    public Club CreateClub(string name, string description, string presidentEmail, NotificationChannel channel)
    {
        // Gọi logic validate và khởi tạo từ Domain Model (Club)
        var club = Club.Create(name, description);
        _clubRepository.Add(club);

        var notifier = _notificationFactory.Create(channel);
        notifier.Send(presidentEmail, $"You are the president of the new club: {name}");

        return club;
    }

    public void AddMemberToClub(Guid clubId, string memberName, string email, NotificationChannel channel)
    {
        var club = _clubRepository.GetById(clubId)
            ?? throw new InvalidOperationException("Club not found");

        var currentMemberCount = _members.Count(m => m.ClubId == clubId);
        if (!club.HasRoom(currentMemberCount))
            throw new InvalidOperationException($"Club is full (max {Club.MaxMembers} members)");

        var member = new Member { Id = Guid.NewGuid(), Name = memberName, Email = email, ClubId = clubId };
        _members.Add(member);

        _logger.Log($"Member {memberName} joined {club.Name}");

        var notifier = _notificationFactory.Create(channel);
        notifier.Send(email, $"Welcome to {club.Name}!");
    }

    public List<Club> GetAllClubs() => _clubRepository.GetAll();
    public List<Member> GetMembers() => _members;
}