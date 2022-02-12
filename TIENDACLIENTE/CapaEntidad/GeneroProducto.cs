using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class GeneroProducto
    { 
        public int IdGeneroProducto { get; set; }
        public string DescripcionGeneroProducto { get; set; }
        public Estado OEstado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
  

}
