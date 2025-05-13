using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Modelos
{
    public class Pago
    {
        [Key] public int Codigo { get; set; }

        [ForeignKey("InscripcionAsistenteCodigo")]
        public int InscripcionAsistenteCodigo { get; set; }
        public string TipoDePago { get; set; }
        public string Estado { get; set; }
        public InscripcionAsistente? InscripcionAsistente { get; set; }


    }
}
