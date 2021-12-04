using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Producto
    {
        private int idProducto;
        private string codigo;
        private string descripcion;
        private GeneroProducto oGeneroProducto;
        private RubroProducto oRubroProducto;
        private Marca oMarca;
        private Color oColor;
        private Talle oTalle;
        private double costo;
        private Estado oEstado;
        private DateTime fechaRegistro;

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public GeneroProducto OGeneroProducto { get => oGeneroProducto; set => oGeneroProducto = value; }
        public RubroProducto ORubroProducto { get => oRubroProducto; set => oRubroProducto = value; }
        public Marca OMarca { get => oMarca; set => oMarca = value; }
        public Color OColor { get => oColor; set => oColor = value; }
        public Talle OTalle { get => oTalle; set => oTalle = value; }
        public double Costo { get => costo; set => costo = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }

        public Producto(int idProducto, string codigo, string descripcion, GeneroProducto oGeneroProducto, RubroProducto oRubroProducto, Marca oMarca, Color oColor, Talle oTalle, double costo, Estado oEstado)
        {
            IdProducto = idProducto;
            Codigo = codigo;
            Descripcion = descripcion;
            OGeneroProducto = oGeneroProducto;
            ORubroProducto = oRubroProducto;
            OMarca = oMarca;
            OColor = oColor;
            OTalle = oTalle;
            Costo = costo;
            OEstado = oEstado;
        }

        public Producto(string codigo, string descripcion, GeneroProducto oGeneroProducto, RubroProducto oRubroProducto, Marca oMarca, Color oColor, Talle oTalle, double costo, Estado oEstado)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            OGeneroProducto = oGeneroProducto;
            ORubroProducto = oRubroProducto;
            OMarca = oMarca;
            OColor = oColor;
            OTalle = oTalle;
            Costo = costo;
            OEstado = oEstado;
        }

        public Producto()
        {
        }

    }
}
