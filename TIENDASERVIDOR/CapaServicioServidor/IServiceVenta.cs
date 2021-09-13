using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CapaServicioServidor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceVenta" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceVenta
    {
        [OperationContract] //metodos expuestos atraves del webservice
        ///DtoUsuario crearDtoUsuario(string nombres, string apellidos, string correo, string nombreUsuario, string clave);
        bool GenerarVenta(DtoVenta oVenta);
        [OperationContract] //metodos expuestos atraves del webservice
        List<DtoVenta> ListaVenta();
        [OperationContract]
        Venta ObtenerVenta(string oVenta);
        [OperationContract]
        Venta ObtenerVenta(int oVenta);
    }
    [DataContract]
    public class DtoVenta
    {
        [DataMember]
        public int IdVenta { get; set; }
        [DataMember]
        public Comprobante oComprobante { get; set; }
        [DataMember]
        public Sucursal oSucursal { get; set; }
        [DataMember]
        public Usuario oUsuario { get; set; }
        [DataMember]
        public Cliente oCliente { get; set; }
        [DataMember]
        public List<LineaDeVenta> oLineaDeVenta { get; set; }
        [DataMember]
        public int CantidadProducto { get; set; }
        [DataMember]
        public double ImporteTotalDeVenta { get; set; }
        [DataMember]
        public List<FormaDePago> oFormaDePago { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
    }
    [DataContract]
    public class DtoLineaDeVenta
    {
        [DataMember]
        public int IdLineaDeVenta { get; set; }
        [DataMember]
        public Venta oVenta { get; set; }
        [DataMember]
        public Producto oProducto { get; set; }
        [DataMember]
        public int cantidad { get; set; }
        [DataMember]
        public double PrecioUnitario { get; set; }
        [DataMember]
        public double ImporteSubtotal { get; set; }
    }
}

