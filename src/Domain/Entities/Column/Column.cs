using System;

namespace Projectify.Domain.Entities.Column;

public class Column(string name)
{
    string Name { get; private set; } = name;
    List<Card> Cards { get; private set; }
}
