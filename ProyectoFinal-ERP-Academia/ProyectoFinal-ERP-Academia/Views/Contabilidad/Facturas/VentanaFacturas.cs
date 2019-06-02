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

namespace ProyectoFinal_ERP_Academia.Views.Contabilidad.Facturas
{
    public partial class VentanaFacturas : Form
    {
        ConnectOracle co;
        int idUsuario;
        Factura f;
        public VentanaFacturas(int idU)
        {
            InitializeComponent();
            co = new ConnectOracle();
            this.idUsuario = idU;
            RefrescarTabla();
        }

        private void RefrescarTabla()
        {
            co.LeerTodasFacturas();
            tablaFacturas.DataSource = co.TablaFacturas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearFactura cf = new CrearFactura(idUsuario);
            cf.FormClosed += Cf_FormClosed;
            cf.ShowDialog();
        }

        private void Cf_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tablaFacturas.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int conf = int.Parse(tablaFacturas.Rows[tablaFacturas.CurrentRow.Index].Cells[8].Value.ToString());
                if (conf == 0)
                {
                    int idF = int.Parse(tablaFacturas.Rows[tablaFacturas.CurrentRow.Index].Cells[0].Value.ToString());
                    ModificarFactura mf = new ModificarFactura(idF);
                    mf.FormClosed += Mf_FormClosed;
                    mf.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se puede modificar una factura que está confirmada");
                }
                
            }
            

                
        }

        private void Mf_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tablaFacturas.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int conf = int.Parse(tablaFacturas.Rows[tablaFacturas.CurrentRow.Index].Cells[8].Value.ToString());
                if (conf == 1)
                {
                    int idF = int.Parse(tablaFacturas.Rows[tablaFacturas.CurrentRow.Index].Cells[0].Value.ToString());
                    f = co.buscarFactura(idF);
                    co.AgregarAbono(f.id, f.cantidadTotal);
                    f = co.buscarFactura(idF);
                    co.AgregarTransaccion(1, f.id, "Rectificacion de factura " + f.codigo, f.cantidadTotal);
                    MessageBox.Show("Factura rectificada correctamente");
                }
                else
                {
                    MessageBox.Show("No se puede rectificar una factura que no está confirmada");
                }
                
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (tablaFacturas.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int conf = int.Parse(tablaFacturas.Rows[tablaFacturas.CurrentRow.Index].Cells[8].Value.ToString());
                if (conf == 0)
                {
                    int idF = int.Parse(tablaFacturas.Rows[tablaFacturas.CurrentRow.Index].Cells[0].Value.ToString());
                    f = co.buscarFactura(idF);
                    co.ConfirmarFactura(idF);
                    f = co.buscarFactura(idF);
                    co.AgregarTransaccion(0, f.id, "Confirmacion de Factura " + f.codigo, f.cantidadTotal);
                    MessageBox.Show("Factura confirmada correctamente");
                    RefrescarTabla();
                }
                else
                {
                    MessageBox.Show("No se puede confirmar una factura que está confirmada");
                }
                

            }
        }


    }
}
