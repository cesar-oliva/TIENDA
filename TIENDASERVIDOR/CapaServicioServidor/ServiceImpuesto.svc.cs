using CapaDatos;
using CapaNegocio;
using System;
using System.Windows;
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
        public bool ModificarImpuesto(DtoImpuesto oImpuesto, int IdImpuesto)
        {
            var nuevo = new Impuesto
            {
                Descripcion = oImpuesto.Descripcion,
                Alicuota = oImpuesto.Alicuota,
                OEstado = oImpuesto.OEstado
            };

            return BD_Impuesto.ModificarImpuesto(nuevo,IdImpuesto);
        }
        public bool EliminarImpuesto(int IdImpuesto)
        {
            return BD_Impuesto.EliminarImpuesto(IdImpuesto);
        }

        public bool IngresarImpuesto(DtoImpuesto oImpuesto)
        {
            var nuevo = new Impuesto
            {
                Descripcion = oImpuesto.Descripcion,
                Alicuota = oImpuesto.Alicuota,
                OEstado = oImpuesto.OEstado
            };
            return BD_Impuesto.RegistrarImpuesto(nuevo);
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
                    OEstado = item.OEstado,
                    FechaRegistro = item.FechaRegistro
                };
                lista.Add(prod);
                
            }
            return lista;
        }

        public bool BuscarImpuestoById(int IdImpuesto)
        {
            return BuscarImpuestoById(IdImpuesto);
        }
    }
}
