using System;
using System.Collections.Generic;
using System.Text;

namespace SensorEventsHub.Domain.Enitidades
{
    public class Sensor: Entity
    {
        public string Timestamp  { get; private set; }
        public string Tag { get; private set; }
        public string Valor { get; private set; }
    }
}
