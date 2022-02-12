using CapaAbstraccion;
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
    public class BD_Impuesto:ICrud<Impuesto>
    {

        public int Registrar(Impuesto oImpuesto)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "INSERT INTO Impuesto(DescripcionImpusto,Alicuota)" +
                                     "VALUES(@DescripcionImpuesto,@Alicuota,@Estado)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("DescripcionImpuesto", oImpuesto.Descripcion);
                    cmd.Parameters.AddWithValue("Alicuota", oImpuesto.Alicuota);
                    oConexion.Open();
                    respuesta = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el producto: " + ex.Message);
                    return 0;
                }
            }
            return respuesta;
        }
        public bool Actualizar(Impuesto oImpuesto)
        {
            bool respuesta = false;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "UPDATE IMPUESTO SET DescripcionImpuesto = @DescripcionImpuesto, Alicuota = @Alicuota, Estado = @Estado WHERE idImpuesto = @IdImpuesto";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("DescripcionImpuesto", oImpuesto.Descripcion);
                    cmd.Parameters.AddWithValue("Alicuota", oImpuesto.Alicuota);
                    cmd.Parameters.AddWithValue("Estado", Operaciones.BuscarByDescripcion(oImpuesto.OEstado.ToString()));
                    cmd.Parameters.AddWithValue("IdImpuesto", oImpuesto.IdImpuesto);
                    oConexion.Open();
                    if (cmd.ExecuteNonQuery() > 0) respuesta = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return respuesta;
                }
            }
            return respuesta;
        }
        public bool Eliminar(int idImpuesto)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "DELETE FROM Impuesto WHERE IdImpuesto = @IdImpuesto";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdImpuesto", idImpuesto);
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
        public List<Impuesto> Mostrar()
        {
            List<Impuesto> Tabla = new List<Impuesto>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT *FROM IMPUESTO";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);

                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var imp = new Impuesto
                            {
                                IdImpuesto = Convert.ToInt32(data.Rows[i]["IdImpuesto"]),
                                Descripcion = data.Rows[i]["DescripcionImpuesto"].ToString(),
                                Alicuota = Convert.ToDouble(data.Rows[i]["Alicuota"].ToString()),
                                OEstado = Operaciones.BuscarByDescripcion(data.Rows[i]["Estado"].ToString()),
                                FechaRegistro = Convert.ToDateTime(data.Rows[i]["FechaRegistro"])
                            };
                            Tabla.Add(imp);
                        }

                        return Tabla;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("impuesto error"+ex.Message);
                    return Tabla;
                }

            }
        }
        public Impuesto BuscarById(int idImpuesto)
        {
            List<Impuesto> lista = Mostrar();
            foreach (var item in lista)
            {
                if (idImpuesto.Equals(item.IdImpuesto)) return item;
            }
            return null;
        }
        public Impuesto BuscarByDescripcion(string descripcionImpuesto)
        {
            var lista = Mostrar();
            foreach (var item in lista)
            {
                if (item.Descripcion.Equals(descripcionImpuesto)) return item;
            }
            return null;
        }
    }
}
