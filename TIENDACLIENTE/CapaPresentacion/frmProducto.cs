using ServiceColor;
using ServiceImpuesto;
using ServiceProducto;
using ServiceTalle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Estado = ServiceProducto.Estado;

namespace CapaPresentacion
{
    public partial class FrmProducto : Form
    {
        DataTable TablaProducto = new();
        frmMensaje msj = new();
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
        #region TABLAS FORMULARIO
        private void CargarDatosProductos()
        {
            using ServiceProducto.ServiceProductoClient client = new();
            var oListaProducto = client.ListaProducto();
            if (oListaProducto.Count() > 0 && oListaProducto != null)
            {
                lblTotalRegistros.Text = oListaProducto.Count().ToString();
                TablaProducto = new DataTable();
                TablaProducto.Columns.Clear();
                TablaProducto.Rows.Clear();
                cmbFiltro.Items.Clear();
                TablaProducto.Columns.Add("IdProducto", typeof(int));
                TablaProducto.Columns.Add("CodigoProducto", typeof(string));
                TablaProducto.Columns.Add("DescripcionProducto", typeof(string));
                TablaProducto.Columns.Add("GeneroProducto", typeof(string));
                TablaProducto.Columns.Add("RubroProducto", typeof(string));
                TablaProducto.Columns.Add("Marca", typeof(string));
                TablaProducto.Columns.Add("TipoTalle", typeof(string));
                TablaProducto.Columns.Add("Estado", typeof(string));
                TablaProducto.Columns.Add("FechaRegistro", typeof(DateTime));
                foreach (DtoProducto row in oListaProducto)
                {
                    if (row.OEstado.Equals(ServiceProducto.Estado.Activo))
                    {        
                            TablaProducto.Rows.Add(row.IdProducto, row.CodigoProducto, row.DescripcionProducto, row.OGeneroProducto.DescripcionGeneroProducto, row.ORubroProducto.DescripcionRubroProducto, row.OMarca.DescripcionMarca, row.OTipoTalle.DescripcionTipoTalle,  row.OEstado, row.FechaRegistro);    
                    }    
                }
                dataGridProducto.DataSource = TablaProducto;
                dataGridProducto.AutoResizeColumns();
                dataGridProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridProducto.Columns["IdProducto"].Visible = false;
                dataGridProducto.Columns["CodigoProducto"].Visible = true;
                dataGridProducto.Columns["DescripcionProducto"].Visible = true;
                dataGridProducto.Columns["GeneroProducto"].Visible = true;
                dataGridProducto.Columns["RubroProducto"].Visible = true;
                dataGridProducto.Columns["Marca"].Visible = true;
                dataGridProducto.Columns["TipoTalle"].Visible = true;
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
            lblTotalRegistros.Text = Convert.ToString(dataGridProducto.Rows.Count-1);
        }
        #endregion
        #region FILTRO DE BUSQUEDA
        private void Txt_Filtro_TextChanged(object sender, EventArgs e)
        {
            string columnaFiltro = cmbFiltro.SelectedItem.ToString();
            (dataGridProducto.DataSource as DataTable).DefaultView.RowFilter = string.Format(columnaFiltro + " like '%{0}%'", txtFiltro.Text);
        }
        #endregion
        #region FUNCIONALIDADES
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            MtnProducto mtn = new();
            mtn.ShowDialog();
            CargarDatosProductos();

        }

        private void Btn_ModificarProducto_Click(object sender, EventArgs e)
        {
            using ServiceProducto.ServiceProductoClient client = new();
            ServiceColorClient client_color = new();
            ServiceTalleClient client_talle = new();
            if (dataGridProducto.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dataGridProducto.SelectedRows[0];
                int index = currentRow.Index;
                DtoProducto oProducto = new()
                {
                    IdProducto = Convert.ToInt32(dataGridProducto.Rows[index].Cells["IdProducto"].Value),
                    CodigoProducto = Convert.ToString(dataGridProducto.Rows[index].Cells["Codigo"].Value),
                    DescripcionProducto = Convert.ToString(dataGridProducto.Rows[index].Cells["Descripcion"].Value),
                    OGeneroProducto = client.ObtenerGeneroProducto(Convert.ToString(dataGridProducto.Rows[index].Cells["GeneroProducto"].Value)),
                    ORubroProducto = client.ObtenerRubroProducto(Convert.ToString(dataGridProducto.Rows[index].Cells["RubroProducto"].Value)),
                    OMarca = client.ObtenerMarca(Convert.ToString(dataGridProducto.Rows[index].Cells["Marca"].Value)),
                    //OColor = client.ObtenerColor(Convert.ToString(dataGridProducto.Rows[index].Cells["Color"].Value)),
                    OTipoTalle = client.ObtenerTipoTalle(Convert.ToString(dataGridProducto.Rows[index].Cells["TipoTalle"].Value)),
                    //Costo = Convert.ToDouble(dataGridProducto.Rows[index].Cells["Costo"].Value),
                    OEstado = client.ObtenerEstado(Convert.ToString(dataGridProducto.Rows[index].Cells["Estado"].Value))
                };
                MtnProducto form = new(oProducto);
                form.ShowDialog();
                CargarDatosProductos();
            }
            else
            {
                DialogResult resmsj = msj.MsjInformacion("Debe Seleccionar un registro de la lista", "MSG-INFORMACION", "ACEPTAR");
                if (resmsj.Equals(DialogResult.OK)) msj.Close();
            }
        }

        private void Btn_EliminarProducto_Click(object sender, EventArgs e)
        {
            using ServiceProducto.ServiceProductoClient client = new();
            if (dataGridProducto.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dataGridProducto.SelectedRows[0];
                int index = currentRow.Index;

                int IdProducto = Convert.ToInt32(dataGridProducto.Rows[index].Cells["IdProducto"].Value);
                string Descripcion = Convert.ToString(dataGridProducto.Rows[index].Cells["Descripcion"].Value);

                DialogResult resmsj = msj.MsjConsulta("¿Desea eliminar el producto\n "+Descripcion+" ?", "MSG-CONSULTA", "SI","NO");
                if (resmsj.Equals(DialogResult.OK))
                {

                    bool Respuesta = client.EliminarProducto(IdProducto);
                    if (Respuesta)
                    {
                        DialogResult resmsj_2 = msj.MsjInformacion("El producto "+Descripcion+" fue eliminado", "MSG-INFORMACION", "ACEPTAR");
                        if (resmsj.Equals(DialogResult.OK)) msj.Close();
                        CargarDatosProductos();
                    }
                    else
                    {
                        DialogResult resmsj_2 = msj.MsjExclamacion("El producto " + Descripcion + " no fue eliminado", "MSG-INFORMACION", "ACEPTAR");
                        if (resmsj.Equals(DialogResult.OK)) msj.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un registro de la lista");
            }
        }
        #endregion
    }
}
