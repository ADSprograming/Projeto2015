using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Biblioteca.Dados
{
    public class Conexao
    {
        #region connection string
        //http://www.connectionstrings.com/
        #region variáveis
        public SqlConnection sqlConn;
        #endregion
        //string de conexão obtida para o sql sever
        string connectionStringSqlServer = "Data Source=MEGAKINGBR\\SQLEXPRESS;Initial Catalog=PetSpa;Trusted_Connection=Yes;";

        public void abrirConexao()
        {
            //iniciando uma conexão com o sql server, utilizando os parâmetros da string de conexão
            this.sqlConn = new SqlConnection(connectionStringSqlServer);
            //abrindo a conexão com a base de dados
            this.sqlConn.Open();
        }


        public void fecharConexao()
        {
            //fechando a conexao com a base de dados
            sqlConn.Close();
            //liberando a conexao da memoria
            sqlConn.Dispose();
        }

        #endregion
    }
}
