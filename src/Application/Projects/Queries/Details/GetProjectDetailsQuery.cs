using MediatR;

namespace Projectify.Application.Projects.Queries.Details;

public record GetProjectDetailsQuery(Guid Id) : IRequest<ProjectDetailsModel>;