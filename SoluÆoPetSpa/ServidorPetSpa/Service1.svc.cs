using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Biblioteca.ClassesBasicas;
using Biblioteca.Dados;

namespace ServidorPetSpa
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<Funcionario> SelecionarFuncionario()
        {
            return new DadosFuncionario().SelecionarFuncionario();
        }

        public void Inserir(Funcionario F)
        {
            new DadosFuncionario().Inserir(F);
        }

        public void Atualizar(Funcionario F)
        {
            new DadosFuncionario().Atualizar(F);
        }

        public void Delete(Funcionario F)
        {
            new DadosFuncionario().Delete(F);
        }

    }
}
