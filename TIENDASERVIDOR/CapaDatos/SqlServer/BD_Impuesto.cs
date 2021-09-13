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
    public class BD_Impuesto
    {

        public static int RegistrarImpuesto(Impuesto oImpuesto)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "INSERT INTO Impuesto(Descripcion,Alicuota,Estado)" +
                                     "VALUES(@Descripcion,@Alicuota,@Estado)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", oImpuesto.Descripcion);
                    cmd.Parameters.AddWithValue("Alicuota", oImpuesto.Alicuota);
                    cmd.Parameters.AddWithValue("Estado", Operaciones.BuscarEstado(oImpuesto.oEstado));
                    oConexion.Open();
                    respuesta = cmd.ExecuteNonQuery();
                    MessageBox.Show("El producto de dio de alta con exito");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el producto: " + ex.Message);
                    return 0;
                }

            }
            return respuesta;
        }
        public static bool ActualizarImpuesto(Impuesto oImpuesto)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "UPDATE Impuesto(Descripcion,Alicuota,Estado)" +
                                     "VALUES(@Descripcion,@Alicuota,@Estado)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", oImpuesto.Descripcion);
                    cmd.Parameters.AddWithValue("Alicuota", oImpuesto.Alicuota);
                    cmd.Parameters.AddWithValue("Estado", Operaciones.BuscarEstado(oImpuesto.oEstado));
                    oConexion.Open();
                    respuesta = cmd.ExecuteNonQuery();
                    MessageBox.Show("Se actualizo el producto descripcin:" + oImpuesto.Descripcion);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }
        public static bool EliminarImpuesto(int IdImpuesto)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "DELETE FROM Impuesto WHERE IdImpuesto = @IdImpuesto";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdImpuesto", IdImpuesto);
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
        public static List<Impuesto> MostrarImpuesto()
        {
            List<Impuesto> Tabla = new List<Impuesto>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT * FROM Impuesto";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);

                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var imp = new Impuesto
                            {
                                IdImpuesto = Convert.ToInt32(data.Rows[i]["IdImpuesto"]),
                                Descripcion = data.Rows[i]["Descripcion"].ToString(),
                                Alicuota = Convert.ToDouble(data.Rows[i]["Alicuota"].ToString()),
                                oEstado = Operaciones.BuscarEstado(data.Rows[i]["Estado"].ToString()),
                                FechaRegistro = Convert.ToDateTime(data.Rows[i]["FechaRegistro"])
                            };
                            Tabla.Add(imp);
                        }

                        return Tabla;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return Tabla;
                }

            }
        }
        public static Impuesto BuscarImpuesto(int idImpuesto)
        {
            List<Impuesto> lista = new List<Impuesto>();
            lista = MostrarImpuesto();
            foreach (var item in lista)
            {
                if (idImpuesto.Equals(item.IdImpuesto)) return item;
            }
            return null;
        }
    }
}
