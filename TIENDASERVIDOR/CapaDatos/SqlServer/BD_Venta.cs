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
    public class BD_Venta
    {
        public static int RegistrarVenta(Venta oVenta)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "INSERT INTO Venta(IdComprobante,IdSucursal,IdUsuario,IdCliente,IdLineaDeVenta,CantidadProducto,ImporteTotalDeVenta,IdFormaDePago)" +
                                      "VALUES(@IdComprobante,@IdSucursal,@IdUsuario,@IdCliente,@IdLineaDeVenta,@CantidadProducto,@ImporteTotalDeVenta,@IdFormaDePago)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdComprobante", oVenta.OComprobante);
                    cmd.Parameters.AddWithValue("IdSucursal", oVenta.OSucursal);
                    cmd.Parameters.AddWithValue("IdUsuario", oVenta.OUsuario);
                    cmd.Parameters.AddWithValue("IdCliente", oVenta.OCliente);
                    cmd.Parameters.AddWithValue("IdLineaDeVenta", oVenta.OLineaDeVenta);
                    cmd.Parameters.AddWithValue("CantidadProducto", oVenta.CantidadProducto);
                    cmd.Parameters.AddWithValue("ImporteTotalDeVenta", oVenta.ImporteTotalDeVenta);
                    cmd.Parameters.AddWithValue("IdFormaDePago", oVenta.OFormaDePago);
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
        
        public static List<Venta> MostrarVenta()
        {
            List<Venta> ventaTabla = new List<Venta>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT * FROM VENTA";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);
                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var ven = new Venta
                            {
                                IdVenta = Convert.ToInt32(data.Rows[i]["IdVenta"]),
                                OComprobante = BD_Comprobante.BuscarComprobante(Convert.ToInt32(data.Rows[i]["IdComprobante"].ToString())),
                                OSucursal = BD_Sucursal.BuscarSucursal(Convert.ToInt32(data.Rows[i]["IdSucursal"].ToString())),
                                OUsuario = BD_Usuario.BuscarUsuario(Convert.ToInt32(data.Rows[i]["IdUsuario"].ToString())),
                                OCliente = BD_Cliente.BuscarClienteById(Convert.ToInt32(data.Rows[i]["IdCCliente"].ToString())),
                                OLineaDeVenta = BD_LineaDeVenta.BuscarListaLineaDeVenta(Convert.ToInt32(data.Rows[i]["IdLineaDeVenta"].ToString())),
                                CantidadProducto = Convert.ToInt32(data.Rows[i]["CantidadDeProducto"].ToString()),
                                ImporteTotalDeVenta = Convert.ToDouble(data.Rows[i]["ImporteTotalDeVEnta"].ToString()),
                                FechaRegistro = Convert.ToDateTime(data.Rows[i]["FechaRegistro"])
                            };
                            ventaTabla.Add(ven);
                        }

                        return ventaTabla;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en Capa Datos: " + ex.Message);
                    return ventaTabla;
                }

            }
        }
        public static Venta BuscarVenta(Venta oVenta)
        {
            List<Venta> lista = MostrarVenta();
            foreach (var item in lista)
            {
                if (oVenta.IdVenta.Equals(item.IdVenta)) return item;
            }
            return null;
        }
        public static Venta BuscarVenta(string oVenta)
        {
            List<Venta> lista = MostrarVenta();
            foreach (var item in lista)
            {
                if (item.OCliente.RazonSocial.Equals(oVenta)) return item;
            }
            return null;
        }
        public static Venta BuscarVenta(int oVenta)
        {
            List<Venta> lista = MostrarVenta();
            foreach (var item in lista)
            {
                if (item.OCliente.IdCliente.Equals(oVenta)) return item;
            }
            return null;
        }
    }
}
