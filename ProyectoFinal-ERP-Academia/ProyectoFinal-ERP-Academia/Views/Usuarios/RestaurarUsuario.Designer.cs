﻿namespace ProyectoFinal_ERP_Academia.Views.Usuarios
{
    partial class RestaurarUsuario
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
            this.btCnl = new System.Windows.Forms.Button();
            this.btAcp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btCnl
            // 
            this.btCnl.Location = new System.Drawing.Point(261, 125);
            this.btCnl.Name = "btCnl";
            this.btCnl.Size = new System.Drawing.Size(75, 23);
            this.btCnl.TabIndex = 5;
            this.btCnl.Text = "Cancelar";
            this.btCnl.UseVisualStyleBackColor = true;
            this.btCnl.Click += new System.EventHandler(this.btCnl_Click);
            // 
            // btAcp
            // 
            this.btAcp.Location = new System.Drawing.Point(12, 125);
            this.btAcp.Name = "btAcp";
            this.btAcp.Size = new System.Drawing.Size(75, 23);
            this.btAcp.TabIndex = 4;
            this.btAcp.Text = "Aceptar";
            this.btAcp.UseVisualStyleBackColor = true;
            this.btAcp.Click += new System.EventHandler(this.btAcp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "¿Está seguro de restaurar este usuario?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(52, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Para restaurar el usuario pulse Aceptar";
            // 
            // RestaurarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 160);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btCnl);
            this.Controls.Add(this.btAcp);
            this.Controls.Add(this.label1);
            this.Name = "RestaurarUsuario";
            this.Text = "Restaurar Usuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCnl;
        private System.Windows.Forms.Button btAcp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}