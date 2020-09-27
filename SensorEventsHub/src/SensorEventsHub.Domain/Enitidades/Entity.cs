using System;

namespace SensorEventsHub.Domain.Enitidades
{
    public abstract class Entity
    {
        public virtual Guid  Id { get; set; }
    }
}
