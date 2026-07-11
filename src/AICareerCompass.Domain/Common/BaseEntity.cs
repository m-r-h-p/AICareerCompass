
using System.Collections.Generic;
using System.Security.Cryptography;

namespace AICareerCompass.Domain.Common
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; protected set; } = default!;

        private readonly List<object> _domainEvents = new();
        public IReadOnlyCollection<object> DomainEvents => _domainEvents.AsReadOnly();
        protected void AddDomainEvent(object domainEvent) => _domainEvents.Add(domainEvent);
        public void ClearDomainEvents() => _domainEvents.Clear();


        public override bool Equals(object? obj)
        {
            if (obj is not BaseEntity<TId> other) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;
            return EqualityComparer<TId>.Default.Equals(Id, other.Id);
        }

        public override int GetHashCode() => Id?.GetHashCode() ?? 0;
    }
}
