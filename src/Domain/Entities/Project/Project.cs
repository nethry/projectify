using Projectify.Domain.Abstractions;
using Projectify.Domain.Events.Project;
using Projectify.Domain.Exceptions;

namespace Projectify.Domain.Entities.Project;

public class Project(
    string name,
    string description,
    DateTime deadline) : Entity
{
    public string Name { get; private set; } = name;

    public string Description { get; private set; } = description;

    public DateTime? StartDate { get; private set; }
    
    public DateTime? EndDate { get; private set; }

    public DateTime Deadline { get; private set; } = deadline;

    public ProjectStatus Status { get; private set; } = ProjectStatus.New;

    public void Start()
    {
        if (Status != ProjectStatus.New)
        {
            throw new InvalidProjectStatusException("The project is already started.");
        }

        Status = ProjectStatus.InProgress;
        StartDate = DateTime.UtcNow;
        AddDomainEvent(new ProjectStartedEvent(Id));
    }

    public void Complete()
    {
        if (Status is not (ProjectStatus.InProgress or ProjectStatus.Overdue))
        {
            throw new InvalidProjectStatusException($"Unable to complete the project with status: {Status}");
        }
        
        Status = ProjectStatus.Completed;
        EndDate = DateTime.UtcNow;
        AddDomainEvent(new ProjectCompletedEvent(Id));
    }
}