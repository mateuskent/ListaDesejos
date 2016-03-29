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
    public partial class FormCadastroDesejos : Form
    {
        private ControllerAmigo desejo;
        public FormCadastroDesejos()
        {
            InitializeComponent();
            desejo = new ControllerDesejo();
        }


        private void novo()
        {
            textBoxAmigoSolicitante.Text = "";
            textBoxAmigoSolicitado.Text = "";
            dateTimePickerDataDesejo.Value = DateTime.Now;
            textBoxValorDesejo.Text = "";
            richTextBoxDescricao.Text = "";
        }

        private void button1_Click(object sender, EventArgs e){
            novo();
        }

        private void FormCadastroDesejos_Load(object sender, EventArgs e)
        {
            novo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Desejo des = new Desejo();
            des.Solicitante = textBoxAmigoSolicitante.Text;
            des.Solicitado = textBoxAmigoSolicitado.Text;
            des.Valor = Convert.ToDouble(textBoxValorDesejo.Text);
            des.DataDesejo = DateTime.Now;
            des.Descricao = richTextBoxDescricao.Text;
            des.IDDesejo = Convert.ToInt32(textBoxIDDesejo.Text);

            if (desejo.GravarDesejo(desejo))
            {
                MessageBox.Show("Desejo salvo com sucesso");
                novo();
            }
            else
            {
                MessageBox.Show("Erro ao salvar Desejo");
            }
        }

        private void FormCadastroDesejos_Load_1(object sender, EventArgs e)
        {

        }
    }
}
