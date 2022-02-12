using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class TipoTalle
    {
        public int IdTipoTalle { get; set; }
        public string DescripcionTipoTalle { get; set; }
        public Estado OEstado { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
