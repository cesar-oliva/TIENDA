using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Venta
    {
        private int idVenta;
        private Comprobante oComprobante;
        private Sucursal oSucursal;
        private Usuario oUsuario;
        private Cliente oCliente;
        private List<LineaDeVenta> oLineaDeVenta;
        private int cantidadProducto;
        private double importeTotalDeVenta;
        private List<FormaDePago> oFormaDePago;
        private DateTime fechaRegistro;

        public int IdVenta { get => idVenta; set => idVenta = value; }
        public Comprobante OComprobante { get => oComprobante; set => oComprobante = value; }
        public Sucursal OSucursal { get => oSucursal; set => oSucursal = value; }
        public Usuario OUsuario { get => oUsuario; set => oUsuario = value; }
        public Cliente OCliente { get => oCliente; set => oCliente = value; }
        public List<LineaDeVenta> OLineaDeVenta { get => oLineaDeVenta; set => oLineaDeVenta = value; }
        public int CantidadProducto { get => cantidadProducto; set => cantidadProducto = value; }
        public double ImporteTotalDeVenta { get => importeTotalDeVenta; set => importeTotalDeVenta = value; }
        public List<FormaDePago> OFormaDePago { get => oFormaDePago; set => oFormaDePago = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }

        public Venta()
        {
        }

        public Venta(int idVenta, Comprobante oComprobante, Sucursal oSucursal, Usuario oUsuario, Cliente oCliente, List<LineaDeVenta> oLineaDeVenta, int cantidadProducto, double importeTotalDeVenta, List<FormaDePago> oFormaDePago, DateTime fechaRegistro)
        {
            IdVenta = idVenta;
            OComprobante = oComprobante;
            OSucursal = oSucursal;
            OUsuario = oUsuario;
            OCliente = oCliente;
            OLineaDeVenta = oLineaDeVenta;
            CantidadProducto = cantidadProducto;
            ImporteTotalDeVenta = importeTotalDeVenta;
            OFormaDePago = oFormaDePago;
            FechaRegistro = fechaRegistro;
        }

        public Venta(Comprobante oComprobante, Sucursal oSucursal, Usuario oUsuario, Cliente oCliente, List<LineaDeVenta> oLineaDeVenta, int cantidadProducto, double importeTotalDeVenta, List<FormaDePago> oFormaDePago)
        {
            OComprobante = oComprobante;
            OSucursal = oSucursal;
            OUsuario = oUsuario;
            OCliente = oCliente;
            OLineaDeVenta = oLineaDeVenta;
            CantidadProducto = cantidadProducto;
            ImporteTotalDeVenta = importeTotalDeVenta;
            OFormaDePago = oFormaDePago;
        }
    }
    

}
