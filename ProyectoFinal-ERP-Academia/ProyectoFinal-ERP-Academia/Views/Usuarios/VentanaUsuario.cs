﻿using ProyectoFinal_ERP_Academia.Conexion;
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
                int elim = int.Parse(tablaUsuarios.Rows[tablaUsuarios.CurrentRow.Index].Cells[3].Value.ToString());
                if (elim == 1)
                {
                    MessageBox.Show("El usuario seleccionado ya está eliminado");
                }
                else
                {
                    int idU = int.Parse(tablaUsuarios.Rows[tablaUsuarios.CurrentRow.Index].Cells[0].Value.ToString());
                    EliminarRegistro eu = new EliminarRegistro("USUARIOS","ID_USUARIO",idU);
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
                int elim = int.Parse(tablaUsuarios.Rows[tablaUsuarios.CurrentRow.Index].Cells[3].Value.ToString());
                if (elim == 0)
                {
                    MessageBox.Show("El usuario seleccionado no está eliminado");
                }
                else
                {
                    int idU = int.Parse(tablaUsuarios.Rows[tablaUsuarios.CurrentRow.Index].Cells[0].Value.ToString());
                    RestaurarRegistro ru = new RestaurarRegistro("USUARIOS", "ID_USUARIO", idU);
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
