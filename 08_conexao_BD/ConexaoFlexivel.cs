using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace _08_conexao_BD
{
    internal class ConexaoFlexivel
    {
        string host = "Localhost", banco = "08_listas_tarefas", usuario = "root", senha = "";

        MySqlConnection conexao;

        public ConexaoFlexivel()
        {
            string dadosConexao = $"Server={host};Database={banco};Uid={usuario};PwD={senha};";
            conexao = new MySqlConnection(dadosConexao);
        }

        public void executaQuery(string query)
        {
            conexao.Open();

            MySqlCommand comando = new MySqlCommand(query, conexao);
            MySqlDataReader dados = comando.ExecuteReader();

            Console.WriteLine("---------------------------------------");
            if (dados.HasRows == false)
            {
                Console.WriteLine("Não encontramos nada :(");
            }
            while (dados.Read() == true)
            {
                Console.WriteLine($"Tarefa {dados[0]}: {dados["descricao"]}");
            }
            conexao.Close();
        }
    }
}