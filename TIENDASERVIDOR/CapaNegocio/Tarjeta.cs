using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Tarjeta
    {
        public string BancoEmisor { get; set; }
        public string NumeroTarjeta { get; set; }
        public string NombreTitular { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string CodigoSegridad { get; set; }
        public Estado oEstado { get; set; }
    }
}
