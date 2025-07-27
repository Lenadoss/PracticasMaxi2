namespace presentacion
{
    partial class frmPrincipal
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
            this.dgvPelicula = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.gboxContainer = new System.Windows.Forms.GroupBox();
            this.btnEliminarLogico = new System.Windows.Forms.Button();
            this.btnEliminarFisico = new System.Windows.Forms.Button();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.btnFiltro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcboxPelicula)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPelicula)).BeginInit();
            this.gboxContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pcboxPelicula
            // 
            this.pcboxPelicula.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pcboxPelicula.Location = new System.Drawing.Point(6, 69);
            this.pcboxPelicula.Name = "pcboxPelicula";
            this.pcboxPelicula.Size = new System.Drawing.Size(311, 282);
            this.pcboxPelicula.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcboxPelicula.TabIndex = 0;
            this.pcboxPelicula.TabStop = false;
            // 
            // dgvPelicula
            // 
            this.dgvPelicula.BackgroundColor = System.Drawing.Color.Azure;
            this.dgvPelicula.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPelicula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPelicula.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPelicula.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvPelicula.Location = new System.Drawing.Point(323, 69);
            this.dgvPelicula.MultiSelect = false;
            this.dgvPelicula.Name = "dgvPelicula";
            this.dgvPelicula.RowHeadersWidth = 51;
            this.dgvPelicula.RowTemplate.Height = 24;
            this.dgvPelicula.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPelicula.Size = new System.Drawing.Size(758, 282);
            this.dgvPelicula.TabIndex = 1;
            this.dgvPelicula.SelectionChanged += new System.EventHandler(this.dgvPelicula_SelectionChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.FlatAppearance.BorderSize = 3;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Location = new System.Drawing.Point(12, 357);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(140, 45);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.FlatAppearance.BorderSize = 3;
            this.btnModificar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Location = new System.Drawing.Point(158, 357);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(140, 45);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // gboxContainer
            // 
            this.gboxContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.gboxContainer.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gboxContainer.Controls.Add(this.btnFiltro);
            this.gboxContainer.Controls.Add(this.txtFiltro);
            this.gboxContainer.Controls.Add(this.lblFiltro);
            this.gboxContainer.Controls.Add(this.btnEliminarLogico);
            this.gboxContainer.Controls.Add(this.btnEliminarFisico);
            this.gboxContainer.Controls.Add(this.pcboxPelicula);
            this.gboxContainer.Controls.Add(this.btnModificar);
            this.gboxContainer.Controls.Add(this.dgvPelicula);
            this.gboxContainer.Controls.Add(this.btnAgregar);
            this.gboxContainer.Location = new System.Drawing.Point(12, 12);
            this.gboxContainer.Name = "gboxContainer";
            this.gboxContainer.Size = new System.Drawing.Size(1087, 419);
            this.gboxContainer.TabIndex = 4;
            this.gboxContainer.TabStop = false;
            // 
            // btnEliminarLogico
            // 
            this.btnEliminarLogico.FlatAppearance.BorderSize = 3;
            this.btnEliminarLogico.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnEliminarLogico.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnEliminarLogico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarLogico.Location = new System.Drawing.Point(450, 357);
            this.btnEliminarLogico.Name = "btnEliminarLogico";
            this.btnEliminarLogico.Size = new System.Drawing.Size(140, 45);
            this.btnEliminarLogico.TabIndex = 5;
            this.btnEliminarLogico.Text = "Eliminar Logico";
            this.btnEliminarLogico.UseVisualStyleBackColor = true;
            this.btnEliminarLogico.Click += new System.EventHandler(this.btnEliminarLogico_Click);
            // 
            // btnEliminarFisico
            // 
            this.btnEliminarFisico.FlatAppearance.BorderSize = 3;
            this.btnEliminarFisico.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnEliminarFisico.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnEliminarFisico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarFisico.Location = new System.Drawing.Point(304, 357);
            this.btnEliminarFisico.Name = "btnEliminarFisico";
            this.btnEliminarFisico.Size = new System.Drawing.Size(140, 45);
            this.btnEliminarFisico.TabIndex = 4;
            this.btnEliminarFisico.Text = "Eliminar Fisico";
            this.btnEliminarFisico.UseVisualStyleBackColor = true;
            this.btnEliminarFisico.Click += new System.EventHandler(this.btnEliminarFisico_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(62, 28);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(226, 22);
            this.txtFiltro.TabIndex = 8;
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(13, 31);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(36, 16);
            this.lblFiltro.TabIndex = 7;
            this.lblFiltro.Text = "Filtro";
            // 
            // btnFiltro
            // 
            this.btnFiltro.Location = new System.Drawing.Point(294, 21);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(116, 36);
            this.btnFiltro.TabIndex = 12;
            this.btnFiltro.Text = "Filtro";
            this.btnFiltro.UseVisualStyleBackColor = true;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1111, 434);
            this.Controls.Add(this.gboxContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Peliculas Disponibles";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcboxPelicula)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPelicula)).EndInit();
            this.gboxContainer.ResumeLayout(false);
            this.gboxContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pcboxPelicula;
        private System.Windows.Forms.DataGridView dgvPelicula;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.GroupBox gboxContainer;
        private System.Windows.Forms.Button btnEliminarFisico;
        private System.Windows.Forms.Button btnEliminarLogico;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.Button btnFiltro;
    }
}

