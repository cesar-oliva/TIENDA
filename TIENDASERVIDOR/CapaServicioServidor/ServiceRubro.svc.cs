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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceRubro" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceRubro.svc o ServiceRubro.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceRubro : IServiceRubro
    {
        public bool AgregarRubro(DtoRubro oRubro)
        {
            var nuevo = new RubroProducto
            {
                Descripcion = oRubro.Descripcion,
                OEstado = oRubro.oEstado
            };
            //MessageBox.Show("Usuario cargadado");
            int i = CapaDatos.BD_RubroProducto.RegistrarRubro(nuevo);
            if (i != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EliminarRubro(int IdRubro)
        {
            return CapaDatos.BD_RubroProducto.EliminarRubro(IdRubro);
        }
        public bool ModificarRubro(DtoRubro oRubro, int IdRubro)
        {
            var nuevo = new RubroProducto
            {
                Descripcion = oRubro.Descripcion,
                OEstado = oRubro.oEstado,
            };

            return CapaDatos.BD_RubroProducto.ActualizarRubro(nuevo, IdRubro);

        }
        private DtoRubro ConvertirRubro(RubroProducto rubro)
        {
            var rub = new DtoRubro
            {
                IdRubro = Convert.ToInt32(rubro.IdRubroProducto),
                Descripcion = rubro.Descripcion,
                oEstado = rubro.OEstado,
                FechaRegistro = Convert.ToDateTime(rubro.FechaRegistro)
            };
            return rub;
        }

        public List<DtoRubro> ListaRubro()
        {
            List<RubroProducto> dato = CapaDatos.BD_RubroProducto.MostrarRubro();
            List<DtoRubro> rub = new List<DtoRubro>();
            foreach (var item in dato)
            {
                DtoRubro rubro = new DtoRubro
                {
                    IdRubro = item.IdRubroProducto,
                    Descripcion = item.Descripcion,
                    oEstado = item.OEstado,
                    FechaRegistro = item.FechaRegistro
                };
                rub.Add(rubro);
            }
            return rub;

        }
        public RubroProducto ObtenerRubro(string oRubro)
        {
            return BD_RubroProducto.BuscarRubroProducto(oRubro);
        }
    }
}
