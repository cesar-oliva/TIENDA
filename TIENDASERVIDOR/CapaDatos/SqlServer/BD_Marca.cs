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
                    string SqlQuery = "INSERT INTO Marca(DescripcionMarca)VALUES(@DescripcionMarca)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("DescripcionMarca", oMarca.DescripcionMarca);
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
                    String SqlQuery = "UPDATE Marca SET DescripcionMarca = @DescripcionMarca, Estado = @Estado  WHERE IdMarca = @IdMarca";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdMarca", IdMarca);
                    cmd.Parameters.AddWithValue("DescripcionMarca", oMarca.DescripcionMarca);
                    cmd.Parameters.AddWithValue("Estado", oMarca.OEstado);
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
                    String SqlQuery = "UPDATE marca SET Estado = @Estado WHERE IdMarca = @IdMarca";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdMarca", IdMarca);
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
                                DescripcionMarca = data.Rows[i]["DescripcionMarca"].ToString(),
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
        public static Marca BuscarMarcaByDescripcion(string oMarca)
        {
            List<Marca> lista = MostrarMarca();
            foreach (var item in lista)
            {
                if (item.DescripcionMarca.Equals(oMarca)) return item;
            }
            return null;
        }
        public static Marca BuscarMarcaById(int oMarca)
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
