namespace ProyectoFinal_ERP_Academia.Views
{
    partial class EliminarRegistro
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
            this.label2 = new System.Windows.Forms.Label();
            this.btCnl = new System.Windows.Forms.Button();
            this.btAcp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(92, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Para eliminar pulse Aceptar";
            // 
            // btCnl
            // 
            this.btCnl.BackColor = System.Drawing.Color.White;
            this.btCnl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCnl.Location = new System.Drawing.Point(299, 125);
            this.btCnl.Name = "btCnl";
            this.btCnl.Size = new System.Drawing.Size(75, 23);
            this.btCnl.TabIndex = 6;
            this.btCnl.Text = "Cancelar";
            this.btCnl.UseVisualStyleBackColor = false;
            this.btCnl.Click += new System.EventHandler(this.btCnl_Click);
            // 
            // btAcp
            // 
            this.btAcp.BackColor = System.Drawing.Color.White;
            this.btAcp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAcp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAcp.Location = new System.Drawing.Point(12, 125);
            this.btAcp.Name = "btAcp";
            this.btAcp.Size = new System.Drawing.Size(75, 23);
            this.btAcp.TabIndex = 5;
            this.btAcp.Text = "Aceptar";
            this.btAcp.UseVisualStyleBackColor = false;
            this.btAcp.Click += new System.EventHandler(this.btAcp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(374, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "¿Está seguro de eliminar este registro?";
            // 
            // EliminarRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(386, 160);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btCnl);
            this.Controls.Add(this.btAcp);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EliminarRegistro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EliminarRegistro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btCnl;
        private System.Windows.Forms.Button btAcp;
        private System.Windows.Forms.Label label1;
    }
}