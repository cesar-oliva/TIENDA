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
    public class BD_LineaDeVenta
    {
        BD_Producto bd_Producto = new BD_Producto();    

        //public int IdLineaDeVenta { get; set; }
        //public Venta oVenta { get; set; }
        //public Producto oProducto { get; set; }
        //public int cantidad { get; set; }
        //public double PrecioUnitario { get; set; }
        //public double ImporteSubtotal { get; set; }
        //public static int RegistrarPuntoDeVenta(PuntoDeVenta oPuntoDeVenta)
        //{
        //    int respuesta;
        //    using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
        //    {
        //        try
        //        {
        //            string SqlQuery = "INSERT INTO PuntoDeVenta(Descripcion,Estado)" +
        //                              "VALUES(@Descripcion,@Estado)";
        //            SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
        //            cmd.Parameters.AddWithValue("Descripcion", oMarca.Descripcion);
        //            cmd.Parameters.AddWithValue("Estado", oMarca.oEstado);
        //            oConexion.Open();
        //            respuesta = cmd.ExecuteNonQuery();

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //            return 0;
        //        }

        //    }
        //    return respuesta;
        //}
        //public static bool ActualizarMarca(Marca oMarca, int IdMarca)
        //{
        //    int respuesta;
        //    using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
        //    {
        //        try
        //        {
        //            String SqlQuery = "UPDATE Marca SET Descripcion = @Descripcion, Estado = @Estado  WHERE IdMarca = @IdMarca";
        //            SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
        //            cmd.Parameters.AddWithValue("Descripcion", oMarca.Descripcion);
        //            cmd.Parameters.AddWithValue("Estado", oMarca.oEstado);
        //            oConexion.Open();
        //            respuesta = cmd.ExecuteNonQuery();
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //            return false;
        //        }
        //    }
        //}
        //public static bool EliminarMarca(int IdMarca)
        //{
        //    int respuesta;
        //    using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
        //    {
        //        try
        //        {
        //            String SqlQuery = "DELETE FROM Marca WHERE IdMarca = @IdMarca";
        //            SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
        //            cmd.Parameters.AddWithValue("IdMarca", IdMarca);
        //            oConexion.Open();
        //            respuesta = cmd.ExecuteNonQuery();
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //            return false;

        //        }
        //    }
        //}
        public static List<LineaDeVenta> MostrarLineaDeVenta()
        {
            List<LineaDeVenta> marcaTabla = new List<LineaDeVenta>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT * FROM LINEADEVENTA";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);
                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var marc = new LineaDeVenta
                            {
                                IdLineaDeVenta = Convert.ToInt32(data.Rows[i]["IdComprobante"]),
                                OVenta = BD_Venta.BuscarVenta(Convert.ToInt32(data.Rows[i]["IdVenta"].ToString())),
                                //OProducto = bd_Producto.BuscarById(Convert.ToInt32(data.Rows[i]["IdProducto"].ToString())),
                                Cantidad = Convert.ToInt32(data.Rows[i]["Cantidad"].ToString()),
                                PrecioUnitario = Convert.ToDouble(data.Rows[i]["PrecioUnitario"].ToString()),
                            };
                            marcaTabla.Add(marc);
                        }

                        return marcaTabla;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en Capa Datos: " + ex.Message);
                    return marcaTabla;
                }

            }
        }
        public static LineaDeVenta BuscarLineaDeVenta(LineaDeVenta oLineaDeVenta)
        {
            List<LineaDeVenta> lista = MostrarLineaDeVenta();
            foreach (var item in lista)
            {
                if (oLineaDeVenta.IdLineaDeVenta.Equals(item.IdLineaDeVenta)) return item;
            }
            return null;
        }
        public static LineaDeVenta BuscarLineaDeVenta(string oLineaDeVenta)
        {
            List<LineaDeVenta> lista = MostrarLineaDeVenta();
            foreach (var item in lista)
            {
                if (item.OVenta.IdVenta.Equals(oLineaDeVenta)) return item;
            }
            return null;
        }
        public static LineaDeVenta BuscarLineaDeVenta(int oLineaDeVenta)
        {
            List<LineaDeVenta> lista = MostrarLineaDeVenta();
            foreach (var item in lista)
            {
                if (item.IdLineaDeVenta.Equals(oLineaDeVenta)) return item;
            }
            return null;
        }
        public static List<LineaDeVenta> BuscarListaLineaDeVenta(int oLineaDeVenta)
        {
            List<LineaDeVenta> lista = MostrarLineaDeVenta();
            List<LineaDeVenta> listaresultado = new List<LineaDeVenta>();
            foreach (var item in lista)
            {
                if (item.IdLineaDeVenta.Equals(oLineaDeVenta)) listaresultado.Add(item);
            }
            return listaresultado;
        }
    }
}
