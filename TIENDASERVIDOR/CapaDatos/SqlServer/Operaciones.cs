using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CapaDatos
{
    public static class Operaciones
    {
        public static Estado BuscarByDescripcion(string descripcionEstado)
        {
            if (descripcionEstado.Equals("True")|| descripcionEstado.Equals("Activo"))
            {
                return Estado.Activo;
            }
            else
            {
                return Estado.Inactivo;
            }
        }
    }
}
