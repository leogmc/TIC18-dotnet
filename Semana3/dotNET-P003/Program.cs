
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
                        System.Console.WriteLine($"Produto encontrado: \n Código: {produto.codigo} \n Nome: {produto.nome} \n Quantidade em estoque: {produto.quantidadeEstoque} \n Preço unitário: {produto.precoUnitario} \n");
                    }
                    else
                    {
                    throw new ProdutoNaoEncontradoException(); // Lança a exceção quando o produto não é encontrado
                    }


                }
                catch (ProdutoNaoEncontradoException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            else
            {
                System.Console.WriteLine("O campo não pode estar vazio.");
            }
        }

    }
    public static void Main(string[] args)
    {

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

            if (int.TryParse(opcaoStr, out opcao) && opcao >= 0 && opcao < 5)
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