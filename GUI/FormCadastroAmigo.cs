using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Model;

namespace GUI
{
    public partial class FormCadastroAmigo : Form
    {
        private ControllerAmigo amigo;

        public FormCadastroAmigo()
        {
            InitializeComponent();
            amigo = new ControllerAmigo();
        }

        private void novo()
        {
            textBoxNome.Text = "";
            textBoxIdAmigo.Text = "0";
        }
        private void atualizaGrid()
        {
            dataGridViewAmigos.DataSource = amigo.ListarAmigos();
            dataGridViewAmigos.Columns[0].Visible = false;
        }

        private void FormCadastroAmigo_Load(object sender, EventArgs e)
        {
            atualizaGrid();
            novo();
        }

        private void dataGridViewAmigos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewAmigos.CurrentRow != null)
            {
                List<Amigo> lista = (List<Amigo>)dataGridViewAmigos.DataSource;
                Amigo amg = lista[dataGridViewAmigos.CurrentRow.Index];
                textBoxNome.Text = amg.Nome;
                textBoxIdAmigo.Text = amg.IDAmigo.ToString();
            }
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            Amigo amg = new Amigo();
            amg.Nome = textBoxNome.Text;
            amg.IDAmigo = Convert.ToInt32(textBoxIdAmigo.Text);

            if (amigo.GravarAmigo(amg))
            {
                MessageBox.Show("Amigo salvo com sucesso");
                novo();
                atualizaGrid();
            }
            else
            {
                MessageBox.Show("Amigo ao salvar cliente");
            }
        }

       
        private void buttonNovo_Click_1(object sender, EventArgs e)
        {
            novo();
        }

        private void buttonExcluir_Click_1(object sender, EventArgs e)
        {
            {
                int idAmigo = Convert.ToInt32(textBoxIdAmigo.Text);
                if (idAmigo != 0)
                {
                    if (amigo.ExcluirAmigo(idAmigo))
                    {
                        MessageBox.Show("Cliente excluido com sucesso");
                        novo();
                        atualizaGrid();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir cliente");
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um cliente para exclusão");
                }
            }

        }
    }
}