using System;
using Projectify.Domain.Entities.Column;

namespace Projectify.Domain.Entities.Board;

public class Board(string name)
{
    string Name { get; private set; } = name;

    List<Column> Columns { get; private set; }
}
