using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CapaServicioServidor.DataObjectTransfer
{
    [DataContract]
    public class DtoRubroProducto
    {
        [DataMember]
        public int IdRubroProducto { get; set; }
        [DataMember]
        public string CodigoRubroProducto { get; set; }
        [DataMember]
        public string DescripcionRubroProducto { get; set; }
        [DataMember]
        public double MargenGanancia { get; set; }
        [DataMember]
        public string DescripcionImpuesto { get; set; }
        [DataMember]
        public string DescripcionEstado { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
        
    }
}