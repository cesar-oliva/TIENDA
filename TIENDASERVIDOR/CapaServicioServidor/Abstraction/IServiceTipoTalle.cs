using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CapaServicioServidor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceTipoTipoTalle" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceTipoTalle
    {
        [OperationContract]
        bool AgregarTipoTalle(TipoTalle oTipoTipoTalle);
        [OperationContract] //metodos expuestos atraves del webservice
        bool ModificarTipoTalle(TipoTalle oTipoTalle, int IdTipoTalle);
        [OperationContract] //metodos expuestos atraves del webservice
        bool EliminarTipoTalle(int IdTipoTalle);
        [OperationContract] //metodos expuestos atraves del webservice
        List<DtoTipoTalle> ListaTipoTalle();
        [OperationContract]
        TipoTalle ObtenerTipoTalleByDescripcion(string oTipoTalle);
    }
    [DataContract]
    public class DtoTipoTalle
    {
        [DataMember]
        public int IdTipoTalle { get; set; }
        [DataMember]
        public string DescripcionTipoTalle { get; set; }
        [DataMember]
        public Estado OEstado { get; set; }
    }
}

