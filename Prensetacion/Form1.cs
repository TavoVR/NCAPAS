using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Prensetacion
{
    public partial class Form1 : Form
    {
        CN_Usuario cnu = new CN_Usuario();
        public Form1()
        {
            InitializeComponent();
            mostrarusuarios();
        }

        private void mostrarusuarios()
        {
            CN_Usuario cnu2 = new CN_Usuario();
            dgvUser.DataSource = null;
            dgvUser.DataSource = cnu2.MuestraUsuario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cnu.InsertaUsuario(txtNom.Text,txtMail.Text,txtPass.Text);
            MessageBox.Show("Usuario ingresado con exito!!!");
            mostrarusuarios();

        }

        private void dgvUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ID_User = 0;
            ID_User = Convert.ToInt32(dgvUser.CurrentRow.Cells[0].Value);

            if (MessageBox.Show("Desea eliminar el usuario " + dgvUser.CurrentRow.Cells[1].Value.ToString(), "Error",MessageBoxButtons.OKCancel,MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                cnu.EliminaUsuario(ID_User);
                mostrarusuarios();
            }

        }
    }
}
