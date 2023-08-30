using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class Usuario
    {
        private Conexion con = new Conexion();
        SqlDataReader dr;
        DataTable dt = new DataTable();
        SqlCommand com = new SqlCommand();

        public DataTable MuestraUsuarios()
        {
            com.Connection = con.AbrirConexion();
            com.CommandText = "Select * from USUARIO";
            com.CommandType = CommandType.Text;
            dr = com.ExecuteReader();
            dt.Load(dr);
            con.CerrarConexion();
            return dt;
        }

        public bool InsertaUsuario(string nombre, string mail, string password)
        {
            int value = 0;
            string consulta = "INSERT INTO USUARIO (USUARIO_NOMBRE, USUARIO_CORREO, USUARIO_PASSWORD) " +
                               "VALUES('" + nombre + "', '" + mail + "', '" + password + "'); ";
            com.Connection = con.AbrirConexion();
            com.CommandType = CommandType.Text;
            com.CommandText = consulta;
            value = com.ExecuteNonQuery();
            con.CerrarConexion();
            return true;
        }

        public bool VerificaUsuario(int ID)
        {
            int value = 0;
            bool bandera = false;
            string consulta = "SELECT * FROM USUARIO WHERE USUARIO_ID=" + ID + ";";
            com.Connection = con.AbrirConexion();
            com.CommandType = CommandType.Text;
            com.CommandText = consulta;
            value = com.ExecuteNonQuery();
            con.CerrarConexion();
            bandera = true;
            return bandera;
        }

        public bool EliminaUsuario(int ID)
        {
            bool bandera = false;
            string consulta = "DELETE FROM USUARIO WHERE usuario_ID="+ID;
            com.Connection = con.AbrirConexion();
            com.CommandType = CommandType.Text;
            com.CommandText = consulta;
            con.CerrarConexion();
            bandera = true;
            return bandera;
        }
    }
}
