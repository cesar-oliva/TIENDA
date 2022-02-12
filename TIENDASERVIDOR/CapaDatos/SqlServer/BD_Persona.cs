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
    public class BD_Persona
    {
        public static List<Persona> MostrarPersona()
        {
            List<Persona> personaTabla = new List<Persona>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT * FROM PERSONA";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);
                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var pers = new Persona
                            {
                                IdPersona = Convert.ToInt32(data.Rows[i]["IdPersona"]),
                                TipoDocumento = data.Rows[i]["TipoDocumento"].ToString(),
                                NumeroDocumento = data.Rows[i]["NumeroDocumento"].ToString(),
                                Nombres = data.Rows[i]["Nombres"].ToString(),
                                Apellidos = data.Rows[i]["Apellidos"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(data.Rows[i]["FechaNacimiento"].ToString()),
                                Domicilio = data.Rows[i]["Domicilio"].ToString(),
                                Telefono = data.Rows[i]["Telefono"].ToString(),
                                OEstado = Operaciones.BuscarByDescripcion(data.Rows[i]["Estado"].ToString()),
                                FechaRegistro = Convert.ToDateTime(data.Rows[i]["FechaRegistro"])
                            };
                            personaTabla.Add(pers);
                        }

                        return personaTabla;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return personaTabla;
                }

            }
        }


        public static Persona BuscarPersona(int oPersona)
        {
            List<Persona> lista = MostrarPersona();
            foreach (var item in lista)
            {
                if (item.IdPersona.Equals(oPersona)) return item;
            }
            return null;
        }
    }
}
