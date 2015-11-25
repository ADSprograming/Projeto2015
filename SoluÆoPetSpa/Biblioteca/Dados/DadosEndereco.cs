using Biblioteca.ClassesBasicas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Biblioteca.Dados
{
    public class DadosEndereco : Conexao
    {
        #region selecionando os registros da tabela
        public List<Endereco> SelecionarEndereco()
        {
            List<Endereco> retorno = new List<Endereco>();
            try
            {
                this.abrirConexao();
                //instrucao a ser executada
                SqlCommand cmd = new SqlCommand("SELECT CodigoEndereco, Logradouro, Complemento, Bairro, Estado, CEP, Numero, Cidade FROM Endereco ", sqlConn);
                //executando a instrucao e colocando o resultado em um leitor
                SqlDataReader DbReader = cmd.ExecuteReader();
                //lendo o resultado da consulta
                while (DbReader.Read())
                {
                    Endereco E = new Endereco();
                    //acessando os valores das colunas do resultado
                    E.CodigoEndereco = DbReader.GetInt32(DbReader.GetOrdinal("CodigoServico"));
                    E.Logradouro = DbReader.GetString(DbReader.GetOrdinal("Logradouro"));
                    E.Complemento = DbReader.GetString(DbReader.GetOrdinal("Complemento"));
                    E.Bairro = DbReader.GetString(DbReader.GetOrdinal("Bairro"));
                    E.Estado = DbReader.GetString(DbReader.GetOrdinal("Estado"));
                    E.Cep = DbReader.GetString(DbReader.GetOrdinal("CEP"));
                    E.Numero = DbReader.GetString(DbReader.GetOrdinal("Numero"));
                    E.Cidade = DbReader.GetString(DbReader.GetOrdinal("Cidade"));
                    retorno.Add(E);
                }
                //fechando o leitor de resultados
                DbReader.Close();
                //liberando a memoria 
                cmd.Dispose();
                //fechando a conexao
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conectar e selecionar " + ex.Message);
            }
            return retorno;
        }
        #endregion

        #region Inserindo registro na tabela
        public void Inserir(Endereco E)
        {

            try
            {
                this.AbrirConexao();
                string sql = "INSERT INTO Endereco (CodigoEndereco, Logradouro, Complemento, Bairro, Estado, CEP, Numero, Cidade) values(" + E.CodigoEndereco + ",'" + E.Logradouro + "','" + E.Complemento + "','" + E.Bairro + "','" + E.Estado + "','" + E.Cep + "','" + E.Numero + "','" + E.Cidade + "')";
                //instrucao a ser executada
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                //executando a instrucao 
                cmd.ExecuteNonQuery();
                //liberando a memoria 
                cmd.Dispose();
                //fechando a conexao
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conectar e inserir " + ex.Message);
            }
        }

        #endregion

        #region Atualizar registro na tabela
        public void Atualizar(Endereco E)
        {

            try
            {
                this.AbrirConexao();
                string sql = "UPDATE Endereco SET Logradouro = '" + E.Logradouro + "', Complemento = '" + E.Complemento + "', Bairro = '" + E.Bairro + "', Estado = '" + E.Estado + "', CEP = '" + E.Cep + "', Numero = '" + E.Numero + "', Cidade = '" + E.Cidade + "' WHERE CodigoEndereco =" + E.CodigoEndereco;
                //instrucao a ser executada
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                //executando a instrucao 
                cmd.ExecuteNonQuery();
                //liberando a memoria 
                cmd.Dispose();
                //fechando a conexao
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conectar e atualizar " + ex.Message);
            }
        }

        #endregion

        #region Delete registro na tabela
        public void Delete(Endereco E)
        {

            try
            {
                this.AbrirConexao();
                string sql = "DELETE FROM Endereco WHERE CodigoEndereco =" + E.CodigoEndereco;
                //instrucao a ser executada
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                //executando a instrucao 
                cmd.ExecuteNonQuery();
                //liberando a memoria 
                cmd.Dispose();
                //fechando a conexao
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conectar e deletar " + ex.Message);
            }
        }

        #endregion

        private void FecharConexao()
        {
            throw new NotImplementedException();
        }

        private void AbrirConexao()
        {
            throw new NotImplementedException();
        }
    }
}
