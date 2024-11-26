using Projectify.Domain.Entities.Project;

namespace Projectify.Application.Projects.Queries.CompleteProjectsList;

public record CompleteProjectListModel(Guid Id,  string Name , ProjectStatus Status);