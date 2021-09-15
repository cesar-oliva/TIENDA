using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Usuario
    {
        private int idUsuario;
        private Empleado oEmpleado;
        private string nombreUsuario;
        private string contraseña;
        private Tienda oTienda;
        private Rol oRol;
        private string email;
        private Estado oEstado;
        private DateTime fechaRegistro;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public Empleado OEmpleado { get => oEmpleado; set => oEmpleado = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public Tienda OTienda { get => oTienda; set => oTienda = value; }
        public Rol ORol { get => oRol; set => oRol = value; }
        public string Email { get => email; set => email = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        

        public Usuario()
        {
        }

        public Usuario(int idUsuario, Empleado oEmpleado, string nombreUsuario, string contraseña, Tienda oTienda, Rol oRol, string email, Estado oEstado, DateTime fechaRegistro)
        {
            IdUsuario = idUsuario;
            OEmpleado = oEmpleado;
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            OTienda = oTienda;
            ORol = oRol;
            Email = email;
            OEstado = oEstado;
            FechaRegistro = fechaRegistro;
        }
        public Usuario(Empleado oEmpleado, string nombreUsuario, string contraseña, Tienda oTienda, Rol oRol, string email, Estado oEstado)
        {
            OEmpleado = oEmpleado;
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            OTienda = oTienda;
            ORol = oRol;
            Email = email;
            OEstado = oEstado;
        }
    }
}
