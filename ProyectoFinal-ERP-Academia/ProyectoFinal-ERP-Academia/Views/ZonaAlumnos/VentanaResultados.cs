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

namespace ProyectoFinal_ERP_Academia.Views.ZonaAlumnos
{
    public partial class VentanaResultados : Form
    {
        ConnectOracle co;
        int idAlum;
        public VentanaResultados(int idA)
        {
            InitializeComponent();
            this.idAlum = idA;
            co = new ConnectOracle();
            RefrescarTabla();
        }
        public void RefrescarTabla()
        {
            co.LeerResultadosTestAlumno(idAlum);
            tablaTestDisponibles.DataSource = co.TablaResultados;
        }
    }
}
