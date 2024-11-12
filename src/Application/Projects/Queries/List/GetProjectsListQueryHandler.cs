using MediatR;
using Projectify.Application.Abstractions.Persistence.Repositories;

namespace Projectify.Application.Projects.Queries.List;

internal sealed class GetProjectsListQueryHandler(IProjectRepository repository)
    : IRequestHandler<GetProjectsListQuery, IEnumerable<ProjectsListItemModel>>
{
    public async Task<IEnumerable<ProjectsListItemModel>> Handle(
        GetProjectsListQuery query,
        CancellationToken cancellationToken)
    {
        var projects = await repository.GetAllAsync();

        return projects
            .Select(project => new ProjectsListItemModel(project.Id, project.Name, project.Status));
    }
}