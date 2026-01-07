// Id (PK)         │◄───┐    │ Id (PK)          │
// │ Email           │    │    │ Name             │
// │ PasswordHash    │    │    │ Description      │
// │ FirstName       │    │    └──────────────────┘
// │ LastName        │    │             ▲
// │ IsActive        │    │             │
// │ CreatedAt

public class User : BaseEntity
{
    public EmailAddress Email { get; set; }
    public string PasswordHash { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Navigation Properties
    public ICollection<Task> Tasks { get; set; }

    public User()
    {
        Email = null!;
        PasswordHash = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        Tasks = new List<Task>();
    }
}