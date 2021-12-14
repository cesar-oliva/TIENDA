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
    public class BD_Producto
    {
        public static int RegistrarProducto(Producto oProducto)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "INSERT INTO Producto(Codigo,Descripcion,GeneroProducto,IdRubroProducto,IdMarca,IdTipoTalle,Estado)" +
                                     "VALUES(@codigo,@Descripcion,@GeneroProducto,@IdRubroProducto,@IdMarca,@IdTipoTalle,@Estado)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("Codigo", oProducto.Codigo);
                    cmd.Parameters.AddWithValue("Descripcion", oProducto.Descripcion);
                    cmd.Parameters.AddWithValue("GeneroProducto", oProducto.OGeneroProducto.ToString());
                    cmd.Parameters.AddWithValue("IdRubroProducto", BD_RubroProducto.BuscarRubroProducto(oProducto.ORubroProducto).IdRubroProducto);
                    cmd.Parameters.AddWithValue("IdMarca", BD_Marca.BuscarMarca(oProducto.OMarca).IdMarca);
                    cmd.Parameters.AddWithValue("IdTipoTalle", BD_TipoTalle.BuscarTipoTalle(oProducto.OTipoTalle).IdTipoTalle);
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
        public static bool ModificarProducto(Producto oProducto)
        {
            bool respuesta = false;
            int cantidad;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "UPDATE PRODUCTO SET Codigo=@Codigo,Descripcion=@Descripcion,GeneroProducto=@GeneroProducto,IdRubroProducto=@IdRubroProducto,IdMarca=@IdMarca," +
                                      "IdTipoTalle=@IdTipoTalle,Estado=@Estado WHERE IdProducto=@IdProducto";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("@Codigo", oProducto.Codigo);
                    cmd.Parameters.AddWithValue("@Descripcion", oProducto.Descripcion);
                    cmd.Parameters.AddWithValue("@GeneroProducto", oProducto.OGeneroProducto.ToString());
                    cmd.Parameters.AddWithValue("@IdRubroProducto", BD_RubroProducto.BuscarRubroProducto(oProducto.ORubroProducto).IdRubroProducto);
                    cmd.Parameters.AddWithValue("@IdMarca", BD_Marca.BuscarMarca(oProducto.OMarca).IdMarca);
                    cmd.Parameters.AddWithValue("@IdTipoTalle", BD_TipoTalle.BuscarTipoTalle(oProducto.OTipoTalle).IdTipoTalle);
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
                    String SqlQuery = "Select * from producto";
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
                                ORubroProducto = BD_RubroProducto.BuscarRubroProductoById(Convert.ToInt32(data.Rows[i]["IdRubroProducto"].ToString())),
                                OMarca = BD_Marca.BuscarMarca(Convert.ToInt32(data.Rows[i]["IdMarca"].ToString())),
                                OTipoTalle = BD_TipoTalle.BuscarTipoTalle(Convert.ToInt32(data.Rows[i]["IdTipoTalle"].ToString())),
                                OProductoVenta = new List<ProductoVenta>(),
                                OEstado = Operaciones.BuscarEstado(data.Rows[i]["Estado"].ToString()),
                                FechaRegistro = Convert.ToDateTime(data.Rows[i]["FechaRegistro"])
                            };
                            prod = cargarProductosVenta(prod);
                            Tabla.Add(prod);
                        } 
                    }
                    return Tabla;
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
            List<Producto> lista = MostrarProducto();
            foreach (var item in lista)
            {
                if (oProducto.IdProducto.Equals(item.IdProducto)) return item;
            }
            return null;
        }
        public static Producto BuscarProducto(string oProducto)
        {
            List<Producto> lista = MostrarProducto();
            foreach (var item in lista)
            {
                if (item.Descripcion.Equals(oProducto)) return item;
            }
            return null;
        }
        public static Producto BuscarProducto(int oProducto)
        {
            List<Producto> lista = MostrarProducto();
            foreach (var item in lista)
            {
                if (item.IdProducto.Equals(oProducto)) return item;
            }
            return null;
        }
        public static Producto cargarProductosVenta(Producto prod)
        {
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            try
            {
            String SqlQuery = "Select * from ProductoVenta";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);
            using (adapter)
            {
                adapter.Fill(data);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (prod.IdProducto.Equals(Convert.ToInt32(data.Rows[i]["IdProducto"])))
                    {
                        var prodVenta = new ProductoVenta
                        {
                            OColor = BD_Color.BuscarColor(Convert.ToInt32(data.Rows[i]["IdColor"].ToString())),
                            OTalle = BD_Talle.BuscarTalle(Convert.ToInt32(data.Rows[i]["IdTalle"].ToString())),
                            Costo = Convert.ToDouble(data.Rows[i]["Costo"].ToString()),
                            Cantidad = Convert.ToInt32(data.Rows[i]["Cantidad"].ToString()),
                        };
                        prod.OProductoVenta.Add(prodVenta);
                    }
                    
                }
            }
            return prod;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return prod;
            }

        }
    }
}
