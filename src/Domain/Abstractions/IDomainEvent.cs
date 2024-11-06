using MediatR;

namespace Projectify.Domain.Abstractions;

public interface IDomainEvent : INotification
{
    Guid Id { get; set; }
    
    DateTime OccuredOn { get; set; }
}