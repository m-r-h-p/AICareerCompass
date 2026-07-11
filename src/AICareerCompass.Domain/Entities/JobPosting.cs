using AICareerCompass.Domain.Common;
using AICareerCompass.Domain.Enums;
using AICareerCompass.Domain.Exceptions;
using AICareerCompass.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AICareerCompass.Domain.Entities
{
    public class JobPosting : BaseEntity<Guid>
    {
        public string Title { get; private set; } = default!;
        public string CompanyName { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public JobSource Source { get; private set; }
        public DateTime PostedAt { get; private set; }
        public SalaryRange? Salary { get; private set; }

        private readonly List<Skill> _requiredSkills = new();
        public IReadOnlyCollection<Skill> RequiredSkills => _requiredSkills.AsReadOnly();

        private JobPosting()
        {
            // برای EF Core
        }

        private JobPosting(
            Guid id,
            string title,
            string companyName,
            string description,
            JobSource source,
            DateTime postedAt,
            SalaryRange? salary)
        {
            Id = id;
            Title = title;
            CompanyName = companyName;
            Description = description;
            Source = source;
            PostedAt = postedAt;
            Salary = salary;
        }
        public static JobPosting Create(
        string title,
        string companyName,
        string description,
        JobSource source,
        DateTime postedAt,
        SalaryRange? salary = null)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new DomainException("عنوان آگهی نمی‌تواند خالی باشد.");

            if (string.IsNullOrWhiteSpace(companyName))
                throw new DomainException("نام شرکت نمی‌تواند خالی باشد.");

            if (postedAt > DateTime.UtcNow)
                throw new DomainException("تاریخ انتشار نمی‌تواند در آینده باشد.");

            return new JobPosting(
                Guid.NewGuid(),
                title.Trim(),
                companyName.Trim(),
                description?.Trim() ?? string.Empty,
                source,
                postedAt,
                salary);
        }
        public void AddRequiredSkill(Skill skill)
        {
            if (skill is null)
                throw new DomainException("مهارت نامعتبر است.");

            if (_requiredSkills.Any(s => s.Name.Equals(skill.Name, StringComparison.OrdinalIgnoreCase)))
                throw new DomainException($"مهارت '{skill.Name}' قبلاً به این آگهی اضافه شده است.");

            _requiredSkills.Add(skill);
        }
        public void RemoveRequiredSkill(Guid skillId)
        {
            var skill = _requiredSkills.FirstOrDefault(s => s.Id == skillId);
            if (skill is not null)
                _requiredSkills.Remove(skill);
        }
    }
}
