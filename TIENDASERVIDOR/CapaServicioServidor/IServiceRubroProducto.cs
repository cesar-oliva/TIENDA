using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CapaServicioServidor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceRubro" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceRubroProducto
    {
        [OperationContract] //metodos expuestos atraves del webservice
        bool AgregarRubroProducto(DtoRubroProducto oRubroProducto);
        [OperationContract] //metodos expuestos atraves del webservice
        bool ModificarRubroProducto(DtoRubroProducto oRubroProducto);
        [OperationContract] //metodos expuestos atraves del webservice
        bool EliminarRubroProducto(int IdRubroProducto);
        [OperationContract] //metodos expuestos atraves del webservice
        List<DtoRubroProducto> ListaRubroProducto();
        [OperationContract]
        RubroProducto ObtenerRubroProductoByDescripcion(string oRubroProducto);
        [OperationContract]
        RubroProducto ObtenerRubroProductoById(int oRubroProducto);
        [OperationContract]
        Estado ObtenerEstadoByDescripcion(string oEstado);
        [OperationContract]
        Impuesto ObtenerImpuestoByDescripcion(string oImpuesto);
        [OperationContract]
        Impuesto ObtenerImpuestoById(int oImpuesto);
    }
    [DataContract]
    public class DtoRubroProducto
    {
        [DataMember]
        public int IdRubroProducto { get; set; }
        [DataMember]
        public string CodigoRubroProducto { get; set; }
        [DataMember]
        public string DescripcionRubroProducto { get; set; }
        [DataMember]
        public double MargenGanancia { get; set; }
        [DataMember]
        public Impuesto OImpuesto { get; set; }
        [DataMember]
        public Estado OEstado { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
    }
}
