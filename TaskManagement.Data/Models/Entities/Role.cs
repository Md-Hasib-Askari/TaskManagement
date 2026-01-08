using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Role : BaseEntity, IAuditableEntity
{
    [Required]
    [MaxLength(100)]
    public string Name { get; private set; } = null!;
    [MaxLength(250)]
    public string Description { get; private set; }

    public Guid UserRoleId { get; private set; }

    // Navigation Properties
    [ForeignKey(nameof(UserRoleId))]
    public UserRole UserRole { get; private set; } = null!;

    // Audit
    public DateTime CreatedAt { get; private set; }

    public string? CreatedBy { get; private set; }

    public DateTime? LastModifiedAt { get; private set; }
    public string? LastModifiedBy { get; private set; }

    // EF Core only
    private Role()
    {
        Name = null!;
        Description = null!;
    }

    public Role(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Role name is required");

        Name = name;
        Description = description;
        // CreatedAt = DateTime.UtcNow;
    }
}