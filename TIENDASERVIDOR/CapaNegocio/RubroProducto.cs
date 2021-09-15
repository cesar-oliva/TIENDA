using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class RubroProducto
    {
        private int idRubroProducto;
        private string descripcion;
        private Estado oEstado;
        private DateTime fechaRegistro;

        public int IdRubroProducto { get => idRubroProducto; set => idRubroProducto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }

        public RubroProducto()
        {
        }
    }
}
