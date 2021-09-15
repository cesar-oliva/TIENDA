using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CapaServicioServidor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceProducto
    {
        [OperationContract]
        bool IngresarProducto(DtoProducto oProducto);
        [OperationContract]
        bool ModificarProducto(DtoProducto oProducto);
        [OperationContract]
        bool EliminarProducto(int IdProducto);
        [OperationContract]
        List<DtoProducto> ListaProducto();
        [OperationContract]
        GeneroProducto ObtenerGeneroProducto(string oGeneroProducto);
        [OperationContract]
        Estado ObtenerEstado(string oEstado);
        [OperationContract]
        RubroProducto ObtenerRubroProducto(string oRubroProducto);
        [OperationContract]
        Marca ObtenerMarca(string oMarca);
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class DtoProducto
    {
        [DataMember]
        public int IdProducto { get; set; } //id de carga
        [DataMember]
        public string Codigo { get; set; } //codigo espercifico (eje: barra)
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public GeneroProducto OGeneroProducto { get; set; }
        [DataMember]
        public RubroProducto ORubroProducto { get; set; }
        [DataMember]
        public Marca OMarca { get; set; }
        [DataMember]
        public double Impuesto { get; set; }
        [DataMember]
        public double Costo { get; set; }
        [DataMember]
        public double MargenGanancia { get; set; }
        [DataMember]
        public double NetoGravado { get; set; }
        [DataMember]
        public double PrecioVenta { get; set; }
        [DataMember]
        public Estado OEstado { get; set; } //activo o inactivo
        [DataMember]
        public DateTime FechaRegistro { get; set; }
    }
}

