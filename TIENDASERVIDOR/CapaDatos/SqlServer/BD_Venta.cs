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
                    cmd.Parameters.AddWithValue("IdComprobante", oVenta.oComprobante);
                    cmd.Parameters.AddWithValue("IdSucursal", oVenta.oSucursal);
                    cmd.Parameters.AddWithValue("IdUsuario", oVenta.oUsuario);
                    cmd.Parameters.AddWithValue("IdCliente", oVenta.oCliente);
                    cmd.Parameters.AddWithValue("IdLineaDeVenta", oVenta.oLineaDeVenta);
                    cmd.Parameters.AddWithValue("CantidadProducto", oVenta.CantidadProducto);
                    cmd.Parameters.AddWithValue("ImporteTotalDeVenta", oVenta.ImporteTotalDeVenta);
                    cmd.Parameters.AddWithValue("IdFormaDePago", oVenta.oFormaDePago);
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
                                oComprobante = BD_Comprobante.BuscarComprobante(Convert.ToInt32(data.Rows[i]["IdComprobante"].ToString())),
                                oSucursal = BD_Sucursal.BuscarSucursal(Convert.ToInt32(data.Rows[i]["IdSucursal"].ToString())),
                                oUsuario = BD_Usuario.BuscarUsuario(Convert.ToInt32(data.Rows[i]["IdUsuario"].ToString())),
                                oCliente = BD_Cliente.BuscarCliente(Convert.ToInt32(data.Rows[i]["IdCCliente"].ToString())),
                                oLineaDeVenta = BD_LineaDeVenta.BuscarListaLineaDeVenta(Convert.ToInt32(data.Rows[i]["IdLineaDeVenta"].ToString())),
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
            List<Venta> lista = new List<Venta>();
            lista = BD_Venta.MostrarVenta();
            foreach (var item in lista)
            {
                if (oVenta.IdVenta.Equals(item.IdVenta)) return item;
            }
            return null;
        }
        public static Venta BuscarVenta(string oVenta)
        {
            List<Venta> lista = new List<Venta>();
            lista = BD_Venta.MostrarVenta();
            foreach (var item in lista)
            {
                if (item.oCliente.RazonSocial.Equals(oVenta)) return item;
            }
            return null;
        }
        public static Venta BuscarVenta(int oVenta)
        {
            List<Venta> lista = new List<Venta>();
            lista = BD_Venta.MostrarVenta();
            foreach (var item in lista)
            {
                if (item.oCliente.IdCliente.Equals(oVenta)) return item;
            }
            return null;
        }
    }
}
