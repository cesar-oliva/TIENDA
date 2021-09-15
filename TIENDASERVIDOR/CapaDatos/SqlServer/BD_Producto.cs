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
    public class BD_Producto
    {
        public static int RegistrarProducto(Producto oProducto)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "INSERT INTO Producto(Codigo,Descripcion,GeneroProducto,IdRubroProducto,IdMarca,IdImpuesto,Costo,MargenGanancia,NetoGravado,PrecioVenta,Estado)" +
                                     "VALUES(@codigo,@Descripcion,@GeneroProducto,@IdRubroProducto,@IdMarca,@IdImpuesto,@Costo,@MargenGanancia,@NetoGravado,@PrecioVenta,@Estado)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("Codigo", oProducto.Codigo);
                    cmd.Parameters.AddWithValue("Descripcion", oProducto.Descripcion);
                    cmd.Parameters.AddWithValue("GeneroProducto", Operaciones.BuscarGenero(oProducto.OGeneroProducto));
                    cmd.Parameters.AddWithValue("IdRubroProducto", BD_RubroProducto.BuscarRubroProducto(oProducto.Rubro).IdRubroProducto);
                    cmd.Parameters.AddWithValue("IdMarca", BD_Marca.BuscarMarca(oProducto.OMarca).IdMarca);
                    cmd.Parameters.AddWithValue("IdImpuesto", oProducto.Impuesto);
                    cmd.Parameters.AddWithValue("Costo", oProducto.Costo);
                    cmd.Parameters.AddWithValue("MargenGanancia", oProducto.MargenGanancia);
                    cmd.Parameters.AddWithValue("NetoGravado", oProducto.NetoGravado);
                    cmd.Parameters.AddWithValue("PrecioVenta", oProducto.PrecioVenta);
                    cmd.Parameters.AddWithValue("Estado", Operaciones.BuscarEstado(oProducto.OEstado));
                    oConexion.Open();
                    respuesta = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el producto: "+ex.Message);
                    return 0;
                }

            }
            return respuesta;
        }
        #region ACTUALIZAR PRODUCTO
        public static bool ActualizarProducto(Producto oProducto)
        {
            bool respuesta = false;
            int cantidad = 0;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "UPDATE PRODUCTO " +
                                      "SET Codigo=@Codigo," +
                                      "Descripcion=@Descripcion," +
                                      "GeneroProducto=@GeneroProducto," +
                                      "IdRubroProducto=@IdRubroProducto," +
                                      "IdMarca=@IdMarca," +
                                      "IdImpuesto=@IdImpuesto," +
                                      "Costo=@Costo," +
                                      "MargenGanancia=@MargenGanancia," +
                                      "NetoGravado=@NetoGravado," +
                                      "PrecioVenta=@PrecioVenta," +
                                      "Estado=@Estado " +
                                      "WHERE IdProducto=@IdProducto";
                    //string SqlQuery = "UPDATE producto SET Codigo='" + oProducto.Codigo + "',Descripcion='" + oProducto.Descripcion + "',GeneroProducto='" + Operaciones.BuscarGenero(oProducto.oGeneroProducto) + "',Rubro='" + BD_Rubro.BuscarRubro(oProducto.Rubro).IdRubro + "',Marca='" + oProducto.Marca + "',Impuesto='" + oProducto.Impuesto + "',Costo='" + oProducto.Costo + "',NetoGravado='" + oProducto.NetoGravado + "',PrecioVenta='" + oProducto.PrecioVenta + "',Estado='" + Operaciones.BuscarEstado(oProducto.oEstado) + "'WHERE IdProducto" + oProducto.IdProducto;

                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("@Codigo", oProducto.Codigo);
                    cmd.Parameters.AddWithValue("@Descripcion", oProducto.Descripcion);
                    cmd.Parameters.AddWithValue("@GeneroProducto", Operaciones.BuscarGenero(oProducto.OGeneroProducto));
                    cmd.Parameters.AddWithValue("@IdRubroProducto", BD_RubroProducto.BuscarRubroProducto(oProducto.Rubro).IdRubroProducto);
                    cmd.Parameters.AddWithValue("@IdMarca", BD_Marca.BuscarMarca(oProducto.OMarca).IdMarca);
                    cmd.Parameters.AddWithValue("@IDImpuesto", oProducto.Impuesto);
                    cmd.Parameters.AddWithValue("@Costo", oProducto.Costo);
                    cmd.Parameters.AddWithValue("@MargenGanancia", oProducto.MargenGanancia);
                    cmd.Parameters.AddWithValue("@NetoGravado", oProducto.NetoGravado);
                    cmd.Parameters.AddWithValue("@PrecioVenta", oProducto.PrecioVenta);
                    cmd.Parameters.AddWithValue("@Estado", Operaciones.BuscarEstado(oProducto.OEstado));
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
                    MessageBox.Show(ex.Message);
                    return respuesta;
                }            
            }
        }
        #endregion
        public static bool EliminarProducto(int IdProducto)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "DELETE FROM Producto WHERE IdProducto = @IdProducto";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdProducto", IdProducto);
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
        public static List<Producto> MostrarProducto()
        {
            List<Producto> Tabla = new List<Producto>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT * FROM Producto";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);

                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var prod = new Producto
                            {
                                IdProducto = Convert.ToInt32(data.Rows[i]["IdProducto"]),
                                Codigo = data.Rows[i]["Codigo"].ToString(),
                                Descripcion = data.Rows[i]["Descripcion"].ToString(),
                                OGeneroProducto = Operaciones.BuscarGenero(data.Rows[i]["GeneroProducto"].ToString()),
                                Rubro = BD_RubroProducto.BuscarRubroProducto(Convert.ToInt32(data.Rows[i]["IdRubroProducto"].ToString())),
                                OMarca = BD_Marca.BuscarMarca(Convert.ToInt32(data.Rows[i]["IdMarca"].ToString())),
                                Impuesto = Convert.ToDouble(data.Rows[i]["IdImpuesto"].ToString()),
                                Costo = Convert.ToDouble(data.Rows[i]["Costo"].ToString()),
                                MargenGanancia = Convert.ToDouble(data.Rows[i]["MargenGanancia"].ToString()),
                                NetoGravado = Convert.ToDouble(data.Rows[i]["NetoGravado"].ToString()),
                                PrecioVenta = Convert.ToDouble(data.Rows[i]["PrecioVenta"].ToString()),
                                OEstado = Operaciones.BuscarEstado(data.Rows[i]["Estado"].ToString()),
                                FechaRegistro = Convert.ToDateTime(data.Rows[i]["FechaRegistro"])
                            };
                            Tabla.Add(prod);
                        }

                        return Tabla;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return Tabla;
                }

            }
        }
        public static Producto BuscarProducto(Producto oProducto)
        {
            List<Producto> lista = new List<Producto>();
            lista = MostrarProducto();
            foreach (var item in lista)
            {
                if (oProducto.IdProducto.Equals(item.IdProducto)) return item;
            }
            return null;
        }
        public static Producto BuscarProducto(string oProducto)
        {
            List<Producto> lista = new List<Producto>();
            lista = MostrarProducto();
            foreach (var item in lista)
            {
                if (item.Descripcion.Equals(oProducto)) return item;
            }
            return null;
        }
        public static Producto BuscarProducto(int oProducto)
        {
            List<Producto> lista = new List<Producto>();
            lista = MostrarProducto();
            foreach (var item in lista)
            {
                if (item.IdProducto.Equals(oProducto)) return item;
            }
            return null;
        }
    }
}
