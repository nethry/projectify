using Projectify.Domain.Abstractions;

namespace Projectify.Domain.Entities.Column;


public class Column(string name) : Entity
{
    public string Name { get; private set; } = name;

    public List<WorkItem.WorkItem>? WorkItems { get; set; }
}
