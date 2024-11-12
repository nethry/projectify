using Projectify.Domain.Entities.Project;

namespace Projectify.Application.Projects.Queries.List;

public record ProjectsListItemModel(Guid Id, string Name, ProjectStatus Status);