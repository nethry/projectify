using MediatR;
using Projectify.Application.Abstractions.Persistence.Repositories;
using Projectify.Domain.Entities.Project;
namespace Projectify.Application.Projects.Queries.CompleteProjectsList;

internal sealed class GetCompleteProjectsListQueryHandler(IProjectRepository repository)
    : IRequestHandler<GetCompleteProjectsListQuery, IEnumerable<CompleteProjectListModel>>
{
    public async Task<IEnumerable<CompleteProjectListModel>> Handle(
        GetCompleteProjectsListQuery query,
        CancellationToken cancellationToken)
    {
        var UnfilteredProjects = await repository.GetAllAsync();

        return (IEnumerable<CompleteProjectListModel>)
            (from project in UnfilteredProjects
            where project.Status == ProjectStatus.Completed 
            select (project.Id, project.Name));
             
    }
}