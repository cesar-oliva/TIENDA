using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CapaDatos
{
    public class BD_Cliente
    {
        public static int RegistrarCliente(Cliente oCliente)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "INSERT INTO Cliente(Cuit,RazonSocial,IdCondicionTributaria,DomicilioFiscal) VALUES(@Cuit,@RazonSocial,@IdCondicionTributaria,@DomicilioFiscal)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("Cuit", oCliente.Cuit);
                    cmd.Parameters.AddWithValue("RazonSocial", oCliente.RazonSocial);
                    cmd.Parameters.AddWithValue("IdCondicionTributaria", oCliente.OCondicionTributaria.IdCondicionTributaria);
                    cmd.Parameters.AddWithValue("DomicilioFiscal", oCliente.DomicilioFiscal);
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
        public static List<Cliente> MostrarCliente()
        {
            List<Cliente> clienteTabla = new List<Cliente>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT * FROM CLIENTE";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);

                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var user = new Cliente
                            {
                                IdCliente = Convert.ToInt32(data.Rows[i]["IdCliente"]),
                                Cuit = data.Rows[i]["Cuit"].ToString(),
                                RazonSocial = data.Rows[i]["RazonSocial"].ToString(),
                                OCondicionTributaria = BD_CondicionTributaria.BuscarCondicionTributariaById(Convert.ToInt32(data.Rows[i]["IdCondicionTributaria"])),
                                DomicilioFiscal = data.Rows[i]["DomicilioFiscal"].ToString(),
                                OEstado = Operaciones.BuscarEstado(data.Rows[i]["Estado"].ToString()),
                                FechaRegistro = Convert.ToDateTime(data.Rows[i]["FechaRegistro"])
                            };
                            clienteTabla.Add(user);
                        }

                        return clienteTabla;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return clienteTabla;
                }

            }
        }
        public static bool ActualizarCliente(Cliente oCliente, int IdCliente)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE Cliente SET Cuit = @Cuit,RazonSocial = @RazonSocial,IdCondicionTributaria = @IdCondicionTributaria, DomicilioFiscal = @DomicilioFiscal,Estado = @Estado WHERE idCliente = @IdCliente";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdCliente", IdCliente);
                    cmd.Parameters.AddWithValue("Cuit", oCliente.Cuit);
                    cmd.Parameters.AddWithValue("RazonSocial", oCliente.RazonSocial);
                    cmd.Parameters.AddWithValue("IdCondicionTributaria", oCliente.OCondicionTributaria.IdCondicionTributaria);
                    cmd.Parameters.AddWithValue("DomicilioFiscal", oCliente.DomicilioFiscal);
                    cmd.Parameters.AddWithValue("Estado", oCliente.OEstado);
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
        public static bool EliminarCliente(int IdCliente)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "UPDATE Cliente SET Estado = @Estado WHERE IdCliente = @IdCliente";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdCliente", IdCliente);
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

        public static Cliente BuscarCliente(Cliente oCliente)
        {
            _ = new List<Cliente>();
            List<Cliente> lista = MostrarCliente();
            foreach (var item in lista)
            {
                if (oCliente.IdCliente.Equals(item.IdCliente)) return item;
            }
            return null;
        }
        public static Cliente BuscarClienteByRazonSocial(string razonSocial)
        {
            List<Cliente> lista = MostrarCliente();
            foreach (var item in lista)
            {
                if (item.RazonSocial.Equals(razonSocial)) return item;
            }
            return null;
        }
        public static Cliente BuscarClienteById(int idCliente)
        {
            List<Cliente> lista = MostrarCliente();
            foreach (var item in lista)
            {
                if (item.IdCliente.Equals(idCliente)) return item;
            }
            return null;
        }
    }
}
