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

namespace ProyectoFinal_ERP_Academia
{
    public partial class Form1 : Form
    {
        private static List<Rol> roleTable;
        public static List<Rol> RoleList
        {
            get { return roleTable; }
            set { roleTable = value; }
        }
        public void AddRoles(DataSet data)
        {
            List<Rol> ps = new List<Rol>();

            foreach (DataRow dr in data.Tables["ROLES"].Rows)
            {
                ps.Add(new Rol(dr["ROL"].ToString()));
            }

            roleTable = ps;
        }
        public void getRoles()
        {
            DataSet data = new DataSet();
            ConnectOracle connection = new ConnectOracle();
            data = connection.getData("SELECT DISTINCT ROL, ID_ROL FROM ROLES ORDER BY ID_ROL", "ROLES");
            AddRoles(data);
        }
        public Form1()
        {
            InitializeComponent();
            getRoles();
            RoleList.ForEach(x => this.comboBox1.Items.Add(x.NombreRol));


        }
    }
}
