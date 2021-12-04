using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class LineaDeVenta
    {
        private int idLineaDeVenta;
        private Venta oVenta;
        private Producto oProducto;
        private int cantidad;    
        private double precioUnitario;
        private double importeSubtotal;

        public int IdLineaDeVenta { get => idLineaDeVenta; set => idLineaDeVenta = value; }
        public Venta OVenta { get => oVenta; set => oVenta = value; }
        public Producto OProducto { get => oProducto; set => oProducto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        //public double ImporteSubtotal { get => importeSubtotal; set => importeSubtotal = value; }

        public LineaDeVenta()
        {
        }
    }
}
