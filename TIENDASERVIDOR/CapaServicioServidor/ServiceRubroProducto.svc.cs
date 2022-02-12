using CapaAbstraccion;
using CapaDatos;
using CapaNegocio;
using CapaServicioServidor.DataObjectTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CapaServicioServidor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceRubroProducto" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceRubroProducto.svc o ServiceRubroProducto.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceRubroProducto : IServiceCrud<DtoRubroProducto>
    {
        BD_RubroProducto bd_RubroProducto = new BD_RubroProducto();
        BD_Impuesto bd_Impuesto = new BD_Impuesto();

        public bool Registrar(DtoRubroProducto oDtoRubroProducto)
        {
            var nuevo = new RubroProducto
            {
                DescripcionRubroProducto = oDtoRubroProducto.DescripcionRubroProducto,
                MargenGanancia = oDtoRubroProducto.MargenGanancia,
                OImpuesto = bd_Impuesto.BuscarByDescripcion(oDtoRubroProducto.DescripcionImpuesto),
                OEstado = Operaciones.BuscarByDescripcion(oDtoRubroProducto.DescripcionEstado)
            };
            int i = bd_RubroProducto.Registrar(nuevo);
            if (i != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Eliminar(int IdRubroProducto)
        {
            return bd_RubroProducto.Eliminar(IdRubroProducto);
        }

        public bool Actualizar(DtoRubroProducto oDtoRubroProducto)
        {
            var nuevo = new RubroProducto
            {
                DescripcionRubroProducto = oDtoRubroProducto.DescripcionRubroProducto,
                MargenGanancia = oDtoRubroProducto.MargenGanancia,
                OImpuesto = bd_Impuesto.BuscarByDescripcion(oDtoRubroProducto.DescripcionImpuesto),
                OEstado = Operaciones.BuscarByDescripcion(oDtoRubroProducto.DescripcionEstado)
            };

            return bd_RubroProducto.Actualizar(nuevo);

        }

        public List<DtoRubroProducto> Mostrar()
        {
            List<RubroProducto> dato = bd_RubroProducto.Mostrar();
            List<DtoRubroProducto> rub = new List<DtoRubroProducto>();
            foreach (var item in dato)
            {
                DtoRubroProducto RubroProducto = new DtoRubroProducto
                {
                    IdRubroProducto = item.IdRubroProducto,
                    DescripcionRubroProducto = item.DescripcionRubroProducto,
                    MargenGanancia = item.MargenGanancia,
                    DescripcionImpuesto = item.OImpuesto.Descripcion,
                    DescripcionEstado = item.OEstado.ToString(),
                    FechaRegistro = item.FechaRegistro
                };
                rub.Add(RubroProducto);
            }
            return rub;

        }
        public RubroProducto BuscarByDescripcion(string DescripcionRubroProducto)
        {
            return bd_RubroProducto.BuscarByDescripcion(DescripcionRubroProducto);
        }
        public RubroProducto BuscarById(int idRubroProducto)
        {
            return bd_RubroProducto.BuscarById(idRubroProducto);
        }
    }
}
