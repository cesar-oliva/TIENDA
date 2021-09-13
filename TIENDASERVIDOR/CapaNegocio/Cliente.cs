using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Cliente
    {
        private int idCliente;
        private string cuit;
        private string razonSocial;
        private CondicionTributaria oCondicionTributaria;
        private string domicilioFiscal;
        private Estado oEstado;
        private DateTime fechaRegistro;

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public string Cuit { get => cuit; set => cuit = value; }
        public CondicionTributaria OCondicionTributaria { get => oCondicionTributaria; set => oCondicionTributaria = value; }
        public string DomicilioFiscal { get => domicilioFiscal; set => domicilioFiscal = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }

        public Cliente(int idCliente, string razonSocial, string cuit, CondicionTributaria oCondicionTributaria, string domicilioFiscal, Estado oEstado, DateTime fechaRegistro)
        {
            IdCliente = idCliente;
            RazonSocial = razonSocial;
            Cuit = cuit;
            OCondicionTributaria = oCondicionTributaria;
            DomicilioFiscal = domicilioFiscal;
            OEstado = oEstado;
            FechaRegistro = fechaRegistro;
        }

        public Cliente(string razonSocial, string cuit, CondicionTributaria oCondicionTributaria, string domicilioFiscal, Estado oEstado)
        {
            RazonSocial = razonSocial;
            Cuit = cuit;
            OCondicionTributaria = oCondicionTributaria;
            DomicilioFiscal = domicilioFiscal;
            OEstado = oEstado;
        }

        public Cliente()
        {
        }
    }
}
