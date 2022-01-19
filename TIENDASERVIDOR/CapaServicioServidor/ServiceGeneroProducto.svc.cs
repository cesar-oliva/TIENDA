using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CapaServicioServidor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceGeneroProducto" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceGeneroProducto.svc o ServiceGeneroProducto.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceGeneroProducto : IServiceGeneroProducto
    {
        public bool AgregarGeneroProducto(DtoGeneroProducto oGeneroProducto)
        {
            var nuevo = new GeneroProducto
            {
                DescripcionGeneroProducto = oGeneroProducto.DescripcionGeneroProducto,
                OEstado = oGeneroProducto.OEstado
            };
            int i = CapaDatos.BD_GeneroProducto.RegistrarGeneroProducto(nuevo);
            if (i != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EliminarGeneroProducto(int IdGeneroProducto)
        {
            return CapaDatos.BD_GeneroProducto.EliminarGeneroProducto(IdGeneroProducto);
        }
        public bool ModificarGeneroProducto(DtoGeneroProducto oGeneroProducto, int IdGeneroProducto)
        {
            var nuevo = new GeneroProducto
            {
                DescripcionGeneroProducto = oGeneroProducto.DescripcionGeneroProducto,
                OEstado = oGeneroProducto.OEstado,
            };

            return CapaDatos.BD_GeneroProducto.ActualizarGeneroProducto(nuevo, IdGeneroProducto);

        }
        public List<DtoGeneroProducto> ListaGeneroProducto()
        {
            List<GeneroProducto> dato = CapaDatos.BD_GeneroProducto.MostrarGeneroProducto();
            List<DtoGeneroProducto> marc = new List<DtoGeneroProducto>();
            foreach (var item in dato)
            {
                DtoGeneroProducto GeneroProducto = new DtoGeneroProducto
                {
                    IdGeneroProducto = item.IdGeneroProducto,
                    DescripcionGeneroProducto = item.DescripcionGeneroProducto,
                    OEstado = item.OEstado,
                };
                marc.Add(GeneroProducto);
            }
            return marc;

        }
        public GeneroProducto ObtenerGeneroProducto(string oGeneroProducto)
        {
            return BD_GeneroProducto.BuscarGeneroProductoByDescripcion(oGeneroProducto);
        }
    }
}

