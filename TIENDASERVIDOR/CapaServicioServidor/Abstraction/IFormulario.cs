using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicioServidor.Abstraction
{
    [ServiceContract]
    public interface IFormulario<T>
    {
        [OperationContract]
        T GetFormulario();
    }
}
