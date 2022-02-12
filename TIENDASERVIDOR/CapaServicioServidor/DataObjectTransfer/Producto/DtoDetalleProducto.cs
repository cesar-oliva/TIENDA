using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CapaServicioServidor.DataObjectTransfer.Producto
{
    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class DtoDetalleProducto
    {
        //Objeto
        [DataMember]
        public int IdDetalleProducto { get; set; }
        [DataMember]
        public string CodigoProducto { get; set; }
        [DataMember]
        public string DescripcionProducto { get; set; }
        [DataMember] 
        public string TalleProducto  { get; set; }
        [DataMember]
        public string ColorProducto { get; set; }
        [DataMember]
        public double PrecioVenta { get { return PrecioCosto * (1 + (MargenGanancia / 100)); } set => PrecioVenta = 0; }
        [DataMember]
        public int StockProducto { get; set; }
        [DataMember]
        public string DescripcionEstado { get; set; }
        public double PrecioCosto { get; set; }
        public double MargenGanancia { get; set; }
    }
}