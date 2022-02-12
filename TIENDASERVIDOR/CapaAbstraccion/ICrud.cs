using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAbstraccion
{
    public interface ICrud<T> where T : class
    {
        int Registrar(T oEntity);
        bool Actualizar(T oEntity);
        bool Eliminar(int IdEntity);
        List<T> Mostrar();
        T BuscarByDescripcion(string oDescripcionEntity);
        T BuscarById(int oIdEntity);
    }
}
