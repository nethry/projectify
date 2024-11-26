using MediatR;
using Projectify.Application.Abstractions.Persistence.Repositories;
using Projectify.Application.Common.Exceptions;

namespace Projectify.Application.Projects.Commands.Complete;

internal sealed class CompleteProjectCommandHandler(IProjectRepository repository) 
    : IRequestHandler<CompleteProjectCommand, Unit>
{
    public async Task<Unit> Handle( 
        CompleteProjectCommand command,
        CancellationToken cancellationToken)
    {
        var project = await repository.GetByIdAsync(command.Id);
        if (project == null)
        {
            throw new NotFoundException();
        }

        project.Complete();
        await repository.UpdateAsync(project);
        return Unit.Value;
    }
}

