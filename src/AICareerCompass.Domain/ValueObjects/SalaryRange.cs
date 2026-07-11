using AICareerCompass.Domain.Exceptions;
using System;

namespace AICareerCompass.Domain.ValueObjects
{
    public sealed class SalaryRange : IEquatable<SalaryRange>
    {
        public decimal Min { get; }
        public decimal Max { get; }
        public string Currency { get; }

        private SalaryRange(decimal min, decimal max, string currency)
        {
            Min = min;
            Max = max;
            Currency = currency;
        }
        public static SalaryRange Create(decimal min, decimal max, string currency)
        {
            if (min < 0 || max < 0)
                throw new DomainException("حقوق نمی‌تواند منفی باشد.");

            if (min > max)
                throw new DomainException("حداقل حقوق نمی‌تواند بیشتر از حداکثر باشد.");

            if (string.IsNullOrWhiteSpace(currency))
                throw new DomainException("واحد پول باید مشخص باشد.");

            return new SalaryRange(min, max, currency.ToUpperInvariant());
        }

        public bool Equals(SalaryRange? other)
        {
            if (other is null) return false;
            return Min == other.Min && Max == other.Max && Currency == other.Currency;
        }

        public override bool Equals(object? obj) => Equals(obj as SalaryRange);
        public override int GetHashCode() => HashCode.Combine(Min, Max, Currency);
        public override string ToString() => $"{Min:N0} - {Max:N0} {Currency}";
    }
}
