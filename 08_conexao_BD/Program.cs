using _08_conexao_BD;
using System.Data;

//ConexaoSimples conexaoSimples = new ConexaoSimples();

/*Conexao conexao = new Conexao();
Tarefa tarefa = new Tarefa();
tarefa = tarefa.BuscaPorId(3);

Console.WriteLine($"Tarefa {tarefa.id} - {tarefa.descricao}");
Console.WriteLine($"Criado em {tarefa.criado_em}");*/
while (true)
{
    Tarefa tarefa = new Tarefa();

    Console.WriteLine("Bem Vindo ao Sisteminha de Consultinhas");
    List<Tarefa> tarefas =  tarefa.buscaTodos();
    foreach (Tarefa t in tarefas)
    {
        Console.WriteLine($"Tarefa {t.id} - {t.descricao} | Criado em {t.criado_em}");
    }
    Console.Write("Digite 1 para consultar ID ou 2 para consultar DESCRIÇÃO: ");
    string opcao = Console.ReadLine();

    if (opcao== "3")
    {
        Console.WriteLine("\nCadastro de tarefas");
        Console.Write("Digite a descrição da tarefa: ");
        string descricao = Console.ReadLine();

        Console.WriteLine("Tá feita? 1 para SIM e 2 para NÃO");
        bool concluido = Console.ReadLine() == "1";

        Tarefa t = new Tarefa();
        t.descricao = descricao;
        t.concluido = concluido;

        tarefa.Insere(t);

        Console.WriteLine("Cadastro concluído!");
    }

   /* if (opcao == "1")
    {
        Console.WriteLine("\n=========================================");
        int idConsulta;
        Console.Write("Digite o ID do usuário que deseja consultar: ");
        idConsulta = int.Parse(Console.ReadLine());

        tarefa = tarefa.BuscaPorId(idConsulta);
        Console.WriteLine("\nResultados Encontrados: ");
        Console.WriteLine($"|Tarefa {tarefa.id} - {tarefa.descricao}|");
        Console.WriteLine($"|Criado em {tarefa.criado_em}|");

    }
    else
    {
        Console.Write("Digite a DESCRIÇÃO que deseja encontrar: ");
        string descricao = Console.ReadLine();
        tarefa = tarefa.BuscaPorDescricao(descricao);

        Console.WriteLine("\nResultados Encontrados: ");
        Console.WriteLine($"|Tarefa {tarefa.id} - {tarefa.descricao}|");
        Console.WriteLine($"|Criado em {tarefa.criado_em}|");
    }*/
}

