namespace ProyectoFinal_ERP_Academia.Views.ZonaAlumnos
{
    partial class VentanaSelecTest
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
            this.button1 = new System.Windows.Forms.Button();
            this.tablaTestDisponibles = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tablaTestDisponibles)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(311, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "Hacer Test";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tablaTestDisponibles
            // 
            this.tablaTestDisponibles.AllowUserToAddRows = false;
            this.tablaTestDisponibles.AllowUserToDeleteRows = false;
            this.tablaTestDisponibles.AllowUserToResizeColumns = false;
            this.tablaTestDisponibles.AllowUserToResizeRows = false;
            this.tablaTestDisponibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaTestDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaTestDisponibles.Location = new System.Drawing.Point(12, 77);
            this.tablaTestDisponibles.MultiSelect = false;
            this.tablaTestDisponibles.Name = "tablaTestDisponibles";
            this.tablaTestDisponibles.ReadOnly = true;
            this.tablaTestDisponibles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.tablaTestDisponibles.RowHeadersVisible = false;
            this.tablaTestDisponibles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaTestDisponibles.Size = new System.Drawing.Size(708, 319);
            this.tablaTestDisponibles.TabIndex = 52;
            // 
            // VentanaSelecTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(730, 408);
            this.Controls.Add(this.tablaTestDisponibles);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "VentanaSelecTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VentanaSelecTest";
            ((System.ComponentModel.ISupportInitialize)(this.tablaTestDisponibles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView tablaTestDisponibles;
    }
}