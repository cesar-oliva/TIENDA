using ServiceImpuesto;
using ServiceProducto;
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
    public partial class FrmProducto : Form
    {
        DataTable TablaProducto = new();
        public FrmProducto()
        {
            InitializeComponent();
        }
        private void Frm_Producto_Load(object sender, EventArgs e)
        {
            CargarDatosProductos();

            dataGridProducto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridProducto.MultiSelect = false;
            dataGridProducto.ReadOnly = true;
            dataGridProducto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProducto.AllowUserToAddRows = false;
        }
        private void CargarDatosProductos()
        {
            using ServiceProducto.ServiceProductoClient client = new();
            List<DtoProducto> oListaProducto = client.ListaProducto();
            if (oListaProducto.Count > 0 && oListaProducto != null)
            {
                lblTotalRegistros.Text = oListaProducto.Count.ToString();
                TablaProducto = new DataTable();
                TablaProducto.Columns.Clear();
                TablaProducto.Rows.Clear();
                cmbFiltro.Items.Clear();
                TablaProducto.Columns.Add("IdProducto", typeof(int));
                TablaProducto.Columns.Add("Codigo", typeof(string));
                TablaProducto.Columns.Add("Descripcion", typeof(string));
                TablaProducto.Columns.Add("GeneroProducto", typeof(string));
                TablaProducto.Columns.Add("RubroProducto", typeof(string));
                TablaProducto.Columns.Add("Marca", typeof(string));
                TablaProducto.Columns.Add("Impuesto", typeof(double));
                TablaProducto.Columns.Add("Costo", typeof(double));
                TablaProducto.Columns.Add("MargenGanancia", typeof(double));
                TablaProducto.Columns.Add("NetoGravado", typeof(double));
                TablaProducto.Columns.Add("PrecioVenta", typeof(double));
                TablaProducto.Columns.Add("Estado", typeof(string));
                TablaProducto.Columns.Add("FechaRegistro", typeof(DateTime));
                foreach (DtoProducto row in oListaProducto)
                {
                    TablaProducto.Rows.Add(row.IdProducto, row.Codigo, row.Descripcion, row.OGeneroProducto, row.ORubroProducto.Descripcion, row.OMarca.Descripcion, row.Impuesto, row.Costo, row.MargenGanancia, row.NetoGravado, row.PrecioVenta, row.OEstado, row.FechaRegistro);
                }
                dataGridProducto.DataSource = TablaProducto;
                dataGridProducto.Columns["IdProducto"].Visible = false;
                dataGridProducto.Columns["Codigo"].Visible = true;
                dataGridProducto.Columns["Descripcion"].Visible = true;
                dataGridProducto.Columns["GeneroProducto"].Visible = true;
                dataGridProducto.Columns["RubroProducto"].Visible = true;
                dataGridProducto.Columns["Marca"].Visible = true;
                dataGridProducto.Columns["Impuesto"].Visible = true;
                dataGridProducto.Columns["Costo"].Visible = false;
                dataGridProducto.Columns["MargenGanancia"].Visible = false;
                dataGridProducto.Columns["NetoGravado"].Visible = true;
                dataGridProducto.Columns["PrecioVenta"].Visible = true;
                dataGridProducto.Columns["Estado"].Visible = true;
                dataGridProducto.Columns["FechaRegistro"].Visible = true;
                foreach (DataGridViewColumn cl in dataGridProducto.Columns)
                {
                    if (cl.Visible == true)
                    {
                        cmbFiltro.Items.Add(cl.HeaderText);
                    }
                }
                cmbFiltro.SelectedIndex = 0;
            }
        }
        private void Txt_Filtro_TextChanged(object sender, EventArgs e)
        {
            string columnaFiltro = cmbFiltro.SelectedItem.ToString();
            (dataGridProducto.DataSource as DataTable).DefaultView.RowFilter = string.Format(columnaFiltro + " like '%{0}%'", txtFiltro.Text);
        }
      
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            MtnProducto mtn = new();
            mtn.ShowDialog();
            CargarDatosProductos();

        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            using ServiceProducto.ServiceProductoClient client = new();
            ServiceImpuestoClient client_imp = new();
            List<DtoImpuesto> imp = client_imp.ListaImpuesto();
            if (dataGridProducto.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dataGridProducto.SelectedRows[0];
                int index = currentRow.Index;
                double Impuesto = 0.00;
                foreach (var item in imp)
                {
                    if (item.Descripcion.Equals(Convert.ToString(dataGridProducto.Rows[index].Cells["Impuesto"].Value))) Impuesto = item.Alicuota;
                }
                DtoProducto oProducto = new()
                {
                    IdProducto = Convert.ToInt32(dataGridProducto.Rows[index].Cells["IdProducto"].Value),
                    Codigo = Convert.ToString(dataGridProducto.Rows[index].Cells["Codigo"].Value),
                    Descripcion = Convert.ToString(dataGridProducto.Rows[index].Cells["Descripcion"].Value),
                    OGeneroProducto = client.ObtenerGeneroProducto(Convert.ToString(dataGridProducto.Rows[index].Cells["GeneroProducto"].Value)),
                    ORubroProducto = client.ObtenerRubroProducto(Convert.ToString(dataGridProducto.Rows[index].Cells["RubroProducto"].Value)),
                    Costo = Convert.ToDouble(dataGridProducto.Rows[index].Cells["Costo"].Value),
                    OMarca = client.ObtenerMarca(Convert.ToString(dataGridProducto.Rows[index].Cells["Marca"].Value)),
                    Impuesto = Impuesto,
                    NetoGravado = Convert.ToDouble(dataGridProducto.Rows[index].Cells["NetoGravado"].Value),
                    PrecioVenta = Convert.ToDouble(dataGridProducto.Rows[index].Cells["PrecioVenta"].Value),
                    OEstado = client.ObtenerEstado(Convert.ToString(dataGridProducto.Rows[index].Cells["Estado"].Value))
                };
                MtnProducto form = new(oProducto);
                form.ShowDialog();
                CargarDatosProductos();
            }
            else
            {
                MessageBox.Show("Selecciona un registro de la lista");
            }
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            using ServiceProducto.ServiceProductoClient client = new();
            if (dataGridProducto.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dataGridProducto.SelectedRows[0];
                int index = currentRow.Index;

                int IdProducto = Convert.ToInt32(dataGridProducto.Rows[index].Cells["IdProducto"].Value);
                string Descripcion = Convert.ToString(dataGridProducto.Rows[index].Cells["Descripcion"].Value);

                if (MessageBox.Show(string.Format("{0} '{1}' {2}", "¿Desea eliminar el producto", Descripcion, "permanentemente?"), "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    bool Respuesta = client.EliminarProducto(IdProducto);
                    if (Respuesta)
                    {
                        MessageBox.Show(string.Format("{0} {1} {2}", "El producto", Descripcion, "fue eliminado"), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatosProductos();
                    }
                    else
                    {
                        MessageBox.Show(string.Format("{0} {1} {2} \n{3}", "El producto", Descripcion, "no fue eliminado.", "El producto se encuentra asignado a alguna venta actualmente"), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
