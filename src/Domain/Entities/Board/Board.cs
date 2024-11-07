using System;
using Projectify.Domain.Entities.Column;
using Projectify.Domain.Abstractions;

namespace Projectify.Domain.Entities.Board;

public class Board(string name) : Entity
{
    string Name { get; private set; } = name;

    List<Column> Columns { get; private set; }
}
