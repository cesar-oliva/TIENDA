using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class RubroProducto
    {
        private int idRubroProducto;
        private string codigoRubroProducto;
        private string descripcionRubroProducto;
        private double margenGanancia;
        private Impuesto oImpuesto;
        private Estado oEstado;
        private DateTime fechaRegistro;

        public int IdRubroProducto { get => idRubroProducto; set => idRubroProducto = value; }
        public string CodigoRubroProducto { get => codigoRubroProducto; set => codigoRubroProducto = value; }
        public string DescripcionRubroProducto { get => descripcionRubroProducto; set => descripcionRubroProducto = value; }
        public double MargenGanancia { get => margenGanancia; set => margenGanancia = value; }
        public Impuesto OImpuesto { get => oImpuesto; set => oImpuesto = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }

        public RubroProducto(string codigoRubroProducto, string descripcionRubroProducto, double margenGanancia, Impuesto oImpuestos, Estado oEstado)
        {
            CodigoRubroProducto = codigoRubroProducto;
            DescripcionRubroProducto = descripcionRubroProducto;
            MargenGanancia = margenGanancia;
            OImpuesto = oImpuestos;
            OEstado = oEstado;
        }

        public RubroProducto()
        {
        }
    }
}
