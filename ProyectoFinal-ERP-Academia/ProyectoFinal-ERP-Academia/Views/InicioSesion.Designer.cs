namespace ProyectoFinal_ERP_Academia.Views
{
    partial class InicioSesion
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
            this.btInSes = new System.Windows.Forms.Button();
            this.btCnl = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDNI = new System.Windows.Forms.TextBox();
            this.tbClave = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btInSes
            // 
            this.btInSes.BackColor = System.Drawing.Color.White;
            this.btInSes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btInSes.Location = new System.Drawing.Point(12, 260);
            this.btInSes.Name = "btInSes";
            this.btInSes.Size = new System.Drawing.Size(101, 23);
            this.btInSes.TabIndex = 0;
            this.btInSes.Text = "Iniciar Sesión";
            this.btInSes.UseVisualStyleBackColor = false;
            this.btInSes.Click += new System.EventHandler(this.btInSes_Click);
            // 
            // btCnl
            // 
            this.btCnl.BackColor = System.Drawing.Color.White;
            this.btCnl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCnl.Location = new System.Drawing.Point(179, 260);
            this.btCnl.Name = "btCnl";
            this.btCnl.Size = new System.Drawing.Size(87, 23);
            this.btCnl.TabIndex = 1;
            this.btCnl.Text = "Cancelar";
            this.btCnl.UseVisualStyleBackColor = false;
            this.btCnl.Click += new System.EventHandler(this.btCnl_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña:";
            // 
            // tbDNI
            // 
            this.tbDNI.Location = new System.Drawing.Point(141, 80);
            this.tbDNI.Name = "tbDNI";
            this.tbDNI.Size = new System.Drawing.Size(125, 20);
            this.tbDNI.TabIndex = 4;
            // 
            // tbClave
            // 
            this.tbClave.Location = new System.Drawing.Point(141, 198);
            this.tbClave.Name = "tbClave";
            this.tbClave.Size = new System.Drawing.Size(125, 20);
            this.tbClave.TabIndex = 5;
            this.tbClave.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "DNI:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(141, 137);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(125, 20);
            this.tbNombre.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(88, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "INICIAR SESIÓN";
            // 
            // InicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(282, 303);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbClave);
            this.Controls.Add(this.tbDNI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCnl);
            this.Controls.Add(this.btInSes);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InicioSesion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btInSes;
        private System.Windows.Forms.Button btCnl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDNI;
        private System.Windows.Forms.TextBox tbClave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label label4;
    }
}