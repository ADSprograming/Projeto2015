using Biblioteca.ClassesBasicas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Biblioteca.Dados
{
    public class DadosCliente : Conexao
    {
        #region selecionando os registros da tabela
        public List<Cliente> SelecionarCliente()
        {
            List<Cliente> retorno = new List<Cliente>();
            try
            {
                this.abrirConexao();
                //instrucao a ser executada
                SqlCommand cmd = new SqlCommand("SELECT CPF, Nome, Telefone, CodigoEndereco FROM Cliente ", sqlConn);
                //executando a instrucao e colocando o resultado em um leitor
                SqlDataReader DbReader = cmd.ExecuteReader();
                //lendo o resultado da consulta
                while (DbReader.Read())
                {
                    Cliente C = new Cliente();
                    //acessando os valores das colunas do resultado
                    C.Cpf = DbReader.GetString(DbReader.GetOrdinal("CPF"));
                    C.Nome = DbReader.GetString(DbReader.GetOrdinal("Nome"));
                    C.Telefone = DbReader.GetString(DbReader.GetOrdinal("Telefone"));
                    C.Endereco.CodigoEndereco = DbReader.GetInt32(DbReader.GetOrdinal("CodigoEndereco"));
                    retorno.Add(C);
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
        public void Inserir(Cliente C)
        {

            try
            {
                this.AbrirConexao();
                string sql = "INSERT INTO Cliente (CPF, Nome, Telefone, CodigoEndereco) values('" + C.Cpf + "','" + C.Nome + "','" + C.Telefone + "'," + C.Endereco.CodigoEndereco + ")";
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
        public void Atualizar(Cliente C)
        {

            try
            {
                this.AbrirConexao();
                string sql = "UPDATE Cliente SET Nome = '" + C.Nome + "', Telefone = '" + C.Telefone + "', CodigoEndereco = '" + C.Endereco.CodigoEndereco + "'  WHERE CPF = '" + C.Cpf;
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
        public void Delete(Cliente C)
        {

            try
            {
                this.AbrirConexao();
                string sql = "DELETE FROM Cliente AS C, Endereco AS E WHERE CPF =" + C.Cpf +" AND C.CodigoEndereco = E.CodigoEndereco";
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
