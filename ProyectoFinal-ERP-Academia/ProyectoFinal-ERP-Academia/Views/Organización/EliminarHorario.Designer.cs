namespace ProyectoFinal_ERP_Academia.Views.Organización
{
    partial class EliminarHorario
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
            this.tablaHorasOcupadas = new System.Windows.Forms.DataGridView();
            this.cbDia = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cbGrupo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAula = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tablaHorasOcupadas)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaHorasOcupadas
            // 
            this.tablaHorasOcupadas.AllowUserToAddRows = false;
            this.tablaHorasOcupadas.AllowUserToDeleteRows = false;
            this.tablaHorasOcupadas.AllowUserToResizeColumns = false;
            this.tablaHorasOcupadas.AllowUserToResizeRows = false;
            this.tablaHorasOcupadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaHorasOcupadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaHorasOcupadas.Location = new System.Drawing.Point(11, 74);
            this.tablaHorasOcupadas.MultiSelect = false;
            this.tablaHorasOcupadas.Name = "tablaHorasOcupadas";
            this.tablaHorasOcupadas.ReadOnly = true;
            this.tablaHorasOcupadas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.tablaHorasOcupadas.RowHeadersVisible = false;
            this.tablaHorasOcupadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaHorasOcupadas.Size = new System.Drawing.Size(708, 319);
            this.tablaHorasOcupadas.TabIndex = 51;
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
            this.cbDia.Location = new System.Drawing.Point(56, 16);
            this.cbDia.Name = "cbDia";
            this.cbDia.Size = new System.Drawing.Size(121, 21);
            this.cbDia.TabIndex = 50;
            this.cbDia.SelectedIndexChanged += new System.EventHandler(this.cbDia_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 49;
            this.label3.Text = "Dia:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(604, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 48;
            this.button1.Text = "Eliminar Grupo";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbGrupo
            // 
            this.cbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrupo.FormattingEnabled = true;
            this.cbGrupo.Location = new System.Drawing.Point(477, 47);
            this.cbGrupo.Name = "cbGrupo";
            this.cbGrupo.Size = new System.Drawing.Size(121, 21);
            this.cbGrupo.TabIndex = 47;
            this.cbGrupo.SelectedIndexChanged += new System.EventHandler(this.cbGrupo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(421, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 46;
            this.label2.Text = "Grupo:";
            // 
            // cbAula
            // 
            this.cbAula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAula.FormattingEnabled = true;
            this.cbAula.Location = new System.Drawing.Point(56, 47);
            this.cbAula.Name = "cbAula";
            this.cbAula.Size = new System.Drawing.Size(121, 21);
            this.cbAula.TabIndex = 45;
            this.cbAula.SelectedIndexChanged += new System.EventHandler(this.cbAula_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 44;
            this.label1.Text = "Aula:";
            // 
            // EliminarHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(730, 409);
            this.Controls.Add(this.tablaHorasOcupadas);
            this.Controls.Add(this.cbDia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbGrupo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbAula);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EliminarHorario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EliminarHorario";
            ((System.ComponentModel.ISupportInitialize)(this.tablaHorasOcupadas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaHorasOcupadas;
        private System.Windows.Forms.ComboBox cbDia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbGrupo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbAula;
        private System.Windows.Forms.Label label1;
    }
}