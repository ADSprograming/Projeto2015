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
    public partial class TelaAgendamento : Form
    {
        public TelaAgendamento()
        {
            InitializeComponent();
            CPF.MaxLength = (11);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void OkCPF_Click(object sender, EventArgs e)
        {
        }

        private void CPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
