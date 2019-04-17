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
    public partial class Usuarios : Form
    {
        ConnectOracle co;
        public Usuarios()
        {
            InitializeComponent();
            co = new ConnectOracle();
            RefrescarTabla();
        }
        private void RefrescarTabla()
        {
            co.LeerTodosUsuarios();
            dgvUsuarios.DataSource = co.TablaUsuarios;
        }  

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarUsuario au = new AgregarUsuario();
            au.ShowDialog();
        }
    }
}
