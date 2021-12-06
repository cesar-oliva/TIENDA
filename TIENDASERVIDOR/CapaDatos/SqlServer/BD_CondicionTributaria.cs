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
    public class BD_CondicionTributaria
    {
        public static int RegistrarCondicionTributaria(CondicionTributaria oCondicionTributaria)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "INSERT INTO CONDICIONTRIBUTARIA(CodigoCondicionTributaria,DescripcionCondicionTributaria,Estado)" +
                                      "VALUES(@CodigoCondicionTributaria,@DescripcionCondicionTributaria,@Estado)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("CodigoCondicionTributaria", oCondicionTributaria.CodigoCondicionTributaria);
                    cmd.Parameters.AddWithValue("DescripcionCondicionTributaria", oCondicionTributaria.DescripcionCondicionTributaria);
                    cmd.Parameters.AddWithValue("Estado", oCondicionTributaria.OEstado);
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
        public static bool ActualizarCondicionTributaria(CondicionTributaria oCondicionTributaria, int IdCondicionTributaria)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE CondicionTributaria SET CodigoCondicionTributaria = @CodigoCondicionTributaria, DescripcionCondicionTributaria = @DescripcionCondicionTributaria,Estado = @Estado  WHERE IdCondicionTributaria = @IdCondicionTributaria";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("CodigoCondicionTributaria", oCondicionTributaria.CodigoCondicionTributaria);
                    cmd.Parameters.AddWithValue("DescripcionCondicionTributaria", oCondicionTributaria.DescripcionCondicionTributaria);
                    cmd.Parameters.AddWithValue("Estado", oCondicionTributaria.OEstado);
                    cmd.Parameters.AddWithValue("IdCondicionTributaria", IdCondicionTributaria);
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
        public static bool EliminarCondicionTributaria(int IdRubro)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE CondicionTributaria SET Estado = @Estado WHERE IdCondicionTributaria = @IdCondicionTributaria";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdCondicionTributaria", IdRubro);
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
        public static List<CondicionTributaria> MostrarCondicionTributaria()
        {
            List<CondicionTributaria> condicionTributariaTabla = new List<CondicionTributaria>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT * FROM CONDICIONTRIBUTARIA";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);

                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var user = new CondicionTributaria
                            {
                                IdCondicionTributaria = Convert.ToInt32(data.Rows[i]["IdCondicionTributaria"]),
                                CodigoCondicionTributaria = data.Rows[i]["CodigoCondicionTributaria"].ToString(),
                                DescripcionCondicionTributaria = data.Rows[i]["DescripcionCondicionTributaria"].ToString(),
                                OEstado = Operaciones.BuscarEstado(data.Rows[i]["Estado"].ToString()),
                                FechaRegistro = Convert.ToDateTime(data.Rows[i]["FechaRegistro"])
                            };
                            condicionTributariaTabla.Add(user);
                        }

                        return condicionTributariaTabla;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return condicionTributariaTabla;
                }

            }
        }
        public static CondicionTributaria BuscarCondicionTributariaByDescripcion(string descripcionCondicionTributaria)
        {
            List<CondicionTributaria> lista = MostrarCondicionTributaria();
            foreach (var item in lista)
            {
                if (item.DescripcionCondicionTributaria.Equals(descripcionCondicionTributaria)) return item;
            }
            return null;
        }
        public static CondicionTributaria BuscarCondicionTributariaById(int idCondicionTributaria)
        {
            List<CondicionTributaria> lista = MostrarCondicionTributaria();
            foreach (var item in lista)
            {
                if (item.IdCondicionTributaria.Equals(idCondicionTributaria)) return item;
            }
            return null;
        }
    }
}
