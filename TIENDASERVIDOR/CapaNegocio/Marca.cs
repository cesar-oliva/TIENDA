using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Marca
    {
        private int idMarca;
        private string descripcionMarca;
        private Estado oEstado;

        public int IdMarca { get => idMarca; set => idMarca = value; }
        public string DescripcionMarca { get => descripcionMarca; set => descripcionMarca = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }

        public Marca()
        {
        }

        public Marca(int idMarca, string descripcionMarca, Estado oEstado)
        {
            IdMarca = idMarca;
            DescripcionMarca = descripcionMarca;
            OEstado = oEstado;
        }

        public Marca(string descripcionMarca, Estado oEstado)
        {
            DescripcionMarca = descripcionMarca;
            OEstado = oEstado;
        }
    }
}
