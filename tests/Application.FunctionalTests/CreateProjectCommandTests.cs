using FluentAssertions;
using Moq;
using Projectify.Application.Abstractions.Persistence.Repositories;
using Projectify.Application.Projects.Commands.Create;
using Projectify.Domain.Entities.Project;

namespace Projectify.Application.FunctionalTests;

public class CreateProjectCommandTests
{
    [Fact]
    public async Task Should_Create_Project()
    {
        // Arrange
        var repositoryMock = new Mock<IProjectRepository>();

        var newProjectId = Guid.NewGuid();

        repositoryMock
            .Setup(x => x.AddAsync(It.IsAny<Project>()))
            .Callback<Project>(project => project.Id = newProjectId);

        var handler = new CreateProjectCommandHandler(repositoryMock.Object);

        var command = new CreateProjectCommand
        {
            Name = "Test Project",
            Description = "Test Description",
            Deadline = DateTime.Now.AddDays(5)
        };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Id.Should().Be(newProjectId);
    }
}