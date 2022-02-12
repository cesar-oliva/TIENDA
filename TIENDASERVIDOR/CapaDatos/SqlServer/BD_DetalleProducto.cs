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

namespace CapaDatos.SqlServer
{
    public class BD_DetalleProducto : ICrud<DetalleProducto>
    {
        public int Registrar(DetalleProducto oDetalleProducto)
        {
            int respuesta;
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "INSERT INTO DetalleProducto(IdProducto,IdTalleColor,StockProducto,Estado)" +
                                    "VALUES(@IdProducto,@IdTalleColor,@StockProducto,@Estado)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdProducto", oDetalleProducto.IdProducto);
                    cmd.Parameters.AddWithValue("IdTalleColor", oDetalleProducto.IdTalleColor);
                    cmd.Parameters.AddWithValue("StockProducto", oDetalleProducto.StockProducto);
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
            throw new NotImplementedException();
        }
        public bool Actualizar(DetalleProducto oEntity)
        {
            throw new NotImplementedException();
        }

        public DetalleProducto BuscarByDescripcion(string oDescripcionEntity)
        {
            throw new NotImplementedException();
        }

        public DetalleProducto BuscarById(int oIdEntity)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int IdEntity)
        {
            throw new NotImplementedException();
        }

        public List<DetalleProducto> Mostrar()
        {
            List<DetalleProducto> Tabla = new List<DetalleProducto>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "Select * from detalleproducto";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);

                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var detprod = new DetalleProducto
                            {
                                IdDetalleProducto = Convert.ToInt32(data.Rows[i]["IdDetalleProducto"].ToString()),
                                IdProducto = Convert.ToInt32(data.Rows[i]["IdProducto"].ToString()),
                                IdTalleColor = Convert.ToInt32(data.Rows[i]["IdTalleColor"].ToString()),
                                StockProducto = Convert.ToInt32(data.Rows[i]["StockProducto"].ToString()),
                                OEstado = Operaciones.BuscarByDescripcion(data.Rows[i]["Estado"].ToString()),
                                FechaRegistro = Convert.ToDateTime(data.Rows[i]["FechaRegistro"].ToString())
                            };
                            Tabla.Add(detprod);
                        }
                    }
                    return Tabla;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en Mostrar DetalleProducto: " + ex.Message);
                    return Tabla;
                }

            }

        }
    }
}
