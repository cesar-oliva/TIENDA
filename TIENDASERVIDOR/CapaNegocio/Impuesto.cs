using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Impuesto
    {
        public int IdImpuesto { get; set; }
        public string Descripcion { get; set; }
        public double Alicuota { get; set; }
        public Estado oEstado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Impuesto(string descripcion, double alicuota, Estado oEstado)
        {
            Descripcion = descripcion;
            Alicuota = alicuota;
            this.oEstado = oEstado;
        }

        public Impuesto()
        {
        }
    }
}
