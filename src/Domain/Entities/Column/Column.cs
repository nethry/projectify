using System;
using Projectify.Domain.Entities.WorkItem;
namespace Projectify.Domain.Entities.Column;
using Projectify.Domain.Abstractions;

public class Column(string name) : Entity
{
    string Name { get; private set; } = name;

    List<WorkItem> WorkItems { get; private set; }
}
