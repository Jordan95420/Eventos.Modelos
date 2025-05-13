using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Modelos
{
    public class Certificado
    {
        [Key] public int Codigo { get; set; }
        public string Tipo { get; set; }

        [ForeignKey("EventoCodigo")]
        public int EventoCodigo { get; set; }

        public Evento? Eventos { get; set; }
    }
}
