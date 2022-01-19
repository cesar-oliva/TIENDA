using CapaDatos.SqlServer;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CapaServicioServidor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceTalle" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceTalle.svc o ServiceTalle.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceTalle : IServiceTalle
    {
        public bool AgregarTalle(Talle oTalle)
        {
            var nuevo = new Talle
            {
                OTipoTalle = oTalle.OTipoTalle,
                ORubroProducto = oTalle.ORubroProducto,
                OGeneroProducto = oTalle.OGeneroProducto,   
                DescripcionTalle = oTalle.DescripcionTalle,
                OEstado = oTalle.OEstado
            };
            int i = BD_Talle.RegistrarTalle(nuevo);
            if (i != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EliminarTalle(int IdTalle)
        {
            return BD_Talle.EliminarTalle(IdTalle);
        }

        public List<DtoTalle> ListaTalle()
        {
            List<Talle> dato = BD_Talle.MostrarTalle();
            List<DtoTalle> tal = new List<DtoTalle>();
            foreach (var item in dato)
            {
                DtoTalle talle = new DtoTalle
                {
                    IdTalle = item.IdTalle,
                    OTipoTalle = item.OTipoTalle,
                    ORubroProducto = item.ORubroProducto,
                    OGeneroProducto = item.OGeneroProducto,
                    DescripcionTalle = item.DescripcionTalle,
                    OEstado = item.OEstado,
                };
                tal.Add(talle);
            }
            return tal;
        }

        public bool ModificarTalle(Talle oTalle, int IdTalle)
        {
            var nuevo = new Talle
            {
                IdTalle = oTalle.IdTalle,
                OTipoTalle = oTalle.OTipoTalle,
                ORubroProducto = oTalle.ORubroProducto,
                OGeneroProducto= oTalle.OGeneroProducto,
                DescripcionTalle = oTalle.DescripcionTalle,
                OEstado = oTalle.OEstado,
            };

            return BD_Talle.ActualizarTalle(nuevo, IdTalle);
        }

        public Talle ObtenerTalle(string Descripcion)
        {
            return BD_Talle.BuscarTalle(Descripcion);
        }
    }

}
