using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class Entity
    {

        private readonly List<IDomainEvent> _domainEvents = new();
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatededAt { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatededAt = DateTime.UtcNow;
        }

        public IReadOnlyList<IDomainEvent> GetDomainEvents()
        {
            return _domainEvents.ToList();
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        protected void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
