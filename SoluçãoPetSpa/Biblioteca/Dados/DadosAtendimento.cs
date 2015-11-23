using Biblioteca.ClassesBasicas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Biblioteca.Dados
{
    public class DadosAtendimento : Conexao
    {
        #region selecionando os registros da tabela
        public List<Atendimento> SelecionarAtendimento()
        {
            List<Atendimento> retorno = new List<Atendimento>();
            try
            {
                this.abrirConexao();
                //instrucao a ser executada
                SqlCommand cmd = new SqlCommand("SELECT CodigoAtendimento, Descricao, Status, CodigoAgenda FROM Atendimento ", sqlConn);
                //executando a instrucao e colocando o resultado em um leitor
                SqlDataReader DbReader = cmd.ExecuteReader();
                //lendo o resultado da consulta
                while (DbReader.Read())
                {
                    Atendimento A = new Atendimento();
                    //acessando os valores das colunas do resultado
                    A.CodigoAtendimento = DbReader.GetInt32(DbReader.GetOrdinal("CodigoAtendimento"));
                    A.Descricao = DbReader.GetString(DbReader.GetOrdinal("Descricao"));
                    A.Status = DbReader.GetString(DbReader.GetOrdinal("Status"));
                    A.Agenda.CodigoAgenda = DbReader.GetInt32(DbReader.GetOrdinal("CodigoAgenda"));
                    retorno.Add(A);
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
        public void Inserir(Atendimento A)
        {

            try
            {
                this.AbrirConexao();
                string sql = "INSERT INTO Atendimento (CodigoAtendimento, Descricao, Status, CodigoAgenda) values('" + A.CodigoAtendimento + "','" + A.Descricao + "','" + A.Status + "'," + A.Agenda.CodigoAgenda + ")";
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
        public void Atualizar(Atendimento A)
        {

            try
            {
                this.AbrirConexao();
                string sql = "UPDATE Atendimento SET Descricao = '" + A.Descricao + "', Status = '" + A.Status + "', CodigoAgenda = '" + A.Agenda.CodigoAgenda + "'  WHERE CodigoAtendimento = '" + A.CodigoAtendimento;
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
        public void Delete(Atendimento A)
        {

            try
            {
                this.AbrirConexao();
                string sql = "DELETE FROM Atendimento WHERE CodigoAtendimento = '" + A.CodigoAtendimento;
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
