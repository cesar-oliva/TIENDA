using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CapaServicioServidor.DataObjectTransfer.Impuesto
{
    [DataContract]
    public class DtoImpuesto
    {
        [DataMember]
        public int IdImpuesto { get; set; } //id de carga
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public double Alicuota { get; set; }
        [DataMember]
        public Estado OEstado { get; set; } //activo o inactivo
        [DataMember]
        public DateTime FechaRegistro { get; set; }
    }
}

