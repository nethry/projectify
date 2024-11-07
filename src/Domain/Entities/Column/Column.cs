using System;
using Projectify.Domain.Entities.WorkItem;
namespace Projectify.Domain.Entities.Column;

public class Column(string name)
{
    string Name { get; private set; } = name;

    List<WorkItem> WorkItems { get; private set; }
}
