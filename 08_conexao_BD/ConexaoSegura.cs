using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace _08_conexao_BD
{
    internal class ConexaoSegura
    {
        string host = "Localhost", banco = "08_listas_tarefas", usuario = "root", senha = "";

        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataReader dados;

        public ConexaoSegura()
        {
            if (conexao == null)
            {
                string dadosConexao = $"Server={host};Database={banco};Uid={usuario};PwD={senha};";
                conexao = new MySqlConnection(dadosConexao);
            }
        }
        public void executaQuery(string query)
        {

            try
            {
                conexao.Open();

                comando = new MySqlCommand(query, conexao);
                dados = comando.ExecuteReader();

                Console.WriteLine("---------------------------------------");
                if (!dados.HasRows)
                {
                    Console.WriteLine("Não encontramos nada :(");
                }
                while (dados.Read())
                {
                    Console.WriteLine($"Tarefa {dados[0]}: {dados["descricao"]}");
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine("BAH PIÁ DEU ERRO TCHÊ");
                Console.WriteLine(erro.Message);
                throw;
            }
            finally { conexao.Close(); }
        }
    }
}