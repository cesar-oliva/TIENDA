using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CapaServicioServidor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceGeneroProducto" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceGeneroProducto
    {

        [OperationContract] //metodos expuestos atraves del webservice
        ///DtoUsuario crearDtoUsuario(string nombres, string apellidos, string correo, string nombreUsuario, string clave);
        bool AgregarGeneroProducto(DtoGeneroProducto oGeneroProducto);
        [OperationContract] //metodos expuestos atraves del webservice
        bool ModificarGeneroProducto(DtoGeneroProducto oGeneroProducto, int IdGeneroProducto);
        [OperationContract] //metodos expuestos atraves del webservice
        bool EliminarGeneroProducto(int IdGeneroProducto);
        [OperationContract] //metodos expuestos atraves del webservice
        List<DtoGeneroProducto> ListaGeneroProducto();
        [OperationContract]
        GeneroProducto ObtenerGeneroProducto(string oGeneroProducto);
    }
    [DataContract]
    public class DtoGeneroProducto
    {
        [DataMember]
        public int IdGeneroProducto { get; set; }
        [DataMember]
        public string DescripcionGeneroProducto { get; set; }
        [DataMember]
        public Estado OEstado { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
    }

}
