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
    public class BD_Talle
    {

        public static int RegistrarTalle(Talle oTalle)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "INSERT INTO Talle(IdTalle,IdTipoTalle,IdRubroProducto,IdGeneroProducto,DescripcionTalle)" +
                                      "VALUES(@IdTalle,@IdTipoTalle,@IdRubroProducto,@IdGeneroProducto,@DescripcionTalle)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdTalle", oTalle.IdTalle);
                    cmd.Parameters.AddWithValue("IdTipoTalle", oTalle.OTipoTalle.IdTipoTalle);
                    cmd.Parameters.AddWithValue("IdRubroProducto", oTalle.ORubroProducto.IdRubroProducto);
                    cmd.Parameters.AddWithValue("IdGeneroProducto", oTalle.OGeneroProducto.IdGeneroProducto);
                    cmd.Parameters.AddWithValue("DescripcionTalle", oTalle.DescripcionTalle);
                    cmd.Parameters.AddWithValue("Estado", oTalle.OEstado);
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
        public static bool ActualizarTalle(Talle oTalle, int IdTalle)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE Talle SET IdTipooTalle = @IdTipoTalle, IdRubroProducto = @IdRubroProducto,IdGeneroProducto = @IdGeneroProducto, DescripcionTalle = @DescripcionTalle, Estado = @Estado  WHERE IdTalle = @IdTalle";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdTalle", IdTalle);
                    cmd.Parameters.AddWithValue("IdTipoTalle", oTalle.OTipoTalle.IdTipoTalle);
                    cmd.Parameters.AddWithValue("IdRubroProducto", oTalle.ORubroProducto.IdRubroProducto);
                    cmd.Parameters.AddWithValue("IdGeneroProducto", oTalle.OGeneroProducto.IdGeneroProducto);
                    cmd.Parameters.AddWithValue("DescripcionTalle", oTalle.DescripcionTalle);                  
                    cmd.Parameters.AddWithValue("Estado", oTalle.OEstado);
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
        public static bool EliminarTalle(int IdTalle)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE Talle SET Estado = @Estado WHERE IdTalle = @IdTalle";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdTalle", IdTalle);
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
        public static List<Talle> MostrarTalle()
        {
            List<Talle> talleTabla = new List<Talle>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT * FROM TALLE";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);
                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var talle = new Talle
                            {
                                IdTalle = Convert.ToInt32(data.Rows[i]["IdTalle"]),
                                OTipoTalle = BD_TipoTalle.BuscarTipoTalleById(Convert.ToInt32(data.Rows[i]["IdTipoTalle"])),
                                ORubroProducto = BD_RubroProducto.BuscarRubroProductoById(Convert.ToInt32(data.Rows[i]["IdRubroProducto"])),
                                OGeneroProducto = BD_GeneroProducto.BuscarGeneroProductoById(Convert.ToInt32(data.Rows[i]["IdGeneroProducto"])),
                                DescripcionTalle = data.Rows[i]["DescripcionTalle"].ToString(),
                                OEstado = Operaciones.BuscarEstado(data.Rows[i]["Estado"].ToString()),
                            };
                            talleTabla.Add(talle);
                        }

                        return talleTabla;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en Capa Datos: " + ex.Message);
                    return talleTabla;
                }

            }
        }
        public static Talle BuscarTalle(Talle oTalle)
        {
            List<Talle> lista = MostrarTalle();
            foreach (var item in lista)
            {
                if (oTalle.IdTalle.Equals(item.IdTalle)) return item;
            }
            return null;
        }
        public static Talle BuscarTalle(string Descripcion)
        {
            List<Talle> lista = MostrarTalle();
            foreach (var item in lista)
            {
                if (item.DescripcionTalle.Equals(Descripcion)) return item;
            }
            return null;
        }
        public static Talle BuscarTalle(int IdTalle)
        {
            List<Talle> lista = MostrarTalle();
            foreach (var item in lista)
            {
                if (item.IdTalle.Equals(IdTalle)) return item;
            }
            return null;
        }
    }

}

