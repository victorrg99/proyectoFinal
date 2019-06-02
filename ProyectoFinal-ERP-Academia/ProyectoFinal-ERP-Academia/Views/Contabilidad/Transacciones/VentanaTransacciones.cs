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

namespace ProyectoFinal_ERP_Academia.Views.Contabilidad.Transacciones
{
    public partial class VentanaTransacciones : Form
    {
        ConnectOracle co;
        public VentanaTransacciones()
        {
            InitializeComponent();
            co = new ConnectOracle();
            RefrescarTabla();
        }

        private void RefrescarTabla()
        {
            co.LeerTodasTransacciones();
            tablaTransacciones.DataSource = co.TablaTransacciones;
        }
    }
}
