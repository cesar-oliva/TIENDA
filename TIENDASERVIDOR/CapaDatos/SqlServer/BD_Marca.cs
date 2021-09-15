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
    public class BD_Marca
    {
        public static int RegistrarMarca(Marca oMarca)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "INSERT INTO Marca(Descripcion,Estado)" +
                                      "VALUES(@Descripcion,@Estado)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", oMarca.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", oMarca.OEstado);
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
        public static bool ActualizarMarca(Marca oMarca, int IdMarca)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE Marca SET Descripcion = @Descripcion, Estado = @Estado  WHERE IdMarca = @IdMarca";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", oMarca.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", oMarca.OEstado);
                    cmd.Parameters.AddWithValue("IdMarca", IdMarca);
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
        public static bool EliminarMarca(int IdMarca)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "DELETE FROM Marca WHERE IdMarca = @IdMarca";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdMarca", IdMarca);
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
        public static List<Marca> MostrarMarca()
        {
            List<Marca> marcaTabla = new List<Marca>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT * FROM MARCA";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);
                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var marc = new Marca
                            {
                                IdMarca = Convert.ToInt32(data.Rows[i]["IdMarca"]),
                                Descripcion = data.Rows[i]["Descripcion"].ToString(),
                                OEstado = Operaciones.BuscarEstado(data.Rows[i]["Estado"].ToString()),
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
        public static Marca BuscarMarca(Marca oMarca)
        {
            List<Marca> lista = MostrarMarca();
            foreach (var item in lista)
            {
                if (oMarca.IdMarca.Equals(item.IdMarca)) return item;
            }
            return null;
        }
        public static Marca BuscarMarca(string oMarca)
        {
            List<Marca> lista = MostrarMarca();
            foreach (var item in lista)
            {
                if (item.Descripcion.Equals(oMarca)) return item;
            }
            return null;
        }
        public static Marca BuscarMarca(int oMarca)
        {
            List<Marca> lista = MostrarMarca();
            foreach (var item in lista)
            {
                if (item.IdMarca.Equals(oMarca)) return item;
            }
            return null;
        }
    }
}
