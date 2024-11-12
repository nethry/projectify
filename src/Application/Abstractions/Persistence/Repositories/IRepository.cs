using Projectify.Domain.Abstractions;

namespace Projectify.Application.Abstractions.Persistence.Repositories;

public interface IRepository<TEntity>
    where TEntity : Entity
{
    Task AddAsync(TEntity entity);
    
    Task UpdateAsync(TEntity entity);
    
    Task<TEntity?> GetByIdAsync(Guid id);
    
    Task<IReadOnlyList<TEntity>> GetAllAsync();
    
    Task RemoveAsync(Guid id);
}