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
    public class BD_Tienda
    {
        public static int RegistrarTienda(Tienda oTienda)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "INSERT INTO Tienda(RazonSocial,CuitTienda,Direccion,Telefono,Estado)" +
                                      "VALUES(@RazonSocial,@CuitTienda,@Direccion,@Telefono,@Estado)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("RazonSocial", oTienda.RazonSocial);
                    cmd.Parameters.AddWithValue("CuitTienda", oTienda.CuitTienda);
                    cmd.Parameters.AddWithValue("Direccion", oTienda.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", oTienda.Telefono);
                    cmd.Parameters.AddWithValue("Estado", oTienda.OEstado);
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
        public static bool ActualizarTienda(Tienda oTienda, int IdTienda)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE Tienda SET RazonSocial = @RazonSocial, CuitTienda = @CuitTienda, Direccion = @Direccion,Telefono = @Telefono, Estado = @Estado  WHERE IdTalle = @IdTalle";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("RazonSocial", oTienda.RazonSocial);
                    cmd.Parameters.AddWithValue("CuitTienda", oTienda.CuitTienda);
                    cmd.Parameters.AddWithValue("Direccion", oTienda.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", oTienda.Telefono);
                    cmd.Parameters.AddWithValue("Estado", oTienda.OEstado);
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
        public static bool EliminarTienda(int IdTienda)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "DELETE FROM Tienda WHERE IdTienda = @IdTienda";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdTienda", IdTienda);
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
        public static List<Tienda> MostrarTienda()
        {
            List<Tienda> tiendaTabla = new List<Tienda>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT * FROM TIENDA";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);
                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var tienda = new Tienda
                            {
                                IdTienda = Convert.ToInt32(data.Rows[i]["IdTienda"]),
                                RazonSocial = Convert.ToString(data.Rows[i]["RazonSocial"]),
                                CuitTienda = Convert.ToString(data.Rows[i]["CuitTienda"]),
                                Direccion = Convert.ToString(data.Rows[i]["Direccion"]),
                                Telefono = Convert.ToString(data.Rows[i]["Telefono"]),
                                OEstado = Operaciones.BuscarEstado(data.Rows[i]["Estado"].ToString()),
                            };
                            tiendaTabla.Add(tienda);
                        }

                        return tiendaTabla;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en Capa Datos: " + ex.Message);
                    return tiendaTabla;
                }

            }
        }
        public static Tienda BuscarTienda(Tienda oTienda)
        {
            List<Tienda> lista = new List<Tienda>();
            lista = BD_Tienda.MostrarTienda();
            foreach (var item in lista)
            {
                if (oTienda.IdTienda.Equals(item.IdTienda)) return item;
            }
            return null;
        }
        public static Tienda BuscarTienda(string RazonSocial)
        {
            List<Tienda> lista = new List<Tienda>();
            lista = BD_Tienda.MostrarTienda();
            foreach (var item in lista)
            {
                if (item.RazonSocial.Equals(RazonSocial)) return item;
            }
            return null;
        }
        public static Tienda BuscarTienda(int IdTienda)
        {
            List<Tienda> lista = new List<Tienda>();
            lista = BD_Tienda.MostrarTienda();
            foreach (var item in lista)
            {
                if (item.IdTienda.Equals(IdTienda)) return item;
            }
            return null;
        }
    }
}
