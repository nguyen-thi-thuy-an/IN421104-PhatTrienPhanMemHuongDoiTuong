using EduHub.Ch02;
using EduHub.Ch02.Domain;

namespace Ch02.Refactor.Tests;

public class DomainTests
{
    // Test 1: Tạo câu lạc bộ với tên rỗng
    [Fact]
    public void CreateClub_WithEmptyName_ThrowsArgumentException()
    {
        // Arrange
        var manager = new ClubManager();

        // Act
        var act = () => manager.CreateClub("", "mô tả", "p@gmail.com");

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    // Test 2: Tạo câu lạc bộ với tên hợp lệ
    [Fact]
    public void Club_Create_WithValidName_ReturnsClub()
    {
        // Arrange
        string name = "Tech Club";
        string description = "Câu lạc bộ công nghệ";

        // Act
        var club = Club.Create(name, description);

        // Assert
        Assert.NotNull(club);
        Assert.Equal(name, club.Name);
    }

    // Test 3: Tên câu lạc bộ không hợp lệ
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Club_Create_WithInvalidName_ThrowsArgumentException(string name)
    {
        // Arrange
        string description = "Mô tả câu lạc bộ";

        // Act
        var act = () => Club.Create(name, description);

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    // Test 4: Câu lạc bộ đã đạt giới hạn thành viên
    [Fact]
    public void Club_HasRoom_AtMaxMembers_ReturnsFalse()
    {
        // Arrange
        var club = Club.Create("Tech Club", "Mô tả");

        // Act
        bool result = club.HasRoom(50);

        // Assert
        Assert.False(result);
    }

    // Test 5: Đăng ký thành viên mới vào sự kiện
    [Fact]
    public void Event_Register_NewMember_ReturnsTrue()
    {
        // Arrange
        var ev = new Event
        {
            Title = "Hội thảo công nghệ",
            Date = DateTime.Now
        };
        var memberId = Guid.NewGuid();

        // Act
        bool result = ev.Register(memberId);

        // Assert
        Assert.True(result);
        Assert.Contains(memberId, ev.RegisteredMemberIds);
    }

    // Test 6: Đăng ký cùng một thành viên hai lần
    [Fact]
    public void Event_Register_SameMemberTwice_ReturnsFalse()
    {
        // Arrange
        var ev = new Event
        {
            Title = "Hội thảo công nghệ",
            Date = DateTime.Now
        };
        var memberId = Guid.NewGuid();

        // Act
        ev.Register(memberId);
        bool result = ev.Register(memberId);

        // Assert
        Assert.False(result);
    }

    // Test 7: Check-in khi chưa đăng ký
    [Fact]
    public void Event_CheckIn_UnregisteredMember_ThrowsInvalidOperationException()
    {
        // Arrange
        var ev = new Event
        {
            Title = "Hội thảo công nghệ",
            Date = DateTime.Now
        };
        var memberId = Guid.NewGuid();

        // Act
        var act = () => ev.CheckIn(memberId);

        // Assert
        Assert.Throws<InvalidOperationException>(act);
    }
}