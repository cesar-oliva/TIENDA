using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Tienda
    {
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public List<PuntoDeVenta> oPuntoDeVenta { get; set; }
        public List<Sucursal> oSucursal { get; set; }
    }
}
