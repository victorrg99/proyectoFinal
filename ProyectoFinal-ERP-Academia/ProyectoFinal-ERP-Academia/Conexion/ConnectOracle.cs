using Oracle.DataAccess.Client;
using ProyectoFinal_ERP_Academia.Util;
using ProyectoFinal_ERP_Academia.Util.Clases;
using ProyectoFinal_ERP_Academia.Views.Organización.Alumnos;
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
        private DataTable alumTable;
        private DataTable profTable;
        private DataTable asigTable;
        private DataTable aulasTable;
        private DataTable gruposTable;
        private static List<Rol> roleTable;
        private static List<Asignatura> asignatuasTable;
        private static List<Profesor> profesoresTable;



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
        int inicioSesion = -1;
        public int IniciarSesion(String usuario, String c)
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            String clave = Encryptor.MD5Hash(c);
            data = query.getData("Select count(ID_USUARIO) from USUARIOS where UPPER(USUARIO) like upper('"+usuario+ "') and  CLAVE = '"+clave+"'", "USUARIOS");
            usersTable = data.Tables["USUARIOS"];
            if (int.Parse(usersTable.Rows[0][0].ToString()) == 1)
            {
                data = query.getData("Select ID_USUARIO from USUARIOS where UPPER(USUARIO) like upper('" + usuario + "') and  CLAVE = '" + clave + "'", "USUARIOS");
                usersTable = data.Tables["USUARIOS"];
                inicioSesion = int.Parse(usersTable.Rows[0][0].ToString());
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
            data = query.getData("Select ID_USUARIO,USUARIO,ID_ROL,ELIMINADO from USUARIOS order by ID_USUARIO", "USUARIOS");
            usersTable = data.Tables["USUARIOS"];
        }

        public Usuario buscarUsuario(int id)
        {
            Usuario u = new Usuario();
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_USUARIO,USUARIO,ID_ROL,ELIMINADO from USUARIOS where ID_USUARIO=" + id + "", "USUARIOS");
            usersTable = data.Tables["USUARIOS"];
            u.Id= int.Parse(usersTable.Rows[0][0].ToString());
            u.USUARIO= usersTable.Rows[0][1].ToString();
            u.ROL= int.Parse(usersTable.Rows[0][2].ToString());
            u.ELIMINADO= int.Parse(usersTable.Rows[0][3].ToString());
            return u;
        }
        public Usuario buscarUsuario(String usuario)
        {
            Usuario u = new Usuario();
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_USUARIO,USUARIO,ID_ROL,ELIMINADO from USUARIOS where USUARIO like '" + usuario + "'", "USUARIOS");
            usersTable = data.Tables["USUARIOS"];
            u.Id = int.Parse(usersTable.Rows[0][0].ToString());
            u.USUARIO = usersTable.Rows[0][1].ToString();
            u.ROL = int.Parse(usersTable.Rows[0][2].ToString());
            u.ELIMINADO = int.Parse(usersTable.Rows[0][3].ToString());
            return u;
        }
        public Boolean buscarUsuarioPorNombre(String usuario)
        {
            Boolean encontrado = false;
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select count(ID_USUARIO) from USUARIOS where USUARIO like '" + usuario + "'", "USUARIOS");
            usersTable = data.Tables["USUARIOS"];
            if (int.Parse(usersTable.Rows[0][0].ToString()) > 0) {
                encontrado = true;
            }
            return encontrado;
        }

        public Boolean comprobarClaves(int id, String clave)
        {
            Boolean encontrado = false;
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select count(ID_USUARIO) from USUARIOS where ID_USUARIO = " + id + " and CLAVE like '"+clave+"'", "USUARIOS");
            usersTable = data.Tables["USUARIOS"];
            if (int.Parse(usersTable.Rows[0][0].ToString()) > 0)
            {
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
        public int AgregarUsuario(String usuario, String clave, int rol)
        {
            String id = DLookUp("COUNT(id_usuario)", "usuarios", "").ToString();
            int iId = int.Parse(id) + 1;
            setData("insert into USUARIOS (ID_USUARIO,USUARIO,CLAVE,ID_ROL,ELIMINADO) values(" + iId + ",'" + usuario + "','" + clave + "','" + rol + "',0)");
            return iId;
        }
        public void ModificarClave(int idU, String clave)
        {
            setData("update USUARIOS set CLAVE='" + clave + "' where ID_USUARIO = "+idU+"");
        }
        public void EliminarUsuario(int idU)
        {
            setData("update USUARIOS set ELIMINADO=" + 1 + " where ID_USUARIO = " + idU + "");
        }
        public void RstaurarUsuario(int idU)
        {
            setData("update USUARIOS set ELIMINADO=" + 0 + " where ID_USUARIO = " + idU + "");
        }
        //Alumnos

        public DataTable TablaAlumnos
        {
            get { return alumTable; }
            set { alumTable = value; }
        }

        public void AgregarAlumno(String dni,String nombre, String apellidos, int usuario)
        {
            String id = DLookUp("COUNT(id_alumno)", "alumnos", "").ToString();
            int iId = int.Parse(id) + 1;
            setData("insert into ALUMNOS (ID_ALUMNO,DNI,NOMBRE,APELLIDOS,ID_USUARIO,ELIMINADO) values(" + iId + ",'" + dni + "','" + nombre + "','" + apellidos + "',"+usuario+",0)");
        }
        public void ModificarAlumno(int idA, String dni,String nombre,String apellidos)
        {
            setData("update ALUMNOS set DNI='" + dni + "',NOMBRE='" + nombre + "',APELLIDOS='"+apellidos+"' where ID_ALUMNO = " + idA + "");
        }
        public void LeerTodosAlumnos()
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_ALUMNO,DNI,NOMBRE,APELLIDOS,ID_USUARIO,ELIMINADO from ALUMNOS order by ID_ALUMNO", "ALUMNOS");
            alumTable = data.Tables["ALUMNOS"];
        }

        public Alumno buscarAlumno(int idA)
        {
            Alumno al = new Alumno();
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_ALUMNO,DNI,NOMBRE,APELLIDOS,ID_USUARIO,ELIMINADO from ALUMNOS where ID_ALUMNO =" + idA + "", "ALUMNOS");
            alumTable = data.Tables["ALUMNOS"];
            al.Id = int.Parse(alumTable.Rows[0][0].ToString());
            al.DNI = alumTable.Rows[0][1].ToString();
            al.NOMBRE = alumTable.Rows[0][2].ToString();
            al.APELLIDO = alumTable.Rows[0][3].ToString();
            al.USUARIO = int.Parse(alumTable.Rows[0][4].ToString());
            al.ELIMINADO = int.Parse(alumTable.Rows[0][5].ToString());
            return al;
        }
        ////////////////////////////////////////////////////////////
        //Profesor

        public DataTable TablaProfesores
        {
            get { return profTable; }
            set { profTable = value; }
        }

        public void AgregarProfesor(String dni,String nombre, String apellidos,String titulacion, int usuario)
        {
            String id = DLookUp("COUNT(id_profesor)", "profesores", "").ToString();
            int iId = int.Parse(id) + 1;
            setData("insert into PROFESORES (ID_PROFESOR,DNI,NOMBRE,APELLIDOS,TITULACION,ID_USUARIO,ELIMINADO) values(" + iId + ",'" + dni + "','" + nombre + "','" + apellidos + "','"+titulacion+"',"+usuario+",0)");
        }
        public void ModificarProfesor(int idP, String dni,String nombre,String apellidos, String titulacion)
        {
            setData("update PROFESORES set DNI='" + dni + "',NOMBRE='" + nombre + "',APELLIDOS='"+apellidos+"',TITULACION='"+titulacion+"' where ID_PROFESOR = " + idP + "");
        }
        public void LeerTodosProfesores()
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_PROFESOR,DNI,NOMBRE,APELLIDOS,TITULACION,ID_USUARIO,ELIMINADO from PROFESORES order by ID_PROFESOR", "PROFESORES");
            profTable = data.Tables["PROFESORES"];
        }

        public Profesor buscarProfesor(int idP)
        {
            Profesor pr = new Profesor();
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_PROFESOR,DNI,NOMBRE,APELLIDOS,TITULACION,ID_USUARIO,ELIMINADO from PROFESORES where ID_PROFESOR = " + idP + " order by ID_PROFESOR ", "PROFESORES");
            profTable = data.Tables["PROFESORES"];
            pr.Id = int.Parse(profTable.Rows[0][0].ToString());
            pr.DNI = profTable.Rows[0][1].ToString();
            pr.NOMBRE = profTable.Rows[0][2].ToString();
            pr.APELLIDO = profTable.Rows[0][3].ToString();
            pr.TITULACION = profTable.Rows[0][4].ToString();
            pr.USUARIO = int.Parse(profTable.Rows[0][5].ToString());
            pr.ELIMINADO = int.Parse(profTable.Rows[0][6].ToString());
            return pr;
        }


        //ASIGNATURAS
        public DataTable TablaAsignaturas
        {
            get { return asigTable; }
            set { asigTable = value; }
        }
        public void AgregarAsignatura(String descripcion, float precio)
        {
            String id = DLookUp("COUNT(id_asignatura)", "asignaturas", "").ToString();
            int iId = int.Parse(id) + 1;
            setData("insert into ASIGNATURAS (ID_ASIGNATURA,NOMBRE,PRECIO,ELIMINADO) values(" + iId + ",'" + descripcion + "','" + precio + "',0)");
        }

        public void ModificarAsignatura(int idA, String nombre, float precio)
        {
            setData("update ASIGNATURAS set NOMBRE = '" + nombre + "', PRECIO = '"+precio+"' where ID_ASIGNATURA = " + idA + "");
        }

        public void LeerTodasAsignaturas()
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_ASIGNATURA,NOMBRE,PRECIO,ELIMINADO from ASIGNATURAS order by ID_ASIGNATURA", "ASIGNATURAS");
            asigTable = data.Tables["ASIGNATURAS"];
        }

        public Boolean encontradoAsignatura(String descripcion)
        {
            Boolean encontrado = false;
            int aux = int.Parse(DLookUp("count(id_asignatura)","asignaturas", "upper(nombre) like upper('" + descripcion+"')").ToString());
            if (aux > 0)
            {
                encontrado = true;
            }

            return encontrado;
        }

        public Asignatura buscarAsignatura(int idA)
        {
            Asignatura asig = new Asignatura();
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_ASIGNATURA,NOMBRE,PRECIO,ELIMINADO from ASIGNATURAS where ID_ASIGNATURA = " + idA+"", "ASIGNATURAS");
            asigTable = data.Tables["ASIGNATURAS"];
            asig.Id = int.Parse(asigTable.Rows[0][0].ToString());
            asig.DESCRIPCION = asigTable.Rows[0][1].ToString();
            asig.PRECIO = float.Parse(asigTable.Rows[0][2].ToString());
            asig.ELIMINADO = int.Parse(asigTable.Rows[0][3].ToString());
            return asig;
        }



        //Aulas

        public DataTable TablaAulas
        {
            get { return aulasTable; }
            set { aulasTable = value; }
        }
        public void AgregarAula(String descripcion, int capacidad)
        {
            String id = DLookUp("COUNT(id_aula)", "aulas", "").ToString();
            int iId = int.Parse(id) + 1;
            setData("insert into AULAS (ID_AULA,NOMBRE,CAPACIDAD_MAXIMA,ELIMINADO) values(" + iId + ",'" + descripcion + "'," + capacidad + ",0)");
        }

        public void ModificarAula(int idA, String nombre, int capacidad)
        {
            setData("update AULAS set NOMBRE = '" + nombre + "', CAPACIDAD_MAXIMA = " + capacidad + " where ID_AULA = " + idA + "");
        }

        public void LeerTodasAulas()
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_AULA,NOMBRE,CAPACIDAD_MAXIMA,ELIMINADO from AULAS order by ID_AULA", "AULAS");
            aulasTable = data.Tables["AULAS"];
        }

        public Boolean encontradoAula(String descripcion)
        {
            Boolean encontrado = false;
            int aux = int.Parse(DLookUp("count(id_aula)", "aulas", "upper(nombre) like upper('" + descripcion + "')").ToString());
            if (aux > 0)
            {
                encontrado = true;
            }

            return encontrado;
        }

        public Aula buscarAula(int idA)
        {
            Aula aula = new Aula();
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_AULA,NOMBRE,CAPACIDAD_MAXIMA,ELIMINADO from AULAS where ID_AULA = " + idA + "", "AULAS");
            aulasTable = data.Tables["AULAS"];
            aula.Id = int.Parse(aulasTable.Rows[0][0].ToString());
            aula.NOMBRE = aulasTable.Rows[0][1].ToString();
            aula.CAPACIDAD = int.Parse(aulasTable.Rows[0][2].ToString());
            aula.ELIMINADO = int.Parse(aulasTable.Rows[0][3].ToString());
            return aula;
        }


        //Grupos

        public DataTable TablaGrupos
        {
            get { return gruposTable; }
            set { gruposTable = value; }
        }

        public void LeerTodosGrupos()
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_GRUPO,NOMBRE,ID_ASIGNATURA,ID_PROFESOR,ELIMINADO from GRUPOS order by ID_GRUPO", "GRUPOS");
            gruposTable = data.Tables["GRUPOS"];
        }

        public Grupo buscarGrupo(int id)
        {
            Grupo u = new Grupo();
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_GRUPO,NOMBRE,ID_ASIGNATURA,ID_PROFESOR,ELIMINADO from GRUPOS where ID_GRUPO=" + id + "", "GRUPOS");
            gruposTable = data.Tables["GRUPOS"];
            u.id = int.Parse(gruposTable.Rows[0][0].ToString());
            u.nombre = gruposTable.Rows[0][1].ToString();
            u.idAsig = int.Parse(gruposTable.Rows[0][2].ToString());
            u.idProf = int.Parse(gruposTable.Rows[0][3].ToString());
            u.eliminado = int.Parse(gruposTable.Rows[0][4].ToString());
            return u;
        }
        public Grupo buscarGrupos(String nombre)
        {
            Grupo u = new Grupo();
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_GRUPO,NOMBRE,ID_ASIGNATURA,ID_PROFESOR,ELIMINADO from GRUPOS where NOMBRE like '" + nombre + "'", "GRUPOS");
            gruposTable = data.Tables["GRUPOS"];
            u.id = int.Parse(gruposTable.Rows[0][0].ToString());
            u.nombre = gruposTable.Rows[0][1].ToString();
            u.idAsig = int.Parse(gruposTable.Rows[0][2].ToString());
            u.idProf = int.Parse(gruposTable.Rows[0][3].ToString());
            u.eliminado = int.Parse(gruposTable.Rows[0][4].ToString());
            return u;

        }
        public Boolean buscarGrupoPorNombre(String nombre)
        {
            Boolean encontrado = false;
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select count(ID_GRUPO) from GRUPOS where NOMBRE like '" + nombre + "'", "GRUPOS");
            gruposTable = data.Tables["GRUPOS"];
            if (int.Parse(gruposTable.Rows[0][0].ToString()) > 0)
            {
                encontrado = true;
            }
            return encontrado;
        }

        public static List<Asignatura> AsigList
        {
            get { return asignatuasTable; }
            set { asignatuasTable = value; }
        }
        public void AddAsignaturas(DataSet data)
        {
            List<Asignatura> ps = new List<Asignatura>();

            foreach (DataRow dr in data.Tables["ASIGNATURAS"].Rows)
            {
                ps.Add(new Asignatura(dr["NOMBRE"].ToString()));
            }

            asignatuasTable = ps;
        }
        public void getAsignaturas()
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = getData("SELECT DISTINCT NOMBRE, ID_ASIGNATURA FROM ASIGNATURAS ORDER BY ID_ASIGNATURA", "ASIGNATURAS");
            AddAsignaturas(data);
        }


        public static List<Profesor> ProfeList
        {
            get { return profesoresTable; }
            set { profesoresTable = value; }
        }
        public void AddProfesores(DataSet data)
        {
            List<Profesor> ps = new List<Profesor>();

            foreach (DataRow dr in data.Tables["PROFESORES"].Rows)
            {
                ps.Add(new Profesor(dr["NOMBRE"].ToString()));
            }

            profesoresTable = ps;
        }
        public void getProfesores()
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = getData("SELECT DISTINCT NOMBRE, ID_PROFESOR FROM PROFESORES ORDER BY ID_PROFESOR", "PROFESORES");
            AddProfesores(data);
        }


        public int AgregarGrupo(String nombre,int idAsig, int idProf)
        {
            String id = DLookUp("COUNT(id_grupo)", "grupos", "").ToString();
            int iId = int.Parse(id) + 1;
            setData("insert into GRUPOS (ID_GRUPO,NOMBRE,ID_ASIGNATURA,ID_PROFESOR,ELIMINADO) values(" + iId + ",'" + nombre + "','" + idAsig + "','"+ idProf + "',0)");
            return iId;
        }
        public void ModificarGrupo(int idG, String nombre, int idAsig, int idProf)
        {
            setData("update GRUPOS set NOMBRE='" + nombre + "',ID_ASIGNATURA = '"+ idAsig + "', ID_PROFESOR = '"+ idProf + "' where ID_GRUPO = " + idG + "");
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
