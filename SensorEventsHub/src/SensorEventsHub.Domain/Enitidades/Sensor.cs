using System;

namespace SensorEventsHub.Domain.Enitidades
{
    [Serializable]
    public class Sensor: Entity
    {
        public string Timestamp  { get; private set; }
        public string Tag { get; private set; }
        public string Valor { get; private set; }
    }
}
