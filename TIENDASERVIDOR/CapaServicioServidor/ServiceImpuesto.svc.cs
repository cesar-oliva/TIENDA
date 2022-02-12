using CapaDatos;
using CapaNegocio;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CapaServicioServidor.DataObjectTransfer.Impuesto;

namespace CapaServicioServidor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceImpuesto" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceImpuesto.svc o ServiceImpuesto.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceImpuesto : IServiceCrud<DtoImpuesto>
    {
        BD_Impuesto bd_Impuesto = new BD_Impuesto();

        public bool Actualizar(DtoImpuesto oImpuesto)
        {
            var nuevo = new Impuesto
            {
                IdImpuesto = oImpuesto.IdImpuesto,
                Descripcion = oImpuesto.Descripcion,
                Alicuota = oImpuesto.Alicuota,
                OEstado = oImpuesto.OEstado
            };

            return bd_Impuesto.Actualizar(nuevo);
        }
        public bool Eliminar(int IdImpuesto)
        {
            return bd_Impuesto.Eliminar(IdImpuesto);
        }

        public bool Registrar(DtoImpuesto oImpuesto)
        {
            var nuevo = new Impuesto
            {
                Descripcion = oImpuesto.Descripcion,
                Alicuota = oImpuesto.Alicuota,
                OEstado = oImpuesto.OEstado
            };
            if (bd_Impuesto.Actualizar(nuevo))
            {
                return true;
            }
            else
            {

                return false;
            }
       }

        public List<DtoImpuesto> Mostrar()
        {
            List<DtoImpuesto> lista = new List<DtoImpuesto>();
            foreach (var item in bd_Impuesto.Mostrar())
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
    }
}
