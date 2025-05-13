using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Modelos
{
    public class CertificadoAsistente
    {
        [Key] public int Codigo {  get; set; }

        [ForeignKey("CertificadoCodigo")]
        public int CertificadoCodigo { get; set; }

        [ForeignKey("AsistenteCodigo")]
        public int AsistenteCodigo { get; set; }
        public string Asistencia { get; set; }
        public Certificado? Certificado { get; set; }
        public Asistente? Asistente { get; set; }
       
    }
}
