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
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public string Timestamp { get; set; }
       
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public string Tag { get; set; }
        public string Valor { get; set; }
    }
}
