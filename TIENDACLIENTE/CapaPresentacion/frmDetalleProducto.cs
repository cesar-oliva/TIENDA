using ServiceProducto;
using ServiceRubroProducto;
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
    public partial class frmDetalleProducto : Form
    {
        DataTable TablaProducto = new();
        public frmDetalleProducto()
        {
            InitializeComponent();
        }

        private void frmDetalleProducto_Load(object sender, EventArgs e)
        {
            CargarDatosProductos();
            dataGridDetalleProducto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridDetalleProducto.MultiSelect = false;
            dataGridDetalleProducto.ReadOnly = true;
            dataGridDetalleProducto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridDetalleProducto.AllowUserToAddRows = false;
        }
        private void CargarDatosProductos()
        {
            using ServiceProducto.ServiceProductoClient client = new();
            using ServiceRubroProducto.ServiceRubroProductoClient client_rub = new();
            var oListaProducto = client.ListaProducto();
            if (oListaProducto.Count() > 0 && oListaProducto != null)
            {
                lblTotalRegistros.Text = oListaProducto.Count().ToString();
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
                TablaProducto.Columns.Add("Color", typeof(string));
                TablaProducto.Columns.Add("Talle", typeof(string));
                TablaProducto.Columns.Add("Costo", typeof(double));
                TablaProducto.Columns.Add("MargenGanancia", typeof(double));
                TablaProducto.Columns.Add("Impuesto", typeof(double));
                TablaProducto.Columns.Add("PrecioVenta", typeof(double));
                TablaProducto.Columns.Add("Stock", typeof(int));
                TablaProducto.Columns.Add("Estado", typeof(string));
                foreach (DtoProducto row in oListaProducto)
                {
                    if (row.OEstado.Equals(ServiceProducto.Estado.Activo))
                    {
                        TablaProducto.Rows.Add(row.IdProducto, row.Codigo, row.Descripcion,row.OGeneroProducto.ToString() ,client_rub.ObtenerRubroProductoById(row.ORubroProducto.IdRubroProducto).DescripcionRubroProducto, row.OMarca.Descripcion, row.OColor.DescripcionColor, row.OTalle.DescripcionTalle,row.Costo, client_rub.ObtenerRubroProductoById(row.ORubroProducto.IdRubroProducto).MargenGanancia, client_rub.ObtenerRubroProductoById(row.ORubroProducto.IdRubroProducto).OImpuesto.Alicuota,row.Costo*(((client_rub.ObtenerRubroProductoById(row.ORubroProducto.IdRubroProducto).OImpuesto.Alicuota)/100)+1)*(((client_rub.ObtenerRubroProductoById(row.ORubroProducto.IdRubroProducto).MargenGanancia)/100)+1),15,row.OEstado);
                    }
                }
                dataGridDetalleProducto.DataSource = TablaProducto;
                dataGridDetalleProducto.AutoResizeColumns();
                dataGridDetalleProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridDetalleProducto.Columns["IdProducto"].Visible = false;
                dataGridDetalleProducto.Columns["Codigo"].Visible = true;
                dataGridDetalleProducto.Columns["Descripcion"].Visible = true;
                dataGridDetalleProducto.Columns["GeneroProducto"].Visible = true;
                dataGridDetalleProducto.Columns["RubroProducto"].Visible = true;
                dataGridDetalleProducto.Columns["Marca"].Visible = true;
                dataGridDetalleProducto.Columns["Color"].Visible = true;
                dataGridDetalleProducto.Columns["Talle"].Visible = true;
                dataGridDetalleProducto.Columns["Costo"].Visible = false;
                dataGridDetalleProducto.Columns["MargenGanancia"].Visible = false;
                dataGridDetalleProducto.Columns["Impuesto"].Visible = true;
                dataGridDetalleProducto.Columns["PrecioVenta"].Visible = true;
                dataGridDetalleProducto.Columns["Stock"].Visible = true;
                dataGridDetalleProducto.Columns["Estado"].Visible = true;
                foreach (DataGridViewColumn cl in dataGridDetalleProducto.Columns)
                {
                    if (cl.Visible == true)
                    {
                        cmbFiltro.Items.Add(cl.HeaderText);
                    }
                }
                cmbFiltro.SelectedIndex = 0;
            }
            lblTotalRegistros.Text = Convert.ToString(dataGridDetalleProducto.Rows.Count - 1);
        }
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string columnaFiltro = cmbFiltro.SelectedItem.ToString();
            (dataGridDetalleProducto.DataSource as DataTable).DefaultView.RowFilter = string.Format(columnaFiltro + " like '%{0}%'", txtFiltro.Text);

        }

        private void Btn_Agregar_Click(object sender, EventArgs e)
        {                
            this.Close();
        }
    }
}
