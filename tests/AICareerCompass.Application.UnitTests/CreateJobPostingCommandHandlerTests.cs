using AICareerCompass.Application.Common.Interfaces;
using AICareerCompass.Application.Features.JobPostings.Commands.CreateJobPosting;
using AICareerCompass.Domain.Entities;
using AICareerCompass.Domain.Enums;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AICareerCompass.Application.UnitTests;

public class CreateJobPostingCommandHandlerTests
{
    private readonly IJobPostingRepository _repository = Substitute.For<IJobPostingRepository>();

    [Fact]
    public async Task Handle_WithValidCommand_ShouldAddJobPostingAndReturnId()
    {
        // Arrange
        var handler = new CreateJobPostingCommandHandler(_repository);
        var command = new CreateJobPostingCommand(
            "Senior .NET Developer",
            "TechCorp",
            "توضیحات آگهی",
            JobSource.Manual,
            DateTime.UtcNow,
            MinSalary: 2000,
            MaxSalary: 3000,
            Currency: "USD");

        // Act
        var resultId = await handler.Handle(command, CancellationToken.None);

        // Assert
        resultId.Should().NotBeEmpty();
        await _repository.Received(1).AddAsync(
            Arg.Is<JobPosting>(jp => jp.Title == "Senior .NET Developer"),
            Arg.Any<CancellationToken>());
    }
}