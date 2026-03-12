using ControleGastos.Application.Abstractions.Repositories;
using ControleGastos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.Infrastructure.Repositories;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    protected readonly AppDbContext _db;
    protected readonly DbSet<TEntity> _set;

    public RepositoryBase(AppDbContext db)
    {
        _db = db;
        _set = db.Set<TEntity>();
    }

    public IQueryable<TEntity> Query() => _set.AsQueryable();

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken ct = default)
    {
        await _set.AddAsync(entity, ct);
        return entity;
    }

    public Task UpdateAsync(TEntity entity, CancellationToken ct = default)
    {
        _set.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(TEntity entity, CancellationToken ct = default)
    {
        _set.Remove(entity);
        return Task.CompletedTask;
    }

    public Task<TEntity?> GetByIdAsync(long id, CancellationToken ct = default)
        => _set.FindAsync(new object[] { id }, ct).AsTask();

    public Task<List<TEntity>> GetAllAsync(CancellationToken ct = default)
        => _set.ToListAsync(ct);

    public Task<int> SaveChangesAsync(CancellationToken ct = default)
        => _db.SaveChangesAsync(ct);
}