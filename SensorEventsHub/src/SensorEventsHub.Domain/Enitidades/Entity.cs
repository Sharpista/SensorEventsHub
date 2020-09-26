using System;
using System.Collections.Generic;
using System.Text;

namespace SensorEventsHub.Domain.Enitidades
{
    public abstract class Entity
    {
        public virtual Guid  Id { get; set; }
    }
}
