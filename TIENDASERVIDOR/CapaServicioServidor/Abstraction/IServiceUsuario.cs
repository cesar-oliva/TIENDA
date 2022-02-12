using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CapaServicioServidor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceUsuario" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceUsuario
    {
        [OperationContract] //metodos expuestos atraves del webservice
        ///DtoUsuario crearDtoUsuario(string nombres, string apellidos, string correo, string nombreUsuario, string clave);
        bool AgregarUsuario(DtoUsuario oUsuario);
        [OperationContract] //metodos expuestos atraves del webservice
        bool ModificarUsuario(DtoUsuario oUsuario, int IdUsuario);
        [OperationContract] //metodos expuestos atraves del webservice
        bool EliminarUsuario(int IdUsuario);
        [OperationContract] //metodos expuestos atraves del webservice
        bool LoginUsuario(string usuario, string contraseña);
        [OperationContract] //metodos expuestos atraves del webservice
        List<DtoUsuario> ObtenerUsuario();
        [OperationContract] //metodos expuestos atraves del webservice
        DtoUsuario ObtenerUsuarioByNombre(string usuario);
        [OperationContract] //metodos expuestos atraves del webservice
        bool RecuperarContraseña(string usuario);

    }
    [DataContract]
    public class DtoUsuario : BaseRespuesta
    {
        [DataMember]
        public int IdUsuario { get; set; }
        [DataMember]
        public Empleado OEmpleado { get; set; }
        [DataMember]
        public string NombreUsuario { get; set; }
        [DataMember]
        public string Contraseña { get; set; }
        [DataMember]
        public Tienda OTienda { get; set; }
        [DataMember]
        public Rol ORol { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public Estado OEstado { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
    }


    [DataContract] //clases que se veran a traves del web ervice
    public class BaseRespuesta
    {
        public string MensajeRespuesta { get; set; }

    }
}
