namespace Domain.Abstractions;

public abstract record DomainEvent : IDomainEvent
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime OccuredOn { get; set; } = DateTime.UtcNow;
}
