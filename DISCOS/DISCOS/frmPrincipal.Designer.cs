namespace DISCOS
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
            this.pbxDiscos = new System.Windows.Forms.PictureBox();
            this.dgvDiscos = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDiscos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscos)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxDiscos
            // 
            this.pbxDiscos.Location = new System.Drawing.Point(24, 46);
            this.pbxDiscos.Name = "pbxDiscos";
            this.pbxDiscos.Size = new System.Drawing.Size(315, 278);
            this.pbxDiscos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxDiscos.TabIndex = 0;
            this.pbxDiscos.TabStop = false;
            // 
            // dgvDiscos
            // 
            this.dgvDiscos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDiscos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDiscos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiscos.Location = new System.Drawing.Point(362, 46);
            this.dgvDiscos.Name = "dgvDiscos";
            this.dgvDiscos.ReadOnly = true;
            this.dgvDiscos.RowHeadersWidth = 61;
            this.dgvDiscos.RowTemplate.Height = 24;
            this.dgvDiscos.Size = new System.Drawing.Size(951, 278);
            this.dgvDiscos.TabIndex = 1;
            this.dgvDiscos.SelectionChanged += new System.EventHandler(this.dgvDiscos_SelectionChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 342);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 387);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvDiscos);
            this.Controls.Add(this.pbxDiscos);
            this.MaximumSize = new System.Drawing.Size(1359, 434);
            this.MinimumSize = new System.Drawing.Size(1359, 434);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discos";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxDiscos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxDiscos;
        private System.Windows.Forms.DataGridView dgvDiscos;
        private System.Windows.Forms.Button button1;
    }
}

