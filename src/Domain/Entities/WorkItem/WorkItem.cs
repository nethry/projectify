using System;
using Projectify.Domain.Abstractions;
namespace Projectify.Domain.Entities.WorkItem;

public class WorkItem(
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
