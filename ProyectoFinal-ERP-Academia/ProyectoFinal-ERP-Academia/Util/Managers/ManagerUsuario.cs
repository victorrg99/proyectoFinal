using ProyectoFinal_ERP_Academia.Conexion;
using ProyectoFinal_ERP_Academia.Util.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_ERP_Academia.Util.Managers
{
    class ManagerUsuario
    {
        private DataTable usersTable;
        private static List<Rol> roleTable;
        ConnectOracle connection = new ConnectOracle();
        public ManagerUsuario() {
            usersTable = new DataTable();
        }
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
            data = connection.getData("SELECT DISTINCT ROL, ID_ROL FROM ROLES ORDER BY ID_ROL", "ROLES");
            AddRoles(data);
        }
        public void AddUser(String dni,String nombre,String apellido,String clave,int rol) {
            String id = connection.DLookUp("COUNT(id_usuario)", "usuarios", "").ToString();
            int iId = int.Parse(id) + 1;
            connection.setData("insert into USUARIOS (ID_USUARIO,DNI,NOMBRE,APELLIDO,CLAVE,ID_ROL,ELIMINADO) values(" + iId + ",'"+dni+"','"+nombre+"','" + apellido + "','" + clave + "','" + rol + "',0)");
        }
    }
}
