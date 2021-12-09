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
    public partial class frmBienvenida : Form
    {
        string Usuario = "";
        string rol = "";
        public frmBienvenida(string NombreUsuario)
        {
            InitializeComponent();
            Usuario = NombreUsuario;
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1) this.Opacity += 0.05;
            progressBar1.Value += 1;
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                timer2.Start();
            }
        }
        
        private void FrmBienvenida_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = Usuario;
            this.Opacity = 0.0;
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            using ServiceUsuario.ServiceUsuarioClient client = new();
            var user = client.ObtenerUsuario();
            foreach (var item in user)
            {
                if (item.NombreUsuario.Equals(Usuario)) rol = item.ORol.Descripcion.ToString();
            }
            if (this.Opacity == 0)
            {
                timer2.Stop();
                this.Close();
                MenuPrincipal frm = new MenuPrincipal();
                if (rol.Equals("Usuario"))
                {
                    frm.btnUsuario.Visible = false;
                    frm.btnProducto.Visible = false;
                    frm.btnRubroProducto.Visible = false;   
                }
                frm.ShowDialog();
            }

        }
    }
}
