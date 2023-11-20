using System;
using System.Collections.Generic; // Adicionando o uso de List<T>
using System.Globalization; // permite o acesso às classes e funcionalidades necessárias para manipulação de datas e culturas.

public class Tarefa
{
    private string? titulo;
    private string? descricao;
    private DateTime dataVencimento;

    public string? Titulo
    {
        get { return titulo; }
        set { titulo = value; }
    }

    public string? Descricao
    {
        get { return descricao; }
        set { descricao = value; }
    }

    public DateTime DataVencimento
    {
        get { return dataVencimento; }
        set { dataVencimento = value; }
    }

}
public class Program
{
    //método para cadastrar uma tarefa
    public static void CadastraTarefa(List<Tarefa> tarefas)
    {

        Tarefa tarefa = new Tarefa();

        Console.WriteLine($"Insira o titulo da tarefa: ");
        tarefa.Titulo = Console.ReadLine();

        Console.WriteLine($"Insira a descrição: ");
        tarefa.Descricao = Console.ReadLine();

        Console.WriteLine($"Insira a data de vencimento (DD/MM/AAAA): ");
        string dataInput = Console.ReadLine();

        DateTime dataVencimento;
        if (DateTime.TryParseExact(dataInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataVencimento))
        {
            if (dataVencimento >= DateTime.Today)
            {
                tarefa.DataVencimento = dataVencimento;
                tarefas.Add(tarefa); // Adicionando a tarefa à lista
                Console.WriteLine($"A data de vencimento da tarefa é: {dataVencimento.ToShortDateString()}");
                Console.WriteLine("Tarefa cadastrada com sucesso!\n");
            }
            else
            {
                Console.WriteLine("Data inválida! A data de vencimento deve ser igual ou posterior à data atual.\n");
            }
        }
        else
        {
            Console.WriteLine("Data inválida! Por favor, insira a data no formato DD/MM/AAAA.\n");
        }
    }
    public static void ListarTarefas(List<Tarefa> tarefas)
    {
        int qtdTarefas = tarefas.Count;

        if (qtdTarefas == 0)
    {
        Console.WriteLine("Não há tarefas criadas. \n");
        return;
    }

        Tarefa first = tarefas[0];
        Tarefa last = tarefas[tarefas.Count-1];

            System.Console.WriteLine("TAREFAS ADICIONADAS (PENDENTES): \n");
            System.Console.WriteLine($"Quantidade de tarefas: {qtdTarefas}\n");
            System.Console.WriteLine($"Tarefa mais antiga: \nTitulo: {first.Titulo} \nDescrição: {first.Descricao} \nData de vencimento: {first.DataVencimento}");
            System.Console.WriteLine($"Tarefa mais recente: \nTitulo: {last.Titulo} \nDescrição: {last.Descricao} \nData de vencimento: {last.DataVencimento}");

        foreach (var item in tarefas)
        {
            System.Console.WriteLine("Titulo:" + item.Titulo);
            System.Console.WriteLine("Descrição:" + item.Descricao);
            System.Console.WriteLine("Data de vencimento:" + item.DataVencimento);
            System.Console.WriteLine("------------------------\n");
        }
    }
    public static void ListarTarefasConcluidas(List<Tarefa> tarefasConcluidas){

        int qtdTarefasFeitas = tarefasConcluidas.Count;

        if (qtdTarefasFeitas == 0)
    {
        Console.WriteLine("Não há tarefas concluídas.\n");
        return;
    }

        Tarefa first = tarefasConcluidas[0];
        Tarefa last = tarefasConcluidas[tarefasConcluidas.Count-1];
        
        System.Console.WriteLine("TAREFAS CONCLUIDAS: \n");
        System.Console.WriteLine($"Quantidade de tarefas feitas: {qtdTarefasFeitas}\n");
        System.Console.WriteLine($"Tarefa mais antiga: \n {first.Titulo} [x] \n {first.Descricao} \n {first.DataVencimento}");
        System.Console.WriteLine($"Tarefa mais recente: \n {last.Titulo} \n {last.Descricao} \n {last.DataVencimento}");
        
           foreach (var item in tarefasConcluidas)
        {
            System.Console.WriteLine("Titulo:" + item.Titulo + " [x]");
            System.Console.WriteLine("Descrição:" + item.Descricao);
            System.Console.WriteLine("Data de vencimento:" + item.DataVencimento);
            System.Console.WriteLine("------------------------\n");

        }
    }

    public static int BuscarTarefas(List<Tarefa> tarefas)
    {
        System.Console.WriteLine("Lista de tarefas:");
        ListarTarefas(tarefas);
        System.Console.WriteLine("\n");

        Console.WriteLine($"Insira o titulo da tarefa que deseja buscar: ");
        string nomeDaTarefa = Console.ReadLine();


        Tarefa tarefaEncontrada = tarefas.Find(tarefas => tarefas.Titulo == nomeDaTarefa);

        if (tarefaEncontrada != null)
        {
            System.Console.WriteLine($"Tarefa encontrada - Titulo: {tarefaEncontrada.Titulo}");
            System.Console.WriteLine($"Descrição: {tarefaEncontrada.Descricao}");
            System.Console.WriteLine($"Data de vencimento: {tarefaEncontrada.DataVencimento}");

            int posicao = tarefas.IndexOf(tarefaEncontrada);

            return posicao;

        }
        else
        {
            System.Console.WriteLine("Tarefa não encontrada na lista.");
            return -1;
        }
    }

    public static void ExcluirTarefa(List<Tarefa> tarefas){

        int indice  =  BuscarTarefas(tarefas);
            // Verifica se o índice está dentro dos limites da lista antes de remover
            if (indice >= 0 && indice < tarefas.Count)
            {
            tarefas.RemoveAt(indice);
            System.Console.WriteLine("Tarefa removida com sucesso!\n");
            } else {
            System.Console.WriteLine("Erro ao remover: Tarefa não encontrada.\n");
            return;
            }
    }
    public static void ConcluirTarefa(List<Tarefa> tarefas, List<Tarefa> tarefasConcluidas){

        int indice = BuscarTarefas(tarefas);

         if (indice >= 0 && indice < tarefas.Count){
           Tarefa tarefaConcluida = tarefas[indice];

           tarefasConcluidas.Add(tarefaConcluida);
           tarefas.RemoveAt(indice);
           System.Console.WriteLine("Tarefa concluida, parabéns!\n");
    }
    }
    public static void Main(string[] args)
    {
        //Gerando uma lista que contém tarefas inseridas pelo usuário
        List<Tarefa> tarefasConcluidas = new List<Tarefa>();
        List<Tarefa> tarefas = new List<Tarefa>();

        int opcao;
        do
        {
            Console.WriteLine("---------- TO-DO LIST ----------");
            Console.WriteLine("      O que deseja fazer?       ");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("[1] - Criar uma nova tarefa");
            Console.WriteLine("[2] - Listar tarefas");
            Console.WriteLine("[3] - Excluir tarefa");
            Console.WriteLine("[4] - Marcar tarefa como concluída");
            Console.WriteLine("[0] - Sair.");
            Console.WriteLine("\n");
            Console.WriteLine("Escolha uma opção: ");
            string opcaoStr = Console.ReadLine();

            if (int.TryParse(opcaoStr, out opcao) && opcao >= 0 && opcao < 5)
            {

                switch (opcao)
                {
                    case 1:
                        CadastraTarefa(tarefas);
                        break;

                    case 2:
                        ListarTarefas(tarefas);
                        ListarTarefasConcluidas(tarefasConcluidas);
                        break;

                    case 3:
                        ExcluirTarefa(tarefas);
                        break;

                    case 4:
                        ConcluirTarefa(tarefas, tarefasConcluidas);
                        break;

                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Você digitou uma opção inválida. \n");
            }

        } while (opcao != 0);
    }
}
