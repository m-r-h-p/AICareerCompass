using AICareerCompass.Application.Common.Interfaces;
using AICareerCompass.Domain.Entities;
using AICareerCompass.Domain.ValueObjects;
using MediatR;

namespace AICareerCompass.Application.Features.JobPostings.Commands.CreateJobPosting;

public class CreateJobPostingCommandHandler : IRequestHandler<CreateJobPostingCommand, Guid>
{
    private readonly IJobPostingRepository _repository;

    public CreateJobPostingCommandHandler(IJobPostingRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateJobPostingCommand request, CancellationToken cancellationToken)
    {
        SalaryRange? salary = null;
        if (request.MinSalary.HasValue && request.MaxSalary.HasValue && request.Currency is not null)
        {
            salary = SalaryRange.Create(request.MinSalary.Value, request.MaxSalary.Value, request.Currency);
        }

        var jobPosting = JobPosting.Create(
            request.Title,
            request.CompanyName,
            request.Description,
            request.Source,
            request.PostedAt,
            salary);

        await _repository.AddAsync(jobPosting, cancellationToken);

        return jobPosting.Id;
    }
}