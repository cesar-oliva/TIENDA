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
    public class BD_Empleado
    {
        public static int RegistrarEmpleado(Empleado oEmpleado)
        {
            int respuesta;
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    string SqlQuery = "INSERT INTO EMPLEADO(IdPersona,Cuil,FechaAlta,Estado)" +
                                      "VALUES(@IdPersona,@Cuil,@FechaAlta,@Estado)";
                    SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
                    cmd.Parameters.AddWithValue("IdPersona", oEmpleado.IdPersona);
                    cmd.Parameters.AddWithValue("Cuil", oEmpleado.Cuil);
                    cmd.Parameters.AddWithValue("FechaAlta", oEmpleado.FechaAlta);
                    cmd.Parameters.AddWithValue("Estado", oEmpleado.OEstado);
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
       
        public static List<Empleado> MostrarEmpleado()
        {
            List<Empleado> empleadoTabla = new List<Empleado>();
            DataTable data = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                try
                {
                    String SqlQuery = "SELECT * FROM EMPLEADO";
                    SqlDataAdapter adapter = new SqlDataAdapter(SqlQuery, oConexion);
                    using (adapter)
                    {
                        adapter.Fill(data);
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var emp = new Empleado
                            {
                                IdEmpleado = Convert.ToInt32(data.Rows[i]["IdEmpleado"]),
                                OPersona = BD_Persona.BuscarPersona(Convert.ToInt32(data.Rows[i]["IdPersona"])),
                                Cuil = Convert.ToString(data.Rows[i]["Cuil"]),
                                FechaAlta = Convert.ToDateTime(data.Rows[i]["FechaAlta"]),
                                OEstado = Operaciones.BuscarEstado(data.Rows[i]["Estado"].ToString()),
                            };
                            empleadoTabla.Add(emp);
                        }

                        return empleadoTabla;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en Capa Datos: " + ex.Message);
                    return empleadoTabla;
                }

            }
        }
        public static Empleado BuscarEmpleado(Empleado oEmpleado)
        {
            List<Empleado> lista = MostrarEmpleado();
            foreach (var item in lista)
            {
                if (oEmpleado.IdEmpleado.Equals(item.IdEmpleado)) return item;
            }
            return null;
        }
        public static Empleado BuscarEmpleado(string cuil)
        {
            List<Empleado> lista = MostrarEmpleado();
            foreach (var item in lista)
            {
                if (item.Cuil.Equals(cuil)) return item;
            }
            return null;
        }
        public static Empleado BuscarEmpleado(int IdEmpleado)
        {
            List<Empleado> lista = MostrarEmpleado();
            foreach (var item in lista)
            {
                if (item.IdEmpleado.Equals(IdEmpleado)) return item;
            }
            return null;
        }
    }
}

