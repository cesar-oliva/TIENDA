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
        private RubroProducto oRubroProducto;
        private GeneroProducto oGeneroProducto;
        private string descripcionTipoTalle;
        private Estado oEstado;
        private DateTime fechaRegistro;

        public int IdTipoTalle { get => idTipoTalle; set => idTipoTalle = value; }
        public RubroProducto ORubroProducto { get; set; }
        public GeneroProducto OGeneroProducto { get; set; }
        public string DescripcionTipoTalle { get => descripcionTipoTalle; set => descripcionTipoTalle = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }

        public TipoTalle()
        {
        }
    }
}
