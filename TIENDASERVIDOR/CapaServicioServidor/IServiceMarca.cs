using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CapaServicioServidor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceMarca" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceMarca
    {
        [OperationContract] //metodos expuestos atraves del webservice
        ///DtoUsuario crearDtoUsuario(string nombres, string apellidos, string correo, string nombreUsuario, string clave);
        bool AgregarMarca(DtoMarca oMarca);
        [OperationContract] //metodos expuestos atraves del webservice
        bool ModificarMarca(DtoMarca oMarca, int IdMarca);
        [OperationContract] //metodos expuestos atraves del webservice
        bool EliminarMarca(int IdMarca);
        [OperationContract] //metodos expuestos atraves del webservice
        List<DtoMarca> ListaMarca();
        [OperationContract]
        Marca ObtenerMarca(string oMarca);
    }
    [DataContract]
    public class DtoMarca
    {
        [DataMember]
        public int IdMarca { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public Estado oEstado { get; set; }
    }
}

