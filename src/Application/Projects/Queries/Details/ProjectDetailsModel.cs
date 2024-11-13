using Projectify.Domain.Entities.Project;

namespace Projectify.Application.Projects.Queries.Details;

public class ProjectDetailsModel
{
    public required string Name { get; set; }
    
    public required string Description { get; set; }

    public ProjectStatus Status { get; set; }

    public required string DeadlineText { get; set; }
}