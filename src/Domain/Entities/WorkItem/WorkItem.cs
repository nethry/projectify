using Projectify.Domain.Abstractions;

namespace Projectify.Domain.Entities.WorkItem;

public class WorkItem(
    string name,
    DateTime deadline,
    string description
) : Entity
{
    public string Name { get; set; } = name;

    public string Description { get; private set; } = description;

    public DateTime StartDate { get; private set; } = DateTime.UtcNow;

    public DateTime Deadline { get; private set; } = deadline;
}