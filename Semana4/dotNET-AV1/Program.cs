    public class Pessoa{

        public string Nome { get; set;}
        public DateTime DataDeNascimento { get; set;}
        public string CPF { get; set;}

        public int Idade => DateTime.Today.Year - DataDeNascimento.Year - (DateTime.Today.DayOfYear < DataDeNascimento.DayOfYear ? 1 : 0);

    }

    public class Treinador : Pessoa{

        public string CREF { get; set;}

    }

    public class Cliente : Pessoa{

        public double altura { get; set;}
        public double peso { get; set;}

    }

    public class Academia{

     // Listas
    List<Treinador> treinadores;
    List<Cliente> clientes;

    // Construtor da classe Academia
    public Academia()
    {
        treinadores = new List<Treinador>(); // Inicializa a lista de treinadores
        clientes = new List<Cliente>(); // Inicializa a lista de clientes
    }

    // Métodos:
    public void CadastraPessoa(List<Pessoa> pessoas)
    {
        Console.WriteLine("Cadastro genérico de pessoa.");
        // Lógica de cadastro genérico comum a todas as pessoas
    }

    public void CadastraTreinador(Treinador treinador){
        treinadores.Add(treinador);
    }

    public void CadastraCliente(Cliente cliente)
    {
        clientes.Add(cliente);
    }

        public void RelatorioTreinadoresPorIdade(int idadeMinima, int idadeMaxima)
    {
        var treinadoresFiltrados = treinadores.Where(t => t.Idade >= idadeMinima && t.Idade <= idadeMaxima);

        Console.WriteLine($"Treinadores com idade entre {idadeMinima} e {idadeMaxima} anos:");
        foreach (var treinador in treinadoresFiltrados)
        {
            Console.WriteLine($"Nome: {treinador.Nome}, Idade: {treinador.Idade}");
        }
    }

        public void RelatorioClientesPorIdade(int idadeMinima, int idadeMaxima)
        {
            var clientesFiltrados = clientes.Where(c => c.Idade >= idadeMinima && c.Idade <= idadeMaxima);

            Console.WriteLine($"Clientes com idade entre {idadeMinima} e {idadeMaxima} anos:");
            foreach (var cliente in clientesFiltrados)
            {
                Console.WriteLine($"Nome: {cliente.Nome}, Idade: {cliente.Idade}");
            }
        }
        public static void Main(string[] args)
    {

        //Criando algumas instancias para teste

        Treinador treinador1 = new Treinador
        {
            Nome = "João Silva",
            DataDeNascimento = new DateTime(1985, 3, 15),
            CPF = "12345678900",
            CREF = "ABC123"
        };

        Treinador treinador2 = new Treinador
        {
            Nome = "Maria Oliveira",
            DataDeNascimento = new DateTime(1990, 7, 25),
            CPF = "98765432100",
            CREF = "DEF456"
        };

        Treinador treinador3 = new Treinador
        {
            Nome = "Joao Oliveira",
            DataDeNascimento = new DateTime(2000, 5, 10),
        
            CPF = "98765437436",
            CREF = "DZF112"
        };

        // Criando alguns clientes
        Cliente cliente1 = new Cliente
        {
            Nome = "Pedro Santos",
            DataDeNascimento = new DateTime(2000, 5, 10),
            CPF = "11122233344",
            altura = 1.75,
            peso = 70.5
        };

        Cliente cliente2 = new Cliente
        {
            Nome = "Ana Souza",
            DataDeNascimento = new DateTime(1995, 9, 20),
            CPF = "55566677788",
            altura = 1.60,
            peso = 55.0
        };

        Cliente cliente3 = new Cliente
        {
            Nome = "Paulo Oliveira",
            DataDeNascimento = new DateTime(2002, 3, 10),
            CPF = "55566623488",
            altura = 1.90,
            peso = 81.0
        };

        // Criando uma instância da Academia
        Academia academia = new Academia();

        // Cadastrando os treinadores e clientes na academia
        academia.CadastraTreinador(treinador1);
        academia.CadastraTreinador(treinador2);
        academia.CadastraTreinador(treinador3);
        academia.CadastraCliente(cliente1);
        academia.CadastraCliente(cliente2);
        academia.CadastraTreinador(treinador3);

        //Relatórios
        System.Console.WriteLine("Relatório 1: Treinadores com idade entre dois valores.");
        academia.RelatorioTreinadoresPorIdade(30, 40);

        
        System.Console.WriteLine("Relatório 2: Clientes com idade entre dois valores.");
        academia.RelatorioClientesPorIdade(25, 50);


    }

    }


