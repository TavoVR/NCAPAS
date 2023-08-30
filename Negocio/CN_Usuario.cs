using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Negocio
{
    public class CN_Usuario
    {
        private Usuario u = new Usuario();
        string msj = "";

        public DataTable MuestraUsuario()
        {
            DataTable dt = new DataTable();
            dt = u.MuestraUsuarios();
            if (dt.Rows.Count == 0)
            {
                msj = "No hay usuarios que mostrar";
            }
            else
            {
                msj = "Mostrando usuarios";
            }
            return dt;
        }

        public bool InsertaUsuario(string nombre, string mail, string pass)
        {
            if (nombre.Equals("") || mail.Equals("") || pass.Equals(""))
            {
                msj = "Favor de llenar los campos correspondientes";
            }
            else
            {
                Usuario u = new Usuario();
                u.InsertaUsuario(nombre, mail, pass);                
            }
            return true;
        }

        public void EliminaUsuario(int ID)
        {
            Usuario u = new Usuario();
            if (u.VerificaUsuario(ID))
            {
                u.EliminaUsuario(ID);
            }
        }
    }
}
