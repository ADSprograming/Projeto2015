using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.ClassesBasicas
{
    public class Agenda
    {
        private int codigoAgenda;

        public int CodigoAgenda
        {
            get { return codigoAgenda; }
            set { codigoAgenda = value; }
        }

        private String hora;

        public String Hora
        {
            get { return hora; }
            set { hora = value; }
        }

        private String data;

        public String Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
