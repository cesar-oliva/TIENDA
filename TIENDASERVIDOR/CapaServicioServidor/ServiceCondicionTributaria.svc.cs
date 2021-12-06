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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceCondicionTributaria" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceCondicionTributaria.svc o ServiceCondicionTributaria.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceCondicionTributaria : IServiceCondicionTributaria
    {
        public bool AgregarCondicionTributaria(DtoCondicionTributaria oCondicionTributaria)
        {
            var nuevo = new CondicionTributaria
            {
                CodigoCondicionTributaria = oCondicionTributaria.CodigoCondicionTributaria,
                DescripcionCondicionTributaria = oCondicionTributaria.DescripcionCondicionTributaria,
                OEstado = oCondicionTributaria.OEstado
            };
            int i = BD_CondicionTributaria.RegistrarCondicionTributaria(nuevo);
            if (i != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EliminarCondicionTributaria(int IdCondicionTributaria)
        {
            return BD_CondicionTributaria.EliminarCondicionTributaria(IdCondicionTributaria);
        }
        public bool ModificarCondicionTributaria(DtoCondicionTributaria oCondicionTributaria)
        {
            var nuevo = new CondicionTributaria
            {
                CodigoCondicionTributaria = oCondicionTributaria.CodigoCondicionTributaria,
                DescripcionCondicionTributaria = oCondicionTributaria.DescripcionCondicionTributaria,
                OEstado = oCondicionTributaria.OEstado
            };

            return BD_CondicionTributaria.ActualizarCondicionTributaria(nuevo, oCondicionTributaria.IdCondicionTributaria);

        }

        public List<DtoCondicionTributaria> ListaCondicionTributaria()
        {
            List<CondicionTributaria> dato = CapaDatos.BD_CondicionTributaria.MostrarCondicionTributaria();
            List<DtoCondicionTributaria> cond = new List<DtoCondicionTributaria>();
            foreach (var item in dato)
            {
                DtoCondicionTributaria CondicionTributaria = new DtoCondicionTributaria
                {
                    IdCondicionTributaria = item.IdCondicionTributaria,
                    CodigoCondicionTributaria = item.CodigoCondicionTributaria,
                    DescripcionCondicionTributaria = item.DescripcionCondicionTributaria,
                    OEstado = item.OEstado,
                    FechaRegistro = item.FechaRegistro
                };
                cond.Add(CondicionTributaria);
            }
            return cond;

        }
        public CondicionTributaria ObtenerCondicionTributariaByDescripcion(string oCondicionTributaria)
        {
            return BD_CondicionTributaria.BuscarCondicionTributariaByDescripcion(oCondicionTributaria);
        }
        public CondicionTributaria ObtenerCondicionTributariaById(int oCondicionTributaria)
        {
            return BD_CondicionTributaria.BuscarCondicionTributariaById(oCondicionTributaria);
        }
        public Estado ObtenerEstadoByDescripcion(string oEstado)
        {
            if (oEstado.Equals("Activo")) return Estado.Activo;
            return Estado.Inactivo;
        }
    }
}

