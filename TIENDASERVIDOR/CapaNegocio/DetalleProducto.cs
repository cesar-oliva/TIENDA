using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class DetalleProducto
    {
        private int idDetalleProducto;
        private int idProducto;
        private int idTalleColor;
        private int stockProducto;
        private Estado oEstado;
        private DateTime fechaRegistro;

        public int IdDetalleProducto { get => idDetalleProducto; set => idDetalleProducto = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int IdTalleColor { get => idTalleColor; set => idTalleColor = value; }
        public int StockProducto { get => stockProducto; set => stockProducto = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }

        public DetalleProducto()
        {
        }
    }
    

}

