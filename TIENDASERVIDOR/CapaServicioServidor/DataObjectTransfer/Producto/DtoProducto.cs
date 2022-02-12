using CapaNegocio;
using CapaServicioServidor.DataObjectTransfer.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CapaServicioServidor.DataObjectTransfer
{
    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class DtoProducto
    {
        //Objeto
        [DataMember]
        public int IdProducto { get; set; } //id de carga
        [DataMember]
        public string CodigoProducto { get; set; } //codigo espercifico (eje: barra)
        [DataMember]
        public string DescripcionProducto { get; set; }
        [DataMember]
        public string DescripcionGeneroProducto { get; set; }
        [DataMember]
        public string DescripcionRubroProducto { get; set; }
        [DataMember]
        public string DescripcionMarcaProducto { get; set; }
        [DataMember]
        public double CostoProducto { get; set; }
        [DataMember]
        public string DescripcionEstado { get; set; } //activo o inactivo
        [DataMember]
        public DateTime FechaRegistro { get; set; }
        [DataMember]
        public string DescripcionTipoTalle { get; set; }
        [DataMember]
        public List<DtoDetalleProducto> DetallePoducto { get; set; }



    }
}