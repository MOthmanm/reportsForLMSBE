using Microsoft.EntityFrameworkCore;

namespace StartBack.Infrastructure.Persistence.UnitOfWork;

public class EfUnitOfWork : IUnitOfWork
{
    private readonly DbContext _db;
    public EfUnitOfWork(DbContext db) { _db = db; }
    public Task<int> SaveChangesAsync(CancellationToken ct = default) => _db.SaveChangesAsync(ct);
}


