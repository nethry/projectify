using System;
using Projectify.Domain.Entities.Card;

namespace Projectify.Domain.Entities.Board;

public class Board(
    string name
    )
{
    string Name { get; private set; } = name;

    list<Card> cards { get; private set; }
}
