using MediatR;

namespace Projectify.Application.Projects.Queries.CompleteProjectsList;

public record GetCompleteProjectsListQuery : IRequest<IEnumerable<CompleteProjectListModel>>;