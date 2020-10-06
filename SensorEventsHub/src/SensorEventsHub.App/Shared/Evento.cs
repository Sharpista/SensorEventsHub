using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorEventsHub.App.Shared
{
    public class Evento
    {
        public string Id { get; set; }
        public string Timestamp { get; set; }
        public string Tag { get; set; }
        public string Valor { get; set; }
    }
}
