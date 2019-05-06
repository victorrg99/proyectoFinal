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
    public partial class VentanaUsuario : Form
    {
        ConnectOracle co;
        public VentanaUsuario()
        {
            InitializeComponent();
            co = new ConnectOracle();
            RefrescarTabla();
        }

        private void RefrescarTabla()
        {
            co.LeerTodosUsuarios();
            tablaUsuarios.DataSource = co.TablaUsuarios;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarUsuario au = new AgregarUsuario();
            au.FormClosed += Au_FormClosed;
            au.ShowDialog();
        }

        private void Au_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tablaUsuarios.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int idU = int.Parse(tablaUsuarios.Rows[tablaUsuarios.CurrentRow.Index].Cells[0].Value.ToString());
                ModificarUsuario mu = new ModificarUsuario(idU);
                mu.FormClosed += Mu_FormClosed;
                mu.ShowDialog();
            }
            
        }

        private void Mu_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla();
        }

        private void btElim_Click(object sender, EventArgs e)
        {
            if (tablaUsuarios.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int elim = int.Parse(tablaUsuarios.Rows[tablaUsuarios.CurrentRow.Index].Cells[5].Value.ToString());
                if (elim == 1)
                {
                    MessageBox.Show("El usuario seleccionado ya está eliminado");
                }
                else
                {
                    int idU = int.Parse(tablaUsuarios.Rows[tablaUsuarios.CurrentRow.Index].Cells[0].Value.ToString());
                    EliminarUsuario eu = new EliminarUsuario(idU);
                    eu.FormClosed += Eu_FormClosed;
                    eu.ShowDialog();
                }
            }
        }

        private void Eu_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla();
        }

        private void btRes_Click(object sender, EventArgs e)
        {
            if (tablaUsuarios.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int elim = int.Parse(tablaUsuarios.Rows[tablaUsuarios.CurrentRow.Index].Cells[5].Value.ToString());
                if (elim == 0)
                {
                    MessageBox.Show("El usuario seleccionado no está eliminado");
                }
                else
                {
                    int idU = int.Parse(tablaUsuarios.Rows[tablaUsuarios.CurrentRow.Index].Cells[0].Value.ToString());
                    RestaurarUsuario ru = new RestaurarUsuario(idU);
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
