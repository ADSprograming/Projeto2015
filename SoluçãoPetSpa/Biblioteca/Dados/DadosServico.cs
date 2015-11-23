using Biblioteca.ClassesBasicas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Biblioteca.Dados
{
    public class DadosServico : Conexao
    {
        #region selecionando os registros da tabela
        public List<Servico> SelecionarServico()
        {
            List<Servico> retorno = new List<Servico>();
            try
            {
                this.abrirConexao();
                //instrucao a ser executada
                SqlCommand cmd = new SqlCommand("SELECT CodigoServico, Nome, Descricao FROM Servico ", sqlConn);
                //executando a instrucao e colocando o resultado em um leitor
                SqlDataReader DbReader = cmd.ExecuteReader();
                //lendo o resultado da consulta
                while (DbReader.Read())
                {
                    Servico S = new Servico();
                    //acessando os valores das colunas do resultado
                    S.CodigoServico = DbReader.GetInt32(DbReader.GetOrdinal("CodigoServico"));
                    S.Nome = DbReader.GetString(DbReader.GetOrdinal("Nome"));
                    S.Descricao = DbReader.GetString(DbReader.GetOrdinal("Descricao"));
                    retorno.Add(S);
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
        public void Inserir(Servico S)
        {

            try
            {
                this.AbrirConexao();
                string sql = "INSERT INTO Servico (CodigoServico, Nome, Descricao) values('" + S.CodigoServico + "','" + S.Nome + "','" + S.Descricao + "')";
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
        public void Atualizar(Servico S)
        {

            try
            {
                this.AbrirConexao();
                string sql = "UPDATE Servico SET Nome = '" + S.Nome + "', Descricao = '" + S.Descricao + "' WHERE CodigoServico =" + S.CodigoServico;
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
        public void Delete(Servico S)
        {

            try
            {
                this.AbrirConexao();
                string sql = "DELETE FROM Servico WHERE CodigoServico =" + S.CodigoServico;
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