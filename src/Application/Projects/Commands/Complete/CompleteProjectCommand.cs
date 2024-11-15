using MediatR;

namespace Projectify.Application.Projects.Commands.Complete;

public class CompleteProjectCommand : IRequest<Unit>
{
    public required Guid Id { get; set; }

    public DateTime EndDate { get; } = DateTime.Now;
    
    public enum Status { Completed }
}