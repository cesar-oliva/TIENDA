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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceImpuesto" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceImpuesto.svc o ServiceImpuesto.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceImpuesto : IServiceImpuesto
    {
        public bool ActualizarImpuesto(DtoImpuesto oImpuesto)
        {
            string Descripcion = oImpuesto.Descripcion;
            double Alicuota = oImpuesto.Alicuota;
            string oEstado = oImpuesto.oEstado;
            var nuevo = new Impuesto(Descripcion,Alicuota, BuscarEstado(oEstado));

            if (BD_Impuesto.ActualizarImpuesto(nuevo))
            {
                return true;
            }
            else
            {

                return false;
            }
        }
        public bool EliminarImpuesto(int IdImpuesto)
        {
            return BD_Impuesto.EliminarImpuesto(IdImpuesto);
        }

        public bool IngresarImpuesto(DtoImpuesto oImpuesto)
        {
            string Descripcion = oImpuesto.Descripcion;
            double Alicuota = oImpuesto.Alicuota;
            string oEstado = oImpuesto.oEstado;
            var nuevo = new Impuesto(Descripcion,Alicuota, BuscarEstado(oEstado));

            //if (RepositorioProducto.agregarProducto(nuevo))
            if (BD_Impuesto.RegistrarImpuesto(nuevo) > 0)
            {
                return true;
            }
            else
            {

                return false;
            }
        }

        public List<DtoImpuesto> ListaImpuesto()
        {
            List<DtoImpuesto> lista = new List<DtoImpuesto>();
            foreach (var item in BD_Impuesto.MostrarImpuesto())
            {
                DtoImpuesto prod = new DtoImpuesto
                {
                    IdImpuesto = item.IdImpuesto,
                    Descripcion = item.Descripcion,
                    Alicuota = item.Alicuota,
                    oEstado = item.oEstado.ToString(),
                    FechaRegistro = item.FechaRegistro
                };
                lista.Add(prod);
            }
            return lista;
        }

        private Estado BuscarEstado(string oEstado)
        {
            if (oEstado.Equals("Activo")) return Estado.Activo;
            return Estado.Inactivo;
        }
        private GeneroProducto BuscarGenero(string oGenero)
        {
            if (oGenero.Equals("Unisex")) return GeneroProducto.Unisex;
            if (oGenero.Equals("Masculino")) return GeneroProducto.Masculino;
            return GeneroProducto.Femenino;
        }

    }
}
