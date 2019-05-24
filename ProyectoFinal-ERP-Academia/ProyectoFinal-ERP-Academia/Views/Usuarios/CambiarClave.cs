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
    public partial class CambiarClave : Form
    {
        int idU;
        ConnectOracle co;
        String clvActual;
        String clvNueva;
        String clvRepetida;
        Usuario u;
        public CambiarClave(int id)
        {
            InitializeComponent();
            idU = id;
            co = new ConnectOracle();
            u = co.buscarUsuario(idU);
        }

        private void ModificarUsuario_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (tbClaveA.Text != "" && tbClaveN.Text != "" && tbClaveR.Text != "")
            {
                clvActual = Encryptor.MD5Hash(tbClaveA.Text);
                if (co.comprobarClaves(u.Id,clvActual))
                {
                    clvNueva = Encryptor.MD5Hash(tbClaveN.Text);
                    clvRepetida = Encryptor.MD5Hash(tbClaveR.Text);
                    if (clvNueva == clvRepetida)
                    {
                        co.ModificarClave(u.Id, clvNueva);
                        MessageBox.Show("Contraseña cambiada correctamente");
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("La contraseña nueva no coincide en ambos campos, prueba de nuevo");
                    }
                }
                else
                {
                    MessageBox.Show("La contraseña actual no coincide, prueba otra vez");
                }
            }
            else
            {
                MessageBox.Show("Debes rellenar todos los campos antes de continuar");
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
