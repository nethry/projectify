using Projectify.Domain.Entities.Project;

namespace Projectify.Application.Abstractions.Persistence.Repositories;

public interface IProjectRepository : IRepository<Project>
{
    Task<IReadOnlyList<Project>> GetActiveProjectsAsync();
}