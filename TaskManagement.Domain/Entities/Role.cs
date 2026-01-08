public class Role : BaseEntity
{
    public required string Name { get; set; }

    // Navigation Properties
    public ICollection<User> Users { get; set; } = new List<User>();
}