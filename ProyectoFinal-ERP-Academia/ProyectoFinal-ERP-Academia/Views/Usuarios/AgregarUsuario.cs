using ProyectoFinal_ERP_Academia.Conexion;
using ProyectoFinal_ERP_Academia.Util;
using ProyectoFinal_ERP_Academia.Views.Organización.Alumnos;
using ProyectoFinal_ERP_Academia.Views.Organización.Profesores;
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
        String usuario;
        String clave;
        int rol;
        ConnectOracle co;
        String usuarioCreado;
        public AgregarUsuario()
        {
            InitializeComponent();
            co = new ConnectOracle();
            co.getRoles();
            ConnectOracle.RoleList.ForEach(x => this.cbRoles.Items.Add(x.NombreRol));

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Util.Util.validarNombreApellido(tbUsuario.Text))
            {
                if (!co.buscarUsuarioPorNombre(tbUsuario.Text))
                {
                    if (tbClave.Text != "")
                    {
                        if (cbRoles.SelectedIndex >= 0)
                        {
                            usuario = tbUsuario.Text;
                            clave = Encryptor.MD5Hash(tbClave.Text);
                            rol = cbRoles.SelectedIndex;
                            rol += 1;
                            int idU = co.AgregarUsuario(usuario, clave, rol);
                            if (rol == 4)
                            {
                                AgregarAlumno au = new AgregarAlumno(idU);
                                au.FormClosed += Au_FormClosed;
                                au.ShowDialog();
                            }
                            else
                            {
                                if (rol == 3)
                                {
                                    AgregarProfesor ap = new AgregarProfesor(idU);
                                    ap.FormClosed += Ap_FormClosed;
                                    ap.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show("Usuario creado correctamente");
                                    this.Dispose();
                                }
                            }
                            
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
                    MessageBox.Show("ERROR-El DNI introducido ya pertenece a un usuario");
                }
            }
            else
            {
                MessageBox.Show("ERROR-Formato de dni incorrecto");
            }



        }

        private void Ap_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Usuario creado correctamente");
            this.Dispose();
        }

        private void Au_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Usuario creado correctamente");
            this.Dispose();
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
