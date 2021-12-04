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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceColor" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceColor.svc o ServiceColor.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceColor : IServiceColor
    {
        public bool AgregarColor(Color oColor)
        {
            var nuevo = new Color
            {
                CodigoColor = oColor.CodigoColor,
                DescripcionColor = oColor.DescripcionColor,
                OEstado = oColor.OEstado
            };
            int i = BD_Color.RegistrarColor(nuevo);
            if (i != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EliminarColor(int IdColor)
        {
            return BD_Color.EliminarColor(IdColor);
        }

        public List<DtoColor> ListaColor()
        {
            List<Color> dato = BD_Color.MostrarColor();
            List<DtoColor> color = new List<DtoColor>();
            foreach (var item in dato)
            {
                DtoColor Color = new DtoColor
                {
                    IdColor = item.IdColor,
                    CodigoColor = item.CodigoColor,
                    DescripcionColor = item.DescripcionColor,
                    OEstado = item.OEstado,
                };
                color.Add(Color);
            }
            return color;
        }

        public bool ModificarColor(Color oColor, int IdColor)
        {
            var nuevo = new Color
            {
                IdColor = oColor.IdColor,
                CodigoColor = oColor.CodigoColor,
                DescripcionColor = oColor.DescripcionColor,
                OEstado = oColor.OEstado,
            };

            return BD_Color.ActualizarColor(nuevo, IdColor);
        }

        public Color ObtenerColor(string Descripcion)
        {
            return BD_Color.BuscarColor(Descripcion);
        }
    }
}
            

