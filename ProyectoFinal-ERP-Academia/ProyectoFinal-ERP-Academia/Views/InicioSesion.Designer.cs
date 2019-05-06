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
            this.SuspendLayout();
            // 
            // btInSes
            // 
            this.btInSes.Location = new System.Drawing.Point(12, 233);
            this.btInSes.Name = "btInSes";
            this.btInSes.Size = new System.Drawing.Size(87, 23);
            this.btInSes.TabIndex = 0;
            this.btInSes.Text = "Iniciar Sesión";
            this.btInSes.UseVisualStyleBackColor = true;
            this.btInSes.Click += new System.EventHandler(this.btInSes_Click);
            // 
            // btCnl
            // 
            this.btCnl.Location = new System.Drawing.Point(169, 233);
            this.btCnl.Name = "btCnl";
            this.btCnl.Size = new System.Drawing.Size(75, 23);
            this.btCnl.TabIndex = 1;
            this.btCnl.Text = "Cancelar";
            this.btCnl.UseVisualStyleBackColor = true;
            this.btCnl.Click += new System.EventHandler(this.btCnl_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña:";
            // 
            // tbDNI
            // 
            this.tbDNI.Location = new System.Drawing.Point(101, 53);
            this.tbDNI.Name = "tbDNI";
            this.tbDNI.Size = new System.Drawing.Size(143, 20);
            this.tbDNI.TabIndex = 4;
            // 
            // tbClave
            // 
            this.tbClave.Location = new System.Drawing.Point(101, 171);
            this.tbClave.Name = "tbClave";
            this.tbClave.Size = new System.Drawing.Size(143, 20);
            this.tbClave.TabIndex = 5;
            this.tbClave.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "DNI:";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(101, 110);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(143, 20);
            this.tbNombre.TabIndex = 7;
            // 
            // InicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 268);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbClave);
            this.Controls.Add(this.tbDNI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCnl);
            this.Controls.Add(this.btInSes);
            this.Name = "InicioSesion";
            this.Text = "InicioSesion";
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
    }
}