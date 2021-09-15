﻿using CapaNegocio;
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
        //public static int RegistrarPuntoDeVenta(PuntoDeVenta oPuntoDeVenta)
        //{
        //    int respuesta;
        //    using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
        //    {
        //        try
        //        {
        //            string SqlQuery = "INSERT INTO PuntoDeVenta(Descripcion,Estado)" +
        //                              "VALUES(@Descripcion,@Estado)";
        //            SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
        //            cmd.Parameters.AddWithValue("Descripcion", oMarca.Descripcion);
        //            cmd.Parameters.AddWithValue("Estado", oMarca.oEstado);
        //            oConexion.Open();
        //            respuesta = cmd.ExecuteNonQuery();

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //            return 0;
        //        }

        //    }
        //    return respuesta;
        //}
        //public static bool ActualizarMarca(Marca oMarca, int IdMarca)
        //{
        //    int respuesta;
        //    using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
        //    {
        //        try
        //        {
        //            String SqlQuery = "UPDATE Marca SET Descripcion = @Descripcion, Estado = @Estado  WHERE IdMarca =
        //            @IdMarca";
        //            SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
        //            cmd.Parameters.AddWithValue("Descripcion", oMarca.Descripcion);
        //            cmd.Parameters.AddWithValue("Estado", oMarca.oEstado);
        //            oConexion.Open();
        //            respuesta = cmd.ExecuteNonQuery();
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //            return false;
        //        }
        //    }
        //}
        //public static bool EliminarMarca(int IdMarca)
        //{
        //    int respuesta;
        //    using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
        //    {
        //        try
        //        {
        //            String SqlQuery = "DELETE FROM Marca WHERE IdMarca = @IdMarca";
        //            SqlCommand cmd = new SqlCommand(SqlQuery, oConexion);
        //            cmd.Parameters.AddWithValue("IdMarca", IdMarca);
        //            oConexion.Open();
        //            respuesta = cmd.ExecuteNonQuery();
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //            return false;

        //        }
        //    }
        //}
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
                                //oSexo = data.Rows[i]["Sexo"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(data.Rows[i]["FechaNacimiento"].ToString()),
                                Edad = Convert.ToInt32(data.Rows[i]["Edad"].ToString()),
                                Domicilio = data.Rows[i]["Domicilio"].ToString(),
                                Telefono = data.Rows[i]["Telefono"].ToString(),
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

        //            return personaTabla;
        //         }


        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error en Capa Datos: " + ex.Message);
        //            return personaTabla;
        //}
        //     }      
        //}
        //public static Comprobante BuscarComprobante(Comprobante oComprobante)
        //{
        //    List<Comprobante> lista = new List<Comprobante>();
        //    lista = MostrarComprobante();
        //    foreach (var item in lista)
        //    {
        //        if (oComprobante.IdComprobante.Equals(item.IdComprobante)) return item;
        //    }
        //    return null;
        //}
        //public static Comprobante BuscarComprobante(string oComprobante)
        //{
        //    List<Comprobante> lista = new List<Comprobante>();
        //    lista = MostrarComprobante();
        //    foreach (var item in lista)
        //    {
        //        if (item.Descripcion.Equals(oComprobante)) return item;
        //    }
        //    return null;
        //}
        public static Persona BuscarPersona(int oPersona)
        {
            List<Persona> lista = new List<Persona>();
            lista = MostrarPersona();
            foreach (var item in lista)
            {
                if (item.IdPersona.Equals(oPersona)) return item;
            }
            return null;
        }
        private static Estado BuscarEstado(string valor)
        {
            if (valor.Equals("Activo"))
            {
                return Estado.Activo;
            }
            else
            {
                return Estado.Inactivo;
            }
        }

    }
}
