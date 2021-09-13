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
                                IdCondicionTributaria = Convert.ToInt32(data.Rows[i]["IdUsuario"]),
                                Codigo = data.Rows[i]["NombreUsuario"].ToString(),
                                Descripcion = data.Rows[i]["Contraseña"].ToString(),
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
        public static CondicionTributaria BuscarCondicionTributaria(string descripcion)
        {
            List<CondicionTributaria> lista = new List<CondicionTributaria>();
            lista = MostrarCondicionTributaria();
            foreach (var item in lista)
            {
                if (item.Descripcion.Equals(descripcion)) return item;
            }
            return null;
        }
        public static CondicionTributaria BuscarCondicionTributaria(int idCondicionTributaria)
        {
            List<CondicionTributaria> lista = new List<CondicionTributaria>();
            lista = MostrarCondicionTributaria();
            foreach (var item in lista)
            {
                if (item.IdCondicionTributaria.Equals(idCondicionTributaria)) return item;
            }
            return null;
        }
    }
}
