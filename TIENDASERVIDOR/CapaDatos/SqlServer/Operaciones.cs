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
        public static int BuscarEstado(Estado oEstado)
        {
            if (oEstado.Equals(Estado.Activo)) return 0;
            return 1;
        }
        public static int BuscarGenero(GeneroProducto oGenero)
        {
            if (oGenero.Equals(GeneroProducto.Unisex)) return 0;
            if (oGenero.Equals(GeneroProducto.Masculino)) return 1;
            return 2;
        }
        public static Estado BuscarEstado(string oEstado)
        {
            if (oEstado.Equals("False")) return Estado.Activo;
            return Estado.Inactivo;
        }
        public static Estado BuscarEstado(int oEstado)
        {
            if (oEstado.Equals(0)) return Estado.Activo;
            return Estado.Inactivo;
        }
        public static GeneroProducto BuscarGenero(string oGenero)
        {
            if (oGenero.Equals("Unisex")) return GeneroProducto.Unisex;
            if (oGenero.Equals("Masculino")) return GeneroProducto.Masculino;
            return GeneroProducto.Femenino;
        }
        
    }
}
