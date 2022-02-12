using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Impuesto
    {
        public int IdImpuesto { get; set; }
        public string Descripcion { get; set; }
        public double Alicuota { get; set; }
        public Estado OEstado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
