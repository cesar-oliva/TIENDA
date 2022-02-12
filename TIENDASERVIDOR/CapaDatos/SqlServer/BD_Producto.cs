
using CapaAbstraccion;
using CapaDatos.SqlServer;
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
    public class BD_Producto:ICrud<Producto>
    {
        // Declaro una instancia de clase
        BD_MarcaProducto bd_MarcaProducto = new BD_MarcaProducto();
        BD_RubroProducto bd_RubroProducto = new BD_RubroProducto();

        public int Registrar(Producto oProducto)
        {
            int respuesta;
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "INSERT INTO Producto(CodigoProducto,IdRubroProducto,DescripcionProducto,IdMarcaProducto,CostoProducto,Estado)" +
                                     "VALUES(@codigoProducto,@IdRubroProducto,@DescripcionProducto,@IdMarcaProducto,@CostoProducto,@Estado)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("CodigoProducto", oProducto.CodigoProducto);
                    cmd.Parameters.AddWithValue("IdRubroProducto", oProducto.ORubroProducto.IdRubroProducto);
                    cmd.Parameters.AddWithValue("DescripcionProducto", oProducto.DescripcionProducto);
                    cmd.Parameters.AddWithValue("IdMarcaProducto", oProducto.OMarcaProducto.IdMarcaProducto);
                    cmd.Parameters.AddWithValue("CostoProducto", oProducto.CostoProducto);
                    cmd.Parameters.AddWithValue("Estado", Estado.Activo);
                    oConexion.Open();
                    respuesta = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al Registrar el producto: " + ex.Message);
                    return 0;
                }
            }
            return respuesta;
        }
        #region ACTUALIZAR PRODUCTO
        public bool Actualizar(Producto oProducto)
        {
            bool respuesta = false;
            int cantidad;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "UPDATE PRODUCTO SET CodigoProducto=@CodigoProducto,IdRubroProducto=@IdRubroProducto,DescripcionProducto=@DescripcionProducto,IdMarcaProducto=@IdMarcaProducto," +
                                      "CostoProducto=@CostoProducto,Estado=@Estado WHERE IdProducto=@IdProducto";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("@CodigoProducto", oProducto.CodigoProducto);
                    cmd.Parameters.AddWithValue("@IdRubroProducto",oProducto.ORubroProducto.IdRubroProducto);
                    cmd.Parameters.AddWithValue("@DescripcionProducto", oProducto.DescripcionProducto);
                    cmd.Parameters.AddWithValue("@IdMarcaProducto", oProducto.OMarcaProducto.IdMarcaProducto);
                    cmd.Parameters.AddWithValue("@CostoProducto", oProducto.CostoProducto);
                    cmd.Parameters.AddWithValue("@Estado", Operaciones.BuscarByDescripcion(oProducto.OEstado.ToString()));
                    cmd.Parameters.AddWithValue("@IdProducto", oProducto.IdProducto);
                    oConexion.Open();
                    cantidad = cmd.ExecuteNonQuery();
                    if (cantidad == 1)
                    {
                        respuesta = true;
                        oConexion.Close();
                        return respuesta;
                    }
                    else
                    {
                        return respuesta;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en Actualizar Producto: " + ex.Message);
                    return respuesta;
                }
            }
        }
        #endregion
        public bool Eliminar(int IdProducto)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE Producto SET Estado = @Estado WHERE IdProducto = @IdProducto";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdProducto", IdProducto);
                    cmd.Parameters.AddWithValue("Estado", Estado.Inactivo);
                    oConexion.Open();
                    respuesta = cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en Eliminar Producto: " + ex.Message);
                    return false;

                }
            }
        }
        public List<Producto> Mostrar()
        {
            List<Producto> Tabla = new List<Producto>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "Select * from producto";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);

                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var prod = new Producto
                            {
                                IdProducto = Convert.ToInt32(data.Rows[i]["IdProducto"].ToString()),
                                CodigoProducto = data.Rows[i]["CodigoProducto"].ToString(),
                                ORubroProducto = bd_RubroProducto.BuscarById(Convert.ToInt32(data.Rows[i]["IdRubroProducto"].ToString())),
                                DescripcionProducto = data.Rows[i]["DescripcionProducto"].ToString(),
                                OMarcaProducto = bd_MarcaProducto.BuscarById(Convert.ToInt32(data.Rows[i]["IdMarcaProducto"].ToString())),
                                CostoProducto = Convert.ToDouble(data.Rows[i]["CostoProducto"].ToString()),
                                OEstado = Operaciones.BuscarByDescripcion(data.Rows[i]["Estado"].ToString()),
                                FechaRegistro = Convert.ToDateTime(data.Rows[i]["FechaRegistro"].ToString())
                            };
                            Tabla.Add(prod);
                        }
                    }
                    return Tabla;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en Mostrar Producto: "+ex.Message);
                    return Tabla;
                }

            }
        }
        public Producto BuscarByDescripcion(string oDescripcionProducto)
        {
            List<Producto> lista = Mostrar();
            foreach (var item in lista)
            {
                if (item.DescripcionProducto.Equals(oDescripcionProducto)) return item;
            }
            return null;
        }

        public Producto BuscarById(int oIdProducto)
        {
            List<Producto> lista = Mostrar();
            foreach (var item in lista)
            {
                if (item.IdProducto.Equals(oIdProducto)) return item;
            }
            return null;
        }
    }
}
