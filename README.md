#Persion
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
#English
# AI Career Compass

An AI-powered career navigation platform for software developers — an API-first system that analyzes real job postings, identifies the most in-demand skills, and compares a developer's GitHub profile with current market requirements to generate a personalized learning roadmap.

## Why This Project?

The software development job market is evolving rapidly. This project serves both as a technical portfolio—demonstrating Clean Architecture, CQRS, testing, and AI Engineering—and as a practical tool that helps developers understand market demands and close their skill gaps.

## Architecture

The project is built using **Clean Architecture** with four layers:

```text
Api  →  Infrastructure  →  Application  →  Domain
```

- **Domain** – The dependency-free core containing entities, value objects, and business rules.
- **Application** – Implements use cases using the CQRS pattern with MediatR.
- **Infrastructure** – Database implementation, external API clients, and LLM integration.
- **API** – The application's entry point and Composition Root.

## Tech Stack

| Category | Technology |
|----------|------------|
| Framework | .NET 9 / ASP.NET Core Web API |
| Architecture | Clean Architecture + CQRS (MediatR) |
| Database | PostgreSQL + Entity Framework Core |
| AI | Microsoft Semantic Kernel + Ollama (Local & Free) |
| Testing | xUnit, FluentAssertions, NSubstitute, Testcontainers |
| API Documentation | Scalar |

## Getting Started

```bash
# 1. Start the PostgreSQL database
docker-compose up -d

# 2. Install Ollama (one-time setup)
ollama pull llama3.1

# 3. Run the application
dotnet run --project src/AICareerCompass.Api
```

## Development Roadmap

The project is developed in one-week sprints. See the complete roadmap in [Roadmap](./AI-Career-Compass-Roadmap.md).

- ✅ Sprint 0 — Project Setup & Core Architecture
- 🚧 Sprint 1 — Domain & Application Core
- 📅 Sprint 2 — Infrastructure & First Data Source
- 📅 Sprint 3 — API Layer
- 📅 Sprint 4 — Analysis Engine
- 📅 Sprint 5 — AI Integration (Phase 1)
- 📅 Sprint 6 — User Profile Analyzer
- 📅 Sprint 7 — Basic RAG Implementation
- 📅 Sprint 8 — Testing & CI/CD
- 📅 Sprint 9 — Final Polish & Release Preparation


