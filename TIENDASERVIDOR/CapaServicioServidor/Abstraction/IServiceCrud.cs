using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CapaServicioServidor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceCrud<T> where T : class
    {
        [OperationContract]
        bool Registrar(T oEntity);
        [OperationContract]
        bool Actualizar (T oEntity);
        [OperationContract]
        bool Eliminar(int idEntity);
        [OperationContract]
        List<T> Mostrar();
    }
}