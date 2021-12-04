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
        private string codigoTalle;
        private string descripcionTalle;
        private Estado oEstado;

        public int IdTalle { get => idTalle; set => idTalle = value; }
        public string CodigoTalle { get => codigoTalle; set => codigoTalle = value; }
        public string DescripcionTalle { get => descripcionTalle; set => descripcionTalle = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }

        public Talle()
        {
        }

        public Talle(string codigoTalle, string descripcion, Estado oEstado)
        {
            CodigoTalle = codigoTalle;
            DescripcionTalle = descripcion;
            OEstado = oEstado;
        }
    }
}
