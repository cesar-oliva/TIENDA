using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Rol
    {
        private int idRol;
        private string descripcion;
        private Estado oEstado;
        private DateTime fechaRegistro;

        public int IdRol { get => idRol; set => idRol = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }

        public Rol(int idRol, string descripcion, Estado oEstado, DateTime fechaRegistro)
        {
            IdRol = idRol;
            Descripcion = descripcion;
            OEstado = oEstado;
            FechaRegistro = fechaRegistro;
        }
        public Rol()
        {
        }
        public Rol(string descripcion, Estado oEstado)
        {
            Descripcion = descripcion;
            OEstado = oEstado;
        }
    }
}
