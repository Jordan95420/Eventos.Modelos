using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Modelos
{
    public class PonenteEvento
    {
        [Key]
        public int Codigo { get; set; }

        // Claves foráneas
        [ForeignKey("PonenteCodigo")]
        public int PonenteCodigo { get; set; }

        [ForeignKey("EventoCodigo")]
        public int EventoCodigo { get; set; }

        // Propiedades de navegación
        public Ponente? Ponente { get; set; }
        public Evento? Evento { get; set; }
    }
}
