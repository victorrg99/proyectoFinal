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
            this.label2 = new System.Windows.Forms.Label();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.tbClave = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btInSes
            // 
            this.btInSes.BackColor = System.Drawing.Color.White;
            this.btInSes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btInSes.Location = new System.Drawing.Point(12, 187);
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
            this.btCnl.Location = new System.Drawing.Point(179, 187);
            this.btCnl.Name = "btCnl";
            this.btCnl.Size = new System.Drawing.Size(87, 23);
            this.btCnl.TabIndex = 1;
            this.btCnl.Text = "Cancelar";
            this.btCnl.UseVisualStyleBackColor = false;
            this.btCnl.Click += new System.EventHandler(this.btCnl_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña:";
            // 
            // tbUsuario
            // 
            this.tbUsuario.Location = new System.Drawing.Point(141, 80);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(125, 20);
            this.tbUsuario.TabIndex = 4;
            // 
            // tbClave
            // 
            this.tbClave.Location = new System.Drawing.Point(141, 125);
            this.tbClave.Name = "tbClave";
            this.tbClave.Size = new System.Drawing.Size(125, 20);
            this.tbClave.TabIndex = 5;
            this.tbClave.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Usuario:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
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
            this.ClientSize = new System.Drawing.Size(282, 235);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbClave);
            this.Controls.Add(this.tbUsuario);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUsuario;
        private System.Windows.Forms.TextBox tbClave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}