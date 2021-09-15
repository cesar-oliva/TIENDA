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
    public class BD_Sucursal
    {
        public static int RegistrarSucursal(Sucursal oSucursal)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "INSERT INTO SUSURSAL(Domicilio,Telefono,IdPuntoDeVenta,Estado)" +
                                      "VALUES(@Domicilio,@Telefono,@IdPuntoDeVenta,@Estado)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("Domicilio", oSucursal.Domicilio);
                    cmd.Parameters.AddWithValue("Telefono", oSucursal.Telefono);
                    cmd.Parameters.AddWithValue("IdPuntoDeVenta", oSucursal.oPuntoDeVenta);
                    cmd.Parameters.AddWithValue("Estado", oSucursal.oEstado);
                    oConexion.Open();
                    respuesta = cmd.ExecuteNonQuery();    }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }

            }
            return respuesta;
        }
        public static bool ActualizarSucursal(Sucursal oSucursal, int IdSucursal)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE SUCURSAL SET Domicilio = @Domicilio,Telefono = @Telefono,IdPuntoDeVenta = @IdPuntoDeVenta, Estado = @Estado  WHERE IdMarca = @IdMarca";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("Domicilio", oSucursal.Domicilio);
                    cmd.Parameters.AddWithValue("Telefono", oSucursal.Telefono);
                    cmd.Parameters.AddWithValue("IdPuntoDeVenta", oSucursal.oPuntoDeVenta);
                    cmd.Parameters.AddWithValue("Estado", oSucursal.oEstado);
                    cmd.Parameters.AddWithValue("IdSucursal", IdSucursal);
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
        public static bool EliminarSucursal(int IdSucursal)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "DELETE FROM SUCURSAL WHERE IdSucursal = @Idsucursal";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdSucursal", IdSucursal);
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
        public static List<Sucursal> MostrarSucursal()
        {
            List<Sucursal> sucursalTabla = new List<Sucursal>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT * FROM SUCURSAL";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);
                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var suc = new Sucursal
                            {
                                IdSucursal = Convert.ToInt32(data.Rows[i]["IdSucursal"]),
                                Domicilio = data.Rows[i]["Domicilio"].ToString(),
                                Telefono = data.Rows[i]["Telefono"].ToString(),
                                oPuntoDeVenta = BD_PuntoDeVenta.BuscarListaPuntoDeVenta(Convert.ToInt32(data.Rows[i]["IdPuntoDeVenta"].ToString())),
                                oEstado = Operaciones.BuscarEstado(data.Rows[i]["Estado"].ToString()),
                                FechaRegistro = Convert.ToDateTime(data.Rows[i]["FechaRegistro"])
                            };
                            sucursalTabla.Add(suc);
                        }

                        return sucursalTabla;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en Capa Datos: " + ex.Message);
                    return sucursalTabla;
                }

            }
        }
        public static Sucursal BuscarSucursal(Sucursal oSucursal)
        {
            List<Sucursal> lista = MostrarSucursal();
            foreach (var item in lista)
            {
                if (oSucursal.IdSucursal.Equals(item.IdSucursal)) return item;
            }
            return null;
        }
        public static Sucursal BuscarSucursal(string oSucursal)
        {
            List<Sucursal> lista = MostrarSucursal();
            foreach (var item in lista)
            {
                if (item.Domicilio.Equals(oSucursal)) return item;
            }
            return null;
        }
        public static Sucursal BuscarSucursal(int oSucursal)
        {
            List<Sucursal> lista = MostrarSucursal();
            foreach (var item in lista)
            {
                if (item.IdSucursal.Equals(oSucursal)) return item;
            }
            return null;
        }
    }
}
