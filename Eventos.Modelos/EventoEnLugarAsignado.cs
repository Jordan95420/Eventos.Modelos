using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Modelos
{
    public class EventoEnLugarAsignado
    {
        [Key] public int Codigo { get; set; }

        [ForeignKey("EventoCodigo")]
        public int EventoCodigo { get; set; }
        [ForeignKey("EspacioAsignadoCodigo")]
        public int EspacioAsignadoCodigo { get; set; }

        public Evento? Evento { get; set; }
        public EspacioAsignado? EspacioAsignado { get; set; }

    }
}
