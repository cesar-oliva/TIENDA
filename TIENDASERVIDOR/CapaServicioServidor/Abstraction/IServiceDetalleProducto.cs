using CapaNegocio;
using CapaServicioServidor.DataObjectTransfer.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CapaServicioServidor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceProductoVenta" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceDetalleProducto
    {
        [OperationContract]
        List<DtoDetalleProducto> MostrarDetalle();
        [OperationContract]
        DetalleProducto BuscarDetalleProductoById(int idProductoVenta);
    }
}

