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
            this.cbBoxcriterio = new System.Windows.Forms.ComboBox();
            this.lblFiltrar = new System.Windows.Forms.Label();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.lblCampo = new System.Windows.Forms.Label();
            this.cbBoxCampo = new System.Windows.Forms.ComboBox();
            this.txtFiltrar = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.btnEliminarLogico = new System.Windows.Forms.Button();
            this.btnEliminarFisico = new System.Windows.Forms.Button();
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
            this.gboxContainer.Controls.Add(this.cbBoxcriterio);
            this.gboxContainer.Controls.Add(this.lblFiltrar);
            this.gboxContainer.Controls.Add(this.lblCriterio);
            this.gboxContainer.Controls.Add(this.lblCampo);
            this.gboxContainer.Controls.Add(this.cbBoxCampo);
            this.gboxContainer.Controls.Add(this.txtFiltrar);
            this.gboxContainer.Controls.Add(this.btnFiltrar);
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
            this.gboxContainer.Size = new System.Drawing.Size(1087, 465);
            this.gboxContainer.TabIndex = 4;
            this.gboxContainer.TabStop = false;
            // 
            // cbBoxcriterio
            // 
            this.cbBoxcriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxcriterio.FormattingEnabled = true;
            this.cbBoxcriterio.Location = new System.Drawing.Point(323, 426);
            this.cbBoxcriterio.Name = "cbBoxcriterio";
            this.cbBoxcriterio.Size = new System.Drawing.Size(198, 24);
            this.cbBoxcriterio.TabIndex = 15;
            // 
            // lblFiltrar
            // 
            this.lblFiltrar.AutoSize = true;
            this.lblFiltrar.Location = new System.Drawing.Point(531, 429);
            this.lblFiltrar.Name = "lblFiltrar";
            this.lblFiltrar.Size = new System.Drawing.Size(40, 16);
            this.lblFiltrar.TabIndex = 14;
            this.lblFiltrar.Text = "Filtrar";
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(275, 429);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(49, 16);
            this.lblCriterio.TabIndex = 13;
            this.lblCriterio.Text = "Criterio";
            // 
            // lblCampo
            // 
            this.lblCampo.AutoSize = true;
            this.lblCampo.Location = new System.Drawing.Point(13, 429);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(51, 16);
            this.lblCampo.TabIndex = 5;
            this.lblCampo.Text = "Campo";
            // 
            // cbBoxCampo
            // 
            this.cbBoxCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxCampo.FormattingEnabled = true;
            this.cbBoxCampo.Location = new System.Drawing.Point(70, 426);
            this.cbBoxCampo.Name = "cbBoxCampo";
            this.cbBoxCampo.Size = new System.Drawing.Size(199, 24);
            this.cbBoxCampo.TabIndex = 6;
            this.cbBoxCampo.SelectedIndexChanged += new System.EventHandler(this.cbBoxCampo_SelectedIndexChanged);
            // 
            // txtFiltrar
            // 
            this.txtFiltrar.Location = new System.Drawing.Point(577, 426);
            this.txtFiltrar.Name = "txtFiltrar";
            this.txtFiltrar.Size = new System.Drawing.Size(198, 22);
            this.txtFiltrar.TabIndex = 7;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(790, 427);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 8;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(62, 28);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(236, 22);
            this.txtFiltro.TabIndex = 8;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
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
            // btnEliminarLogico
            // 
            this.btnEliminarLogico.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnEliminarLogico.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
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
            this.btnEliminarFisico.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnEliminarFisico.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnEliminarFisico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarFisico.Location = new System.Drawing.Point(304, 357);
            this.btnEliminarFisico.Name = "btnEliminarFisico";
            this.btnEliminarFisico.Size = new System.Drawing.Size(140, 45);
            this.btnEliminarFisico.TabIndex = 4;
            this.btnEliminarFisico.Text = "Eliminar Fisico";
            this.btnEliminarFisico.UseVisualStyleBackColor = true;
            this.btnEliminarFisico.Click += new System.EventHandler(this.btnEliminarFisico_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1111, 489);
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
        private System.Windows.Forms.ComboBox cbBoxcriterio;
        private System.Windows.Forms.Label lblFiltrar;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.Label lblCampo;
        private System.Windows.Forms.ComboBox cbBoxCampo;
        private System.Windows.Forms.TextBox txtFiltrar;
        private System.Windows.Forms.Button btnFiltrar;
    }
}

