using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolucaoPetSpa
{
    public partial class Atendimento : Form
    {
        DateTime date_time;
        public Atendimento()
        {
            InitializeComponent();
        }

        private void Atendimento_Load(object sender, EventArgs e)
        {

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void funcionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TelaFuncionario TF = new TelaFuncionario();
                TF.Show();
            }
            catch (Exception ex)
            {
                
               throw new Exception("Erro ao abrir tela de cadastro do Funcionario " + ex.Message);
            }
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TelaCliente TC = new TelaCliente();
                TC.Show();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao abrir tela de cadastro do Cliente " + ex.Message);
            }
        }

        private void serviçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TelaServico TS = new TelaServico();
                TS.Show();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao abrir tela de cadastro do Serviço " + ex.Message);
            }
        }

        private void animalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TelaAnimal TA = new TelaAnimal();
                TA.Show();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao abrir tela de cadastro do Animal " + ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            date_time = DateTime.Now;
            lb_date_time.Text = "Data : " + date_time.ToLongDateString() + "  Hora: " + date_time.ToLongTimeString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fábio José Lucena \nBrunno Barbosa \nSostenes Freitas \nVinicius Marinho", "Desenvolvedores:", MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }

        private void raçaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TelaRaca TR = new TelaRaca();
                TR.Show();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao abrir tela de cadastro do Animal " + ex.Message);
            }
        }
    }
}
