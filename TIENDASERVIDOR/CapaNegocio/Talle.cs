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
        private RubroProducto oRubroProducto;
        private string siglaInternacional;
        private string descripcion;
        private Estado oEstado;

        public int IdTalle { get => idTalle; set => idTalle = value; }
        public RubroProducto ORubroProducto { get => oRubroProducto; set => oRubroProducto = value; }
        public string SiglaInternacional { get => siglaInternacional; set => siglaInternacional = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }

        public Talle()
        {
        }

        public Talle(RubroProducto oRubroProducto, string siglaInternacional, string descripcion, Estado oEstado)
        {
            ORubroProducto = oRubroProducto;
            SiglaInternacional = siglaInternacional;
            Descripcion = descripcion;
            OEstado = oEstado;
        }
    }
}
