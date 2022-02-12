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
    public class BD_MarcaProducto:ICrud<MarcaProducto>
    {
             public int Registrar(MarcaProducto oMarca)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "INSERT INTO Marca(DescripcionMarcaProducto)VALUES(@DescripcionMarcaProducto)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("DescripcionMarcaProducto", oMarca.DescripcionMarcaProducto);
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
        public bool Actualizar(MarcaProducto oMarca)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE Marca SET DescripcionMarcaProducto = @DescripcionMarcaProducto, Estado = @Estado  WHERE IdMarcaProducto = @IdMarcaProducto";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdMarcaProducto", oMarca.IdMarcaProducto);
                    cmd.Parameters.AddWithValue("DescripcionMarcaProducto", oMarca.DescripcionMarcaProducto);
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
        public bool Eliminar(int IdMarca)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE marca SET Estado = @Estado WHERE IdMarcaProducto = @IdMarcaProducto";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdMarcaProducto", IdMarca);
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
        public List<MarcaProducto> Mostrar()
        {
            List<MarcaProducto> marcaTabla = new List<MarcaProducto>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT * FROM MARCAPRODUCTO";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);
                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var marc = new MarcaProducto
                            {
                                IdMarcaProducto = Convert.ToInt32(data.Rows[i]["IdMarcaProducto"]),
                                DescripcionMarcaProducto = data.Rows[i]["DescripcionMarcaProducto"].ToString(),
                                OEstado = Operaciones.BuscarByDescripcion(data.Rows[i]["Estado"].ToString()),
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
        public MarcaProducto BuscarByDescripcion(string oDescripcionMarca)
        {
            List<MarcaProducto> lista = Mostrar();
            foreach (var item in lista)
            {
                if (item.DescripcionMarcaProducto.Equals(oDescripcionMarca)) return item;
            }
            return null;
        }
        public MarcaProducto BuscarById(int oIdMarca)
        {
            List<MarcaProducto> lista = Mostrar();
            foreach (var item in lista)
            {
                if (item.IdMarcaProducto.Equals(oIdMarca)) return item;
            }
            return null;
        }
    }
}
