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
    public interface IServiceRubro
    {
        [OperationContract] //metodos expuestos atraves del webservice
        ///DtoUsuario crearDtoUsuario(string nombres, string apellidos, string correo, string nombreUsuario, string clave);
        bool AgregarRubro(DtoRubro oRubro);
        [OperationContract] //metodos expuestos atraves del webservice
        bool ModificarRubro(DtoRubro oRubro, int IdRubro);
        [OperationContract] //metodos expuestos atraves del webservice
        bool EliminarRubro(int IdRubro);
        [OperationContract] //metodos expuestos atraves del webservice
        List<DtoRubro> ListaRubro();
        [OperationContract]
        RubroProducto ObtenerRubro(string oRubro);
    }
    [DataContract]
    public class DtoRubro
    {
        [DataMember]
        public int IdRubro { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public Estado oEstado { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
    }
}
