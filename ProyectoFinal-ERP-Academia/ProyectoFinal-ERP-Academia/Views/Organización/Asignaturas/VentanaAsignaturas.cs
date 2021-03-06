﻿using ProyectoFinal_ERP_Academia.Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_ERP_Academia.Views.Organización.Asignaturas
{
    public partial class VentanaAsignaturas : Form
    {
        ConnectOracle co;
        public VentanaAsignaturas()
        {
            InitializeComponent();
            co = new ConnectOracle();
            RefrescarTabla();
        }

        public void RefrescarTabla()
        {
            co.LeerTodasAsignaturas();
            tablaAsignaturas.DataSource = co.TablaAsignaturas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarAsignatura aa = new AgregarAsignatura();
            aa.FormClosed += Aa_FormClosed;
            aa.ShowDialog();
        }

        private void Aa_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tablaAsignaturas.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int idA = int.Parse(tablaAsignaturas.Rows[tablaAsignaturas.CurrentRow.Index].Cells[0].Value.ToString());
                ModificarAsignatura ma = new ModificarAsignatura(idA);
                ma.FormClosed += Ma_FormClosed;
                ma.ShowDialog();
            }
        }

        private void Ma_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tablaAsignaturas.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int elim = int.Parse(tablaAsignaturas.Rows[tablaAsignaturas.CurrentRow.Index].Cells[3].Value.ToString());
                if (elim == 1)
                {
                    MessageBox.Show("El registro seleccionado ya está eliminado");
                }
                else
                {
                    int idP = int.Parse(tablaAsignaturas.Rows[tablaAsignaturas.CurrentRow.Index].Cells[0].Value.ToString());
                    EliminarRegistro eu = new EliminarRegistro("ASIGNATURAS", "ID_ASIGNATURA", idP);
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
            if (tablaAsignaturas.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int elim = int.Parse(tablaAsignaturas.Rows[tablaAsignaturas.CurrentRow.Index].Cells[3].Value.ToString());
                if (elim == 0)
                {
                    MessageBox.Show("El usuario seleccionado no está eliminado");
                }
                else
                {
                    int idP = int.Parse(tablaAsignaturas.Rows[tablaAsignaturas.CurrentRow.Index].Cells[0].Value.ToString());
                    RestaurarRegistro ru = new RestaurarRegistro("ASIGNATURAS", "ID_ASIGNATURA", idP);
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
