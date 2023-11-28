
public class Program
{
    //Criando uma excessão personalizada
    public class ProdutoNaoEncontradoException : Exception
    {
        public ProdutoNaoEncontradoException() : base("Produto não encontrado na lista.")
        {
        }

        public ProdutoNaoEncontradoException(string message) : base(message)
        {
        }

        public ProdutoNaoEncontradoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public static void CadastraProduto(List<(string codigo, string? nome, int quantidadeEstoque, double precoUnitario)> produtos)
    {

        bool inputValido = false;

        while (!inputValido)
        {

            Console.Write("Informe o código do produto: ");
            string codigoProduto = Console.ReadLine();

            if (!string.IsNullOrEmpty(codigoProduto))
            {

                Console.Write("Informe o nome do produto: ");
                string? nomeProduto = Console.ReadLine();

                int quantidadeEstoque;
                double precoUnitario;

                Console.Write("Informe a quantidade em estoque: ");
                if (!int.TryParse(Console.ReadLine(), out quantidadeEstoque) || quantidadeEstoque < 0)
                {
                    Console.WriteLine("Quantidade em estoque inválida. Por favor, insira um valor numérico inteiro maior ou igual a zero.");
                    return;
                }

                Console.Write("Preço Unitário: ");
                if (!double.TryParse(Console.ReadLine(), out precoUnitario) || precoUnitario < 0)
                {
                    Console.WriteLine("Preço unitário inválido. Por favor, insira um valor numérico positivo.");
                    return;
                }

                var produto = (codigoProduto, nomeProduto, quantidadeEstoque, precoUnitario);

                produtos.Add(produto);

                inputValido = true;
                Console.WriteLine("\n");
                Console.WriteLine("Produto cadastrado com sucesso! \n");

                foreach (var item in produtos)
                {
                    Console.WriteLine($"Código: {item.codigo}, Nome: {item.nome}, Quantidade: {item.quantidadeEstoque}, Preço: R${item.precoUnitario}\n");
                }

            }
            else
            {
                System.Console.WriteLine("Nenhum dos dados pode ser vazio. Preencha os campos corretamente. \n");
            }

        }
    }
    public static void LocalizaProduto(List<(string codigo, string? nome, int quantidadeEstoque, double precoUnitario)> produtos)
    {

        bool inputValido = false;
        while (!inputValido)
        {
            System.Console.WriteLine("Insira o código do produto que você deseja localizar: ");
            string produtoProcurado = Console.ReadLine();

            if (!string.IsNullOrEmpty(produtoProcurado))
            {

                try
                {
                    //Expressão Lambda que retorna o primeiro item encontrado que seja igual ao parâmetro desejado ou retorna default caso não encontre.
                    var produto = produtos.FirstOrDefault(p => p.codigo == produtoProcurado);
                    if (produto != default)
                    {
                        inputValido = true;
                        int indice = produtos.IndexOf(produto);
                        System.Console.WriteLine("\n");
                        System.Console.WriteLine($"Produto encontrado: \n Código: {produto.codigo} \n Nome: {produto.nome} \n Quantidade em estoque: {produto.quantidadeEstoque} \n Preço unitário: {produto.precoUnitario} \n");

                        int opcao;
                        do
                        {
                            Console.WriteLine("------------------ Alteração de estoque --------------------");
                            Console.WriteLine("        O que deseja fazer com o produto encontrado?        ");
                            Console.WriteLine("------------------------------------------------------------");
                            Console.WriteLine("[1] - Adicionar estoque do produto");
                            Console.WriteLine("[2] - Diminuir estoque do produto");
                            Console.WriteLine("[0] - Não fazer nada (Sair)");
                            Console.WriteLine("\n");
                            Console.WriteLine("Escolha uma opção: ");
                            string opcaoStr = Console.ReadLine();

                            if (int.TryParse(opcaoStr, out opcao) && opcao >= 0 && opcao < 3)
                            {
                                switch (opcao)
                                {
                                    case 1:
                                        AdicionaProduto(produtos, indice, produto);
                                        break;

                                    case 2:
                                        RemoveProduto(produtos, indice, produto);
                                        break;

                                    case 0:
                                        System.Console.WriteLine("\n");
                                        System.Console.WriteLine("Voltando para o menu principal...");
                                        System.Console.WriteLine("\n");

                                        break;

                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Você digitou uma opção inválida. \n");
                                {
                                    throw new ProdutoNaoEncontradoException(); // Lança a exceção quando o produto não é encontrado
                                }
                            }

                        } while (opcao != 0);
                    }
                    else
                    {
                        System.Console.WriteLine("O campo não pode estar vazio.");
                    }
                }
                catch (ProdutoNaoEncontradoException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }
    }
    public static void AdicionaProduto(List<(string codigo, string? nome, int quantidadeEstoque, double precoUnitario)> produtos, int indice, (string codigo, string? nome, int quantidadeEstoque, double precoUnitario) produto)
    {
        int qtd;
        System.Console.WriteLine("Insira a quantidade de estoque que deseja adicionar: ");

        if (!int.TryParse(Console.ReadLine(), out qtd) || qtd < 0)
        {
            Console.WriteLine("Quantidade em estoque inválida. Por favor, insira um valor numérico inteiro maior ou igual a zero.");
            return;
        }
        else
        {
            var produtoAtualizado = (produto.codigo, produto.nome, produto.quantidadeEstoque + qtd, produto.precoUnitario);
            produtos.RemoveAt(indice);
            produtos.Insert(indice, produtoAtualizado);
            System.Console.WriteLine("\n");
            System.Console.WriteLine("Produto adicionado com sucesso!");
            System.Console.WriteLine("\n");

        }
    }
    public static void RemoveProduto(List<(string codigo, string? nome, int quantidadeEstoque, double precoUnitario)> produtos, int indice, (string codigo, string? nome, int quantidadeEstoque, double precoUnitario) produto)
    {
        int qtd;
        System.Console.WriteLine("Insira a quantidade deseja retirar do estoque: ");

        if (!int.TryParse(Console.ReadLine(), out qtd) || qtd > produto.quantidadeEstoque || qtd < 0)
        {
            Console.WriteLine("Entrada de dados inválida ou a quantidade que deseja retirar é maior do que a quantidade do estoque.");
            return;
        }
        else
        {
            var produtoAtualizado = (produto.codigo, produto.nome, produto.quantidadeEstoque - qtd, produto.precoUnitario);
            produtos.RemoveAt(indice);
            produtos.Insert(indice, produtoAtualizado);
        }
    }
    public static void GeraRelatorios(List<(string codigo, string? nome, int quantidadeEstoque, double precoUnitario)> produtos)
    {

        //Lista de produtos com quantidade em estoque abaixo de um determinado limite informado pelo usuário.
        //List<(string codigo, string? nome, int quantidadeEstoque, double precoUnitario)> listaQuantidade = new List<(string codigo, string? nome, int quantidadeEstoque, double precoUnitario)>();

        int opcao;
        do
        {
            Console.WriteLine("------------------------ Relatórios --------------------------");
            Console.WriteLine("               Qual relatório deseja receber?                 ");
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("[1] - Produtos com quantidade abaixo do limite determinado");
            Console.WriteLine("[2] - Produtos entre um valor mínimo e máximo determinado");
            Console.WriteLine("[3] - Valor total do estoque & valor total de cada produto");
            Console.WriteLine("[0] - Sair.");
            Console.WriteLine("\n");
            Console.WriteLine("Escolha uma opção: ");
            string opcaoStr = Console.ReadLine();

            if (int.TryParse(opcaoStr, out opcao) && opcao >= 0 && opcao < 4)
            {
                switch (opcao)
                {
                    case 1:

                        int qtd;
                        Console.WriteLine("Informe uma quantidade para receber uma lista de produtos que tenha o estoque abaixo dessa quantidade: ");
                        if (!int.TryParse(Console.ReadLine(), out qtd) || qtd < 0)
                        {
                            Console.WriteLine("Quantidade em estoque inválida. Por favor, insira um valor numérico inteiro maior ou igual a zero.");
                            return;
                        }
                        else
                        {

                            var listaQuantidade = produtos.Where(x => x.quantidadeEstoque < qtd).ToList();

                            if (listaQuantidade.Any())
                            {
                                Console.WriteLine("Produtos com estoque menor que o limite informado:");
                                foreach (var produto in listaQuantidade)
                                {
                                    System.Console.WriteLine("-----------------------");
                                    Console.WriteLine($"Código: {produto.codigo} \n Nome: {produto.nome} \n Estoque: {produto.quantidadeEstoque} \n Preço: {produto.precoUnitario} \n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Não foram encontrados produtos com estoque menor que o limite informado. \n");
                            }

                        }
                        break;

                    case 2:

                        double min;
                        double max;

                        Console.WriteLine("Informe um valor mínimo e um valor máximo para receber uma lista de produtos dentro dessa faixa de preço: \n");

                        Console.WriteLine("Informe um valor mínimo: ");
                        if (!double.TryParse(Console.ReadLine(), out min) || min < 0)
                        {
                            Console.WriteLine("Preço inválido. Por favor, insira um preço maior que zero. \n");
                            return;
                        }

                        Console.WriteLine("Informe um valor máximo: ");
                         if (!double.TryParse(Console.ReadLine(), out max) || max < 0)
                        {
                            Console.WriteLine("Preço inválido. Por favor, insira um preço maior que zero. \n");
                            return;
                        }

                        else
                        {
                            var listaPreco = produtos.Where(x => x.precoUnitario > min && x.precoUnitario < max ).ToList();

                            if (listaPreco.Any())
                            {
                                Console.WriteLine($"Produtos com valores entre {min} e {max}:");
                                foreach (var produto in listaPreco)
                                {
                                    System.Console.WriteLine("-----------------------");
                                    Console.WriteLine($"Código: {produto.codigo} \n Nome: {produto.nome} \n Estoque: {produto.quantidadeEstoque} \n Preço: {produto.precoUnitario} \n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Não foram encontrados produtos dentro da faixa de valor informada. \n");
                            }

                        }

                        break;

                    case 3:

                    double totalEstoque = 0;

                    // Aplicando a função lambda a cada elemento da lista usando o método Select
                    List<double> totalProduto = produtos.Select(produto => produto.quantidadeEstoque * produto.precoUnitario).ToList();

                    //Imprimindo os produtos da lista + seu valor total
                    Console.WriteLine("Valor total de cada produto de acordo com seu estoque: ");
                    for (int i = 0; i < produtos.Count; i++)
                    {
                        var produto = produtos[i];
                        double resultado = totalProduto[i];
                        totalEstoque += resultado;
                        
                        System.Console.WriteLine("-------------------------");
                        System.Console.WriteLine($"Código: {produto.codigo}");
                        System.Console.WriteLine($"Produto: {produto.nome}");
                        System.Console.WriteLine(resultado);
                    
                    }

                    string totalEstoqueFormatado = totalEstoque.ToString("0.00");

                    Console.WriteLine($"Valor Total do estoque de produtos: R${totalEstoqueFormatado}");
                    
                        break;

                    case 0:
                        System.Console.WriteLine("Retornando...\n");
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

    public static void Main(string[] args)
    {

        //Lista principal
        List<(string codigo, string? nome, int quantidadeEstoque, double precoUnitario)> produtos = new List<(string codigo, string? nome, int quantidadeEstoque, double precoUnitario)>();

        int opcao;
        do
        {
            Console.WriteLine("---------- Controle de Estoque ----------");
            Console.WriteLine("           O que deseja fazer?           ");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("[1] - Cadastrar produto");
            Console.WriteLine("[2] - Alterar estoque");
            Console.WriteLine("[3] - Gerar relatórios");
            Console.WriteLine("[0] - Sair.");
            Console.WriteLine("\n");
            Console.WriteLine("Escolha uma opção: ");
            string opcaoStr = Console.ReadLine();

            if (int.TryParse(opcaoStr, out opcao) && opcao >= 0 && opcao < 4)
            {

                switch (opcao)
                {
                    case 1:
                        CadastraProduto(produtos);
                        break;

                    case 2:
                        LocalizaProduto(produtos);
                        break;

                    case 3:
                        GeraRelatorios(produtos);
                        break;

                    case 0:
                        System.Console.WriteLine("Programa finalizado.");
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