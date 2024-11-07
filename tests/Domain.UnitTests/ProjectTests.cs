using FluentAssertions;
using Projectify.Domain.Entities.Project;
using Projectify.Domain.Exceptions;

namespace Projectify.Domain.UnitTests;

public class ProjectTests
{
    [Fact]
    public void Should_Create_Project()
    {
        var project = new Project(
            "TestProject",
            "Description",
            DateTime.Now.Date.AddMonths(6));

        project.Should().NotBeNull();
        project.Status.Should().Be(ProjectStatus.New);
    }

    [Fact]
    public void Should_Start_Project_With_Correct_Status()
    {
        var project = new Project(
            "TestProject",
            "Description",
            DateTime.Now.Date.AddMonths(6));
        
        project.Start();
        
        project.Status.Should().Be(ProjectStatus.InProgress);
    }

    [Fact]
    public void Should_Throw_Exception_When_Try_To_Complete_Not_Started_Project()
    {
        var project = new Project(
            "TestProject",
            "Description",
            DateTime.Now.Date.AddMonths(6));

        FluentActions.Invoking(() => project.Complete())
            .Should().Throw<InvalidProjectStatusException>();
    }

    [Fact]
    public void Should_Complete_Project_With_Correct_Status()
    {
        var project = new Project(
            "TestProject",
            "Description",
            DateTime.Now.Date.AddMonths(6));

        project.Start();
        project.Complete();
        
        project.Status.Should().Be(ProjectStatus.Completed);
    }
}