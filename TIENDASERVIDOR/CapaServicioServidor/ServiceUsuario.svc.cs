using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CapaServicioServidor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceUsuario" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceUsuario.svc o ServiceUsuario.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceUsuario : IServiceUsuario
    {
        public bool AgregarUsuario(DtoUsuario oUsuario)
        {
            var nuevo = new Usuario
            {
                OEmpleado = oUsuario.OEmpleado,
                NombreUsuario = oUsuario.NombreUsuario,
                Contraseña = oUsuario.Contraseña,
                OTienda = oUsuario.OTienda,
                ORol = oUsuario.ORol,
                Email = oUsuario.Email,
                OEstado = oUsuario.OEstado
            };
            int i = CapaDatos.BD_Usuario.RegistrarUsuario(nuevo);
            if (i != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EliminarUsuario(int IdUsuario)
        {
            return CapaDatos.BD_Usuario.EliminarUsuario(IdUsuario);
        }

        public bool LoginUsuario(string usuario, string clave)
        {
            return CapaDatos.BD_Usuario.LoginUsuario(usuario, clave);
        }

        public bool ModificarUsuario(DtoUsuario oUsuario, int IdUsuario)
        {
            var nuevo = new Usuario
            {
                OEmpleado = oUsuario.OEmpleado,
                NombreUsuario = oUsuario.NombreUsuario,
                Contraseña = oUsuario.Contraseña,
                OTienda = oUsuario.OTienda,
                ORol = oUsuario.ORol,
                Email = oUsuario.Email,
                OEstado = oUsuario.OEstado
            };

            return CapaDatos.BD_Usuario.ActualizarUsuario(nuevo, IdUsuario);

        }
        public List<DtoUsuario> ObtenerUsuario()
        {
            List<Usuario> dato = CapaDatos.BD_Usuario.MostrarUsuario();
            List<DtoUsuario> user = new List<DtoUsuario>();
            foreach (var item in dato)
            {
                var usuario = new DtoUsuario
                {
                    IdUsuario = item.IdUsuario,
                    OEmpleado = item.OEmpleado,
                    NombreUsuario = item.NombreUsuario,
                    Contraseña = item.Contraseña,
                    OTienda = item.OTienda,
                    ORol = item.ORol,
                    Email = item.Email,
                    OEstado = item.OEstado,
                    FechaRegistro = item.FechaRegistro
                };
                user.Add(usuario);

            }
            return user;
        }
        public bool RecuperarContraseña(string usuario)
        {
            return CapaDatos.BD_Usuario.recoverPassword(usuario);
        }
    }
}
