using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CapaServicioServidor.DataObjectTransfer.Producto
{
    public class DtoFormProducto
    {
        //Formulario
        [DataMember]
        public List<string> ListGeneroProducto { get; set; }
        [DataMember]
        public List<string> ListRubroProducto { get; set; }
        [DataMember]
        public List<string> ListMarcaProducto { get; set; }
        [DataMember]
        public List<string> ListTipoTalle { get; set; }
        [DataMember]
        public List<(string,string)> ListTalle { get; set; }
        [DataMember]
        public List<string> ListColor { get; set; }
        [DataMember]
        public List<string> ListEstado { get; set; }
    }
}