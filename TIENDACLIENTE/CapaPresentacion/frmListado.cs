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
    public partial class frmListado : Form
    {
        string cuit = "";
        public frmListado()
        {
            InitializeComponent();
        }
        DataTable lista = new();
        private void frmListado_Load_1(object sender, EventArgs e)
        {
            tabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tabla.MultiSelect = false;
            tabla.ReadOnly = true;
            tabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabla.AllowUserToAddRows = false;
            CargarDatosClientes();
        }
        private void CargarDatosClientes()
        {
            using ServiceCliente.ServiceClienteClient client = new();
            var oListaCliente = client.ListaCliente();
            if (oListaCliente.Count() > 0 && oListaCliente != null)
            {
                lblTotalRegistros.Text = oListaCliente.Count().ToString();
                lista = new DataTable();
                lista.Columns.Clear();
                lista.Rows.Clear();
                cmbFiltro.Items.Clear();
                lista.Columns.Add("IdCliente", typeof(int));
                lista.Columns.Add("Cuit", typeof(string));
                lista.Columns.Add("RazonSocial", typeof(string));
                lista.Columns.Add("CondicionTributaria", typeof(string));
                lista.Columns.Add("DomicilioFiscal", typeof(string));
                lista.Columns.Add("Estado", typeof(string));
                lista.Columns.Add("FechaRegistro", typeof(DateTime));
                foreach (DtoCliente row in oListaCliente)
                {
                    if (row.OEstado.Equals(ServiceCliente.Estado.Activo))
                    {
                        lista.Rows.Add(row.IdCliente, row.Cuit, row.RazonSocial, row.OCondicionTributaria.DescripcionCondicionTributaria, row.DomicilioFiscal, row.OEstado, row.FechaRegistro);
                    }
                }
                tabla.DataSource = lista;
                tabla.AutoResizeColumns();
                tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                tabla.Columns["IdCliente"].Visible = false;
                tabla.Columns["Cuit"].Visible = true;
                tabla.Columns["RazonSocial"].Visible = true;
                tabla.Columns["CondicionTributaria"].Visible = true;
                tabla.Columns["DomicilioFiscal"].Visible = true;
                tabla.Columns["Estado"].Visible = true;
                tabla.Columns["FechaRegistro"].Visible = true;
                foreach (DataGridViewColumn cl in tabla.Columns)
                {
                    if (cl.Visible == true)
                    {
                        cmbFiltro.Items.Add(cl.HeaderText);
                    }
                }
                cmbFiltro.SelectedIndex = 0;
            }
            lblTotalRegistros.Text = Convert.ToString(tabla.Rows.Count);
        }
        private void txtFiltro_TextChanged_1(object sender, EventArgs e)
        {
            string columnaFiltro = cmbFiltro.SelectedItem.ToString();
            (tabla.DataSource as DataTable).DefaultView.RowFilter = string.Format(columnaFiltro + " like '%{0}%'", txtFiltro.Text);
        }
        public string ObtenerCliente()
        {
            return cuit;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cuit = tabla.Rows[e.RowIndex].Cells["Cuit"].Value.ToString();
        }
    }
}
