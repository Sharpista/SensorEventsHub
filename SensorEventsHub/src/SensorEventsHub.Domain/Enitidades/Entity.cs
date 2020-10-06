using System;

namespace SensorEventsHub.Domain.Enitidades
{
    public abstract class Entity
    {

        protected Entity()
        {
            Id = Guid.NewGuid(); 
        }
        public virtual Guid  Id { get; set; }
    }
}
