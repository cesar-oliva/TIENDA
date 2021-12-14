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
        private string codigoTalle;
        private string descripcionTalle;
        private Estado oEstado;

        public int IdTalle { get => idTalle; set => idTalle = value; }
        public TipoTalle OTipoTalle { get => oTipoTalle; set => oTipoTalle = value; }
        public string CodigoTalle { get => codigoTalle; set => codigoTalle = value; }
        public string DescripcionTalle { get => descripcionTalle; set => descripcionTalle = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }

        public Talle()
        {
        }

        public Talle(TipoTalle oTipoTalle,string codigoTalle, string descripcion, Estado oEstado)
        {
            OTipoTalle = oTipoTalle;
            CodigoTalle = codigoTalle;
            DescripcionTalle = descripcion;
            OEstado = oEstado;
        }
    }
}
