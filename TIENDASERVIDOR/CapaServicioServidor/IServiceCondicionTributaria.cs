using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CapaServicioServidor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceCondicionTributaria" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceCondicionTributaria
    {
        [OperationContract] //metodos expuestos atraves del webservice
        bool AgregarCondicionTributaria(DtoCondicionTributaria oCondicionTributaria);
        [OperationContract] //metodos expuestos atraves del webservice
        bool ModificarCondicionTributaria(DtoCondicionTributaria oCondicionTributaria);
        [OperationContract] //metodos expuestos atraves del webservice
        bool EliminarCondicionTributaria(int IdCondicionTributaria);
        [OperationContract] //metodos expuestos atraves del webservice
        List<DtoCondicionTributaria> ListaCondicionTributaria();
        [OperationContract]
        CondicionTributaria ObtenerCondicionTributariaByDescripcion(string oCondicionTributaria);
        [OperationContract]
        CondicionTributaria ObtenerCondicionTributariaById(int oCondicionTributaria);
        [OperationContract]
        Estado ObtenerEstadoByDescripcion(string oEstado);
    }
    [DataContract]
    public class DtoCondicionTributaria
    {
        [DataMember]
        public int IdCondicionTributaria { get; set; }
        [DataMember]
        public string CodigoCondicionTributaria{ get; set; }
        [DataMember]
        public string DescripcionCondicionTributaria { get; set; }
        [DataMember]
        public Estado OEstado { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
    }
}

