using FluentValidation;

namespace AICareerCompass.Application.Features.JobPostings.Commands.CreateJobPosting;

public class CreateJobPostingCommandValidator : AbstractValidator<CreateJobPostingCommand>
{
    public CreateJobPostingCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("عنوان آگهی الزامی است.")
            .MaximumLength(200);

        RuleFor(x => x.CompanyName)
            .NotEmpty().WithMessage("نام شرکت الزامی است.");

        RuleFor(x => x.PostedAt)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("تاریخ انتشار نمی‌تواند در آینده باشد.");

        When(x => x.MinSalary.HasValue && x.MaxSalary.HasValue, () =>
        {
            RuleFor(x => x.MinSalary)
                .LessThanOrEqualTo(x => x.MaxSalary)
                .WithMessage("حداقل حقوق نباید بیشتر از حداکثر باشد.");
        });
    }
}