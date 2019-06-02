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

namespace ProyectoFinal_ERP_Academia.Views.Contabilidad.Abonos
{
    public partial class VentanaAbonos : Form
    {
        ConnectOracle co;
        public VentanaAbonos()
        {
            InitializeComponent();
            co = new ConnectOracle();
            RefrescarTabla();
        }

        private void RefrescarTabla()
        {
            co.LeerTodosAbonos();
            tablaAbonos.DataSource = co.TablaAbonos;
        }
    }
}
