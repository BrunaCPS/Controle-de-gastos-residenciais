namespace ControleGastos.Application.Abstractions.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    Task<TEntity> AddAsync(TEntity entity, CancellationToken ct = default);
    Task UpdateAsync(TEntity entity, CancellationToken ct = default);
    Task DeleteAsync(TEntity entity, CancellationToken ct = default);

    Task<TEntity?> GetByIdAsync(long id, CancellationToken ct = default);
    Task<List<TEntity>> GetAllAsync(CancellationToken ct = default);

    IQueryable<TEntity> Query();

    Task<int> SaveChangesAsync(CancellationToken ct = default);
}