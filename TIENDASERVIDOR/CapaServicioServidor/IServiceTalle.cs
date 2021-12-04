using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CapaServicioServidor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceTalle" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceTalle
    {
        [OperationContract]
        bool AgregarTalle(Talle oTalle);
        [OperationContract] //metodos expuestos atraves del webservice
        bool ModificarTalle(Talle oTalle, int IdTalle);
        [OperationContract] //metodos expuestos atraves del webservice
        bool EliminarTalle(int IdTalle);
        [OperationContract] //metodos expuestos atraves del webservice
        List<DtoTalle> ListaTalle();
        [OperationContract]
        Talle ObtenerTalle(string Rubro);
    }
    [DataContract]
    public class DtoTalle
    {
        [DataMember]
        public int IdTalle { get; set; }
        [DataMember]
        public string CodigoTalle { get; set; }
        [DataMember]
        public string DescripcionTalle { get; set; }
        [DataMember]
        public Estado OEstado { get; set; }
    }
}
