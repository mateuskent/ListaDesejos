using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormPrincipal : Form
    {
        private FormCadastroDesejos formDesejos;
        private FormCadastroAmigo formAmigos;
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void solicitarDesejoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formDesejos == null)
                formDesejos = new FormCadastroDesejos();
            formDesejos.ShowDialog(this);
        }

        private void amigosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formAmigos == null)
            {
                formAmigos = new FormCadastroAmigo();
            }
            formAmigos.ShowDialog(this);
        }
    }
}
