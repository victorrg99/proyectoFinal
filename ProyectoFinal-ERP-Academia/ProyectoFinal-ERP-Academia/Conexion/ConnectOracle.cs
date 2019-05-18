using Oracle.DataAccess.Client;
using ProyectoFinal_ERP_Academia.Util;
using ProyectoFinal_ERP_Academia.Util.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ERP_Academia.Conexion
{
    class ConnectOracle
    { ////////////////////////////////////////////////////////////
        ////////////////////  DRIVER //////////////////////
        ////////////////////////////////////////////////////////////
        const String driver = "Data Source=(DESCRIPTION ="
        + "(ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.1.104)(PORT = 1522)))"
        + "(CONNECT_DATA = (SERVICE_NAME = XE))); "
        + "User Id=ProyectoFinal; Password=123456;";

        ////////////////////////////////////////////////////////////
        //Atributos
        private DataTable usersTable;
        private static List<Rol> roleTable;
        


        ///////////////////////////////////////////////////////////

        /**
         * Method to retrieve a set of data
         * Parameter: Query
         * Parameter: Table
         */

        public DataSet getData(String query, String table)
        {
            OracleConnection objConexion;
            OracleDataAdapter objComando;
            DataSet requestQuery = new DataSet();

            objConexion = new OracleConnection(driver);
            objConexion.Open();
            objComando = new OracleDataAdapter(query, objConexion);
            objComando.Fill(requestQuery, table);
            objConexion.Close();

            return requestQuery;
        }

        /**
         * Method to insert/update
         * 
         *  data in a table
         * Parameter: Sentence 
         */
        public void setData(String sentencia)
        {
            OracleConnection objConexion;
            OracleCommand objComando;

            objConexion = new OracleConnection(driver);
            objConexion.Open();
            objComando = new OracleCommand(sentencia, objConexion);

            objComando.ExecuteNonQuery();
            objComando.Connection.Close();
        }

        /**
         * Method to retrieve only one value
         * Parameter: column
         * Parameter: Table
         * Parameter: Condition
         */
        public Object DLookUp(String columna, String tabla, String condicion)
        {
            OracleConnection objConexion;
            OracleDataAdapter objComando;
            DataSet requestQuery = new DataSet();
            Object resultado;

            objConexion = new OracleConnection(driver);
            objConexion.Open();

            if (condicion.Equals(""))
            {
                objComando = new OracleDataAdapter("Select " + columna + " from " + tabla, objConexion);
            }
            else
            {
                objComando = new OracleDataAdapter("Select " + columna + " from " + tabla + " where " + condicion, objConexion);
            }

            objComando.Fill(requestQuery);

            try
            {
                resultado = requestQuery.Tables[0].Rows[0][requestQuery.Tables[0].Columns.IndexOf(columna)];
            }
            catch (Exception)
            {
                resultado = -1;
            }
            objConexion.Close();
            return resultado;
        }

        //Inicio de Sesion
        Boolean inicioSesion = false;
        public Boolean IniciarSesion(String dni,String nombre,String c)
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            String clave = Encryptor.MD5Hash(c);
            data = query.getData("Select count(ID_USUARIO) from USUARIOS where UPPER(DNI) like upper('"+dni+"') and  NOMBRE = '"+nombre+"' and CLAVE = '"+clave+"'", "USUARIOS");
            usersTable = data.Tables["USUARIOS"];
            if (int.Parse(usersTable.Rows[0][0].ToString()) == 1)
            {
                inicioSesion = true;
            }
            return inicioSesion;
        }


        //Usuarios

        public DataTable TablaUsuarios
        {
            get { return usersTable; }
            set { usersTable = value; }
        }

        public void LeerTodosUsuarios()
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_USUARIO,DNI,NOMBRE,APELLIDO,ID_ROL,ELIMINADO from USUARIOS order by ID_USUARIO", "USUARIOS");
            usersTable = data.Tables["USUARIOS"];
        }

        public Usuario buscarUsuario(int id)
        {
            Usuario u = new Usuario();
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_USUARIO,DNI,NOMBRE,APELLIDO,ID_ROL,ELIMINADO from USUARIOS where ID_USUARIO=" + id + "", "USUARIOS");
            usersTable = data.Tables["USUARIOS"];
            u.Id= int.Parse(usersTable.Rows[0][0].ToString());
            u.DNI= usersTable.Rows[0][1].ToString();
            u.NOMBRE = usersTable.Rows[0][2].ToString();
            u.APELLIDO= usersTable.Rows[0][3].ToString();
            u.ROL= int.Parse(usersTable.Rows[0][4].ToString());
            u.ELIMINADO= int.Parse(usersTable.Rows[0][5].ToString());
            return u;
        }
        public Usuario buscarUsuario(String dni)
        {
            Usuario u = new Usuario();
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_USUARIO,DNI,NOMBRE,APELLIDO,ID_ROL,ELIMINADO from USUARIOS where DNI like '" + dni + "'", "USUARIOS");
            usersTable = data.Tables["USUARIOS"];
            u.Id = int.Parse(usersTable.Rows[0][0].ToString());
            u.DNI = usersTable.Rows[0][1].ToString();
            u.NOMBRE = usersTable.Rows[0][2].ToString();
            u.APELLIDO = usersTable.Rows[0][3].ToString();
            u.ROL = int.Parse(usersTable.Rows[0][4].ToString());
            u.ELIMINADO = int.Parse(usersTable.Rows[0][5].ToString());
            return u;
        }
        public Boolean buscarUsuarioPorDNI(String dni)
        {
            Boolean encontrado = false;
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select count(ID_USUARIO) from USUARIOS where DNI like '" + dni + "'", "USUARIOS");
            usersTable = data.Tables["USUARIOS"];
            if (int.Parse(usersTable.Rows[0][0].ToString()) > 0) {
                encontrado = true;
            }
            return encontrado;
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
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = getData("SELECT DISTINCT ROL, ID_ROL FROM ROLES ORDER BY ID_ROL", "ROLES");
            AddRoles(data);
        }
        public void AgregarUsuario(String dni, String nombre, String apellido, String clave, int rol)
        {
            String id = DLookUp("COUNT(id_usuario)", "usuarios", "").ToString();
            int iId = int.Parse(id) + 1;
            setData("insert into USUARIOS (ID_USUARIO,DNI,NOMBRE,APELLIDO,CLAVE,ID_ROL,ELIMINADO) values(" + iId + ",'" + dni + "','" + nombre + "','" + apellido + "','" + clave + "','" + rol + "',0)");
        }
        public void ModificarUsuario(int idU,String dni, String nombre, String apellido, int rol)
        {
            setData("update USUARIOS set DNI='" + dni + "',NOMBRE='" + nombre + "',APELLIDO='" + apellido + "',ID_ROL=" + rol + " where ID_USUARIO = "+idU+"");
        }
        public void EliminarUsuario(int idU)
        {
            setData("update USUARIOS set ELIMINADO=" + 1 + " where ID_USUARIO = " + idU + "");
        }
        public void RstaurarUsuario(int idU)
        {
            setData("update USUARIOS set ELIMINADO=" + 0 + " where ID_USUARIO = " + idU + "");
        }
        //General
        public void EliminarRegistro(String tabla,String fila,int id)
        {
            setData("update "+tabla+" set ELIMINADO=" + 1 + " where "+fila+" = " + id + "");
        }
        public void RestaurarRegistro(String tabla, String fila, int id)
        {
            setData("update " + tabla + " set ELIMINADO=" + 0 + " where " + fila + " = " + id + "");
        }
    }
}
