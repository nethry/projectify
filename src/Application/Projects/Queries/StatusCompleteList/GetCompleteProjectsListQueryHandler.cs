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
        var allProjects = await repository.GetAllAsync();
        
        var filteredProjects = allProjects
            .Where(project => project.Status == ProjectStatus.Completed) 
            .Select(project => new CompleteProjectListModel(project.Id, project.Name, project.Status));
        
        return filteredProjects;
    }
}