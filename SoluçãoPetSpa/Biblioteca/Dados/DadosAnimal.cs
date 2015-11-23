using Biblioteca.ClassesBasicas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Biblioteca.Dados
{
    public class DadosAnimal : Conexao
    {
        #region selecionando os registros da tabela
        public List<Animal> SelecionarAnimal()
        {
            List<Animal> retorno = new List<Animal>();
            try
            {
                this.abrirConexao();
                //instrucao a ser executada
                SqlCommand cmd = new SqlCommand("SELECT CodigoAnimal, NomeDoAnimal, Raca, Peso, Idade, Tipo, CPF FROM Animal ", sqlConn);
                //executando a instrucao e colocando o resultado em um leitor
                SqlDataReader DbReader = cmd.ExecuteReader();
                //lendo o resultado da consulta
                while (DbReader.Read())
                {
                    Animal A = new Animal();
                    //acessando os valores das colunas do resultado
                    A.CodigoAnimal = DbReader.GetInt32(DbReader.GetOrdinal("CodigoAgenda"));
                    A.Nome = DbReader.GetString(DbReader.GetOrdinal("NomeDoAnimal"));
                    A.Raca = DbReader.GetString(DbReader.GetOrdinal("Raca"));
                    A.Peso = DbReader.GetString(DbReader.GetOrdinal("Peso"));
                    A.Idade = DbReader.GetString(DbReader.GetOrdinal("Idade"));
                    A.Tipo = DbReader.GetString(DbReader.GetOrdinal("Tipo"));
                    A.Cliente.Cpf = DbReader.GetString(DbReader.GetOrdinal("CPF"));
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
        public void Inserir(Animal A)
        {

            try
            {
                this.AbrirConexao();
                string sql = "INSERT INTO Animal (NomeDoAnimal, Raca, Peso, Idade, Tipo, CPF) values('" + A.Nome + "','" + A.Raca + "','" + A.Peso + "','" + A.Idade + "','" + A.Tipo + "','" + A.Cliente.Cpf + "')";
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
        public void Atualizar(Animal A)
        {

            try
            {
                this.AbrirConexao();
                string sql = "UPDATE Animal SET NomeDoAnimal = '" + A.Nome + "', Raca = '" + A.Raca + "', Peso = '" + A.Peso + "', Idade = '" + A.Idade + "', Tipo = '" + A.Tipo + "', CPF = '" + A.Cliente.Cpf + "' WHERE CodigoAnimal =" + A.CodigoAnimal;
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
        public void Delete(Animal A)
        {

            try
            {
                this.AbrirConexao();
                string sql = "DELETE FROM Agenda WHERE CodigoAnimal =" + A.CodigoAnimal;
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
