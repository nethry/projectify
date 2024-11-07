using Projectify.Domain.Abstractions;

namespace Projectify.Domain.Events.Project;

public record ProjectStartedEvent(Guid ProjectId) : DomainEvent;