namespace ProyectoFinal_ERP_Academia.Views.ZonaAlumnos
{
    partial class VentanaResultados
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
            this.tablaTestDisponibles = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tablaTestDisponibles)).BeginInit();
            this.SuspendLayout();
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
            this.tablaTestDisponibles.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(173, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(349, 25);
            this.label2.TabIndex = 76;
            this.label2.Text = "Resultados de test completados";
            // 
            // VentanaResultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(730, 408);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tablaTestDisponibles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "VentanaResultados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VentanaResultados";
            ((System.ComponentModel.ISupportInitialize)(this.tablaTestDisponibles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaTestDisponibles;
        private System.Windows.Forms.Label label2;
    }
}