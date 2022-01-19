using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Talle
    {
        private int idTalle;
        private TipoTalle oTipoTalle;
        private RubroProducto oRubroProducto;
        private GeneroProducto oGeneroProducto;
        private string descripcionTalle;
        private Estado oEstado;
        private DateTime fechaRegistro;

        public int IdTalle { get => idTalle; set => idTalle = value; }
        public TipoTalle OTipoTalle { get => oTipoTalle; set => oTipoTalle = value; }
        public RubroProducto ORubroProducto { get => oRubroProducto; set => oRubroProducto = value; }
        public GeneroProducto OGeneroProducto { get => oGeneroProducto; set => oGeneroProducto = value; }
        public string DescripcionTalle { get => descripcionTalle; set => descripcionTalle = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }

        public Talle()
        {
        }
    }
}
