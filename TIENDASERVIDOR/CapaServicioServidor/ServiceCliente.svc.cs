using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CapaServicioServidor
{
    public class ServiceCliente : IServiceCliente
    {
        public bool EliminarCliente(int IdCliente)
        {
            return CapaDatos.BD_Cliente.EliminarCliente(IdCliente);
        }

        public bool AgregarCliente(DtoCliente oCliente)
        {
            var nuevo = new Cliente
            {
                Cuit = oCliente.Cuit,
                RazonSocial = oCliente.RazonSocial,
                OCondicionTributaria = oCliente.OCondicionTributaria,
                DomicilioFiscal = oCliente.DomicilioFiscal,
                OEstado = oCliente.OEstado
            };
            int i = CapaDatos.BD_Cliente.RegistrarCliente(nuevo);
            if (i != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<DtoCliente> ListaCliente()
        {
            List<Cliente> dato = CapaDatos.BD_Cliente.MostrarCliente();
            List<DtoCliente> cli = new List<DtoCliente>();
            foreach (var item in dato)
            {
                DtoCliente cliente = new DtoCliente
                {
                    IdCliente = item.IdCliente,
                    Cuit = item.Cuit,
                    RazonSocial = item.RazonSocial,
                    OCondicionTributaria = item.OCondicionTributaria,
                    DomicilioFiscal = item.DomicilioFiscal,
                    OEstado = item.OEstado
                };
                cli.Add(cliente);
            }
            return cli;
        }

        public bool ModificarCliente(DtoCliente oCliente)
        {
            throw new NotImplementedException();
        }
    }
}
