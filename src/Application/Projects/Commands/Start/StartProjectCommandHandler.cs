using MediatR;
using Projectify.Application.Abstractions.Persistence.Repositories;
using Projectify.Application.Common.Exceptions;


namespace Projectify.Application.Projects.Commands.Start;

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

        await repository.UpdateAsync(project);
        
        return Unit.Value;
    }
}