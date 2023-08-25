using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_conexao_BD
{
    internal class Tarefa
    {
        public int id; public string descricao; public bool concluido; public string criado_em;
        public Tarefa()
        {

        }

        public Tarefa(int id, string des, bool conc, string criado_em)
        {
            this.id = id;
            this.descricao = des;
            this.concluido = conc;
            this.criado_em = criado_em;
        }

        public Tarefa BuscaPorId(int id)
        {
            string query = $"select * from tarefas where id = {id};";
            DataTable tabela = Conexao.executaQuery(query);
            Tarefa tarefa = carregaDados(tabela.Rows[0]);
            return tarefa;
        }

        public Tarefa BuscaPorDescricao(string descricao)
        {
            string query = $"select * from tarefas where descricao like '%{descricao}%';";
            DataTable tabela = Conexao.executaQuery(query);
            Tarefa tarefa = carregaDados(tabela.Rows[0]);
            return tarefa;
        }

        public List<Tarefa> buscaTodos()
        {
            string query = "select * from tarefas;";
            DataTable tabela = Conexao.executaQuery(query);
            List<Tarefa> tarefas= new List<Tarefa>();
            foreach (DataRow linha in tabela.Rows)
            {
                Tarefa tarefa = carregaDados(linha);
                tarefas.Add(tarefa);;
            }
            return tarefas;
        }

        public void Insere (Tarefa tarefa)
        {
            int concluido = tarefa.concluido == true ? 1 : 0;
            string query = $"insert into tarefas (descricao, concluido) values ('{tarefa.descricao}', {concluido});";
            Conexao.executaQuery(query);
        }

        public Tarefa carregaDados(DataRow linha)
        {
            int id = int.Parse(linha["id"].ToString());
            string descricao = linha["descricao"].ToString();
            bool concluido = bool.Parse(linha["concluido"].ToString());
            string criado_em = linha["criado_em"].ToString();
            Tarefa tarefa = new Tarefa(id, descricao, concluido, criado_em);
            return tarefa;
        }
    }
}
