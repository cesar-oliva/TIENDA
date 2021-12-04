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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceRubroProducto" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceRubroProducto.svc o ServiceRubroProducto.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceRubroProducto : IServiceRubroProducto
    {
        public bool AgregarRubroProducto(DtoRubroProducto oRubroProducto)
        {
            var nuevo = new RubroProducto
            {
                CodigoRubroProducto = oRubroProducto.CodigoRubroProducto,
                DescripcionRubroProducto = oRubroProducto.DescripcionRubroProducto,
                MargenGanancia = oRubroProducto.MargenGanancia,
                OImpuesto = oRubroProducto.OImpuesto,
                OEstado = oRubroProducto.OEstado
            };
            int i = CapaDatos.BD_RubroProducto.RegistrarRubroProducto(nuevo);
            if (i != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EliminarRubroProducto(int IdRubroProducto)
        {
            return CapaDatos.BD_RubroProducto.EliminarRubroProducto(IdRubroProducto);
        }
        public bool ModificarRubroProducto(DtoRubroProducto oRubroProducto)
        {
            var nuevo = new RubroProducto
            {
                CodigoRubroProducto = oRubroProducto.CodigoRubroProducto,
                DescripcionRubroProducto = oRubroProducto.DescripcionRubroProducto,
                MargenGanancia = oRubroProducto.MargenGanancia,
                OImpuesto = oRubroProducto.OImpuesto,
                OEstado = oRubroProducto.OEstado
            };

            return CapaDatos.BD_RubroProducto.ActualizarRubroProducto(nuevo, oRubroProducto.IdRubroProducto);

        }

        public List<DtoRubroProducto> ListaRubroProducto()
        {
            List<RubroProducto> dato = CapaDatos.BD_RubroProducto.MostrarRubroProducto();
            List<DtoRubroProducto> rub = new List<DtoRubroProducto>();
            foreach (var item in dato)
            {
                DtoRubroProducto RubroProducto = new DtoRubroProducto
                {
                    IdRubroProducto = item.IdRubroProducto,
                    CodigoRubroProducto = item.CodigoRubroProducto,
                    DescripcionRubroProducto = item.DescripcionRubroProducto,
                    MargenGanancia = item.MargenGanancia,
                    OImpuesto = item.OImpuesto,
                    OEstado = item.OEstado,
                    FechaRegistro = item.FechaRegistro
                };
                rub.Add(RubroProducto);
            }
            return rub;

        }
        public RubroProducto ObtenerRubroProductoByDescripcion(string oRubroProducto)
        {
            return BD_RubroProducto.BuscarRubroProductoByDescripcion(oRubroProducto);
        }
        public RubroProducto ObtenerRubroProductoById(int oRubroProducto)
        {
            return BD_RubroProducto.BuscarRubroProductoById(oRubroProducto);
        }
        public Estado ObtenerEstadoByDescripcion(string oEstado)
        {
            if (oEstado.Equals("Activo")) return Estado.Activo;
            return Estado.Inactivo;
        }

        public Impuesto ObtenerImpuestoById(int oImpuesto)
        {
            return BD_Impuesto.BuscarImpuestoById(oImpuesto);
        }
        public Impuesto ObtenerImpuestoByDescripcion(string oImpuesto)
        {
            return BD_Impuesto.BuscarImpuestoByDescripcion(oImpuesto);
        }
    }
}
