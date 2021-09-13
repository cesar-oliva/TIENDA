using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
   public class Organizacion
    {
        public int IdOrganizacion { get; set; }
        public string CUIT { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Contacto { get; set; }
        public Estado oEstado { get; set; }
        public DateTime FechaRegistro { get; set; }


    }
}
