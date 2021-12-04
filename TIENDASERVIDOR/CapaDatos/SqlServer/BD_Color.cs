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
    public class BD_Color
    {
        public static int RegistrarColor(Color oColor)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "INSERT INTO Color(CodigoColor,DescripcionColor,Estado)" +
                                      "VALUES(@CodigoColor@DescripcionColor,@Estado)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("CodigoColor", oColor.CodigoColor);
                    cmd.Parameters.AddWithValue("DescripcionColor", oColor.DescripcionColor);
                    cmd.Parameters.AddWithValue("Estado", oColor.OEstado);
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
        public static bool ActualizarColor(Color oColor, int IdColor)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE Color SET CodigoColor = @CodigoColor,DescripcionColor = @DescripcionColor, Estado = @Estado  WHERE IdColor = @IdColor";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("CodigoColor", oColor.CodigoColor);
                    cmd.Parameters.AddWithValue("DescripcionColor", oColor.DescripcionColor);
                    cmd.Parameters.AddWithValue("Estado", oColor.OEstado);
                    cmd.Parameters.AddWithValue("IdColor", oColor.IdColor);
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
        public static bool EliminarColor(int IdColor)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "DELETE FROM Color WHERE IdColor = @IdColor";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdColor", IdColor);
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
        public static List<Color> MostrarColor()
        {
            List<Color> colorTabla = new List<Color>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT * FROM COLOR";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);
                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var color = new Color
                            {
                                IdColor = Convert.ToInt32(data.Rows[i]["IdColor"]),
                                CodigoColor = data.Rows[i]["CodigoColor"].ToString(),
                                DescripcionColor = data.Rows[i]["DescripcionColor"].ToString(),
                                OEstado = Operaciones.BuscarEstado(data.Rows[i]["Estado"].ToString()),
                            };
                            colorTabla.Add(color);
                        }

                        return colorTabla;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en Capa Datos: " + ex.Message);
                    return colorTabla;
                }

            }
        }
        public static Color BuscarColor(Color oColor)
        {
            List<Color> lista = MostrarColor();
            foreach (var item in lista)
            {
                if (oColor.IdColor.Equals(item.IdColor)) return item;
            }
            return null;
        }
        public static Color BuscarColor(string oColor)
        {
            List<Color> lista = MostrarColor();
            foreach (var item in lista)
            {
                if (item.DescripcionColor.Equals(oColor)) return item;
            }
            return null;
        }
        public static Color BuscarColor(int oColor)
        {
            List<Color> lista = MostrarColor();
            foreach (var item in lista)
            {
                if (item.IdColor.Equals(oColor)) return item;
            }
            return null;
        }
    }
}

