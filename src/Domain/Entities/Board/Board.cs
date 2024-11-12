using System;
using Projectify.Domain.Entities.Column;
using Projectify.Domain.Abstractions;

namespace Projectify.Domain.Entities.Board;

public class Board(string name) : Entity
{
    public string Name { get; private set; } = name;

    public List<Column.Column>? Columns { get; private set; }
}
