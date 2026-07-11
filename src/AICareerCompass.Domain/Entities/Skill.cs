using AICareerCompass.Domain.Common;
using AICareerCompass.Domain.Enums;
using AICareerCompass.Domain.Exceptions;
using System;

namespace AICareerCompass.Domain.Entities;

public class Skill : BaseEntity<Guid>
{
    public string Name { get; private set; } = default!;
    public SkillCategory Category { get; private set; }

    private Skill()
    {
        // این سازنده‌ی خالی فقط برای EF Core لازمه (بعداً توی Sprint 2 می‌فهمی چرا)
        // خودت هیچ‌وقت مستقیم صداش نزن
    }

    private Skill(Guid id, string name, SkillCategory category)
    {
        Id = id;
        Name = name;
        Category = category;
    }

    public static Skill Create(string name, SkillCategory category)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("نام مهارت نمی‌تواند خالی باشد.");

        return new Skill(Guid.NewGuid(), name.Trim(), category);
    }
}