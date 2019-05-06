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
    public partial class RestaurarUsuario : Form
    {
        int idU;
        ConnectOracle co;
        public RestaurarUsuario(int id)
        {
            InitializeComponent();
            idU = id;
            co = new ConnectOracle();
        }

        private void btAcp_Click(object sender, EventArgs e)
        {
            co.RstaurarUsuario(idU);
            MessageBox.Show("Usuario restaurado correctamente");
            this.Dispose();
        }

        private void btCnl_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
