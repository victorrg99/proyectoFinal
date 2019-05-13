namespace ProyectoFinal_ERP_Academia.Views.Usuarios
{
    partial class VentanaUsuario
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
            this.btAgregar = new System.Windows.Forms.Button();
            this.btMod = new System.Windows.Forms.Button();
            this.tablaUsuarios = new System.Windows.Forms.DataGridView();
            this.btElim = new System.Windows.Forms.Button();
            this.btRes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // btAgregar
            // 
            this.btAgregar.Location = new System.Drawing.Point(12, 48);
            this.btAgregar.Name = "btAgregar";
            this.btAgregar.Size = new System.Drawing.Size(75, 23);
            this.btAgregar.TabIndex = 0;
            this.btAgregar.Text = "Añadir";
            this.btAgregar.UseVisualStyleBackColor = true;
            this.btAgregar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btMod
            // 
            this.btMod.Location = new System.Drawing.Point(93, 48);
            this.btMod.Name = "btMod";
            this.btMod.Size = new System.Drawing.Size(75, 23);
            this.btMod.TabIndex = 1;
            this.btMod.Text = "Modificar";
            this.btMod.UseVisualStyleBackColor = true;
            this.btMod.Click += new System.EventHandler(this.button2_Click);
            // 
            // tablaUsuarios
            // 
            this.tablaUsuarios.AllowUserToAddRows = false;
            this.tablaUsuarios.AllowUserToDeleteRows = false;
            this.tablaUsuarios.AllowUserToResizeColumns = false;
            this.tablaUsuarios.AllowUserToResizeRows = false;
            this.tablaUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaUsuarios.Location = new System.Drawing.Point(12, 77);
            this.tablaUsuarios.MultiSelect = false;
            this.tablaUsuarios.Name = "tablaUsuarios";
            this.tablaUsuarios.ReadOnly = true;
            this.tablaUsuarios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.tablaUsuarios.RowHeadersVisible = false;
            this.tablaUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaUsuarios.Size = new System.Drawing.Size(708, 319);
            this.tablaUsuarios.TabIndex = 2;
            // 
            // btElim
            // 
            this.btElim.Location = new System.Drawing.Point(564, 48);
            this.btElim.Name = "btElim";
            this.btElim.Size = new System.Drawing.Size(75, 23);
            this.btElim.TabIndex = 3;
            this.btElim.Text = "Eliminar";
            this.btElim.UseVisualStyleBackColor = true;
            this.btElim.Click += new System.EventHandler(this.btElim_Click);
            // 
            // btRes
            // 
            this.btRes.Location = new System.Drawing.Point(645, 48);
            this.btRes.Name = "btRes";
            this.btRes.Size = new System.Drawing.Size(75, 23);
            this.btRes.TabIndex = 4;
            this.btRes.Text = "Restaurar";
            this.btRes.UseVisualStyleBackColor = true;
            this.btRes.Click += new System.EventHandler(this.btRes_Click);
            // 
            // VentanaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 408);
            this.Controls.Add(this.btRes);
            this.Controls.Add(this.btElim);
            this.Controls.Add(this.tablaUsuarios);
            this.Controls.Add(this.btMod);
            this.Controls.Add(this.btAgregar);
            this.Name = "VentanaUsuario";
            this.Text = "Usuarios";
            ((System.ComponentModel.ISupportInitialize)(this.tablaUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btAgregar;
        private System.Windows.Forms.Button btMod;
        private System.Windows.Forms.DataGridView tablaUsuarios;
        private System.Windows.Forms.Button btElim;
        private System.Windows.Forms.Button btRes;
    }
}