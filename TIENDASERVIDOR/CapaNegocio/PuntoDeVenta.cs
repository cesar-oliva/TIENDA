using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class PuntoDeVenta
    {
        private int idPuntoDeVenta;
        private string codigoPuntoDeVenta;
        private string sistemaFacturacion;
        private string domicilioFacturacion;
        private string nombreFantasia;
        private Estado oEstado;
        private DateTime fechaRegistro;

        public int IdPuntoDeVenta { get => idPuntoDeVenta; set => idPuntoDeVenta = value; }
        public string CodigoPuntoDeVenta { get => codigoPuntoDeVenta; set => codigoPuntoDeVenta = value; }
        public string SistemaFacturacion { get => sistemaFacturacion; set => sistemaFacturacion = value; }
        public string DomicilioFacturacion { get => domicilioFacturacion; set => domicilioFacturacion = value; }
        public string NombreFantasia { get => nombreFantasia; set => nombreFantasia = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }

        public PuntoDeVenta()
        {
        }
    }
}
