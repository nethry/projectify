using Domain.Abstractions;
using Domain.Events.Project;
using Domain.Exceptions;

namespace Domain.Entities.Project;

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
        StartDate = DateTime.Now;
        AddDomainEvent(new ProjectStartedEvent(Id));
    }
}