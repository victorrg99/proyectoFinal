using ProyectoFinal_ERP_Academia.Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_ERP_Academia.Views
{
    public partial class EliminarRegistro : Form
    {
        ConnectOracle co;
        String tabla;
        String fila;
        int id;
        public EliminarRegistro(String t,String f, int i)
        {
            InitializeComponent();
            co = new ConnectOracle();
            this.tabla = t;
            this.fila = f;
            this.id = i;
        }

        private void btAcp_Click(object sender, EventArgs e)
        {
            co.EliminarRegistro(tabla, fila, id);
            MessageBox.Show("Registro eliminado correctamente");
            this.Dispose();
        }

        private void btCnl_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
