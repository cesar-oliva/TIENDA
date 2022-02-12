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
    public class BD_TipoTalle
    {
        BD_RubroProducto bd_RubroProducto = new BD_RubroProducto();

        public static int RegistrarTipoTalle(TipoTalle oTipoTalle)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "INSERT INTO TipoTalle(IdRubroProducto,IdGeneroProducto,DescripcionTipoTalle)VALUES(@IdRubroProducto,@IdGeneroProducto,@DescripcionTipoTalle)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdRubroProducto", oTipoTalle.ORubroProducto.IdRubroProducto);
                    cmd.Parameters.AddWithValue("IdGeneroProducto", oTipoTalle.OGeneroProducto.IdGeneroProducto);
                    cmd.Parameters.AddWithValue("DescripcionTipoTalle", oTipoTalle.DescripcionTipoTalle);

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
        public static bool ActualizarTipoTalle(TipoTalle oTipoTalle, int IdTipoTalle)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE TipoTalle SET IdRubroProducto = @ IdRubroProducto, IdGeneroProducto = @IdGeneroProducto,DescripcionTipotalle = @DescripcionTipoTalle, Estado = @Estado  WHERE IdTipoTalle = @IdTipoTalle";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdTipoTalle", IdTipoTalle);
                    cmd.Parameters.AddWithValue("IdRubroProducto", oTipoTalle.ORubroProducto.IdRubroProducto);
                    cmd.Parameters.AddWithValue("IdGeneroProducto", oTipoTalle.OGeneroProducto.IdGeneroProducto);
                    cmd.Parameters.AddWithValue("DescripcionTipoTalle", oTipoTalle.DescripcionTipoTalle);                  
                    cmd.Parameters.AddWithValue("Estado", oTipoTalle.OEstado);
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
        public static bool EliminarTipoTalle(int IdTipoTalle)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE TipoTalle SET Estado = @Estado WHERE IdTipoTalle = @IdTipoTalle";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdTipoTalle", IdTipoTalle);
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
        public static List<TipoTalle> MostrarTipoTalle()
        {
            List<TipoTalle> TipoTalleTabla = new List<TipoTalle>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT * FROM TipoTalle";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);
                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var TipoTalle = new TipoTalle
                            {
                                IdTipoTalle = Convert.ToInt32(data.Rows[i]["IdTipoTalle"]),
                                OGeneroProducto = BD_GeneroProducto.BuscarGeneroProductoById(Convert.ToInt32(data.Rows[i]["IdGeneroProducto"])),
                               
                                //ORubroProducto = bd_RubroProducto.BuscarById(Convert.ToInt32(data.Rows[i]["IdRubroProducto"])),
                                DescripcionTipoTalle = data.Rows[i]["DescripcionTipoTalle"].ToString(),
                                OEstado = Operaciones.BuscarByDescripcion(data.Rows[i]["Estado"].ToString()),
                                FechaRegistro = Convert.ToDateTime(data.Rows[i]["FechaRegistro"].ToString()),
                            };
                            TipoTalleTabla.Add(TipoTalle);
                        }

                        return TipoTalleTabla;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en Capa Datos: " + ex.Message);
                    return TipoTalleTabla;
                }

            }
        }
        public static TipoTalle BuscarTipoTalle(TipoTalle oTipoTalle)
        {
            List<TipoTalle> lista = MostrarTipoTalle();
            foreach (var item in lista)
            {
                if (oTipoTalle.IdTipoTalle.Equals(item.IdTipoTalle)) return item;
            }
            return null;
        }
        public static TipoTalle BuscarTipoTalleByDescripcion(string Descripcion)
        {
            List<TipoTalle> lista = MostrarTipoTalle();
            foreach (var item in lista)
            {
                if (item.DescripcionTipoTalle.Equals(Descripcion)) return item;
            }
            return null;
        }
        public static TipoTalle BuscarTipoTalleById(int IdTipoTalle)
        {
            List<TipoTalle> lista = MostrarTipoTalle();
            foreach (var item in lista)
            {
                if (item.IdTipoTalle.Equals(IdTipoTalle)) return item;
            }
            return null;
        }
    }

}

