using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CapaServicioServidor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceColor" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceColor
    {

        [OperationContract]
        bool AgregarColor(Color oColor);
        [OperationContract] //metodos expuestos atraves del webservice
        bool ModificarColor(Color oColor, int IdColor);
        [OperationContract] //metodos expuestos atraves del webservice
        bool EliminarColor(int IdColor);
        [OperationContract] //metodos expuestos atraves del webservice
        List<DtoColor> ListaColor();
        [OperationContract]
        Color ObtenerColor(string Rubro);
    }
    [DataContract]
    public class DtoColor
    {
        [DataMember]
        public int IdColor { get; set; }
        [DataMember]
        public string CodigoColor { get; set; }
        [DataMember]
        public string DescripcionColor { get; set; }
        [DataMember]
        public Estado OEstado { get; set; }
    }
}
