using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class RubroProducto
    {
        public int IdRubroProducto { get; set; }
        public string CodigoRubroProducto { get; set; }
        public string DescripcionRubroProducto { get; set; }
        public double MargenGanancia { get; set; }
        public Impuesto OImpuesto { get; set; }
        public Estado OEstado { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
