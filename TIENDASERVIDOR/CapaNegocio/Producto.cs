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
        private double impuesto;
        private double costo;
        private double margenGanancia;
        private double netoGravado;
        private double precioVenta;
        private Estado oEstado;
        private DateTime fechaRegistro;

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public GeneroProducto OGeneroProducto { get => oGeneroProducto; set => oGeneroProducto = value; }
        public RubroProducto ORubroProducto { get => oRubroProducto; set => oRubroProducto = value; }
        public Marca OMarca { get => oMarca; set => oMarca = value; }
        public double Impuesto { get => impuesto; set => impuesto = value; }
        public double Costo { get => costo; set => costo = value; }
        public double MargenGanancia { get => margenGanancia; set => margenGanancia = value; }
        public double NetoGravado { get => netoGravado; set => netoGravado = value; }
        public double PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }


        public Producto(string codigo, string descripcion, GeneroProducto oGeneroProducto, RubroProducto oRubroProducto, Marca marca, double impuesto, double costo, double margenGanancia, double netoGravado, double precioVenta, Estado oEstado)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            this.OGeneroProducto = oGeneroProducto;
            this.ORubroProducto = oRubroProducto;
            this.OMarca = marca;
            Impuesto = impuesto;
            Costo = costo;
            MargenGanancia = margenGanancia;
            NetoGravado = netoGravado;
            PrecioVenta = precioVenta;
            this.OEstado = oEstado;
        }

        public Producto(int idProducto, string codigo, string descripcion, GeneroProducto oGeneroProducto, RubroProducto oRubroProducto, Marca marca, double impuesto, double costo, double margenGanancia, double netoGravado, double precioVenta, Estado oEstado)
        {
            IdProducto = idProducto;
            Codigo = codigo;
            Descripcion = descripcion;
            this.OGeneroProducto = oGeneroProducto;
            this.ORubroProducto = oRubroProducto;
            this.OMarca = marca;
            Impuesto = impuesto;
            Costo = costo;
            MargenGanancia = margenGanancia;
            NetoGravado = netoGravado;
            PrecioVenta = precioVenta;
            this.OEstado = oEstado;
        }

        public Producto()
        {
        }

    }
}
