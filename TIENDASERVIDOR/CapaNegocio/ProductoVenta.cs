using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ProductoVenta
    {
        private Color oColor;
        private Talle oTalle;
        private double costo;
        private int cantidad;
        private Estado oEstado;
        private DateTime fechaRegistro;

        public Color OColor{ get => oColor; set => oColor = value; }
        public Talle OTalle { get => oTalle; set => oTalle = value; }
        public double Costo { get => costo; set => costo = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }

        public ProductoVenta()
        {
        }


       
    }
    

}

