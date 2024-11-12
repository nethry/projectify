using MediatR;

namespace Projectify.Application.Projects.Queries.List;

public record GetProjectsListQuery : IRequest<IEnumerable<ProjectsListItemModel>>;