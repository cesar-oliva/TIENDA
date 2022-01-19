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
        private string descripcionTipoTalle;
        private Estado oEstado;
        private DateTime fechaRegistro;

        public int IdTipoTalle { get => idTipoTalle; set => idTipoTalle = value; }
        public string DescripcionTipoTalle { get => descripcionTipoTalle; set => descripcionTipoTalle = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }

        public TipoTalle()
        {
        }
    }
}
