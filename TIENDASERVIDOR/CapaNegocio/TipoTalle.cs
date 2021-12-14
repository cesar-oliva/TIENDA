using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class TipoTalle
    {
        private int idTipoTalle;
        private string descripcion;
        private Estado oEstado;

        public int IdTipoTalle { get => idTipoTalle; set => idTipoTalle = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }

        public TipoTalle()
        {
        }
    }
}
