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

namespace ProyectoFinal_ERP_Academia.Views.Organización
{
    public partial class GestionarHorario : Form
    {
        ConnectOracle co;
        public GestionarHorario()
        {
            InitializeComponent();
            co = new ConnectOracle();
            cbDia.SelectedIndex = 0;

            co.getAulas();
            ConnectOracle.AulasList.ForEach(x => this.cbAula.Items.Add(x.NOMBRE));
            if (cbAula.Items.Count > 0)
            {
                cbAula.SelectedIndex = 0;
            }

            co.getGrupos();
            ConnectOracle.GrupList.ForEach(x => this.cbGrupo.Items.Add(x.nombre));
            if (cbGrupo.Items.Count > 0)
            {
                cbGrupo.SelectedIndex = 0;
            }
            RefrescarTabla();
        }
        public void RefrescarTabla()
        {
            co.LeerHoras(cbAula.SelectedIndex + 1, cbGrupo.SelectedIndex + 1,cbDia.SelectedItem.ToString());
            tablaHorasLibres.DataSource = co.TablaHoras;
        }

        private void cbAula_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefrescarTabla();
        }

        private void cbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefrescarTabla();
        }

        private void cbDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefrescarTabla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tablaHorasLibres.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                if (co.checkGA(cbGrupo.SelectedIndex + 1, cbAula.SelectedIndex + 1))
                {
                    int idH = int.Parse(tablaHorasLibres.Rows[tablaHorasLibres.CurrentRow.Index].Cells[0].Value.ToString());
                    if (co.checkGrupoHorario(cbGrupo.SelectedIndex + 1, idH))
                    {
                        co.AgregarGrupoAulaHorario(cbGrupo.SelectedIndex + 1, cbAula.SelectedIndex + 1, idH);
                        MessageBox.Show("Registro agregado correctamente");
                        RefrescarTabla();
                    }
                    else
                    {
                        MessageBox.Show("El grupo seleccionado ya tiene la hora seleccionada asignada en otro aula");
                    }
                    
                    
                }
                else
                {
                    MessageBox.Show("El aula seleccionada no tiene aforo suficiente para ese grupo");
                }
            }
                

        }
    }
}
