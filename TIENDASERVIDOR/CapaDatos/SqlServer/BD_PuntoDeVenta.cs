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
    public class BD_PuntoDeVenta
    {

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
        public static List<PuntoDeVenta> MostrarPuntoDeVenta()
        {
            List<PuntoDeVenta> marcaTabla = new List<PuntoDeVenta>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT * FROM PUNTODEVENTA";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);
                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var marc = new PuntoDeVenta
                            {
                                IdPuntoDeVenta = Convert.ToInt32(data.Rows[i]["IdPuntoDeVenta"]),
                                CodigoPuntoDeVenta = data.Rows[i]["CodigoPuntoDeVenta"].ToString(),
                                DomicilioFacturacion = data.Rows[i]["DomicilioFacturacion"].ToString(),
                                NombreFantasia = data.Rows[i]["NombreFantasia"].ToString(),
                                OEstado = Operaciones.BuscarByDescripcion(data.Rows[i]["Estado"].ToString()),
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
        public static PuntoDeVenta BuscarPuntoDeVenta(PuntoDeVenta oPuntoDeVenta)
        {
            List<PuntoDeVenta> lista = MostrarPuntoDeVenta();
            foreach (var item in lista)
            {
                if (oPuntoDeVenta.IdPuntoDeVenta.Equals(item.IdPuntoDeVenta)) return item;
            }
            return null;
        }
        public static PuntoDeVenta BuscarPuntoDeVenta(string oPuntoDeVenta)
        {
            List<PuntoDeVenta> lista = MostrarPuntoDeVenta();
            foreach (var item in lista)
            {
                if (item.DomicilioFacturacion.Equals(oPuntoDeVenta)) return item;
            }
            return null;
        }
        public static PuntoDeVenta BuscarPuntoDeVenta(int oPuntoDeVenta)
        {
            List<PuntoDeVenta> lista = MostrarPuntoDeVenta();
            foreach (var item in lista)
            {
                if (item.CodigoPuntoDeVenta.Equals(oPuntoDeVenta)) return item;
            }
            return null;
        }
        public static List<PuntoDeVenta> BuscarListaPuntoDeVenta(int oPuntoDeVenta)
        {
            List<PuntoDeVenta> lista =  MostrarPuntoDeVenta();
            List<PuntoDeVenta> listaresultado = new List<PuntoDeVenta>();
            foreach (var item in lista)
            {
                if (item.CodigoPuntoDeVenta.Equals(oPuntoDeVenta)) listaresultado.Add(item);
            }
            return listaresultado;
        }
    }
}
