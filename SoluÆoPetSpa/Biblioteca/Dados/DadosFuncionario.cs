using Biblioteca.ClassesBasicas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Biblioteca.Dados
{
    public class DadosFuncionario : Conexao
    {
        #region selecionando os registros da tabela
        public List<Funcionario> SelecionarFuncionario()
        {
            List<Funcionario> retorno = new List<Funcionario>();
           try
            {
                this.abrirConexao();
                //instrucao a ser executada
                SqlCommand cmd = new SqlCommand("SELECT MatriculaDoFuncionario, NomeDoFuncionario, Funcao FROM Funcionario ", sqlConn);
                //executando a instrucao e colocando o resultado em um leitor
                SqlDataReader DbReader = cmd.ExecuteReader();
                //lendo o resultado da consulta
                while (DbReader.Read())
                {
                    Funcionario F = new Funcionario();
                    //acessando os valores das colunas do resultado
                    F.Matricula = DbReader.GetInt32(DbReader.GetOrdinal("MatriculaDoFuncionario"));
                    F.Nome = DbReader.GetString(DbReader.GetOrdinal("NomeDoFuncionario"));
                    F.Funcao = DbReader.GetString(DbReader.GetOrdinal("Funcao"));
                    retorno.Add(F);
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
        public void Inserir(Funcionario F)
        {

            try
            {
                this.AbrirConexao();
                string sql = "INSERT INTO Funcionario (Funcao, NomeDoFuncionario) values('" + F.Funcao + "','" + F.Nome + "')";
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
        public void Atualizar(Funcionario F)
        {

            try
            {
                this.AbrirConexao();
                string sql = "UPDATE Funcionario SET Funcao = '" + F.Funcao + "', NomeDoFuncionario = '" + F.Nome + "' WHERE MatriculaDoFuncionario =" + F.Matricula;
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
        public void Delete (Funcionario F)
        {

            try
            {
                this.AbrirConexao();
                string sql = "DELETE FROM Funcionario WHERE MatriculaDoFuncionario =" + F.Matricula;
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
