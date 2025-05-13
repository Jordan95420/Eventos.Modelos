using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Modelos
{
    public class EspacioAsignado
    {
        [Key] public int Codigo { get; set; }
        public string Espacio { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFin {  get; set; } 

        public List<EventoEnLugarAsignado>? EventosEnLugaresAsignados { get; set; }
    }
}
