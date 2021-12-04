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
        public static int RegistrarRubroProducto(RubroProducto oRubro)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "INSERT INTO RubroProducto(CodigoRubroProducto,DescripcionRubroProducto,MargenGanancia,IdImpuesto,Estado)" +
                                      "VALUES(@CodigoRubroProducto,@DescripcionRubroProducto,@MargenGanancia,@IdImpuesto,@Estado)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("CodigoRubroProducto", oRubro.CodigoRubroProducto);
                    cmd.Parameters.AddWithValue("DescripcionRubroProducto", oRubro.DescripcionRubroProducto);
                    cmd.Parameters.AddWithValue("MargenGanancia", oRubro.MargenGanancia);
                    cmd.Parameters.AddWithValue("IdImpuesto", oRubro.OImpuesto.IdImpuesto);
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
        public static bool ActualizarRubroProducto(RubroProducto oRubro, int IdRubroProducto)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE RubroProducto SET CodigoRubroProducto = @CodigoRubroProducto, DescripcionRubroProducto = @DescripcionRubroProducto,MargenGanancia = @MargenGanancia, IdImpuesto = @IdImpuesto, Estado = @Estado  WHERE IdRubroProducto = @IdRubroProducto";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("CodigoRubroProducto", oRubro.CodigoRubroProducto);
                    cmd.Parameters.AddWithValue("DescripcionRubroProducto", oRubro.DescripcionRubroProducto);
                    cmd.Parameters.AddWithValue("MargenGanancia", oRubro.MargenGanancia);
                    cmd.Parameters.AddWithValue("IdImpuesto", oRubro.OImpuesto.IdImpuesto);
                    cmd.Parameters.AddWithValue("Estado", oRubro.OEstado);
                    cmd.Parameters.AddWithValue("IdRubroProducto", IdRubroProducto);
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
        public static bool EliminarRubroProducto(int IdRubro)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE RubroProducto SET Estado = @Estado WHERE IdRubroProducto = @IdRubroProducto";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdRubroProducto", IdRubro);
                    cmd.Parameters.AddWithValue("Estado",Estado.Inactivo);
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
        public static List<RubroProducto> MostrarRubroProducto()
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
                                CodigoRubroProducto = data.Rows[i]["CodigoRubroProducto"].ToString(),   
                                DescripcionRubroProducto = data.Rows[i]["DescripcionRubroProducto"].ToString(),
                                MargenGanancia = Convert.ToDouble(data.Rows[i]["MargenGanancia"].ToString()),
                                OImpuesto = BD_Impuesto.BuscarImpuestoById(Convert.ToInt32(data.Rows[i]["IdImpuesto"].ToString())),
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
            List<RubroProducto> lista = MostrarRubroProducto();
            foreach (var item in lista)
            {
                if (oRubro.IdRubroProducto.Equals(item.IdRubroProducto)) return item;
            }
            return null;
        }
        public static RubroProducto BuscarRubroProductoByDescripcion(string oRubro)
        {
            List<RubroProducto> lista = MostrarRubroProducto();
            foreach (var item in lista)
            {
                if (item.DescripcionRubroProducto.Equals(oRubro)) return item;
            }
            return null;
        }
        public static RubroProducto BuscarRubroProductoById(int oRubro)
        {
            List<RubroProducto> lista = MostrarRubroProducto();
            foreach (var item in lista)
            {
                if (item.IdRubroProducto.Equals(oRubro)) return item;
            }
            return null;
        }
    }
}

