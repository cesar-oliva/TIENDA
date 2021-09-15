using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CapaDatos
{
    public class BD_Usuario
    {
        public static int RegistrarUsuario(Usuario oUsuario)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "INSERT INTO Usuario(IdEmpleado,NombreUsuario,Contraseña,IdTienda,IdRol,Email,Estado) VALUES(@IdEmpleado,@NombreUsuario,@Contraseña,@IdTienda,@IdRol,@Email,@Estado)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdEmpleado", oUsuario.OEmpleado.IdEmpleado);
                    cmd.Parameters.AddWithValue("NombreUsuario", oUsuario.NombreUsuario);
                    cmd.Parameters.AddWithValue("Contraseña", oUsuario.Contraseña);
                    cmd.Parameters.AddWithValue("Tienda", oUsuario.OTienda.IdTienda);
                    cmd.Parameters.AddWithValue("Rol", oUsuario.ORol.IdRol);
                    cmd.Parameters.AddWithValue("Email", oUsuario.Email);
                    cmd.Parameters.AddWithValue("Estado", oUsuario.OEstado);
                    oConexion.Open();
                    respuesta = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }

            }
            return respuesta;
        }
        public static List<Usuario> MostrarUsuario()
        {
            List<Usuario> usuarioTabla = new List<Usuario>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT * FROM Usuario";
                    SqlDataAdapter adapterUsuario = new SqlDataAdapter(SqlQuery, oConexion);

                    using (adapterUsuario)
                    {
                        adapterUsuario.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var user = new Usuario
                            {
                                IdUsuario = Convert.ToInt32(data.Rows[i]["IdUsuario"]),
                                //OEmpleado = BuscarEmpleado(Convert.ToInt32(data.Rows[i]["IdEmpleado"])),
                                NombreUsuario = data.Rows[i]["NombreUsuario"].ToString(),
                                Contraseña = data.Rows[i]["Contraseña"].ToString(),
                                //OTienda = BuscarTienda(Convert.ToInt32(data.Rows[i]["IdTienda"])),
                                //ORol = BuscarRol(Convert.ToInt32(data.Rows[i]["IdRol"])),
                                Email = data.Rows[i]["Email"].ToString(),
                                OEstado = BuscarEstado(data.Rows[i]["Estado"].ToString()),
                                FechaRegistro = Convert.ToDateTime(data.Rows[i]["FechaRegistro"])
                            };
                            usuarioTabla.Add(user);
                        }

                        return usuarioTabla;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return usuarioTabla;
                }

            }
        }
        public static bool ActualizarUsuario(Usuario oUsuario, int IdUsuario)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE Usuario SET NombreUsuario = @NombreUsuario,Contraseña = @Contraseña,IdTienda = @IdTienda, IdRol = @IdRol,Estado = @Estado WHERE idUsuario = @IdUsuario";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
                    cmd.Parameters.AddWithValue("IdEmpleado", oUsuario.OEmpleado.IdEmpleado);
                    cmd.Parameters.AddWithValue("NombreUsuario", oUsuario.NombreUsuario);
                    cmd.Parameters.AddWithValue("Contraseña", oUsuario.Contraseña);
                    cmd.Parameters.AddWithValue("Tienda", oUsuario.OTienda.IdTienda);
                    cmd.Parameters.AddWithValue("Rol", oUsuario.ORol.IdRol);
                    cmd.Parameters.AddWithValue("Email", oUsuario.Email);
                    cmd.Parameters.AddWithValue("Estado", oUsuario.OEstado);
                    oConexion.Open();
                    respuesta = cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }
        public static bool EliminarUsuario(int IdUsuario)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "DELETE FROM Usuario WHERE IdUsuario = @IdUsuario";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
                    oConexion.Open();
                    respuesta = cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;

                }
            }
        }
        public static bool LoginUsuario(String usuario, String contraseña)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT Contraseña FROM USUARIO WHERE NombreUsuario=@NombreUsuario";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("NombreUsuario", usuario);
                    oConexion.Open();
                    string dato = Convert.ToString(cmd.ExecuteScalar());
                    if (dato.Equals(contraseña))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;

                }
            }
        }
        public static bool recoverPassword(string userRequesting)
        {
            using(SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT *FROM USUARIO WHERE NombreUsuario=@NombreUsuario or Email=@Email";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("@NombreUsuario", userRequesting);
                    cmd.Parameters.AddWithValue("@Email", userRequesting);
                    oConexion.Open();
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()==true)
                    {
                        string NombreUsuario = reader.GetString(2);
                        string MailUsuario = reader.GetString(5);
                        string contraseña = reader.GetString(3);
                        var mailService = new MailServices.MailSupport();
                        mailService.sendMail(
                            subject:"SYSTEM: Password recovery request",
                            body: "Hi,"+NombreUsuario+"\nYou Requested to Recover your password. \n"+
                            "your current pasword is: "+contraseña+
                            "\n However, we ask that you change your password inmediately once you enter the system.",
                            recipientMail: new List<string> { MailUsuario}
                            );
                        MessageBox.Show("Hola, " + NombreUsuario + "\n Su contraseña se ha enviado por correo");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado una cuenta con el usuario declarado");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }
        public static Usuario BuscarUsuario(Usuario oUsuario)
        {
            List<Usuario> lista = new List<Usuario>();
            lista = MostrarUsuario();
            foreach (var item in lista)
            {
                if (oUsuario.IdUsuario.Equals(item.IdUsuario)) return item;
            }
            return null;
        }
        public static Usuario BuscarUsuario(string oUsuario)
        {
            List<Usuario> lista = new List<Usuario>();
            lista = MostrarUsuario();
            foreach (var item in lista)
            {
                if (item.NombreUsuario.Equals(oUsuario)) return item;
            }
            return null;
        }
        public static Usuario BuscarUsuario(int oUsuario)
        {
            List<Usuario> lista = new List<Usuario>();
            lista = MostrarUsuario();
            foreach (var item in lista)
            {
                if (item.IdUsuario.Equals(oUsuario)) return item;
            }
            return null;
        }
        private static Estado BuscarEstado(string valor)
        {
            if (valor.Equals("Activo"))
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
