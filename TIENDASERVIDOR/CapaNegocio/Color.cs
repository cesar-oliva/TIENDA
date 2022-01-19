using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Color
    {
        private int idColor;
        private string codigoColor;
        private string descripcionColor;
        private Estado oEstado;
        private DateTime fechaRegistro;
       
        public int IdColor { get => idColor; set => idColor = value; }
        public string CodigoColor { get => codigoColor; set => codigoColor = value; }
        public string DescripcionColor { get => descripcionColor; set => descripcionColor = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }

        public Color()
        {
        }
    }
}
