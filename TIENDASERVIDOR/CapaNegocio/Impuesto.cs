using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Impuesto
    {
        private int idImpuesto;
        private string descripcion;
        private double alicuota;
        private Estado oEstado;
        private DateTime fechaRegistro;
        public int IdImpuesto { get => idImpuesto; set => idImpuesto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Alicuota { get => alicuota; set => alicuota = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public Impuesto(string descripcion, double alicuota, Estado oEstado)
        {
            Descripcion = descripcion;
            Alicuota = alicuota;
            OEstado = oEstado;
        }
        public Impuesto()
        {
        }
    }
}
