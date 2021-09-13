using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Comprobante
    {
        public int IdComprobante { get; set; }
        public string Descripcion { get; set; }
        public PuntoDeVenta oPuntoDeVenta{ get; set; }
        public int ContadorNumero { get; set; }
        public Estado oEstado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
