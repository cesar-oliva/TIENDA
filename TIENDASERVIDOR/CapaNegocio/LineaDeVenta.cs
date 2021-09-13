using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class LineaDeVenta
    {
        public int IdLineaDeVenta { get; set; }
        public Venta oVenta { get; set; }
        public Producto oProducto { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double ImporteSubtotal { get; set; }
    }
}
