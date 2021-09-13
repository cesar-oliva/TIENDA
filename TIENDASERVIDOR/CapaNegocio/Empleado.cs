using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Empleado : Persona
    {
        public int IdEmpleado { get; set; }
        public string Cuil { get; set; }
        public DateTime FechaAlta { get; set; }
        public int Antiguedad { get; set; }
        public DateTime FechaBaja { get; set; }
    }
}
