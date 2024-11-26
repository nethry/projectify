using MediatR;

namespace Projectify.Application.Projects.Commands.Remove;

public class RemoveProjectCommand : IRequest<Unit>
{
    public required Guid Id { get; set; }
}