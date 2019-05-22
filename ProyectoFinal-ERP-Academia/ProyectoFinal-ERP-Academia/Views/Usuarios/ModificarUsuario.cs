using ProyectoFinal_ERP_Academia.Conexion;
using ProyectoFinal_ERP_Academia.Util;
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
    public partial class ModificarUsuario : Form
    {
        int idU;
        ConnectOracle co;
        String usuario;
        String clave;
        int rol;
        public ModificarUsuario(int id)
        {
            InitializeComponent();
            idU = id;
            co = new ConnectOracle();
            Usuario u = co.buscarUsuario(idU);
            co.getRoles();
            ConnectOracle.RoleList.ForEach(x => this.cbRoles.Items.Add(x.NombreRol));
            tbUsuario.Text = u.USUARIO;
            cbRoles.SelectedIndex = u.ROL-1;
        }

        private void ModificarUsuario_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Util.Util.validarNombreApellido(tbUsuario.Text))
            {
                if (cbRoles.SelectedIndex >= 0)
                {
                    usuario = tbUsuario.Text;
                    rol = cbRoles.SelectedIndex;
                    rol += 1;
                    co.ModificarUsuario(idU, usuario, rol);
                    MessageBox.Show("Usuario modificado correctamente");
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("ERROR-Selecciona un rol");
                }
            }
            else
            {
                MessageBox.Show("ERROR-Formato de dni incorrecto");
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
