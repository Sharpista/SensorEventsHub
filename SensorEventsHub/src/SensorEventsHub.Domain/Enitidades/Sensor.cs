using System;

namespace SensorEventsHub.Domain.Enitidades
{
    [Serializable]
    public class Sensor: Entity
    {
        public string Timestamp  { get;  set; }
        public string Tag { get;  set; }
        public string Valor { get;  set; }
    }
}
