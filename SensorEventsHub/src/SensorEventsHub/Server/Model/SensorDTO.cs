using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SensorEventsHub.API.Model
{
    public class SensorDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Timestamp { get; private set; }
        public string Tag { get; private set; }
        public string Valor { get; private set; }
    }
}
