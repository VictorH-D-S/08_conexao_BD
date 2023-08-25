using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace _08_conexao_BD
{
    internal class ConexaoSimples
    {
        string host = "Localhost", banco = "08_listas_tarefas", usuario = "root", senha = "";

        public ConexaoSimples()
        {
            string dadosConexao = $"Server={host};Database={banco};Uid={usuario};PwD={senha};", query = "select * from tarefas;";
            MySqlConnection conexao = new MySqlConnection(dadosConexao);

            conexao.Open();

            MySqlCommand comando = new MySqlCommand(query, conexao);
            MySqlDataReader dados = comando.ExecuteReader();

            while (dados.Read() == true)
            {
                Console.WriteLine($"Descrição da tarefa: {dados["descricao"]}");
            }

            conexao.Close();
        }
    }
}