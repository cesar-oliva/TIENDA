using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Tienda
    {
        private int idTienda;
        private string razonSocial;
        private string cuit;
        private string domicilio;
        private string telefono;
        private List<PuntoDeVenta> oPuntoDeVenta;
        private List<Sucursal> oSucursal;

        public int IdTienda { get => idTienda; set => idTienda = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public string Cuit { get => cuit; set => cuit = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<PuntoDeVenta> OPuntoDeVenta { get => oPuntoDeVenta; set => oPuntoDeVenta = value; }
        public List<Sucursal> OSucursal { get => oSucursal; set => oSucursal = value; }
        

        public Tienda()
        {
        }
        public Tienda(string razonSocial, string cuit, string domicilio, string telefono, List<PuntoDeVenta> oPuntoDeVenta, List<Sucursal> oSucursal)
        {
            RazonSocial = razonSocial;
            Cuit = cuit;
            Domicilio = domicilio;
            Telefono = telefono;
            OPuntoDeVenta = oPuntoDeVenta;
            OSucursal = oSucursal;
        }
    }
}
