using MediatR;
using Projectify.Application.Abstractions.Persistence.Repositories;
using Projectify.Application.Common.Exceptions;

namespace Projectify.Application.Projects.Queries.Details;

internal sealed class GetProjectDetailsQueryHandler(IProjectRepository repository)
    : IRequestHandler<GetProjectDetailsQuery, ProjectDetailsModel>
{
    public async Task<ProjectDetailsModel> Handle(
        GetProjectDetailsQuery query,
        CancellationToken cancellationToken)
    {
        var project = await repository.GetByIdAsync(query.Id);

        if (project == null)
        {
            throw new NotFoundException();
        }

        return new ProjectDetailsModel
        {
            Name = project.Name,
            Description = project.Description,
            Status = project.Status,
            DeadlineText = project.Deadline.ToLongDateString()
        };
    }
}