using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CondicionTributaria
    {
        private int idCondicionTributaria;
        private string codigo;
        private string descripcion;
        private Estado oEstado;
        private DateTime fechaRegistro;

        public int IdCondicionTributaria { get => idCondicionTributaria; set => idCondicionTributaria = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }

        public CondicionTributaria(string codigo, string descripcion, Estado oEstado)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            OEstado = oEstado;
        }
        public CondicionTributaria(int idCondicionTributaria, string codigo, string descripcion, Estado oEstado, DateTime FechaRegistro)
        {
            IdCondicionTributaria = idCondicionTributaria;
            Codigo = codigo;
            Descripcion = descripcion;
            OEstado = oEstado;
            fechaRegistro = FechaRegistro;
        }
        public CondicionTributaria()
        {
        }
    }
}
