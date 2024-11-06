using MediatR;

namespace Domain.Abstractions;

public interface IDomainEvent : INotification
{
    Guid Id { get; set; }
    
    DateTime OccuredOn { get; set; }
}