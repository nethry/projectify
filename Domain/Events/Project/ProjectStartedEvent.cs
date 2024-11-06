using Domain.Abstractions;

namespace Domain.Events.Project;

public record ProjectStartedEvent(Guid ProjectId) : DomainEvent;