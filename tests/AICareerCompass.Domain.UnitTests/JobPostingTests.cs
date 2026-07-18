using AICareerCompass.Domain.Entities;
using AICareerCompass.Domain.Enums;
using AICareerCompass.Domain.Exceptions;
using FluentAssertions;

namespace AICareerCompass.Domain.UnitTests;

public class JobPostingTests
{
    [Fact]
    public void Create_WithValidData_ShouldSucceed()
    {
        // Arrange & Act
        var jobPosting = JobPosting.Create(
            title: "Senior .NET Developer",
            companyName: "TechCorp",
            description: "We are hiring...",
            source: JobSource.Arbeitnow,
            postedAt: DateTime.UtcNow.AddDays(-1));

        // Assert
        jobPosting.Title.Should().Be("Senior .NET Developer");
        jobPosting.RequiredSkills.Should().BeEmpty();
    }
    [Fact]
    public void Create_WithEmptyTitle_ShouldThrowDomainException()
    {
        // Arrange
        Action act = () => JobPosting.Create(
            title: "",
            companyName: "TechCorp",
            description: "desc",
            source: JobSource.Manual,
            postedAt: DateTime.UtcNow);

        // Act & Assert
        act.Should().Throw<DomainException>()
            .WithMessage("*عنوان آگهی*");
    }
    [Fact]
    public void AddRequiredSkill_DuplicateSkill_ShouldThrowDomainException()
    {
        // Arrange
        var jobPosting = JobPosting.Create(
            "Backend Developer", "TechCorp", "desc",
            JobSource.Manual, DateTime.UtcNow);

        var skill = Skill.Create("C#", SkillCategory.ProgrammingLanguage);
        jobPosting.AddRequiredSkill(skill);

        var duplicateSkill = Skill.Create("c#", SkillCategory.ProgrammingLanguage);

        // Act
        Action act = () => jobPosting.AddRequiredSkill(duplicateSkill);

        // Assert
        act.Should().Throw<DomainException>()
            .WithMessage("*قبلاً*");
    }
}
