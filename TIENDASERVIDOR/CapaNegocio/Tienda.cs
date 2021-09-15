using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Tienda
    {

        private int idTienda;
        private string razonSocial;
        private string cuitTienda;
        private string direccion;
        private string telefono;
        private Estado oEstado;
        private DateTime fechaRegistro;

        public int IdTienda { get => idTienda; set => idTienda = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public string CuitTienda { get => cuitTienda; set => cuitTienda = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public Estado OEstado { get => oEstado; set => oEstado = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public Tienda()
        {
        }
        public Tienda(string razonSocial, string cuitTienda, string direccion, string telefono, Estado oEstado)
        {
            RazonSocial = razonSocial;
            CuitTienda = cuitTienda;
            Direccion = direccion;
            Telefono = telefono;
            OEstado = oEstado;
        }
        public Tienda(int idTienda, string razonSocial, string cuitTienda, string direccion, string telefono, Estado oEstado, DateTime fechaRegistro)
        {
            IdTienda = idTienda;
            RazonSocial = razonSocial;
            CuitTienda = cuitTienda;
            Direccion = direccion;
            Telefono = telefono;
            OEstado = oEstado;
            FechaRegistro = fechaRegistro;
        }

    }
}
