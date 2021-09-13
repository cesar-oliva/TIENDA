using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public Comprobante oComprobante { get; set; }
        public Sucursal oSucursal { get; set; }
        public Usuario oUsuario { get; set; }
        public Cliente oCliente { get; set; }
        public List<LineaDeVenta> oLineaDeVenta { get; set; }
        public int CantidadProducto { get; set; }
        public double ImporteTotalDeVenta { get; set; }
        public List<FormaDePago> oFormaDePago { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Venta(int idVenta, Comprobante oComprobante, Sucursal oSucursal, Usuario oUsuario, Cliente oCliente, int cantidadProducto, double importeTotalDeVenta, List<FormaDePago> oFormaDePago, DateTime fechaRegistro)
        {
            IdVenta = idVenta;
            this.oComprobante = oComprobante;
            this.oSucursal = oSucursal;
            this.oUsuario = oUsuario;
            this.oCliente = oCliente;
            CantidadProducto = cantidadProducto;
            ImporteTotalDeVenta = importeTotalDeVenta;
            this.oFormaDePago = oFormaDePago;
            FechaRegistro = fechaRegistro;
        }

        public Venta(Comprobante oComprobante, Sucursal oSucursal, Usuario oUsuario, Cliente oCliente, int cantidadProducto, double importeTotalDeVenta, List<FormaDePago> oFormaDePago)
        {
            this.oComprobante = oComprobante;
            this.oSucursal = oSucursal;
            this.oUsuario = oUsuario;
            this.oCliente = oCliente;
            CantidadProducto = cantidadProducto;
            ImporteTotalDeVenta = importeTotalDeVenta;
            this.oFormaDePago = oFormaDePago;
        }

        public Venta()
        {
        }
    }

}
