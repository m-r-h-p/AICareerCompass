<div dir="rtl" style="text-align: right;">

# AI Career Compass

قطب‌نمای مسیر شغلی برنامه‌نویس در عصر هوش مصنوعی — یک سیستم API-محور که آگهی‌های شغلی واقعی رو تحلیل می‌کنه، مهارت‌های پرتقاضای بازار رو پیدا می‌کنه، و با مقایسه‌ی پروفایل گیت‌هاب کاربر با نیاز بازار، یک نقشه‌ی راه شخصی‌سازی‌شده تولید می‌کنه.

## چرا این پروژه؟

بازار کار برنامه‌نویسی داره سریع تغییر می‌کنه. این پروژه هم یک نمونه‌کار فنی (معماری تمیز، CQRS، تست، AI Engineering) و هم یک ابزار واقعاً کاربردیه.

## معماری

پروژه بر اساس **Clean Architecture** با ۴ لایه ساخته شده:

```
Api  →  Infrastructure  →  Application  →  Domain
```

- **Domain**: هسته‌ی بدون وابستگی (Entities, Value Objects)
- **Application**: منطق Use Case‌ها با الگوی CQRS (MediatR)
- **Infrastructure**: پیاده‌سازی دیتابیس، کلاینت‌های API خارجی، اتصال به LLM
- **Api**: نقطه‌ی ورود و Composition Root

## استک فنی

| بخش | تکنولوژی |
|---|---|
| Framework | .NET 9 / ASP.NET Core Web API |
| معماری | Clean Architecture + CQRS (MediatR) |
| دیتابیس | PostgreSQL + EF Core |
| AI | Microsoft Semantic Kernel + Ollama (لوکال و رایگان) |
| تست | xUnit, FluentAssertions, NSubstitute, Testcontainers |
| مستندسازی API | Scalar |

## اجرای پروژه

```bash
# ۱. بالا آوردن دیتابیس
docker-compose up -d

# ۲. نصب Ollama (یک بار، از ollama.com)
ollama pull llama3.1

# ۳. اجرای برنامه
dotnet run --project src/AICareerCompass.Api
```

## نقشه‌ی راه توسعه

توسعه‌ی این پروژه به‌صورت اسپرینت‌های ۱ هفته‌ای پیش می‌ره. جزئیات کامل در [Roadmap](./AI-Career-Compass-Roadmap.md).

-  Sprint 0 — راه‌اندازی و معماری پایه
-  Sprint 1 — Domain & Application Core
-  Sprint 2 — Infrastructure & اولین منبع داده
-  Sprint 3 — لایه API
-  Sprint 4 — موتور تحلیل
-  Sprint 5 — ورود AI (فاز اول)
-  Sprint 6 — تحلیلگر پروفایل کاربر
-  Sprint 7 — RAG ساده
-  Sprint 8 — تست، CI/CD
-  Sprint 9 — آماده‌سازی نهایی

</div>
