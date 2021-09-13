using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Tienda { get; set; }
        public string Rol { get; set; }
        public Estado oEstado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
