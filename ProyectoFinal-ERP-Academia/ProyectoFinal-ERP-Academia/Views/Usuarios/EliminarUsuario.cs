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

namespace ProyectoFinal_ERP_Academia.Views.Usuarios
{
    public partial class EliminarUsuario : Form
    {
        int idU;
        ConnectOracle co;
        public EliminarUsuario(int id)
        {
            InitializeComponent();
            idU = id;
            co = new ConnectOracle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btAcp_Click(object sender, EventArgs e)
        {
            co.EliminarUsuario(idU);
            MessageBox.Show("Usuario eliminado correctamente");
            this.Dispose();
        }
    }
}
