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
    public partial class frmMensaje : Form
    {
        public frmMensaje()
        {
            InitializeComponent();
        }
        private DialogResult result = DialogResult.No;

        public DialogResult MsjInformacion(string mensaje, string caption, string btnText1, string btnText2)
        {
            //var msgBox = new frmMensaje();
            Image imagen = Image.FromFile("exc.png");
            PicBoxMensaje.Image = imagen;
            PicBoxMensaje.SizeMode = PictureBoxSizeMode.StretchImage;
            lblMensaje.Text = mensaje;
            btn_Si.Text = btnText1;
            btn_No.Text = btnText2;
            Text = caption;
            ShowDialog();
            return result;
        }
        public DialogResult MsjInformacion(string mensaje, string caption, string btnText1)
        {
            //var msgBox = new frmMensaje();
            Image imagen = Image.FromFile("exc.png");
            PicBoxMensaje.Image = imagen;
            PicBoxMensaje.SizeMode = PictureBoxSizeMode.StretchImage;
            lblMensaje.Text = mensaje;
            btn_Si.Text = btnText1;
            btn_No.Visible = false;
            Text = caption;
            ShowDialog();
            return result;
        }
        public DialogResult MsjConsulta(string mensaje, string caption, string btnText1, string btnText2)
        {
            Image imagen = Image.FromFile("consulta.png");
            PicBoxMensaje.Image = imagen;
            PicBoxMensaje.SizeMode = PictureBoxSizeMode.StretchImage;
            lblMensaje.Text = mensaje;
            btn_Si.Text = btnText1;
            btn_No.Text = btnText2;
            Text = caption;
            ShowDialog();
            return result;
        }
        public DialogResult MsjExclamacion(string mensaje, string caption, string btnText1)
        {
            //var msgBox = new frmMensaje();
            Image imagen = Image.FromFile("critico.png");
            PicBoxMensaje.Image = imagen;
            PicBoxMensaje.SizeMode = PictureBoxSizeMode.StretchImage;
            lblMensaje.Text = mensaje;
            btn_Si.Text = btnText1;
            btn_No.Visible = false;
            Text = caption;
            ShowDialog();
            return result;
        }
        private void btn_No_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_Si_Click(object sender, EventArgs e)
        {
            result = DialogResult.OK;
            this.Close();
        }
    }
}
