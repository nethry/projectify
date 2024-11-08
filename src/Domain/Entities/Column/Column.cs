using System;
using Projectify.Domain.Entities.WorkItem;
namespace Projectify.Domain.Entities.Column;
using Projectify.Domain.Abstractions;

public class Column(string name) : Entity
{
    public string Name { get; private set; } = name;

    public List<WorkItem.WorkItem>? WorkItems { get; private set; }
}
