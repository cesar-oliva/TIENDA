using ServiceCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmVenta : Form
    {
        public frmVenta()
        {
            InitializeComponent();
            using ServiceCliente.ServiceClienteClient client = new();
            List<DtoCliente> oListaCliente = client.ListaCliente();
            txtCuit.Text = "00-00000000-0";
            foreach (var item in oListaCliente)
            {
                if (txtCuit.Text.Trim().ToString().Equals(item.Cuit.ToString()))
                {
                    txtRazonSocial.Text = item.RazonSocial.ToString();
                    txtDomicilio.Text = item.DomicilioFiscal.ToString();
                    txtCondicion.Text = item.OCondicionTributaria.Codigo.ToString();
                }
            }
        }
        private void MtxtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            using ServiceCliente.ServiceClienteClient client = new();
            List<DtoCliente> oListaCliente = client.ListaCliente();
            bool bandera = false;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                foreach (var item in oListaCliente)
                {
                    if (txtCuit.Text.Trim().ToString().Equals(item.Cuit.ToString()))
                    {
                        txtRazonSocial.Text = item.RazonSocial.ToString();
                        txtDomicilio.Text = item.DomicilioFiscal.ToString();
                        txtCondicion.Text = item.OCondicionTributaria.Codigo.ToString();
                        bandera = true;
                    }
                }
                if (bandera == false)
                {
                    MessageBox.Show("El Cuit ingresado no corresponde a un Cliente activo");
                    txtCuit.Text = "00-00000000-0";
                    foreach (var item in oListaCliente)
                    {
                        if (txtCuit.Text.Trim().ToString().Equals(item.Cuit.ToString()))
                        {
                            txtRazonSocial.Text = item.RazonSocial.ToString();
                            txtDomicilio.Text = item.DomicilioFiscal.ToString();
                            txtCondicion.Text = item.OCondicionTributaria.Codigo.ToString();
                            bandera = true;
                        }
                    }
                }
            }
        }
        private void txtCuit_Click(object sender, EventArgs e)
        {
            txtCuit.Text = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmDetalleProducto fdp = new();
            fdp.ShowDialog();   
        }
    }

}
