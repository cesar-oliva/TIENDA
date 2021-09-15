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
    public class BD_RubroProducto
    {
        public static int RegistrarRubro(RubroProducto oRubro)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "INSERT INTO RubroProducto(Descripcion,Estado)" +
                                      "VALUES(@Descripcion,@Estado)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", oRubro.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", oRubro.OEstado);
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
        public static bool ActualizarRubro(RubroProducto oRubro, int IdRubroProducto)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE RubroProducto SET Descripcion = @Descripcion, Estado = @Estado  WHERE IdRubroProducto = @IdRubroProducto";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", oRubro.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", oRubro.OEstado);
                    cmd.Parameters.AddWithValue("IdRubroProducto", oRubro.IdRubroProducto);
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
        public static bool EliminarRubro(int IdRubro)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "DELETE FROM RubroProducto WHERE IdRubroProducto = @IdRubroProducto";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdRubroProducto", IdRubro);
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
        public static List<RubroProducto> MostrarRubro()
        {
            List<RubroProducto> rubroTabla = new List<RubroProducto>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT * FROM RubroProducto";
                    SqlDataAdapter adapterRubro = new SqlDataAdapter(SqlQuery, oConexion);
                    using (adapterRubro)
                    {
                        adapterRubro.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var rub = new RubroProducto
                            {
                                IdRubroProducto = Convert.ToInt32(data.Rows[i]["IdRubroProducto"]),
                                Descripcion = data.Rows[i]["Descripcion"].ToString(),
                                OEstado = Operaciones.BuscarEstado(data.Rows[i]["Estado"].ToString()),
                                FechaRegistro = Convert.ToDateTime(data.Rows[i]["FechaRegistro"])
                            };
                            rubroTabla.Add(rub);
                        }

                        return rubroTabla;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en Capa Datos: " + ex.Message);
                    return rubroTabla;
                }

            }
        }
        public static RubroProducto BuscarRubroProducto(RubroProducto oRubro)
        {
            List<RubroProducto> lista = new List<RubroProducto>();
            lista = BD_RubroProducto.MostrarRubro();
            foreach (var item in lista)
            {
                if (oRubro.IdRubroProducto.Equals(item.IdRubroProducto)) return item;
            }
            return null;
        }
        public static RubroProducto BuscarRubroProducto(string oRubro)
        {
            List<RubroProducto> lista = new List<RubroProducto>();
            lista = BD_RubroProducto.MostrarRubro();
            foreach (var item in lista)
            {
                if (item.Descripcion.Equals(oRubro)) return item;
            }
            return null;
        }
        public static RubroProducto BuscarRubroProducto(int oRubro)
        {
            List<RubroProducto> lista = new List<RubroProducto>();
            lista = BD_RubroProducto.MostrarRubro();
            foreach (var item in lista)
            {
                if (item.IdRubroProducto.Equals(oRubro)) return item;
            }
            return null;
        }
    }
}

