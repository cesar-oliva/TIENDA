using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class  GeneroProducto
    {
        private int idGeneroProducto;
        private string descripcionGeneroProducto;
        private Estado oEstado;
        private DateTime fechaRegistro;

        public int IdGeneroProducto { get => idGeneroProducto; set => idGeneroProducto = value; }
        public string DescripcionGeneroProducto { get => descripcionGeneroProducto; set => descripcionGeneroProducto = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }

        public GeneroProducto()
        {
        }
    }
}
