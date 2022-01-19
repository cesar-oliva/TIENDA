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
    public class BD_GeneroProducto
    {
        public static int RegistrarGeneroProducto(GeneroProducto oGeneroProducto)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "INSERT INTO GeneroProducto(DescripcionGeneroProducto)VALUES(@DescripcionGeneroProducto)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("DescripcionGeneroProducto", oGeneroProducto.DescripcionGeneroProducto);
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
        public static bool ActualizarGeneroProducto(GeneroProducto oGeneroProducto, int IdGeneroProducto)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE GeneroProducto SET DescripcionGeneroProducto = @DescripcionGeneroProducto, Estado = @Estado  WHERE IdGeneroProducto = @IdGeneroProducto";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdGeneroProducto", IdGeneroProducto);
                    cmd.Parameters.AddWithValue("DescripcionGeneroProducto", oGeneroProducto.DescripcionGeneroProducto);
                    cmd.Parameters.AddWithValue("Estado", oGeneroProducto.OEstado);
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
        public static bool EliminarGeneroProducto(int IdGeneroProducto)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE GeneroProducto SET Estado = @Estado WHERE IdGeneroProducto = @IdGeneroProducto";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdGeneroProducto", IdGeneroProducto);
                    cmd.Parameters.AddWithValue("Estado", Estado.Inactivo);
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
        public static List<GeneroProducto> MostrarGeneroProducto()
        {
            List<GeneroProducto> GeneroProductoTabla = new List<GeneroProducto>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT * FROM GeneroProducto";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);
                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var marc = new GeneroProducto
                            {
                                IdGeneroProducto = Convert.ToInt32(data.Rows[i]["IdGeneroProducto"]),
                                DescripcionGeneroProducto = data.Rows[i]["DescripcionGeneroProducto"].ToString(),
                                OEstado = Operaciones.BuscarEstado(data.Rows[i]["Estado"].ToString()),
                                FechaRegistro = Convert.ToDateTime(data.Rows[i]["FechaRegistro"])
                            };
                            GeneroProductoTabla.Add(marc);
                        }

                        return GeneroProductoTabla;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en Capa Datos: " + ex.Message);
                    return GeneroProductoTabla;
                }

            }
        }
        public static GeneroProducto BuscarGeneroProducto(GeneroProducto oGeneroProducto)
        {
            List<GeneroProducto> lista = MostrarGeneroProducto();
            foreach (var item in lista)
            {
                if (oGeneroProducto.IdGeneroProducto.Equals(item.IdGeneroProducto)) return item;
            }
            return null;
        }
        public static GeneroProducto BuscarGeneroProductoByDescripcion(string oGeneroProducto)
        {
            List<GeneroProducto> lista = MostrarGeneroProducto();
            foreach (var item in lista)
            {
                if (item.DescripcionGeneroProducto.Equals(oGeneroProducto)) return item;
            }
            return null;
        }
        public static GeneroProducto BuscarGeneroProductoById(int oGeneroProducto)
        {
            List<GeneroProducto> lista = MostrarGeneroProducto();
            foreach (var item in lista)
            {
                if (item.IdGeneroProducto.Equals(oGeneroProducto)) return item;
            }
            return null;
        }
    }
}
