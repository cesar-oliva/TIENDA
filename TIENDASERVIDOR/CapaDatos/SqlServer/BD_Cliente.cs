using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CapaDatos
{
    public class BD_Cliente
    {
        public static int RegistrarCliente(Cliente oCliente)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "INSERT INTO Cliente(RazonSocial,Cuit,IdCondicionTributaria,DomicilioFiscal,Estado) VALUES(@RazonSocial,@Cuit,@IdCondicionTributaria,@Estado)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("RazonSocial", oCliente.RazonSocial);
                    cmd.Parameters.AddWithValue("Cuit", oCliente.Cuit);
                    cmd.Parameters.AddWithValue("IdCondicionTributaria", oCliente.OCondicionTributaria);
                    cmd.Parameters.AddWithValue("Estado", oCliente.OEstado);
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
        public static List<Cliente> MostrarCliente()
        {
            List<Cliente> clienteTabla = new List<Cliente>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT * FROM CLIENTE";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);

                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var user = new Cliente
                            {
                                IdCliente = Convert.ToInt32(data.Rows[i]["IdUsuario"]),
                                RazonSocial = data.Rows[i]["RazonSocial"].ToString(),
                                OCondicionTributaria = BD_CondicionTributaria.BuscarCondicionTributaria(Convert.ToInt32(data.Rows[i]["IdCondicionTributaria"])),
                                OEstado = Operaciones.BuscarEstado(data.Rows[i]["Estado"].ToString()),
                                FechaRegistro = Convert.ToDateTime(data.Rows[i]["FechaRegistro"])
                            };
                            clienteTabla.Add(user);
                        }

                        return clienteTabla;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return clienteTabla;
                }

            }
        }
        //public static bool ActualizarUsuario(Usuario oUsuario, int IdUsuario)
        //{
        //    int respuesta;
        //    using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
        //    {
        //        try
        //        {
        //            String SqlQuery = "UPDATE Usuario SET NombreUsuario = @NombreUsuario,Contraseña = @Contraseña,IdTienda = @IdTienda, IdRol = @IdRol,Estado = @Estado WHERE idUsuario = @IdUsuario";
        //            SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
        //            cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
        //            cmd.Parameters.AddWithValue("NombreUsuario", oUsuario.NombreUsuario);
        //            cmd.Parameters.AddWithValue("Contraseña", oUsuario.Contraseña);
        //            cmd.Parameters.AddWithValue("Tienda", oUsuario.Tienda);
        //            cmd.Parameters.AddWithValue("Rol", oUsuario.Rol);
        //            cmd.Parameters.AddWithValue("Estado", oUsuario.oEstado);
        //            oConexion.Open();
        //            respuesta = cmd.ExecuteNonQuery();
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //            return false;
        //        }
        //    }
        //}
        //public static bool EliminarUsuario(int IdUsuario)
        //{
        //    int respuesta;
        //    using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
        //    {
        //        try
        //        {
        //            String SqlQuery = "DELETE FROM Usuario WHERE IdUsuario = @IdUsuario";
        //            SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
        //            cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
        //            oConexion.Open();
        //            respuesta = cmd.ExecuteNonQuery();
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //            return false;

        //        }
        //    }
        //}

        //public static Usuario BuscarUsuario(Usuario oUsuario)
        //{
        //    List<Usuario> lista = new List<Usuario>();
        //    lista = MostrarUsuario();
        //    foreach (var item in lista)
        //    {
        //        if (oUsuario.IdUsuario.Equals(item.IdUsuario)) return item;
        //    }
        //    return null;
        //}
        public static Cliente BuscarCliente(string razonSocial)
        {
            List<Cliente> lista = MostrarCliente();
            foreach (var item in lista)
            {
                if (item.RazonSocial.Equals(razonSocial)) return item;
            }
            return null;
        }
        public static Cliente BuscarCliente(int idCliente)
        {
            List<Cliente> lista = MostrarCliente();
            foreach (var item in lista)
            {
                if (item.IdCliente.Equals(idCliente)) return item;
            }
            return null;
        }
    }
}
