using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CapaServicioServidor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceImpuesto" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceImpuesto
    {
        [OperationContract]
        bool IngresarImpuesto(DtoImpuesto oImpuesto);
        [OperationContract]
        bool ActualizarImpuesto(DtoImpuesto oImpuestoo);
        [OperationContract]
        bool EliminarImpuesto(int IdImpuesto);
        [OperationContract]
        List<DtoImpuesto> ListaImpuesto();
    }

    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
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
        public string oEstado { get; set; } //activo o inactivo
        [DataMember]
        public DateTime FechaRegistro { get; set; }
    }
}
