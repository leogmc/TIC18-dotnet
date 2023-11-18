using System;
using System.Collections.Generic; // Adicionando o uso de List<T>

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

      // método para cadastrar uma tarefa
    public static void CadastraTarefa(List<Tarefa> tarefas) {

        Tarefa tarefa = new Tarefa();

        Console.WriteLine($"Insira o titulo da tarefa: ");
        tarefa.Titulo = Console.ReadLine();
        
        Console.WriteLine($"Insira a descrição: ");
        tarefa.Descricao = Console.ReadLine();
        
        // Solicitando a data de vencimento ao usuário
        Console.WriteLine($"Insira a data de vencimento: ");

        Console.Write("Dia: ");
        int dia = int.Parse(Console.ReadLine());

        Console.Write("Mês: ");
        int mes = int.Parse(Console.ReadLine());

        Console.Write("Ano: ");
        int ano = int.Parse(Console.ReadLine());


        // Verificando se a data é válida usando o método TryParse
        DateTime dataVencimento;
        if (DateTime.TryParse($"{dia}-{mes}-{ano}", out dataVencimento))
        {
            // Exibindo a data de vencimento
            Console.WriteLine($"A data de vencimento do produto é: {dataVencimento.ToShortDateString()}");
        }
        else
        {
            Console.WriteLine("Data inválida! Por favor, insira uma data válida.");
        }

            System.Console.WriteLine("Tarefa cadastrada com sucesso!");

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
                    default:
                        break;
                }
                

            } else {
                Console.WriteLine("Você digitou uma opção inválida. \n");
            }

        } while (opcao != 0);
    }
}
