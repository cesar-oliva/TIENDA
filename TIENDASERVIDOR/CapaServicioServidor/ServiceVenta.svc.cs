using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CapaServicioServidor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceVenta" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceVenta.svc o ServiceVenta.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceVenta : IServiceVenta
    {
        public bool GenerarVenta(DtoVenta oVenta)
        {
            var nuevo = new Venta
            {
                OComprobante = oVenta.OComprobante,
                OSucursal = oVenta.OSucursal,
                OUsuario = oVenta.OUsuario,
                OCliente = oVenta.OCliente,
                OLineaDeVenta = oVenta.OLineaDeVenta,
                CantidadProducto = oVenta.CantidadProducto,
                ImporteTotalDeVenta = oVenta.ImporteTotalDeVenta,
                OFormaDePago = oVenta.OFormaDePago
            };
            int i = CapaDatos.BD_Venta.RegistrarVenta(nuevo);
            if (i != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<DtoVenta> ListaVenta()
        {
            throw new NotImplementedException();
        }

        public Venta ObtenerVenta(string oVenta)
        {
            throw new NotImplementedException();
        }

        public Venta ObtenerVenta(int oVenta)
        {
            throw new NotImplementedException();
        }
    }
}
