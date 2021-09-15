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
    public class BD_Talle
    {

        public static int RegistrarTalle(Talle oTalle)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "INSERT INTO Talle(IdRubro,SiglaInternacional,Descripcion,Estado)" +
                                      "VALUES(@IdRubro,@SiglaInternacional,@Descripcion,@Estado)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdRubro", oTalle.ORubroProducto.IdRubro);
                    cmd.Parameters.AddWithValue("SglaInternacional", oTalle.SiglaInternacional);
                    cmd.Parameters.AddWithValue("Descripcion", oTalle.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", oTalle.OEstado);
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
        public static bool ActualizarTalle(Talle oTalle, int IdTalle)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE Talle SET IdRubro = @IdRubro, Descripcion = @Descripcion, Estado = @Estado  WHERE IdTalle = @IdTalle";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdRubro", oTalle.ORubroProducto.IdRubro);
                    cmd.Parameters.AddWithValue("SglaInternacional", oTalle.SiglaInternacional);
                    cmd.Parameters.AddWithValue("Descripcion", oTalle.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", oTalle.OEstado);
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
        public static bool EliminarTalle(int IdTalle)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "DELETE FROM Talle WHERE IdTalle = @IdTalle";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdTalle", IdTalle);
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
        public static List<Talle> MostrarTalle()
        {
            List<Talle> talleTabla = new List<Talle>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT * FROM TALLE";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);
                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var talle = new Talle
                            {
                                IdTalle = Convert.ToInt32(data.Rows[i]["IdMarca"]),
                                ORubroProducto = BD_RubroProducto.BuscarRubroProducto(Convert.ToInt32(data.Rows[i]["IdRubroProducto"])),
                                Descripcion = data.Rows[i]["Descripcion"].ToString(),
                                OEstado = Operaciones.BuscarEstado(data.Rows[i]["Estado"].ToString()),
                            };
                            talleTabla.Add(talle);
                        }

                        return talleTabla;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en Capa Datos: " + ex.Message);
                    return talleTabla;
                }

            }
        }
        public static Talle BuscarTalle(Talle oTalle)
        {
            List<Talle> lista = new List<Talle>();
            lista = BD_Talle.MostrarTalle();
            foreach (var item in lista)
            {
                if (oTalle.IdTalle.Equals(item.IdTalle)) return item;
            }
            return null;
        }
        public static Talle BuscarTalle(string Descripcion)
        {
            List<Talle> lista = new List<Talle>();
            lista = BD_Talle.MostrarTalle();
            foreach (var item in lista)
            {
                if (item.Descripcion.Equals(Descripcion)) return item;
            }
            return null;
        }
        public static Talle BuscarTalle(int IdTalle)
        {
            List<Talle> lista = new List<Talle>();
            lista = BD_Talle.MostrarTalle();
            foreach (var item in lista)
            {
                if (item.IdTalle.Equals(IdTalle)) return item;
            }
            return null;
        }
    }

}

