using AICareerCompass.Domain.Entities;

namespace AICareerCompass.Application.Common.Interfaces
{
    public interface IJobPostingRepository
    {
        Task<JobPosting?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync(JobPosting jobPosting, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<JobPosting>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
