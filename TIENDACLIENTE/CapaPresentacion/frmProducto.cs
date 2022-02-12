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

namespace CapaPresentacion
{
    public partial class FrmProducto : Form
    {
        DataTable TablaProducto = new();
        frmMensaje msj = new();
        ServiceCrudOf_DtoProductoClient client_Prod = new();
        ServiceColorClient client_color = new();
        ServiceTalleClient client_talle = new();


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
            var oListaProducto = client_Prod.Mostrar();
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
                TablaProducto.Columns.Add("RubroProducto", typeof(string));
                TablaProducto.Columns.Add("MarcaProducto", typeof(string));
                TablaProducto.Columns.Add("CostoProducto", typeof(double));
                TablaProducto.Columns.Add("Estado", typeof(string));
                TablaProducto.Columns.Add("FechaRegistro", typeof(DateTime));
                foreach (DtoProducto row in oListaProducto)
                {
                    if (row.DescripcionEstado.Equals("Activo"))
                    {        
                            TablaProducto.Rows.Add(row.IdProducto, row.CodigoProducto, row.DescripcionProducto, row.DescripcionRubroProducto, row.DescripcionMarcaProducto, row.CostoProducto, row.DescripcionEstado, row.FechaRegistro);    
                    }    
                }
                dataGridProducto.DataSource = TablaProducto;
                dataGridProducto.AutoResizeColumns();
                dataGridProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridProducto.Columns["IdProducto"].Visible = false;
                dataGridProducto.Columns["CodigoProducto"].Visible = true;
                dataGridProducto.Columns["DescripcionProducto"].Visible = true;
                dataGridProducto.Columns["RubroProducto"].Visible = true;
                dataGridProducto.Columns["MarcaProducto"].Visible = true;
                dataGridProducto.Columns["CostoProducto"].Visible = true;
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
            lblTotalRegistros.Text = Convert.ToString(dataGridProducto.Rows.Count);
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
            if (dataGridProducto.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dataGridProducto.SelectedRows[0];
                int index = currentRow.Index;
                DtoProducto oProducto = new()
                {
                    IdProducto = Convert.ToInt32(dataGridProducto.Rows[index].Cells["IdProducto"].Value),
                    CodigoProducto = Convert.ToString(dataGridProducto.Rows[index].Cells["CodigoProducto"].Value),
                    DescripcionProducto = Convert.ToString(dataGridProducto.Rows[index].Cells["DescripcionProducto"].Value),
                    DescripcionRubroProducto = Convert.ToString(dataGridProducto.Rows[index].Cells["RubroProducto"].Value),
                    DescripcionMarcaProducto = Convert.ToString(dataGridProducto.Rows[index].Cells["MarcaProducto"].Value),
                    CostoProducto = Convert.ToDouble(dataGridProducto.Rows[index].Cells["CostoProducto"].Value),
                    DescripcionEstado = Convert.ToString(dataGridProducto.Rows[index].Cells["Estado"].Value)
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
            if (dataGridProducto.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dataGridProducto.SelectedRows[0];
                int index = currentRow.Index;

                int IdProducto = Convert.ToInt32(dataGridProducto.Rows[index].Cells["IdProducto"].Value);
                string Descripcion = Convert.ToString(dataGridProducto.Rows[index].Cells["DescripcionProducto"].Value);

                DialogResult resmsj = msj.MsjConsulta("¿Desea eliminar el producto\n "+Descripcion+" ?", "MSG-CONSULTA", "SI","NO");
                if (resmsj.Equals(DialogResult.OK))
                {

                    bool Respuesta = client_Prod.Eliminar(IdProducto);
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
