using MediatR;
using Microsoft.VisualBasic;
using Projectify.Application.Abstractions.Persistence.Repositories;
using Projectify.Domain.Entities.Project;

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

    // public async Task<IEnumerable<ProjectsListItemModel>> HandleSingleProject(
    //     Guid Id,
    //     GetProjectsListQuery query,
    //     CancellationToken cancellationToken)
    // {
    //     var projects = await repository.GetAllAsync();
        
    //     var singleProject = projects.Single(project => project.Id == Id);
    //     var project =  new ProjectsListItemModel(singleProject.Id,singleProject.Name, singleProject.Status);
    //     return (IEnumerable<ProjectsListItemModel>)project;
    // }

    public async Task<IEnumerable<ProjectsListItemModel>> HandleSingleProject(
        GetProjectsListQuery query,
        CancellationToken cancellationToken)
    {
        var projects = await repository.GetAllAsync();

        var singleProject = projects.Single(project => project.Id == query.Id);

            var project = new ProjectsListItemModel(singleProject.Id,singleProject.Name, singleProject.Status);
            return (IEnumerable<ProjectsListItemModel>)project;
    }
}