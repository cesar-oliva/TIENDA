using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CapaDatos.SqlServer
{
    public class BD_Rol
    {
        public static int RegistrarRol(Rol oRol)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "INSERT INTO Rol(Descripcion,Estado)" +
                                      "VALUES(@Descripcion,@Estado)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", oRol.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", oRol.OEstado);
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
        public static bool ActualizarRol(Rol oRol, int IdRol)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE ROL SET Descripcion = @Descripcion, Estado = @Estado  WHERE IdRol = @IdRol";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", oRol.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", oRol.OEstado);
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
        public static bool EliminarRol(int IdRol)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "DELETE FROM Rol WHERE IdRol = @IdRol";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdRol", IdRol);
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
        public static List<Rol> MostrarRol()
        {
            List<Rol> rolTabla = new List<Rol>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT * FROM ROL";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);
                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var rol = new Rol
                            {
                                IdRol = Convert.ToInt32(data.Rows[i]["IdRol"]),
                                Descripcion = Convert.ToString(data.Rows[i]["Descripcion"]),
                                OEstado = Operaciones.BuscarEstado(data.Rows[i]["Estado"].ToString()),
                                FechaRegistro = Convert.ToDateTime(data.Rows[i]["FechaRegistro"].ToString())
                            };
                            rolTabla.Add(rol);
                        }

                        return rolTabla;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en Capa Datos: " + ex.Message);
                    return rolTabla;
                }

            }
        }
        public static Rol BuscarRol(Rol oRol)
        {
            List<Rol> lista = new List<Rol>();
            lista = BD_Rol.MostrarRol();
            foreach (var item in lista)
            {
                if (oRol.IdRol.Equals(item.IdRol)) return item;
            }
            return null;
        }
        public static Rol BuscarRol(string descripcion)
        {
            List<Rol> lista = new List<Rol>();
            lista = BD_Rol.MostrarRol();
            foreach (var item in lista)
            {
                if (item.Descripcion.Equals(descripcion)) return item;
            }
            return null;
        }
        public static Rol BuscarRol(int idRol)
        {
            List<Rol> lista = new List<Rol>();
            lista = BD_Rol.MostrarRol();
            foreach (var item in lista)
            {
                if (item.IdRol.Equals(idRol)) return item;
            }
            return null;
        }
    }
}

