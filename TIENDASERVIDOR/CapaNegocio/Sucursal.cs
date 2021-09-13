using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Sucursal
    {
        public int IdSucursal { get; set; }
        public string Domicilio { get; set; }
        public string Telefono{ get; set; }
        public List<PuntoDeVenta> oPuntoDeVenta { get; set; }
        public Estado oEstado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
