namespace CapaPresentacion
{
    partial class frmMensaje
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_No = new System.Windows.Forms.Button();
            this.btn_Si = new System.Windows.Forms.Button();
            this.PicBoxMensaje = new System.Windows.Forms.PictureBox();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxMensaje)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(52)))), ((int)(((byte)(93)))));
            this.panel1.Controls.Add(this.btn_No);
            this.panel1.Controls.Add(this.btn_Si);
            this.panel1.Location = new System.Drawing.Point(0, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 70);
            this.panel1.TabIndex = 0;
            // 
            // btn_No
            // 
            this.btn_No.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(118)))), ((int)(((byte)(113)))));
            this.btn_No.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_No.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_No.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_No.Location = new System.Drawing.Point(302, 16);
            this.btn_No.Name = "btn_No";
            this.btn_No.Size = new System.Drawing.Size(100, 36);
            this.btn_No.TabIndex = 4;
            this.btn_No.Text = "Cancelar";
            this.btn_No.UseVisualStyleBackColor = false;
            this.btn_No.Click += new System.EventHandler(this.btn_No_Click);
            // 
            // btn_Si
            // 
            this.btn_Si.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(188)))), ((int)(((byte)(101)))));
            this.btn_Si.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Si.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Si.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Si.Location = new System.Drawing.Point(182, 16);
            this.btn_Si.Name = "btn_Si";
            this.btn_Si.Size = new System.Drawing.Size(100, 36);
            this.btn_Si.TabIndex = 3;
            this.btn_Si.Text = "Confirmar";
            this.btn_Si.UseVisualStyleBackColor = false;
            this.btn_Si.Click += new System.EventHandler(this.btn_Si_Click);
            // 
            // PicBoxMensaje
            // 
            this.PicBoxMensaje.Location = new System.Drawing.Point(25, 25);
            this.PicBoxMensaje.Name = "PicBoxMensaje";
            this.PicBoxMensaje.Size = new System.Drawing.Size(76, 68);
            this.PicBoxMensaje.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxMensaje.TabIndex = 1;
            this.PicBoxMensaje.TabStop = false;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMensaje.ForeColor = System.Drawing.SystemColors.Control;
            this.lblMensaje.Location = new System.Drawing.Point(144, 38);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(91, 17);
            this.lblMensaje.TabIndex = 2;
            this.lblMensaje.Text = "Texto mensaje";
            // 
            // frmMensaje
            // 
            this.AcceptButton = this.btn_Si;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(38)))), ((int)(((byte)(69)))));
            this.CancelButton = this.btn_No;
            this.ClientSize = new System.Drawing.Size(427, 196);
            this.ControlBox = false;
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.PicBoxMensaje);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMensaje";
            this.Opacity = 0.8D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MENSAJE";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxMensaje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_No;
        private System.Windows.Forms.Button btn_Si;
        private System.Windows.Forms.PictureBox PicBoxMensaje;
        private System.Windows.Forms.Label lblMensaje;
    }
}