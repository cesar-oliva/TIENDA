﻿namespace CapaPresentacion
{
    partial class frmDetalleProducto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_Agregar = new System.Windows.Forms.Button();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.dataGridDetalleProducto = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetalleProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(52)))), ((int)(((byte)(93)))));
            this.panel1.Controls.Add(this.Btn_Agregar);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1064, 100);
            this.panel1.TabIndex = 0;
            // 
            // Btn_Agregar
            // 
            this.Btn_Agregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(118)))), ((int)(((byte)(113)))));
            this.Btn_Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Agregar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Btn_Agregar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Btn_Agregar.Location = new System.Drawing.Point(928, 23);
            this.Btn_Agregar.Name = "Btn_Agregar";
            this.Btn_Agregar.Size = new System.Drawing.Size(100, 50);
            this.Btn_Agregar.TabIndex = 2;
            this.Btn_Agregar.Text = "Cancelar";
            this.Btn_Agregar.UseVisualStyleBackColor = false;
            this.Btn_Agregar.Click += new System.EventHandler(this.Btn_Agregar_Click);
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalRegistros.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTotalRegistros.Location = new System.Drawing.Point(985, 540);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(19, 21);
            this.lblTotalRegistros.TabIndex = 14;
            this.lblTotalRegistros.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(830, 539);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 21);
            this.label3.TabIndex = 13;
            this.label3.Text = "Total de Registros:";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(868, 120);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(184, 23);
            this.txtFiltro.TabIndex = 12;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.Location = new System.Drawing.Point(697, 120);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(148, 23);
            this.cmbFiltro.TabIndex = 11;
            // 
            // dataGridDetalleProducto
            // 
            this.dataGridDetalleProducto.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.dataGridDetalleProducto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDetalleProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridDetalleProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDetalleProducto.EnableHeadersVisualStyles = false;
            this.dataGridDetalleProducto.Location = new System.Drawing.Point(12, 166);
            this.dataGridDetalleProducto.Name = "dataGridDetalleProducto";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDetalleProducto.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridDetalleProducto.RowTemplate.Height = 25;
            this.dataGridDetalleProducto.Size = new System.Drawing.Size(1040, 369);
            this.dataGridDetalleProducto.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(601, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Filtrar Por:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(12, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Lista de Productos Venta:";
            // 
            // frmDetalleProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(1064, 576);
            this.Controls.Add(this.lblTotalRegistros);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.cmbFiltro);
            this.Controls.Add(this.dataGridDetalleProducto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "frmDetalleProducto";
            this.Text = "PRODUCTOS VENTA";
            this.Load += new System.EventHandler(this.frmDetalleProducto_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetalleProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btn_Agregar;
        private System.Windows.Forms.Label lblTotalRegistros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.DataGridView dataGridDetalleProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}