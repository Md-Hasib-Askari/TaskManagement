public class RoleRepository : IGenericRepository<Role>, IRoleRepository
{
    private readonly ApplicationDbContext _context;

    public RoleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task AddAsync(Role entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Role entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Role>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Role?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Role?> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public void Update(Role entity)
    {
        throw new NotImplementedException();
    }
}