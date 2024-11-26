using System.Data.Common;
using MediatR;
using Projectify.Application.Abstractions.Persistence.Repositories;
using Projectify.Application.Common.Exceptions;

namespace Projectify.Application.Projects.Commands.Remove;

internal sealed class RemoveProjectCommandHandler(IProjectRepository repository)
    :IRequestHandler<RemoveProjectCommand, Unit>
{
    public async Task<Unit> Handle( 
        RemoveProjectCommand command,
        CancellationToken cancellationToken)
    {
        var project = await repository.GetByIdAsync(command.Id);
        if (project == null)
        {
            throw new NotFoundException();
        }
        await repository.RemoveAsync(project.Id);

        return Unit.Value;
    }

}