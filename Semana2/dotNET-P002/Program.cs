using System;
using System.Collections.Generic; // Adicionando o uso de List<T>
using System.Globalization; // permite o acesso às classes e funcionalidades necessárias para manipulação de datas e culturas.

public class Tarefa {
    private string titulo;
    private string descricao;
    private DateTime dataVencimento;

    public string Titulo {
        get { return titulo; }
        set { titulo = value; }
    }

    public string Descricao {
        get { return descricao; }
        set { descricao = value; }
    }

    public DateTime DataVencimento {
        get { return dataVencimento; }
        set { dataVencimento = value; }
    }

  
}
public class Program {

      //método para cadastrar uma tarefa
    public static void CadastraTarefa(List<Tarefa> tarefas) {

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
        Console.WriteLine("Tarefa cadastrada com sucesso!");
    }
    else
    {
        Console.WriteLine("Data inválida! A data de vencimento deve ser igual ou posterior à data atual.");
    }
}
else
{
    Console.WriteLine("Data inválida! Por favor, insira a data no formato DD/MM/AAAA.");
}

   

    }

    public static void ListarTarefas(List<Tarefa> tarefas){

        foreach(var item in tarefas)
        {
            System.Console.WriteLine("Titulo:" + item.Titulo);
            System.Console.WriteLine("Descrição:" + item.Descricao);
            System.Console.WriteLine("Data de vencimento:" + item.DataVencimento);
            System.Console.WriteLine("----------------------------//");
        }

    }
    public static void Main(string[] args) {
       
       //Gerando uma lista que contém tarefas inseridas pelo usuário
        List<Tarefa> tarefas = new List<Tarefa>();

        int opcao;
        do {
            Console.WriteLine("---------- TO-DO LIST ----------");
            Console.WriteLine("      O que deseja fazer?       ");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("[1] - Criar uma nova tarefa");
            Console.WriteLine("[2] - Listar tarefas");
            Console.WriteLine("[3] - Excluir tarefa");
            Console.WriteLine("[4] - Buscar tarefa");
            Console.WriteLine("[0] - Sair.");
            Console.WriteLine("\n");
            Console.WriteLine("Escolha uma opção: ");
            string opcaoStr = Console.ReadLine(); 

            if (int.TryParse(opcaoStr, out opcao) && opcao >= 0 && opcao < 5) {

                switch (opcao)
                {
                    case 1:
                        CadastraTarefa(tarefas);
                        break;
                    case 2:
                        ListarTarefas(tarefas);
                        break;
                    default:
                        break;
                }
                

            } else {
                Console.WriteLine("Você digitou uma opção inválida. \n");
            }

        } while (opcao != 0);
    }
}
