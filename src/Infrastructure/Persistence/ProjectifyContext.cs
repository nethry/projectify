using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Projectify.Domain.Entities.Board;
using Projectify.Domain.Entities.Project;
using Projectify.Domain.Entities.WorkItem;

namespace Projectify.Infrastructure.Persistence;

public class ProjectifyContext(DbContextOptions<ProjectifyContext> options)
    : DbContext(options)
{
    public DbSet<Project> Projects { get; set; }

    public DbSet<WorkItem> WorkItems { get; set; }

    public DbSet<Column> Columns { get; set; }

    public DbSet<Board> Boards { get; set; }
}