using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class MarcaProducto
    {
        private int idMarcaProducto;
        private string descripcionMarcaProducto;
        private Estado oEstado;

        public int IdMarcaProducto { get => idMarcaProducto; set => idMarcaProducto = value; }
        public string DescripcionMarcaProducto { get => descripcionMarcaProducto; set => descripcionMarcaProducto = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }

        public MarcaProducto()
        {
        }
    }
}
