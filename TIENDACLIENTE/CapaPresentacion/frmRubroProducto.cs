using ServiceImpuesto;
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
    public partial class FrmRubroProducto : Form
    {
        DataTable TablaRubro = new();
        ServiceCrudOf_DtoRubroProductoClient client = new ();
        public FrmRubroProducto()
        {
            InitializeComponent();
        }

        private void Frm_Rubro_Load(object sender, EventArgs e)
        {
            CargarDatosRubroProducto();

            dataGridRubro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridRubro.MultiSelect = false;
            dataGridRubro.ReadOnly = true;
            dataGridRubro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridRubro.AllowUserToAddRows = false;
        }
        private void CargarDatosRubroProducto()
        {
            var oListaRubro = client.Mostrar();
            if (oListaRubro.Count() > 0 && oListaRubro != null)
            {
                lblTotalRegistros.Text = oListaRubro.Count().ToString();
                TablaRubro = new DataTable();
                TablaRubro.Columns.Clear();
                TablaRubro.Rows.Clear();
                cmbFiltro.Items.Clear();
                TablaRubro.Columns.Add("IdRubroProducto", typeof(int));
                //TablaRubro.Columns.Add("CodigoRubroProducto", typeof(string));
                TablaRubro.Columns.Add("DescripcionRubroProducto", typeof(string));
                TablaRubro.Columns.Add("MargenGanancia", typeof(string));
                TablaRubro.Columns.Add("Impuesto", typeof(string));
                TablaRubro.Columns.Add("Estado", typeof(string));
                TablaRubro.Columns.Add("FechaRegistro", typeof(DateTime));
                //foreach (DtoRubroProducto row in oListaRubro)
                //{
                //    if (row.OEstado.Equals(ServiceRubroProducto.Estado.Activo))
                //    {
                //        TablaRubro.Rows.Add(row.IdRubroProducto, row.DescripcionRubroProducto, row.MargenGanancia, row.OImpuesto.Descripcion, row.OEstado, row.FechaRegistro);
                //    }      
                //}
                dataGridRubro.DataSource = TablaRubro;
                dataGridRubro.AutoResizeColumns();
                dataGridRubro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridRubro.Columns["IdRubroProducto"].Visible = false;
                //dataGridRubro.Columns["CodigoRubroProducto"].Visible = true;
                dataGridRubro.Columns["DescripcionRubroProducto"].Visible = true;
                dataGridRubro.Columns["MargenGanancia"].Visible = true;
                dataGridRubro.Columns["Impuesto"].Visible = true;
                dataGridRubro.Columns["Estado"].Visible = true;
                dataGridRubro.Columns["FechaRegistro"].Visible = true;
                foreach (DataGridViewColumn cl in dataGridRubro.Columns)
                {
                    if (cl.Visible == true)
                    {
                        cmbFiltro.Items.Add(cl.HeaderText);
                    }
                }
                cmbFiltro.SelectedIndex = 0;
            }
            
            lblTotalRegistros.Text = Convert.ToString(dataGridRubro.Rows.Count-1); 
        }

        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            mtnRubroProducto mtn = new();
            mtn.ShowDialog();
            CargarDatosRubroProducto();
        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (dataGridRubro.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dataGridRubro.SelectedRows[0];
                int index = currentRow.Index;
                DtoRubroProducto oRubroProducto = new()
                {
                    IdRubroProducto = Convert.ToInt32(dataGridRubro.Rows[index].Cells["IdRubroProducto"].Value),
                    //CodigoRubroProducto = Convert.ToString(dataGridRubro.Rows[index].Cells["CodigoRubroProducto"].Value),
                    DescripcionRubroProducto = Convert.ToString(dataGridRubro.Rows[index].Cells["DescripcionRubroProducto"].Value),
                    MargenGanancia = Convert.ToDouble(dataGridRubro.Rows[index].Cells["MargenGanancia"].Value),
                    DescripcionImpuesto = Convert.ToString(dataGridRubro.Rows[index].Cells["Impuesto"].Value),
                    DescripcionEstado = Convert.ToString(dataGridRubro.Rows[index].Cells["Estado"].Value)
                };
                mtnRubroProducto form = new(oRubroProducto);
                form.ShowDialog();
                CargarDatosRubroProducto();
            }
            else
            {
                MessageBox.Show("Selecciona un registro de la lista");
            }
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridRubro.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dataGridRubro.SelectedRows[0];
                int index = currentRow.Index;

                int IdRubroProducto = Convert.ToInt32(dataGridRubro.Rows[index].Cells["IdRubroProducto"].Value);
                string Descripcion = Convert.ToString(dataGridRubro.Rows[index].Cells["DescripcionRubroProducto"].Value);

                if (MessageBox.Show(string.Format("{0} '{1}' {2}", "¿Desea eliminar el producto", Descripcion,IdRubroProducto ,"permanentemente?"), "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    bool Respuesta = client.Eliminar(IdRubroProducto);
                    if (Respuesta)
                    {
                        MessageBox.Show(string.Format("{0} {1} {2}", "El producto", Descripcion, "fue eliminado"), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatosRubroProducto();
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

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string columnaFiltro = cmbFiltro.SelectedItem.ToString();
            (dataGridRubro.DataSource as DataTable).DefaultView.RowFilter = string.Format(columnaFiltro + " like '%{0}%'", txtFiltro.Text);
        }
    }
}
