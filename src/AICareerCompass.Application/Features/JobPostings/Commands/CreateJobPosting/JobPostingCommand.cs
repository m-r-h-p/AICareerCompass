using AICareerCompass.Domain.Enums;
using MediatR;

namespace AICareerCompass.Application.Features.JobPostings.Commands.CreateJobPosting;

public record CreateJobPostingCommand(
    string Title,
    string CompanyName,
    string Description,
    JobSource Source,
    DateTime PostedAt,
    decimal? MinSalary,
    decimal? MaxSalary,
    string? Currency) : IRequest<Guid>;