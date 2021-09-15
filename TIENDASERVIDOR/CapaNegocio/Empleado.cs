using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Empleado : Persona
    {
        private int idEmpleado;
        private Persona oPersona;
        private string cuil;
        private DateTime fechaAlta;
        private int antiguedad;
        private Estado oEstado;
        private DateTime fechaRegistro;

        public int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public Persona OPersona { get => oPersona; set => oPersona = value; }
        public string Cuil { get => cuil; set => cuil = value; }
        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta = value; }
        public int Antiguedad { get => antiguedad; set => antiguedad = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        

        public Empleado(int idEmpleado, Persona oPersona, string cuil, DateTime fechaAlta, int antiguedad, Estado oEstado, DateTime fechaRegistro)
        {
            IdEmpleado = idEmpleado;
            OPersona = oPersona;
            Cuil = cuil;
            FechaAlta = fechaAlta;
            Antiguedad = antiguedad;
            FechaRegistro = fechaRegistro;
        }

        public Empleado()
        {
        }

    }
}
