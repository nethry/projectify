using System;
using Projectify.Domain.Abstractions;
namespace Projectify.Domain.Entities.Card;

public class Card(
	string name,
	DateTime startDate,
	DateTime deadline,
	string description,
	) : Entity
{
	string Name { get; set; } = name;

	string Description { get; private set; } = description;

	DateTime StartDate { get; private set; } = DateTime.UtcNow;
	
	DateTime deadline { get; private set; }
}
