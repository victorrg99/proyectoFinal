using ProyectoFinal_ERP_Academia.Conexion;
using ProyectoFinal_ERP_Academia.Util.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_ERP_Academia.Views.Organización.Grupos
{
    public partial class VentanaGrupos : Form
    {
        ConnectOracle co;
        Grupo gr;
        public VentanaGrupos()
        {
            InitializeComponent();
            co = new ConnectOracle();
            gr = new Grupo();
            RefrescarTabla();
        }
        public void RefrescarTabla()
        {
            co.LeerTodosGrupos();
            tablaGrupos.DataSource = co.TablaGrupos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarGrupo ag = new AgregarGrupo();
            ag.FormClosed += Ag_FormClosed;
            ag.ShowDialog();
        }

        private void Ag_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tablaGrupos.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int id = int.Parse(tablaGrupos.Rows[tablaGrupos.CurrentRow.Index].Cells[0].Value.ToString());
                ModificarGrupo mg = new ModificarGrupo(id);
                mg.FormClosed += Mg_FormClosed;
                mg.ShowDialog();
            }
        }

        private void Mg_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tablaGrupos.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int elim = int.Parse(tablaGrupos.Rows[tablaGrupos.CurrentRow.Index].Cells[4].Value.ToString());
                if (elim == 1)
                {
                    MessageBox.Show("El registro seleccionado ya está eliminado");
                }
                else
                {
                    int idP = int.Parse(tablaGrupos.Rows[tablaGrupos.CurrentRow.Index].Cells[0].Value.ToString());
                    EliminarRegistro eu = new EliminarRegistro("GRUPOS", "ID_GRUPO", idP);
                    eu.FormClosed += Eu_FormClosed;
                    eu.ShowDialog();
                }
            }
        }

        private void Eu_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tablaGrupos.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int elim = int.Parse(tablaGrupos.Rows[tablaGrupos.CurrentRow.Index].Cells[4].Value.ToString());
                if (elim == 0)
                {
                    MessageBox.Show("El registro seleccionado no está eliminado");
                }
                else
                {
                    int idP = int.Parse(tablaGrupos.Rows[tablaGrupos.CurrentRow.Index].Cells[0].Value.ToString());
                    RestaurarRegistro ru = new RestaurarRegistro("GRUPOS", "ID_GRUPO", idP);
                    ru.FormClosed += Ru_FormClosed;
                    ru.ShowDialog();
                }
            }
        }

        private void Ru_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla();
        }
    }
}
