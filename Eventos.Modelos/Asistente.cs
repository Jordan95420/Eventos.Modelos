using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Modelos
{
    public class Asistente
    {
        [Key] public int Codigo {  get; set; }
        public string  Nombre { get; set; }
        public string Apellido { get; set; }
        public string Tipo { get; set; }

    }
}
