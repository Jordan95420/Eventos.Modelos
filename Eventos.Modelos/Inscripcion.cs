using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Modelos
{
    public class Inscripcion
    {
        [Key]public int Codigo { get; set; }

        [ForeignKey("EventoCodigo")]
        public int EventoCodigo { get; set; }
       
        public DateTime FechaInicioEvento { get; set; }
        public DateTime FechaFinEvento { get; set; }


        public Evento? Evento { get; set; }

    }
}
