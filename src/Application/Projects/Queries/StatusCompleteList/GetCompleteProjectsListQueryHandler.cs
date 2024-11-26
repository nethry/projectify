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
        var unfilteredProjects = await repository.GetAllAsync();
        
        var FilteredProjects = unfilteredProjects
            .Where(project => project.Status == ProjectStatus.Completed) 
            .Select(project => new CompleteProjectListModel(project.Id, project.Name, project.Status));
        
        return FilteredProjects;
    }
}