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
        private string descripcion;
        private Estado oEstado;

        public int IdMarca { get => idMarca; set => idMarca = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }

        public Marca()
        {
        }

        public Marca(int idMarca, string descripcion, Estado oEstado)
        {
            IdMarca = idMarca;
            Descripcion = descripcion;
            OEstado = oEstado;
        }

        public Marca(string descripcion, Estado oEstado)
        {
            Descripcion = descripcion;
            OEstado = oEstado;
        }
    }
}
