using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class PuntoDeVenta
    {
        public int IdPuntoDeVenta { get; set; }
        public string CodigoPuntoDeVenta { get; set; }
        public string SistemaFacturacion { get; set; }
        public string DomicilioFacturacion { get; set; }
        public string NombreFantasia { get; set; }
        public Estado oEstado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
