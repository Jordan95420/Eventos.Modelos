using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Modelos
{
    public class InscripcionAsistente
    {
        [Key] public int Codigo { get; set; }

        [ForeignKey("AsistenteCodigo")]
        public int AsistenteCodigo { get; set; }
        [ForeignKey("InscripcionCodigo")]
        public int InscripcionCodigo { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public Asistente? Asistente { get; set; }
        public Inscripcion? Inscripcion{ get; set; }

    }
}
