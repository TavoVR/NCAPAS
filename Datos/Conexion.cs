using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    class Conexion
    {
        private SqlConnection con = new SqlConnection("Server=SJS-DIM-ANC\\SQLEXPRESS;Database=CRUD_ASP;User Id=sa;Password=masterkey;");

        public SqlConnection AbrirConexion()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public SqlConnection CerrarConexion()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            return con;
        }
    }
}
