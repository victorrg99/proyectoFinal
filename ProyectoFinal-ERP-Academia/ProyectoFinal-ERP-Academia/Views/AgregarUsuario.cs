using ProyectoFinal_ERP_Academia.Conexion;
using ProyectoFinal_ERP_Academia.Util;
using ProyectoFinal_ERP_Academia.Util.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_ERP_Academia.Views
{
    public partial class AgregarUsuario : Form
    {
        String dni;
        String nombre;
        String apellido;
        String clave;
        int rol;
        ConnectOracle mu;
        String usuarioCreado;
        public AgregarUsuario()
        {
            InitializeComponent();
            mu = new ConnectOracle();
            mu.getRoles();
            ConnectOracle.RoleList.ForEach(x => this.cbRoles.Items.Add(x.NombreRol));
            usuarioCreado = "Usuario creado correctamente";

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {


            if (Util.Util.validarDNI(tbDNI.Text))
            {
                if (Util.Util.validarNombreApellido(tbNombre.Text))
                {
                    if (Util.Util.validarNombreApellido(tbApellido.Text))
                    {

                        if (tbClave.Text != "")
                        {
                            if (cbRoles.SelectedIndex >= 0)
                            {
                                dni = tbDNI.Text;
                                nombre = tbNombre.Text;
                                apellido = tbApellido.Text;
                                clave = Encryptor.MD5Hash(tbClave.Text);
                                rol = cbRoles.SelectedIndex;
                                rol += 1;
                                mu.AddUser(dni, nombre,apellido, clave, rol);
                                MessageBox.Show(usuarioCreado);
                                this.Dispose();
                            }
                            else
                            {
                                MessageBox.Show("ERROR-Selecciona un rol");
                            }
                        }
                        else
                        {
                            MessageBox.Show("ERROR-La contraseña no puede estar vacía");
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR-Formato de apellido incorrecto");
                    }
                }
                else
                {
                    MessageBox.Show("ERROR-Formato de nombre incorrecto");
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
