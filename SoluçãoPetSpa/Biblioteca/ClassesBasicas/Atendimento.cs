using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.ClassesBasicas
{
    public class Atendimento
    {
        private int codigoAtendimento;

        public int CodigoAtendimento
        {
            get { return codigoAtendimento; }
            set { codigoAtendimento = value; }
        }

        private String descricao;

        public String Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        private String status;

        public String Status
        {
            get { return status; }
            set { status = value; }
        }

        private Agenda agenda;

        public Agenda Agenda
        {
            get { return agenda; }
            set { agenda = value; }
        }
    }
}
