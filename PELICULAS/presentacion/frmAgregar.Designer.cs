namespace presentacion
{
    partial class frmAgregar
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
            this.pcboxPelicula = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblFechaDeLanzamiento = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.cbboxGenero = new System.Windows.Forms.ComboBox();
            this.cbboxEdicion = new System.Windows.Forms.ComboBox();
            this.lblGenero = new System.Windows.Forms.Label();
            this.lblEdicion = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcboxPelicula)).BeginInit();
            this.SuspendLayout();
            // 
            // pcboxPelicula
            // 
            this.pcboxPelicula.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.pcboxPelicula.Location = new System.Drawing.Point(399, 12);
            this.pcboxPelicula.Name = "pcboxPelicula";
            this.pcboxPelicula.Size = new System.Drawing.Size(267, 232);
            this.pcboxPelicula.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcboxPelicula.TabIndex = 0;
            this.pcboxPelicula.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(100, 45);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(43, 16);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Titulo:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(149, 42);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(226, 22);
            this.txtTitulo.TabIndex = 2;
            // 
            // lblFechaDeLanzamiento
            // 
            this.lblFechaDeLanzamiento.AutoSize = true;
            this.lblFechaDeLanzamiento.Location = new System.Drawing.Point(1, 75);
            this.lblFechaDeLanzamiento.Name = "lblFechaDeLanzamiento";
            this.lblFechaDeLanzamiento.Size = new System.Drawing.Size(142, 16);
            this.lblFechaDeLanzamiento.TabIndex = 3;
            this.lblFechaDeLanzamiento.Text = "Fecha de lanzamiento:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(149, 70);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(226, 22);
            this.dtpFecha.TabIndex = 4;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(57, 101);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(86, 16);
            this.lblUrl.TabIndex = 5;
            this.lblUrl.Text = "Url del cover:";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(149, 98);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(226, 22);
            this.txtUrl.TabIndex = 6;
            this.txtUrl.Leave += new System.EventHandler(this.txtUrl_Leave);
            // 
            // cbboxGenero
            // 
            this.cbboxGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxGenero.FormattingEnabled = true;
            this.cbboxGenero.Location = new System.Drawing.Point(149, 126);
            this.cbboxGenero.Name = "cbboxGenero";
            this.cbboxGenero.Size = new System.Drawing.Size(226, 24);
            this.cbboxGenero.TabIndex = 7;
            // 
            // cbboxEdicion
            // 
            this.cbboxEdicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxEdicion.FormattingEnabled = true;
            this.cbboxEdicion.Location = new System.Drawing.Point(149, 156);
            this.cbboxEdicion.Name = "cbboxEdicion";
            this.cbboxEdicion.Size = new System.Drawing.Size(226, 24);
            this.cbboxEdicion.TabIndex = 8;
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(91, 129);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(52, 16);
            this.lblGenero.TabIndex = 9;
            this.lblGenero.Text = "Genero";
            // 
            // lblEdicion
            // 
            this.lblEdicion.AutoSize = true;
            this.lblEdicion.Location = new System.Drawing.Point(88, 159);
            this.lblEdicion.Name = "lblEdicion";
            this.lblEdicion.Size = new System.Drawing.Size(55, 16);
            this.lblEdicion.TabIndex = 10;
            this.lblEdicion.Text = "Edicion:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(49, 205);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(116, 36);
            this.btnAgregar.TabIndex = 11;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(183, 205);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(116, 36);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 265);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lblEdicion);
            this.Controls.Add(this.lblGenero);
            this.Controls.Add(this.cbboxEdicion);
            this.Controls.Add(this.cbboxGenero);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblFechaDeLanzamiento);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pcboxPelicula);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmAgregar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAgregar";
            this.Load += new System.EventHandler(this.frmAgregar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcboxPelicula)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcboxPelicula;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblFechaDeLanzamiento;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.ComboBox cbboxGenero;
        private System.Windows.Forms.ComboBox cbboxEdicion;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.Label lblEdicion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelar;
    }
}