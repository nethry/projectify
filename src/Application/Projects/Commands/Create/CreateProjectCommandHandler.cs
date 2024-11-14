using MediatR;
using Projectify.Application.Abstractions.Persistence.Repositories;
using Projectify.Domain.Entities.Project;

namespace Projectify.Application.Projects.Commands.Create;

internal sealed class CreateProjectCommandHandler(
    IProjectRepository repository)
    : IRequestHandler<CreateProjectCommand, NewProjectResultModel>
{
    public async Task<NewProjectResultModel> Handle(
        CreateProjectCommand command,
        CancellationToken cancellationToken)
    {
        var newProject = new Project(command.Name, command.Description, command.Deadline);

        await repository.AddAsync(newProject);

        return new NewProjectResultModel(newProject.Id);
    }
}