using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Modelos
{
    public class CertificadoPonente
    {
        [Key] public int Codigo { get; set; }

        [ForeignKey("CertificadoCodigo")]
        public int CertificadoCodigo { get; set; }

        [ForeignKey("PonenteCodigo")]
        public int PonenteCodigo { get; set; }
        public Certificado? Certificado { get; set; }
        public Ponente? Ponente { get; set; }
    }
}
