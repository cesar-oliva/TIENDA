
namespace CapaPresentacion
{
    partial class MenuPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMenuVertical = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Btn_Venta = new System.Windows.Forms.Button();
            this.Btn_Producto = new System.Windows.Forms.Button();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.Btn_Cerrar = new System.Windows.Forms.PictureBox();
            this.Btn_Minimizar = new System.Windows.Forms.PictureBox();
            this.pnlBarraTitulo = new System.Windows.Forms.Panel();
            this.pnlMenuVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Cerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Minimizar)).BeginInit();
            this.pnlBarraTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenuVertical
            // 
            this.pnlMenuVertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(52)))), ((int)(((byte)(93)))));
            this.pnlMenuVertical.Controls.Add(this.pictureBox1);
            this.pnlMenuVertical.Controls.Add(this.Btn_Venta);
            this.pnlMenuVertical.Controls.Add(this.Btn_Producto);
            this.pnlMenuVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenuVertical.Location = new System.Drawing.Point(0, 35);
            this.pnlMenuVertical.Name = "pnlMenuVertical";
            this.pnlMenuVertical.Size = new System.Drawing.Size(220, 615);
            this.pnlMenuVertical.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.crearlogogratis_1024x1024_01;
            this.pictureBox1.Location = new System.Drawing.Point(47, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Btn_Venta
            // 
            this.Btn_Venta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(188)))), ((int)(((byte)(101)))));
            this.Btn_Venta.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Btn_Venta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Btn_Venta.Location = new System.Drawing.Point(47, 219);
            this.Btn_Venta.Name = "Btn_Venta";
            this.Btn_Venta.Size = new System.Drawing.Size(112, 57);
            this.Btn_Venta.TabIndex = 1;
            this.Btn_Venta.Text = "Venta";
            this.Btn_Venta.UseVisualStyleBackColor = false;
            this.Btn_Venta.Click += new System.EventHandler(this.Btn_Venta_Click);
            // 
            // Btn_Producto
            // 
            this.Btn_Producto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(188)))), ((int)(((byte)(101)))));
            this.Btn_Producto.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Btn_Producto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Btn_Producto.Location = new System.Drawing.Point(47, 136);
            this.Btn_Producto.Name = "Btn_Producto";
            this.Btn_Producto.Size = new System.Drawing.Size(112, 57);
            this.Btn_Producto.TabIndex = 0;
            this.Btn_Producto.Text = "Producto";
            this.Btn_Producto.UseVisualStyleBackColor = false;
            this.Btn_Producto.Click += new System.EventHandler(this.Btn_Producto_Click);
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(38)))), ((int)(((byte)(69)))));
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(220, 35);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1080, 615);
            this.pnlContenedor.TabIndex = 2;
            // 
            // Btn_Cerrar
            // 
            this.Btn_Cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Cerrar.Image = global::CapaPresentacion.Properties.Resources.cancel;
            this.Btn_Cerrar.ImageLocation = "";
            this.Btn_Cerrar.Location = new System.Drawing.Point(1263, 4);
            this.Btn_Cerrar.Name = "Btn_Cerrar";
            this.Btn_Cerrar.Size = new System.Drawing.Size(25, 25);
            this.Btn_Cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Btn_Cerrar.TabIndex = 0;
            this.Btn_Cerrar.TabStop = false;
            this.Btn_Cerrar.Click += new System.EventHandler(this.Btn_Cerrar_Click);
            // 
            // Btn_Minimizar
            // 
            this.Btn_Minimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Minimizar.Image = global::CapaPresentacion.Properties.Resources.minimize;
            this.Btn_Minimizar.ImageLocation = "";
            this.Btn_Minimizar.Location = new System.Drawing.Point(1226, 4);
            this.Btn_Minimizar.Name = "Btn_Minimizar";
            this.Btn_Minimizar.Size = new System.Drawing.Size(25, 25);
            this.Btn_Minimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Btn_Minimizar.TabIndex = 2;
            this.Btn_Minimizar.TabStop = false;
            this.Btn_Minimizar.Click += new System.EventHandler(this.PictureBox2_Click);
            // 
            // pnlBarraTitulo
            // 
            this.pnlBarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(188)))), ((int)(((byte)(101)))));
            this.pnlBarraTitulo.Controls.Add(this.Btn_Minimizar);
            this.pnlBarraTitulo.Controls.Add(this.Btn_Cerrar);
            this.pnlBarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlBarraTitulo.Name = "pnlBarraTitulo";
            this.pnlBarraTitulo.Size = new System.Drawing.Size(1300, 35);
            this.pnlBarraTitulo.TabIndex = 0;
            this.pnlBarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pnl_BarraTitulo_MouseDown);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 650);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlMenuVertical);
            this.Controls.Add(this.pnlBarraTitulo);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuPrincipal";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MENU";
            this.pnlMenuVertical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Cerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Minimizar)).EndInit();
            this.pnlBarraTitulo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMenuVertical;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Button Btn_Producto;
        private System.Windows.Forms.Button Btn_Venta;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox Btn_Cerrar;
        private System.Windows.Forms.PictureBox Btn_Minimizar;
        private System.Windows.Forms.Panel pnlBarraTitulo;
    }
}

