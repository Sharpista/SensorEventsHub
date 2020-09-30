using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SensorEventsHub.App.Data
{
    public class SensorDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Timestamp { get; set; }
        public string Tag { get; set; }
        public string Valor { get; set; }
    }
}
