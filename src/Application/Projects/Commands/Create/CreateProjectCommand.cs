using MediatR;

namespace Projectify.Application.Projects.Commands.Create;

public class CreateProjectCommand : IRequest<NewProjectResultModel>
{
    public required string Name { get; set; }
    
    public required string Description { get; set; }

    public DateTime Deadline { get; set; }
}