using System;
using Biblioteca;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca.Dados;
using Biblioteca.ClassesBasicas;
namespace SoluçãoPetSpa
{
  
    public partial class Form1 : Form 

    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<Cliente> lista = new DadosCliente().SelecionarClientes().ToList();
                listBox1.Items.Clear();
                foreach (Cliente a in lista)
                {
                    listBox1.Items.Add(a.Nome);
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
