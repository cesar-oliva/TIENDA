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
        private string codigoProducto;
        private RubroProducto oRubroProducto;
        private string descripcionProducto;
        private MarcaProducto oMarcaProducto;
        private double costoProducto;
        private Estado oEstado;
        private DateTime fechaRegistro;

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string CodigoProducto { get => codigoProducto; set => codigoProducto = value; }
        public RubroProducto ORubroProducto { get => oRubroProducto; set => oRubroProducto = value; }
        public string DescripcionProducto { get => descripcionProducto; set => descripcionProducto = value; }
        public MarcaProducto OMarcaProducto { get => oMarcaProducto; set => oMarcaProducto = value; }
        public double CostoProducto { get => costoProducto; set => costoProducto = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }

        public Producto()
        {
        }


    }

}
