﻿using Oracle.DataAccess.Client;
using ProyectoFinal_ERP_Academia.Util;
using ProyectoFinal_ERP_Academia.Util.Clases;
using ProyectoFinal_ERP_Academia.Views.Organización.Alumnos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_ERP_Academia.Conexion
{
    class ConnectOracle
    { ////////////////////////////////////////////////////////////
        ////////////////////  DRIVER //////////////////////
        ////////////////////////////////////////////////////////////
        const String driver = "Data Source=(DESCRIPTION ="
        + "(ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = LOCALHOST)(PORT = 1522)))"
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
        private DataTable preguntasTable;
        private DataTable testTable;
        private DataTable resultadosTable;
        private DataTable testpregTable;
        private DataTable grupalumnoTable;
        private DataTable transaccionesTable;
        private DataTable facturasTable;
        private DataTable matriculasTable;
        private DataTable abonosTable;
        private DataTable horasTable;
        private static List<Rol> roleTable;
        private static List<Asignatura> asignatuasTable;
        private static List<Profesor> profesoresTable;
        private static List<Alumno> alumnTable;
        private static List<Grupo> grupTable;
        private static List<Aula> aulaTable;
        private static List<Pregunta> pregTable;




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
        public Boolean ExisteAlumno(String dni)
        {
            Boolean existe = false;
            String id = DLookUp("COUNT(id_alumno)", "alumnos", "dni like '"+dni+"'").ToString();
            int iId = int.Parse(id);
            if (iId > 0)
            {
                existe = true;
            }
            return existe;
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
        public Alumno buscarAlumno(string dni)
        {
            Alumno al = new Alumno();
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_ALUMNO,DNI,NOMBRE,APELLIDOS,ID_USUARIO,ELIMINADO from ALUMNOS where DNI like '" + dni + "'", "ALUMNOS");
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
        public Boolean ExisteProfesor(String dni)
        {
            Boolean existe = false;
            String id = DLookUp("COUNT(id_profesor)", "profesores", "dni like '" + dni + "'").ToString();
            int iId = int.Parse(id);
            if (iId > 0)
            {
                existe = true;
            }
            return existe;
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
            data = query.getData("Select ID_GRUPO,NOMBRE,ID_ASIGNATURA,ID_PROFESOR,CAPACIDAD,ELIMINADO from GRUPOS order by ID_GRUPO", "GRUPOS");
            gruposTable = data.Tables["GRUPOS"];
        }

        public Grupo buscarGrupo(int id)
        {
            Grupo u = new Grupo();
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_GRUPO,NOMBRE,ID_ASIGNATURA,ID_PROFESOR,CAPACIDAD,ELIMINADO from GRUPOS where ID_GRUPO=" + id + "", "GRUPOS");
            gruposTable = data.Tables["GRUPOS"];
            u.id = int.Parse(gruposTable.Rows[0][0].ToString());
            u.nombre = gruposTable.Rows[0][1].ToString();
            u.idAsig = int.Parse(gruposTable.Rows[0][2].ToString());
            u.idProf = int.Parse(gruposTable.Rows[0][3].ToString());
            u.capacidad = int.Parse(gruposTable.Rows[0][4].ToString());
            u.eliminado = int.Parse(gruposTable.Rows[0][5].ToString());
            return u;
        }
        public Grupo buscarGrupo(String nombre)
        {
            Grupo u = new Grupo();
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_GRUPO,NOMBRE,ID_ASIGNATURA,ID_PROFESOR,CAPACIDAD,ELIMINADO from GRUPOS where NOMBRE like '" + nombre + "'", "GRUPOS");
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


        public int AgregarGrupo(String nombre,int idAsig, int idProf,int capacidad)
        {
            String id = DLookUp("COUNT(id_grupo)", "grupos", "").ToString();
            int iId = int.Parse(id) + 1;
            setData("insert into GRUPOS (ID_GRUPO,NOMBRE,ID_ASIGNATURA,ID_PROFESOR,CAPACIDAD,ELIMINADO) values(" + iId + ",'" + nombre + "','" + idAsig + "','"+ idProf + "','"+capacidad+"',0)");
            return iId;
        }
        public void ModificarGrupo(int idG, String nombre, int idAsig, int idProf,int capacidad)
        {
            setData("update GRUPOS set NOMBRE='" + nombre + "',ID_ASIGNATURA = '"+ idAsig + "', ID_PROFESOR = '"+ idProf + "',CAPACIDAD = '"+capacidad+"' where ID_GRUPO = " + idG + "");
        }

        //Preguntas

        public DataTable TablaPreguntas
        {
            get { return preguntasTable; }
            set { preguntasTable = value; }
        }

        public void AgregarPregunta(int idA,String preg,String res1,String res2, String res3, int resC)
        {
            String id = DLookUp("COUNT(id_pregunta)", "preguntas", "").ToString();
            int iId = int.Parse(id) + 1;
            setData("insert into PREGUNTAS (ID_PREGUNTA,ID_ASIGNATURA,PREGUNTA,RESPUESTA1,RESPUESTA2,RESPUESTA3,RESPUESTA_CORRECTA,ELIMINADO) values(" + iId + ",'" + idA + "','"+preg+"','" + res1 + "','" + res2 + "','" + res3 + "',"+resC+",0)");
        }
        public void ModificarPregunta(int idP, int idA, String preg, String res1, String res2, String res3, int resC)
        {
            setData("update PREGUNTAS set ID_ASIGNATURA='" + idA + "',PREGUNTA='" + preg + "',RESPUESTA1='" + res1 + "',RESPUESTA2='" + res2 + "',RESPUESTA3='" + res3 + "',RESPUESTA_CORRECTA=" + resC + " where ID_PREGUNTA = " + idP + "");
        }
        public void LeerTodasPreguntas()
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_PREGUNTA,ID_ASIGNATURA,PREGUNTA,RESPUESTA1,RESPUESTA2,RESPUESTA3,RESPUESTA_CORRECTA,ELIMINADO from PREGUNTAS order by ID_PREGUNTA", "PREGUNTAS");
            preguntasTable = data.Tables["PREGUNTAS"];
        }

        public void LeerTodasPreguntasDeAsignatura(int idAsig)
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_PREGUNTA,ID_ASIGNATURA,PREGUNTA,RESPUESTA1,RESPUESTA2,RESPUESTA3,RESPUESTA_CORRECTA,ELIMINADO from PREGUNTAS  where ID_ASIGNATURA = "+idAsig+" order by ID_PREGUNTA", "PREGUNTAS");
            preguntasTable = data.Tables["PREGUNTAS"];
        }

        public Pregunta buscarPregunta(int idP)
        {
            Pregunta pr = new Pregunta();
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_PREGUNTA,ID_ASIGNATURA,PREGUNTA,RESPUESTA1,RESPUESTA2,RESPUESTA3,RESPUESTA_CORRECTA,ELIMINADO from PREGUNTAS where ID_PREGUNTA =" + idP + "", "PREGUNTAS");
            preguntasTable = data.Tables["PREGUNTAS"];
            pr.idPregunta = int.Parse(preguntasTable.Rows[0][0].ToString());
            pr.idAsignatura = int.Parse(preguntasTable.Rows[0][1].ToString());
            pr.pregunta = preguntasTable.Rows[0][2].ToString();
            pr.respuesta1 = preguntasTable.Rows[0][3].ToString();
            pr.respuesta2 = preguntasTable.Rows[0][4].ToString();
            pr.respuesta3 = preguntasTable.Rows[0][5].ToString();
            pr.resCorrecta = int.Parse(preguntasTable.Rows[0][6].ToString());
            pr.eliminado = int.Parse(preguntasTable.Rows[0][7].ToString());
            return pr;
        }

        //Test

        public DataTable TablaTest
        {
            get { return testTable; }
            set { testTable = value; }
        }

        public void AgregarTest(int idA, int dif)
        {
            String id = DLookUp("COUNT(id_test)", "test", "").ToString();
            int iId = int.Parse(id) + 1;
            setData("insert into TEST (ID_TEST,ID_ASIGNATURA,DIFICULTAD,ELIMINADO) values(" + iId + ",'" + idA + "','" + dif + "',0)");
        }
        public void ModificarTest(int idT, int idA, int dif)
        {
            setData("update TEST set ID_ASIGNATURA='" + idA + "',DIFICULTAD='" + dif + "' where ID_TEST = " + idT + "");
        }
        public void LeerTodosTest()
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_TEST,ID_ASIGNATURA,DIFICULTAD,ELIMINADO from TEST order by ID_TEST", "TEST");
            testTable = data.Tables["TEST"];
        }
        
        public void LeerTodosTest(int idA)
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_TEST,ID_ASIGNATURA,DIFICULTAD,ELIMINADO from TEST where ID_ASIGNATURA = "+idA+" order by ID_TEST", "TEST");
            testTable = data.Tables["TEST"];
        }

        public Test buscarTest(int idT)
        {
            Test test = new Test();
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_TEST,ID_ASIGNATURA,DIFICULTAD,ELIMINADO from TEST where ID_TEST =" + idT + "", "TEST");
            testTable = data.Tables["TEST"];
            test.idTest = int.Parse(testTable.Rows[0][0].ToString());
            test.idAsignatura = int.Parse(testTable.Rows[0][1].ToString());
            test.dificultad = int.Parse(testTable.Rows[0][2].ToString());
            test.eliminado = int.Parse(testTable.Rows[0][3].ToString());
            return test;
        }
        //Test-Preguntas ---testpregTable

        public DataTable TablaTestPreg
        {
            get { return testpregTable; }
            set { testpregTable = value; }
        }
        public void LeerTodasPreguntasDeTest(int idTest)
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_PREGUNTA,ID_ASIGNATURA,PREGUNTA,RESPUESTA1,RESPUESTA2,RESPUESTA3,RESPUESTA_CORRECTA,ELIMINADO from PREGUNTAS  where ID_PREGUNTA IN (SELECT ID_PREGUNTA FROM TEST_PREGUNTAS WHERE ID_TEST = "+idTest+") order by ID_PREGUNTA", "TESTPREG");
            testpregTable = data.Tables["TESTPREG"];
        }

        public void AgregarTestPregunta(int idT, int idP)
        {
            String id = DLookUp("MAX(id_test_pregunta)", "test_preguntas", "").ToString();
            if (id == "")
            {
                id = "0";
            }
            int iId = int.Parse(id) + 1;
            setData("insert into TEST_PREGUNTAS (ID_TEST_PREGUNTA,ID_TEST,ID_PREGUNTA) values(" + iId + ",'" + idT + "','" + idP + "')");
        }

        public Boolean BuscarTestPregunta(int idT, int idP)
        {
            Boolean res = true;
            String id = DLookUp("COUNT(id_test_pregunta)", "test_preguntas", "id_test =" + idT + " and id_pregunta = " + idP ).ToString();
            int iId = int.Parse(id);
            if (iId == 0)
            {
                res = false;
            }
            return res;
        }
        public Boolean TestCompleto(int idT)
        {
            Boolean res = false;

            String id = DLookUp("dificultad", "test", "id_test =" + idT).ToString();
            int maxCapacidad = int.Parse(id) * 10;
            String ocupacion = DLookUp("COUNT(id_test)", "test_preguntas", "id_test=" + idT).ToString();
            int ocu = int.Parse(ocupacion);
            if (ocu>=maxCapacidad)
            {
                res = true;
            }
            return res;
        }

        public void EliminarTestPregunta(int idT, int idP)
        {
            String id = DLookUp("id_test_pregunta", "test_preguntas", "id_test =" + idT + " and id_pregunta = " + idP).ToString();
            int iId = int.Parse(id);
            setData("DELETE FROM TEST_PREGUNTAS WHERE ID_TEST_PREGUNTA = "+iId+"");
        }



        //GRUPOS-ALUMNOS  grupalumnoTable

        public DataTable TablaGrupAlumno
        {
            get { return grupalumnoTable; }
            set { grupalumnoTable = value; }
        }
        public void LeerTodosAlumnosDeGrupo(int idGrupo)
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_ALUMNO,DNI,NOMBRE,APELLIDOS,ID_USUARIO,ELIMINADO from ALUMNOS  where ID_ALUMNO IN (SELECT ID_ALUMNO FROM ALUMNOS_GRUPOS WHERE ID_GRUPO = " + idGrupo + ") order by ID_ALUMNO", "GRUPALUMNO");
            grupalumnoTable = data.Tables["GRUPALUMNO"];
        }

        public void AgregarAlumnoGrupo(int idA, int idG)
        {
            String id = DLookUp("MAX(id_alumno_grupo)", "alumnos_grupos", "").ToString();
            if (id == "")
            {
                id = "0";
            }
            int iId = int.Parse(id) + 1;
            setData("insert into ALUMNOS_GRUPOS (ID_ALUMNO_GRUPO,ID_ALUMNO,ID_GRUPO) values(" + iId + ",'" + idA + "','" + idG + "')");
        }

        public Boolean BuscarAlumnoGrupo(int idA, int idG)
        {
            Boolean res = true;
            String id = DLookUp("COUNT(id_alumno_grupo)", "alumnos_grupos", "id_alumno =" + idA + " and id_grupo = " + idG).ToString();
            int iId = int.Parse(id);
            if (iId == 0)
            {
                res = false;
            }
            return res;
        }

        public Boolean GrupoCompleto(int idG)
        {
            Boolean res = false;

            String id = DLookUp("capacidad", "grupos", "id_grupo =" + idG).ToString();
            int maxCapacidad = int.Parse(id);
            String ocupacion = DLookUp("COUNT(id_grupo)", "alumnos_grupos", "id_grupo=" + idG).ToString();
            int ocu = int.Parse(ocupacion);
            if (ocu >= maxCapacidad)
            {
                res = true;
            }
            return res;
        }

        public void EliminarAlumnoGrupo(int idA, int idG)
        {
            String id = DLookUp("id_alumno_grupo", "alumnos_grupos", "id_alumno =" + idA + " and id_grupo = " + idG).ToString();
            int iId = int.Parse(id);
            setData("DELETE FROM ALUMNOS_GRUPOS WHERE ID_ALUMNO_GRUPO = " + iId + "");
        }
        //Matriculas

        public DataTable TablaMatriculas
        {
            get { return matriculasTable; }
            set { matriculasTable = value; }
        }
        public void LeerTodasMatriculas()
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_MATRICULA,ID_ALUMNO,ID_GRUPO,PRECIO,FECHA_EXPEDICION,ELIMINADO FROM MATRICULAS ORDER BY ID_MATRICULA", "MATRICULAS");
            matriculasTable = data.Tables["MATRICULAS"];
        }
        public float getPrecioGrupo(int idG)
        {
            String pr = DLookUp("precio", "asignaturas", "id_asignatura in (select id_asignatura from grupos where id_grupo = '"+idG+"')").ToString();
            float precio = float.Parse(pr);
            return precio;
        }
        public void AgregarMatricula(int idA, int idG, float precio)
        {
            String id = DLookUp("COUNT(id_matricula)", "matriculas", "").ToString();
            int iId = int.Parse(id) + 1;
            String date = DateTime.Now.ToString("dd'/'MM'/'yyyy - HH:mm:ss");
            setData("insert into MATRICULAS (ID_MATRICULA,ID_ALUMNO,ID_GRUPO,PRECIO,FECHA_EXPEDICION,ELIMINADO) values('" + iId + "','" + idA + "','" + idG + "','" + precio + "',TO_DATE('" + date + "', 'DD/MM/YYYY - HH24:MI:SS'),0)");
        }
        public void ModificarMatricula(int idM,int idA,int idG, float precio)
        {
            setData("update MATRICULAS set ID_ALUMNO = '"+idA+"',ID_GRUPO='"+idG+"',PRECIO='"+precio+"' where ID_MATRICULA = '"+idM+"'");
        }
        public Matricula BuscarMatricula(int idM)
        {
            Matricula ma = new Matricula();
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_MATRICULA,ID_ALUMNO,ID_GRUPO,PRECIO,FECHA_EXPEDICION,ELIMINADO FROM MATRICULAS WHERE ID_MATRICULA='"+idM+"'", "MATRICULAS");
            matriculasTable = data.Tables["MATRICULAS"];
            ma.id = int.Parse(matriculasTable.Rows[0][0].ToString());
            ma.idAlumno = int.Parse(matriculasTable.Rows[0][1].ToString());
            ma.idGrupo = int.Parse(matriculasTable.Rows[0][2].ToString());
            ma.precio = float.Parse(matriculasTable.Rows[0][3].ToString());
            ma.fecha = matriculasTable.Rows[0][4].ToString();
            ma.eliminado = int.Parse(matriculasTable.Rows[0][5].ToString());
            return ma;
        }

        //Facturas

        public DataTable TablaFacturas
        {
            get { return facturasTable; }
            set { facturasTable = value; }
        }
        public void LeerTodasFacturas()
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_FACTURA,CODIGO,FECHA,ID_USUARIO,ID_ALUMNO,CANTIDAD_SIN_IMPUESTO,IMPUESTO,CANTIDAD_TOTAL,CONFIRMADO FROM FACTURAS ORDER BY ID_FACTURA", "FACTURAS");
            facturasTable = data.Tables["FACTURAS"];
        }
        public void AgregarFactura(int idU,int idA, float cant1)
        {
            String id = DLookUp("COUNT(id_factura)", "facturas", "").ToString();
            int iId = int.Parse(id) + 1;
            float imp = float.Parse("0,21");
            float cant2 = cant1 * (1+imp);
            
            setData("insert into FACTURAS (ID_FACTURA,ID_USUARIO,ID_ALUMNO,CANTIDAD_SIN_IMPUESTO,IMPUESTO,CANTIDAD_TOTAL,CONFIRMADO) values(" + iId + ",'" + idU + "','" + idA + "','" +cant1 + "','"+imp+"','" +cant2.ToString("N2")+ "',0)");
        }
        public void ModificarFactura(int idF,int idU, int idA, float cant1)
        {
            float imp = float.Parse("1,21");
            float cant2 = cant1 * imp;
            setData("update FACTURAS set ID_USUARIO = '" + idU+ "',ID_ALUMNO='" + idA+ "',CANTIDAD_SIN_IMPUESTO='" + cant1+ "',CANTIDAD_TOTAL='"+ cant2.ToString("N2") +"' where ID_FACTURA = "+ idF);
        }
        public void ConfirmarFactura(int idF)
        {
            String id = DLookUp("COUNT(id_transaccion)", "transacciones", "").ToString();
            int iId = int.Parse(id) + 1;
            String date = DateTime.Now.ToString("dd'/'MM'/'yyyy - HH:mm:ss");
            String codigo = "ING-";
            codigo += DateTime.Now.Year.ToString();
            codigo += "0000"+idF;
            setData("update FACTURAS set CODIGO = '"+codigo+ "', FECHA = TO_DATE('" + date + "', 'DD/MM/YYYY - HH24:MI:SS'),CONFIRMADO = 1 where ID_FACTURA = "+idF+"");

        }
        public int getConfirmado(int idF)
        {
            String id = DLookUp("confirmado", "facturas", "id_factura="+idF).ToString();
            int iId = int.Parse(id);
            return iId;
        }

        public Factura buscarFactura(int idF)
        {
            Factura f = new Util.Clases.Factura();
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_FACTURA,CODIGO,FECHA,ID_USUARIO,ID_ALUMNO,CANTIDAD_SIN_IMPUESTO,IMPUESTO,CANTIDAD_TOTAL,CONFIRMADO FROM FACTURAS WHERE ID_FACTURA = "+idF+"", "FACTURAS");
            facturasTable = data.Tables["FACTURAS"];
            f.id = int.Parse(facturasTable.Rows[0][0].ToString()); 
            f.codigo = facturasTable.Rows[0][1].ToString();
            f.fecha = facturasTable.Rows[0][2].ToString();
            f.idUsuario = int.Parse(facturasTable.Rows[0][3].ToString());
            f.idAlumno = int.Parse(facturasTable.Rows[0][4].ToString());
            f.cantidadSinImpuesto = float.Parse(facturasTable.Rows[0][5].ToString());
            f.impuesto = float.Parse(facturasTable.Rows[0][6].ToString());
            f.cantidadTotal = float.Parse(facturasTable.Rows[0][7].ToString());
            f.confirmado = int.Parse(facturasTable.Rows[0][8].ToString());
            return f;
            
        }


        //Transacciones

        public DataTable TablaTransacciones
        {
            get { return transaccionesTable; }
            set { transaccionesTable = value; }
        }
        public void LeerTodasTransacciones()
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_TRANSACCION,TIPO,ID_FACTURA,CONCEPTO,CANTIDAD,FECHA from TRANSACCIONES order by ID_TRANSACCION", "TRANSACCIONES");
            transaccionesTable = data.Tables["TRANSACCIONES"];
        }

        public void AgregarTransaccion(int tipo, int idF,String conc,float cant)
        {
            String id = DLookUp("COUNT(id_transaccion)", "transacciones", "").ToString();
            int iId = int.Parse(id) + 1;
            String date = DateTime.Now.ToString("dd'/'MM'/'yyyy - HH:mm:ss");
            setData("insert into TRANSACCIONES (ID_TRANSACCION,TIPO,ID_FACTURA,CONCEPTO,CANTIDAD,FECHA) values(" + iId + ",'" + tipo + "','" + idF + "','"+conc+"','"+cant+ "',TO_DATE('" + date + "', 'DD/MM/YYYY - HH24:MI:SS'))");
        }

        //Abonos abonosTable

        public DataTable TablaAbonos
        {
            get { return abonosTable; }
            set { abonosTable = value; }
        }
        public void LeerTodosAbonos()
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_ABONO,ID_FACTURA,CANTIDAD,FECHA from ABONOS order by ID_ABONO", "ABONOS");
            abonosTable = data.Tables["ABONOS"];
        }

        public void AgregarAbono(int idF,float cant)
        {
            String id = DLookUp("COUNT(id_abono)", "abonos", "").ToString();
            int iId = int.Parse(id) + 1;
            String date = DateTime.Now.ToString("dd'/'MM'/'yyyy - HH:mm:ss");
            setData("insert into ABONOS (ID_ABONO,ID_FACTURA,CANTIDAD,FECHA) values(" + iId + ",'" + idF + "','" + cant + "',TO_DATE('" + date + "', 'DD/MM/YYYY - HH24:MI:SS'))");
        }

        //Horas

        public DataTable TablaHoras
        {
            get { return horasTable; }
            set { horasTable = value; }
        }
        public void LeerHoras(int idA,int idG,String dia)
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_HORARIO,DIA,HORA_INICIO,HORA_FIN from HORARIO where ID_HORARIO NOT IN (SELECT ID_HORARIO FROM GRUPOS_AULAS_HORARIOS WHERE ID_AULA = '"+idA+ "' AND ID_HORARIO IN (SELECT ID_HORARIO FROM HORARIO WHERE upper(DIA) like upper('"+dia+"'))) and upper(DIA) like upper('"+dia+"') order by ID_HORARIO", "HORARIO");
            horasTable = data.Tables["HORARIO"];
        }
        public void LeerHorasOcupadas(int idA, int idG, String dia)
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("Select ID_HORARIO,DIA,HORA_INICIO,HORA_FIN from HORARIO where ID_HORARIO IN (SELECT ID_HORARIO FROM GRUPOS_AULAS_HORARIOS WHERE ID_AULA = '" + idA + "' AND ID_GRUPO = '" + idG + "' AND ID_HORARIO IN (SELECT ID_HORARIO FROM HORARIO WHERE upper(DIA) like upper('" + dia + "'))) and upper(DIA) like upper('" + dia + "') order by ID_HORARIO", "HORARIO");
            horasTable = data.Tables["HORARIO"];
        }
        public Boolean checkGH()
        {
            Boolean posible = true;
            String a = DLookUp("COUNT(id_aula)", "aulas", "").ToString();
            int au = int.Parse(a);
            String g = DLookUp("COUNT(id_grupo)", "grupos", "").ToString();
            int gr = int.Parse(g);
            if (au == 0) { posible = false; }
            if (gr == 0) { posible = false; }
            return posible;
        }
        public Boolean checkGA(int idG,int idA)
        {
            Boolean posible = false;
            String a = DLookUp("CAPACIDAD_MAXIMA", "AULAS", "ID_AULA = '"+idA+"'").ToString();
            int au = int.Parse(a);
            String g = DLookUp("CAPACIDAD", "GRUPOS", "ID_GRUPO = '"+idG+"'").ToString();
            int gr = int.Parse(g);
            if (au >= gr) { posible = true; }
            return posible;
        }
        public Boolean checkGrupoHorario(int idG, int idH)
        {
            Boolean posible = true;
            String a = DLookUp("COUNT(ID_GRUPO_AULA_HORARIO)", "GRUPOS_AULAS_HORARIOS", "ID_GRUPO = '" + idG + "' AND ID_HORARIO = '"+idH+"'").ToString();
            int au = int.Parse(a);
            if (au > 0) { posible = false; }
            return posible;
        }
        public void AgregarGrupoAulaHorario(int idGrupo,int idAula,int idHorario)
        {
            String a = DLookUp("MAX(id_grupo_aula_horario)", "grupos_aulas_horarios", "").ToString();
            if (a == "")
            {
                a = "0";
            }
            int id = int.Parse(a)+1;
            setData("insert into GRUPOS_AULAS_HORARIOS (ID_GRUPO_AULA_HORARIO,ID_GRUPO,ID_AULA,ID_HORARIO) values("+id+","+idGrupo+","+ idAula + ","+ idHorario + ")");
        }
        public void EliminarGrupoAulaHorario(int idGrupo, int idAula, int idHorario)
        {
            String a = DLookUp("id_grupo_aula_horario", "grupos_aulas_horarios", "id_grupo ='"+idGrupo+"' and id_aula ='"+idAula+"' and id_horario = '"+idHorario+"'").ToString();
            int id = int.Parse(a);
            setData("delete from GRUPOS_AULAS_HORARIOS where ID_GRUPO_AULA_HORARIO = '"+id+"'");
        }

        //Hacer Test

        public void LeerTestCompletos()
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("select * from test where id_test in(select t.id_test from test t where dificultad*10 = (select count(id_test) from test_preguntas where id_test=t.id_test))", "TEST");
            testTable = data.Tables["TEST"];
        }

        public static List<Pregunta> PregList
        {
            get { return pregTable; }
            set { pregTable = value; }
        }
        public List<Pregunta> AddPreguntas(DataSet data)
        {
            List<Pregunta> ps = new List<Pregunta>();

            foreach (DataRow dr in data.Tables["PREGUNTAS"].Rows)
            {
                Pregunta p = new Pregunta();
                p.idPregunta = int.Parse(dr["ID_PREGUNTA"].ToString());
                p.pregunta= dr["PREGUNTA"].ToString();
                p.respuesta1= dr["RESPUESTA1"].ToString();
                p.respuesta2= dr["RESPUESTA2"].ToString();
                p.respuesta3= dr["RESPUESTA3"].ToString();
                p.resCorrecta= int.Parse(dr["RESPUESTA_CORRECTA"].ToString());
                p.eliminado= int.Parse(dr["ELIMINADO"].ToString());
                p.idAsignatura= int.Parse(dr["ID_ASIGNATURA"].ToString());
                ps.Add(p);
            }

            pregTable = ps;
            return ps;
        }
        public List<Pregunta> getPreguntas(int idT)
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = getData("select * from preguntas where id_pregunta in (select id_pregunta from test_preguntas where id_test = '"+idT+"')", "PREGUNTAS");
            List<Pregunta>  lp = AddPreguntas(data);
            return lp;
        }

        //Mostrar Resultados

        public DataTable TablaResultados
        {
            get { return resultadosTable; }
            set { resultadosTable = value; }
        }

        public void LeerResultadosTestAlumno(int idA)
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = query.getData("select * from resultados where id_alumno = '"+idA+"'", "RESULTADOS");
            resultadosTable = data.Tables["RESULTADOS"];
        }
        public void AñadirResultados(int idT,int idA,int aciertos,int fallos)
        {
            int aprobado=0;
            String a = DLookUp("MAX(id_resultado)", "resultados", "").ToString();
            if (a == "")
            {
                a = "0";
            }
            if (aciertos >= fallos)
            {
                aprobado = 1;
            }
            int id = int.Parse(a)+1;

            String date = DateTime.Now.ToString("dd'/'MM'/'yyyy - HH:mm:ss");
            setData("insert into RESULTADOS (ID_RESULTADO,ID_TEST,ID_ALUMNO,ACIERTOS,FALLOS,APROBADO,FECHA) values ('"+id+"','"+idT+ "','"+idA+ "','"+aciertos+ "','"+fallos+"','"+aprobado+ "',TO_DATE('" + date + "', 'DD/MM/YYYY - HH24:MI:SS'))");
        }



        //General
        public int getIdAlum(int idU)
        {
            String a = DLookUp("id_alumno", "alumnos", "id_usuario = '"+idU+"'").ToString();
            if (a == "")
            {
                a = "0";
            }
            int id = int.Parse(a);
            return id;
        }

        public void EliminarRegistro(String tabla,String fila,int id)
        {
            setData("update "+tabla+" set ELIMINADO=" + 1 + " where "+fila+" = " + id + "");
        }
        public void RestaurarRegistro(String tabla, String fila, int id)
        {
            setData("update " + tabla + " set ELIMINADO=" + 0 + " where " + fila + " = " + id + "");
        }

        public static List<Alumno> AlumList
        {
            get { return alumnTable; }
            set { alumnTable = value; }
        }
        public void AddAlumnos(DataSet data)
        {
            List<Alumno> ps = new List<Alumno>();

            foreach (DataRow dr in data.Tables["ALUMNOS"].Rows)
            {
                ps.Add(new Alumno(dr["DNI"].ToString()));
            }

            alumnTable = ps;
        }
        public void getAlumnos()
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = getData("SELECT DISTINCT DNI, ID_ALUMNO FROM ALUMNOS WHERE ID_ALUMNO IN (SELECT ID_ALUMNO FROM ALUMNOS_GRUPOS) ORDER BY ID_ALUMNO", "ALUMNOS");
            AddAlumnos(data);
        }


        public static List<Grupo> GrupList
        {
            get { return grupTable; }
            set { grupTable = value; }
        }
        public void AddGrupos(DataSet data)
        {
            List<Grupo> ps = new List<Grupo>();

            foreach (DataRow dr in data.Tables["GRUPOS"].Rows)
            {
                ps.Add(new Grupo(dr["NOMBRE"].ToString()));
            }

            grupTable = ps;
        }
        public void getGrupos(int idA)
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = getData("SELECT DISTINCT NOMBRE, ID_GRUPO FROM GRUPOS WHERE ID_GRUPO IN(SELECT ID_GRUPO FROM ALUMNOS_GRUPOS WHERE ID_ALUMNO = '"+idA+"') ORDER BY ID_GRUPO", "GRUPOS");
            AddGrupos(data);
        }
        public void getGrupos()
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = getData("SELECT DISTINCT NOMBRE, ID_GRUPO FROM GRUPOS ORDER BY ID_GRUPO", "GRUPOS");
            AddGrupos(data);
        }

        public static List<Aula> AulasList
        {
            get { return aulaTable; }
            set { aulaTable = value; }
        }
        public void AddAulas(DataSet data)
        {
            List<Aula> ps = new List<Aula>();

            foreach (DataRow dr in data.Tables["AULAS"].Rows)
            {
                ps.Add(new Aula(dr["NOMBRE"].ToString()));
            }

            aulaTable = ps;
        }
        public void getAulas()
        {
            ConnectOracle query = new ConnectOracle();
            DataSet data = new DataSet();
            data = getData("SELECT DISTINCT NOMBRE, ID_AULA FROM AULAS ORDER BY ID_AULA", "AULAS");
            AddAulas(data);
        }
    }
}
