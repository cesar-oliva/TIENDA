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
        private string codigoCondicionTributaria;
        private string descripcionCondicionTributaria;
        private Estado oEstado;
        private DateTime fechaRegistro;

        public int IdCondicionTributaria { get => idCondicionTributaria; set => idCondicionTributaria = value; }
        public string CodigoCondicionTributaria { get => codigoCondicionTributaria; set => codigoCondicionTributaria = value; }
        public string DescripcionCondicionTributaria { get => descripcionCondicionTributaria; set => descripcionCondicionTributaria = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }

        public CondicionTributaria(string codigoCondicionTributaria, string descripcionCondicionTributaria, Estado oEstado)
        {
            CodigoCondicionTributaria = codigoCondicionTributaria;
            DescripcionCondicionTributaria = descripcionCondicionTributaria;
            OEstado = oEstado;
        }
        public CondicionTributaria(int idCondicionTributaria, string codigoCondicionTributaria, string descripcionCondicionTributaria, Estado oEstado, DateTime FechaRegistro)
        {
            IdCondicionTributaria = idCondicionTributaria;
            CodigoCondicionTributaria = codigoCondicionTributaria;
            DescripcionCondicionTributaria = descripcionCondicionTributaria;
            OEstado = oEstado;
            fechaRegistro = FechaRegistro;
        }
        public CondicionTributaria()
        {
        }
    }
}
