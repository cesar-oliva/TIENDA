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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceMarca" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceMarca.svc o ServiceMarca.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceMarca : IServiceCrud<DtoMarca>
    {
        BD_MarcaProducto bd_MarcaProducto = new BD_MarcaProducto();

        public bool Registrar(DtoMarca oMarca)
        {
            var m = new MarcaProducto
            {
                DescripcionMarcaProducto = oMarca.DescripcionMarcaProducto,
                OEstado = oMarca.OEstado
            };
            int i = bd_MarcaProducto.Registrar(m);
            if (i != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Eliminar(int IdMarca)
        {
            return bd_MarcaProducto.Eliminar(IdMarca);
        }
        public bool Actualizar(DtoMarca oMarca)
        {
            var m = new MarcaProducto
            {
                DescripcionMarcaProducto = oMarca.DescripcionMarcaProducto,
                OEstado = oMarca.OEstado,
            };

            return bd_MarcaProducto.Actualizar(m);

        }
        public List<DtoMarca> Mostrar()
        {
            List<MarcaProducto> dato = bd_MarcaProducto.Mostrar();
            List<DtoMarca> marc = new List<DtoMarca>();
            foreach (var item in dato)
            {
                DtoMarca marca = new DtoMarca
                {
                    IdMarcaProducto = item.IdMarcaProducto,
                    DescripcionMarcaProducto = item.DescripcionMarcaProducto,
                    OEstado = item.OEstado,
                };
                marc.Add(marca);
            }
            return marc;

        }

        public DtoMarca Formulario()
        {
            throw new NotImplementedException();
        }
    }
}
