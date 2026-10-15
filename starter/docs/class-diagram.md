# Sơ đồ lớp sơ bộ — EduHub

Vẽ bằng Mermaid (hiển thị trực tiếp trên GitHub) hoặc xuất ảnh từ draw.io rồi đặt cạnh file này.
Ghi rõ thuộc tính chính, khoá ngoại (FK) và bội số quan hệ (1, *, 0..1).

```mermaid
classDiagram
    class Member {
        +Id 
        + Name 
        + Email
        +StudentCode
        +JoinedAt
        + Status 
        +Create() 
        +IsActive()
        +Deactivate()
    }
    class Event {
        +Id 
        +ClubId (FK)
        +Title 
        +Date
        +Capacity
        +IsOnline
        +HasCapacity()
    }
    class Club {
        +Id 
        +Name
        +Description
        +CreatedAt
        +Members
        +AddMember()
        +MemberCount()
    }
    
  class Registration {
        +Id 
        +MemberId (FK)
        +EventId (FK)
        +RegisteredAt
        +Status
        +Confirm()
        +Cancel()
    }
    
  class CheckIn {
        +Id 
        +RegistrationId (FK)
        +CheckedInAt 
        +Method
        +Create()
        +Summary()
        
    }
    
  
    Club "1" --> "*" Event : tổ chức
    Member "*" -- "*" Club : tham gia
    Member "1" --> "*" Registration : đăng ký
    Event "1" --> "*" Registration : có
    Registration "1" --> "0..1" CheckIn : điểm danh
    %% TODO: bổ sung Member, Registration, CheckIn, đủ thuộc tính, phương thức và các quan hệ còn lại
```
