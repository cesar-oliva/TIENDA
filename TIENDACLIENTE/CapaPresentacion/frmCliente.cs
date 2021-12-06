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
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }
        DataTable TablaCliente = new();

        private void frmCliente_Load(object sender, EventArgs e)
        {
            dataGridCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridCliente.MultiSelect = false;
            dataGridCliente.ReadOnly = true;
            dataGridCliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridCliente.AllowUserToAddRows = false;
            CargarDatosClientes();
        }
        private void CargarDatosClientes()
        {
            using ServiceCliente.ServiceClienteClient client = new();
            var oListaCliente = client.ListaCliente();
            if (oListaCliente.Count() > 0 && oListaCliente != null)
            {
                lblTotalRegistros.Text = oListaCliente.Count().ToString();
                TablaCliente = new DataTable();
                TablaCliente.Columns.Clear();
                TablaCliente.Rows.Clear();
                cmbFiltro.Items.Clear();
                TablaCliente.Columns.Add("IdCliente", typeof(int));
                TablaCliente.Columns.Add("Cuit", typeof(string));
                TablaCliente.Columns.Add("RazonSocial", typeof(string));
                TablaCliente.Columns.Add("CondicionTributaria", typeof(string));
                TablaCliente.Columns.Add("DomicilioFiscal", typeof(string));
                TablaCliente.Columns.Add("Estado", typeof(string));
                TablaCliente.Columns.Add("FechaRegistro", typeof(DateTime));
                foreach (DtoCliente row in oListaCliente)
                {
                    if (row.OEstado.Equals(ServiceCliente.Estado.Activo))
                    {
                        TablaCliente.Rows.Add(row.IdCliente, row.Cuit, row.RazonSocial, row.OCondicionTributaria.DescripcionCondicionTributaria, row.DomicilioFiscal,row.OEstado, row.FechaRegistro);
                    }
                }
                dataGridCliente.DataSource = TablaCliente;
                dataGridCliente.AutoResizeColumns();
                dataGridCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridCliente.Columns["IdCliente"].Visible = false;
                dataGridCliente.Columns["Cuit"].Visible = true;
                dataGridCliente.Columns["RazonSocial"].Visible = true;
                dataGridCliente.Columns["CondicionTributaria"].Visible = true;
                dataGridCliente.Columns["DomicilioFiscal"].Visible = true;
                dataGridCliente.Columns["Estado"].Visible = true;
                dataGridCliente.Columns["FechaRegistro"].Visible = true;
                foreach (DataGridViewColumn cl in dataGridCliente.Columns)
                {
                    if (cl.Visible == true)
                    {
                        cmbFiltro.Items.Add(cl.HeaderText);
                    }
                }
                cmbFiltro.SelectedIndex = 0;
            }
            lblTotalRegistros.Text = Convert.ToString(dataGridCliente.Rows.Count - 1);
        }
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string columnaFiltro = cmbFiltro.SelectedItem.ToString();
            (dataGridCliente.DataSource as DataTable).DefaultView.RowFilter = string.Format(columnaFiltro + " like '%{0}%'", txtFiltro.Text);
        }
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            mtnCliente mtn = new();
            mtn.ShowDialog();
            CargarDatosClientes();

        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            using ServiceCliente.ServiceClienteClient client = new();
            if (dataGridCliente.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dataGridCliente.SelectedRows[0];
                int index = currentRow.Index;
                DtoCliente oCliente = new()
                {
                    IdCliente = Convert.ToInt32(dataGridCliente.Rows[index].Cells["IdCliente"].Value),
                    Cuit = Convert.ToString(dataGridCliente.Rows[index].Cells["Cuit"].Value),
                    RazonSocial = Convert.ToString(dataGridCliente.Rows[index].Cells["RazonSocial"].Value),
                    OCondicionTributaria = client.ObtenerCondicionTributariaByDescripcion(Convert.ToString(dataGridCliente.Rows[index].Cells["CondicionTributaria"].Value)),
                    DomicilioFiscal = Convert.ToString(dataGridCliente.Rows[index].Cells["DomicilioFiscal"].Value),
                    OEstado = client.ObtenerEstadoByDescripcion(Convert.ToString(dataGridCliente.Rows[index].Cells["Estado"].Value))
                };
                mtnCliente form = new(oCliente);
                form.ShowDialog();
                CargarDatosClientes();
            }
            else
            {
                MessageBox.Show("Selecciona un registro de la lista");
            }
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            using ServiceCliente.ServiceClienteClient client = new();
            if (dataGridCliente.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dataGridCliente.SelectedRows[0];
                int index = currentRow.Index;

                int IdCliente = Convert.ToInt32(dataGridCliente.Rows[index].Cells["IdCliente"].Value);
                string RazonSocial= Convert.ToString(dataGridCliente.Rows[index].Cells["RazonSocial"].Value);

                if (MessageBox.Show(string.Format("{0} '{1}' {2}", "¿Desea eliminar el cliente",RazonSocial, "permanentemente?"), "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    bool Respuesta = client.EliminarCliente(IdCliente);
                    if (Respuesta)
                    {
                        MessageBox.Show(string.Format("{0} {1} {2}", "El cliente", RazonSocial, "fue eliminado"), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatosClientes();
                    }
                    else
                    {
                        MessageBox.Show(string.Format("{0} {1} {2} \n{3}", "El cliente", RazonSocial, "no fue eliminado.", "El cliente se encuentra asignado a alguna venta actualmente"), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }


            }
            else
            {
                MessageBox.Show("Selecciona un registro de la lista");
            }
        }
    }
}

