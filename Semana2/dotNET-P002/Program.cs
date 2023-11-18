using System;

//   Usuario novoUsuario = new Usuario { titulo = titulo, DataRegistro = dataRegistro };
//   listaUsuarios.Add(novoUsuario);
public class Tarefa {
    private string titulo;
    private string descricao;
    private DateTime data;

    public string Titulo {
        get { return titulo; }
        set { titulo = value; }
    }

    public string Descricao {
        get { return descricao; }
        set { descricao = value; }
    }

    public DateTime Data {
        get { return data; }
        set { data = value; }
    }

}

public class Program {
    public static void Main(string[] args) {
        int opcao;

    //  Gerando uma lista que contém tarefas inseridas pelo usuário
        List<Tarefa> tarefas = new List<Tarefa>();

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

            } else {
                Console.WriteLine("Você digitou uma opção inválida. \n");
            }

        } while (opcao != 0);
    }
}
