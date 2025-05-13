using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Modelos
{
    public class InscripcionPonente
    {
        [Key] public int Codigo { get; set; }

        [ForeignKey("InscripcionCodigo")]
        public int InscripcionCodigo { get; set; }

        [ForeignKey("PonenteCodigo")]
        public int PonenteCodigo { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public Ponente? Ponente { get; set; }
        public Inscripcion? Inscripcion { get; set; }
    }
}
