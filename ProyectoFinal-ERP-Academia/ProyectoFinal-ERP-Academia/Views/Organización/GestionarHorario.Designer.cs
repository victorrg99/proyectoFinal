namespace ProyectoFinal_ERP_Academia.Views.Organización
{
    partial class GestionarHorario
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbAula = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbGrupo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbDia = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tablaHorasLibres = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tablaHorasLibres)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 36;
            this.label1.Text = "Aula:";
            // 
            // cbAula
            // 
            this.cbAula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAula.FormattingEnabled = true;
            this.cbAula.Location = new System.Drawing.Point(57, 50);
            this.cbAula.Name = "cbAula";
            this.cbAula.Size = new System.Drawing.Size(121, 21);
            this.cbAula.TabIndex = 37;
            this.cbAula.SelectedIndexChanged += new System.EventHandler(this.cbAula_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(422, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 38;
            this.label2.Text = "Grupo:";
            // 
            // cbGrupo
            // 
            this.cbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrupo.FormattingEnabled = true;
            this.cbGrupo.Location = new System.Drawing.Point(478, 50);
            this.cbGrupo.Name = "cbGrupo";
            this.cbGrupo.Size = new System.Drawing.Size(121, 21);
            this.cbGrupo.TabIndex = 39;
            this.cbGrupo.SelectedIndexChanged += new System.EventHandler(this.cbGrupo_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(605, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "Añadir Grupo";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbDia
            // 
            this.cbDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDia.FormattingEnabled = true;
            this.cbDia.Items.AddRange(new object[] {
            "LUNES",
            "MARTES",
            "MIERCOLES",
            "JUEVES",
            "VIERNES"});
            this.cbDia.Location = new System.Drawing.Point(57, 19);
            this.cbDia.Name = "cbDia";
            this.cbDia.Size = new System.Drawing.Size(121, 21);
            this.cbDia.TabIndex = 42;
            this.cbDia.SelectedIndexChanged += new System.EventHandler(this.cbDia_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 41;
            this.label3.Text = "Dia:";
            // 
            // tablaHorasLibres
            // 
            this.tablaHorasLibres.AllowUserToAddRows = false;
            this.tablaHorasLibres.AllowUserToDeleteRows = false;
            this.tablaHorasLibres.AllowUserToResizeColumns = false;
            this.tablaHorasLibres.AllowUserToResizeRows = false;
            this.tablaHorasLibres.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaHorasLibres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaHorasLibres.Location = new System.Drawing.Point(12, 77);
            this.tablaHorasLibres.MultiSelect = false;
            this.tablaHorasLibres.Name = "tablaHorasLibres";
            this.tablaHorasLibres.ReadOnly = true;
            this.tablaHorasLibres.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.tablaHorasLibres.RowHeadersVisible = false;
            this.tablaHorasLibres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaHorasLibres.Size = new System.Drawing.Size(708, 319);
            this.tablaHorasLibres.TabIndex = 43;
            // 
            // GestionarHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(730, 409);
            this.Controls.Add(this.tablaHorasLibres);
            this.Controls.Add(this.cbDia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbGrupo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbAula);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "GestionarHorario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgregarGrupoHorario";
            ((System.ComponentModel.ISupportInitialize)(this.tablaHorasLibres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbGrupo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbDia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView tablaHorasLibres;
    }
}