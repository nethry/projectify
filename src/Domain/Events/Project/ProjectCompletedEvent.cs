using Projectify.Domain.Abstractions;

namespace Projectify.Domain.Events.Project;

public record ProjectCompletedEvent(Guid ProjectId) : DomainEvent;