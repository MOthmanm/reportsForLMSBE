using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace StartBack.Infrastructure.Persistence.Repositories;

public class EfRepository<T> : IRepository<T> where T : class
{
    private readonly DbContext _db;
    private readonly DbSet<T> _set;

    public EfRepository(DbContext db)
    {
        _db = db;
        _set = _db.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await _set.FindAsync([id], ct);

    public Task<List<T>> ListAsync(CancellationToken ct = default)
        => _set.ToListAsync(ct);

    public Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
        => _set.Where(predicate).ToListAsync(ct);

    public Task AddAsync(T entity, CancellationToken ct = default)
        => _set.AddAsync(entity, ct).AsTask();

    public void Remove(T entity) => _set.Remove(entity);

    public IQueryable<T> Query() => _set.AsQueryable();
}


