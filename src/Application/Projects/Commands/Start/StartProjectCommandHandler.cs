using MediatR;
using Projectify.Application.Abstractions.Persistence.Repositories;
using Projectify.Application.Common.Exceptions;
using Projectify.Application.Projects.Commands.Start;
using Projectify.Domain.Entities.Project;

namespace Projectify.Application.Projects.Commands;

internal sealed class StartProjectCommandHandler(IProjectRepository repository) 
    : IRequestHandler<StartProjectCommand, Unit>
{
    public async Task<Unit> Handle(
        StartProjectCommand command,
        CancellationToken cancellationToken)
    {
        var project = await repository.GetByIdAsync(command.Id);
        if (project == null)
        {
            throw new NotFoundException();
        }
        project.Start();
        
        return Unit.Value;
    }
}