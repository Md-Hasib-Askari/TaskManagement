using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

public class User : BaseEntity, IAuditableEntity
{
    [Required]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format")]
    public string Email { get; private set; } = null!;
    [Required]
    [MinLength(8)]
    public string PasswordHash { get; private set; } = null!;
    [Required]
    [MaxLength(50)]
    [MinLength(2)]
    public string FirstName { get; private set; } = null!;
    [Required]
    [MaxLength(50)]
    public string LastName { get; private set; } = null!;
    [Required]
    public bool IsActive { get; private set; }

    public Guid UserRoleId { get; private set; }

    // Navigation Properties
    [ForeignKey(nameof(UserRoleId))]
    public UserRole UserRole { get; private set; } = null!;

    // Audit
    public DateTime CreatedAt { get; private set; }
    public string? CreatedBy { get; private set; }
    public DateTime? LastModifiedAt { get; private set; }
    public string? LastModifiedBy { get; private set; }

    // Behavioral Methods
    [MemberNotNull(nameof(FirstName), nameof(LastName))]
    public void SetName(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new DomainException("First name is required");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new DomainException("Last name is required");

        FirstName = firstName;
        LastName = lastName;
    }

    [MemberNotNull(nameof(PasswordHash))]

    public void SetPasswordHash(string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new DomainException("Password hash is required");

        PasswordHash = passwordHash;
    }

    public void Deactivate()
    {
        if (!IsActive) return;
        IsActive = false;
    }

    public void Activate()
    {
        if (IsActive) return;
        IsActive = true;
    }
}
