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
    public class BD_Comprobante
    {
        //public int IdComprobante { get; set; }
        //public string Descripcion { get; set; }
        //public PuntoDeVenta oPuntoDeVenta { get; set; }
        //public int ContadorNumero { get; set; }
        //public Estado oEstado { get; set; }
        //public DateTime FechaRegistro { get; set; }
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
        public static List<Comprobante> MostrarComprobante()
        {
            List<Comprobante> marcaTabla = new List<Comprobante>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT * FROM COMPROBANTE";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);
                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var marc = new Comprobante
                            {
                                IdComprobante = Convert.ToInt32(data.Rows[i]["IdComprobante"]),
                                Descripcion = data.Rows[i]["Descripcion"].ToString(),
                                OPuntoDeVenta = BD_PuntoDeVenta.BuscarPuntoDeVenta(Convert.ToInt32(data.Rows[i]["IdPuntoDeVenta"].ToString())),
                                ContadorNumero = Convert.ToInt32(data.Rows[i]["ContadorNumero"].ToString()),
                                OEstado = Operaciones.BuscarEstado(data.Rows[i]["Estado"].ToString()),
                                FechaRegistro = Convert.ToDateTime(data.Rows[i]["FechaRegistro"].ToString())
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
        public static Comprobante BuscarComprobante(Comprobante oComprobante)
        {
            List<Comprobante> lista = MostrarComprobante();
            foreach (var item in lista)
            {
                if (oComprobante.IdComprobante.Equals(item.IdComprobante)) return item;
            }
            return null;
        }
        public static Comprobante BuscarComprobante(string oComprobante)
        {
            List<Comprobante> lista = MostrarComprobante();
            foreach (var item in lista)
            {
                if (item.Descripcion.Equals(oComprobante)) return item;
            }
            return null;
        }
        public static Comprobante BuscarComprobante(int oComprobante)
        {
            List<Comprobante> lista = MostrarComprobante();
            foreach (var item in lista)
            {
                if (item.ContadorNumero.Equals(oComprobante)) return item;
            }
            return null;
        }
    }
}
