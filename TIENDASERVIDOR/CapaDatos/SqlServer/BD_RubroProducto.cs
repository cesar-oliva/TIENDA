using CapaAbstraccion;
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
    public class BD_RubroProducto:ICrud<RubroProducto>
    {
        BD_Impuesto bd_Impuesto = new BD_Impuesto();    

        public int Registrar(RubroProducto oRubro)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "INSERT INTO RubroProducto(DescripcionRubroProducto,MargenGanancia,IdImpuesto)" +
                                      "VALUES(@DescripcionRubroProducto,@MargenGanancia,@IdImpuesto)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
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
        public bool Actualizar(RubroProducto oRubro)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE RubroProducto SET DescripcionRubroProducto = @DescripcionRubroProducto,MargenGanancia = @MargenGanancia, IdImpuesto = @IdImpuesto, Estado = @Estado  WHERE IdRubroProducto = @IdRubroProducto";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("DescripcionRubroProducto", oRubro.DescripcionRubroProducto);
                    cmd.Parameters.AddWithValue("MargenGanancia", oRubro.MargenGanancia);
                    cmd.Parameters.AddWithValue("IdImpuesto", oRubro.OImpuesto.IdImpuesto);
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
        public bool Eliminar(int IdRubro)
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
        public List<RubroProducto> Mostrar()
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
                                DescripcionRubroProducto = data.Rows[i]["DescripcionRubroProducto"].ToString(),
                                MargenGanancia = Convert.ToDouble(data.Rows[i]["MargenGanancia"].ToString()),
                                OImpuesto = bd_Impuesto.BuscarById(Convert.ToInt32(data.Rows[i]["IdImpuesto"].ToString())),
                                OEstado = Operaciones.BuscarByDescripcion(data.Rows[i]["Estado"].ToString()),
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
        
        public RubroProducto BuscarByDescripcion(string oDescripcionRubro)
        {
            List<RubroProducto> lista = Mostrar();
            foreach (var item in lista)
            {
                if (item.DescripcionRubroProducto.Equals(oDescripcionRubro)) return item;
            }
            return null;
        }
        public RubroProducto BuscarById(int oIdRubro)
        {
            List<RubroProducto> lista = Mostrar();
            foreach (var item in lista)
            {
                if (item.IdRubroProducto.Equals(oIdRubro)) return item;
            }
            return null;
        }
    }
}

