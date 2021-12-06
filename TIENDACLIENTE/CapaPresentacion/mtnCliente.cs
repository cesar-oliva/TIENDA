using ServiceCliente;
using ServiceCondicionTributaria;
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
    public partial class mtnCliente : Form
    {
        private bool modoEditar = false;
        public mtnCliente(DtoCliente cCliente = null)
        {
            InitializeComponent();
            CargarCombosSeleccion();
            ServiceClienteClient client_cli = new();
            var cliente = client_cli.ListaCliente();
            var IdCliente = 0;
            foreach (var item in cliente)
            {
                if (item.IdCliente >= IdCliente) IdCliente = item.IdCliente + 1;
            }
            if (cCliente != null)
            {
                modoEditar = true;
                cmbEstado.Enabled = true;
                txtId.Text = cCliente.IdCliente.ToString();
                txtCuit.Text = cCliente.Cuit.ToString();
                txtRazonSocial.Text = cCliente.RazonSocial.ToString();
                cmbCondicionTributaria.Text = cCliente.OCondicionTributaria.DescripcionCondicionTributaria.ToString();
                txtDomicilioFiscal.Text = cCliente. DomicilioFiscal.ToString();
                cmbEstado.Text = cCliente.OEstado.ToString();
            }
        }
        private void CargarCombosSeleccion()
        {
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");
            cmbEstado.DisplayMember = "Text";
            cmbEstado.ValueMember = "Value";
            cmbEstado.SelectedIndex = 0;

            using (ServiceCondicionTributaria.ServiceCondicionTributariaClient client_cond = new())
            {
                var oListaCondicionTributaria = client_cond.ListaCondicionTributaria();
                foreach (var item in oListaCondicionTributaria)
                {
                    if (item.OEstado.Equals(ServiceCondicionTributaria.Estado.Activo)) cmbCondicionTributaria.Items.Add(item.DescripcionCondicionTributaria);
                }
                cmbCondicionTributaria.DisplayMember = "Text";
                cmbCondicionTributaria.ValueMember = "Value";
                client_cond.Close();
            }
        }
        private void mtn_Cliente_Load(object sender, EventArgs e)
        {
            txtCuit.Focus();
        }
        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            ServiceClienteClient client = new();
            _ = client.ListaCliente();
            var Cuit = txtCuit.Text.Trim();
            var RazonSocial = txtRazonSocial.Text.Trim();
            var oCondicionTributaria = client.ObtenerCondicionTributariaByDescripcion(cmbCondicionTributaria.Items[cmbCondicionTributaria.SelectedIndex].ToString());
            var DomicilioFiscal= txtDomicilioFiscal.Text.Trim();    
            var oEstado = client.ObtenerEstadoByDescripcion(cmbEstado.Items[cmbEstado.SelectedIndex].ToString());
            DtoCliente cli = new()
            {
                Cuit = Cuit,
                RazonSocial = RazonSocial,
                OCondicionTributaria = oCondicionTributaria,
                DomicilioFiscal = DomicilioFiscal,
                OEstado = oEstado
            };
            bool Respuesta;
            string msgSuccess;
            string msgError;
            if (modoEditar)
            {
                cli.IdCliente = Convert.ToInt32(txtId.Text.Trim());
                Respuesta = client.ModificarCliente(cli);
                msgSuccess = "Cliente Modificado \n¿Desea modificar otro Cliente ahora?";
                msgError = "No se pudo modificar el Cliente, \nes posible que ya se encuentre registrado";
            }
            else
            {

                Respuesta = client.AgregarCliente(cli);
                msgSuccess = "Cliente Registrado \n¿Desea registrar un nuevo Cliente ahora?";
                msgError = "No se pudo registrar el Cliente, \nes posible que ya se encuentre registrado";

            }
            if (Respuesta)
            {
                if (MessageBox.Show(msgSuccess, "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    txtId.Text = "";
                    txtCuit.Text = "";
                    txtRazonSocial.Text = "";
                    cmbCondicionTributaria.SelectedIndex = 0;
                    cmbEstado.SelectedIndex = 0;
                    modoEditar = false;
                    txtCuit.Focus();
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(msgError, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            client.Close();
        }
    }
}
