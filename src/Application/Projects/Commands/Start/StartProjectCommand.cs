using MediatR;

namespace Projectify.Application.Projects.Commands.Start;

public class StartProjectCommand : IRequest<Unit>
{
    public required Guid Id { get; set; }
}