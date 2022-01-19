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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceTipoTipoTalle" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceTipoTipoTalle.svc o ServiceTipoTipoTalle.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceTipoTalle : IServiceTipoTalle
    {
       public bool AgregarTipoTalle(TipoTalle oTipoTalle)
        {
            var nuevo = new TipoTalle
            {
                DescripcionTipoTalle = oTipoTalle.DescripcionTipoTalle,
                OEstado = oTipoTalle.OEstado
            };
            int i = BD_TipoTalle.RegistrarTipoTalle(nuevo);
            if (i != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EliminarTipoTalle(int IdTipoTalle)
        {
            return BD_TipoTalle.EliminarTipoTalle(IdTipoTalle);
        }

        public List<DtoTipoTalle> ListaTipoTalle()
        {
            List<TipoTalle> dato = BD_TipoTalle.MostrarTipoTalle();
            List<DtoTipoTalle> tal = new List<DtoTipoTalle>();
            foreach (var item in dato)
            {
                DtoTipoTalle TipoTalle = new DtoTipoTalle
                {
                    IdTipoTalle = item.IdTipoTalle,
                    DescripcionTipoTalle = item.DescripcionTipoTalle,
                    OEstado = item.OEstado,
                };
                tal.Add(TipoTalle);
            }
            return tal;
        }

        public bool ModificarTipoTalle(TipoTalle oTipoTalle, int IdTipoTalle)
        {
            var nuevo = new TipoTalle
            {
                IdTipoTalle = oTipoTalle.IdTipoTalle,
                DescripcionTipoTalle = oTipoTalle.DescripcionTipoTalle,
                OEstado = oTipoTalle.OEstado,
            };

            return BD_TipoTalle.ActualizarTipoTalle(nuevo, IdTipoTalle);
        }

        public TipoTalle ObtenerTipoTalleByDescripcion(string Descripcion)
        {
            return BD_TipoTalle.BuscarTipoTalleByDescripcion(Descripcion);
        }
    }

}

