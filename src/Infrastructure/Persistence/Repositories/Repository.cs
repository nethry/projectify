using Microsoft.EntityFrameworkCore;
using Projectify.Application.Abstractions.Persistence.Repositories;
using Projectify.Domain.Abstractions;

namespace Projectify.Infrastructure.Persistence.Repositories;

internal abstract class Repository<TEntity>(ProjectifyContext context)
    : IRepository<TEntity>
    where TEntity : Entity
{
    public async Task AddAsync(TEntity entity)
    {
        await context.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        context.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await context.FindAsync<TEntity>(id);
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync()
    {
        return await context.Set<TEntity>().ToListAsync();
    }

    public async Task RemoveAsync(Guid id)
    {
        var entity = context.Find<TEntity>(id);

        if (entity != null)
        {
            context.Remove(entity);
        }
        
        await context.SaveChangesAsync();
    }
}