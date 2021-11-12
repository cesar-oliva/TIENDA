using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CapaServicioServidor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceCliente" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceCliente
    {
        [OperationContract]
        bool AgregarCliente(DtoCliente oCliente);
        [OperationContract]
        bool ModificarCliente(DtoCliente oCliente);
        [OperationContract]
        bool EliminarCliente(int IdCliente);
        [OperationContract]
        List<DtoCliente> ListaCliente();
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class DtoCliente
    {
        [DataMember]
        public int IdCliente { get; set; } //id de carga
        [DataMember]
        public string Cuit { get; set; } //codigo espercifico (eje: barra)
        [DataMember]
        public string RazonSocial { get; set; }
        [DataMember]
        public CondicionTributaria OCondicionTributaria { get; set; }
        [DataMember]
        public string DomicilioFiscal{ get; set; }
        public Estado OEstado { get; set; } //activo o inactivo
        [DataMember]
        public DateTime FechaRegistro { get; set; }
    }
}

