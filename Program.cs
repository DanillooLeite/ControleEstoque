using ControleEstoque;
using System;

class Program
{
    static void Main()
    {
        ProdutoRepository produtoRepository = new ProdutoRepository();

        while (true)
        {
            MostrarMenu();
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarProduto(produtoRepository);
                    break;

                case "2":
                    ListarProdutos(produtoRepository);
                    break;

                case "3":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("-------------------------");
        Console.WriteLine("1. Adicionar Produto");
        Console.WriteLine("2. Listar Produtos");
        Console.WriteLine("3. Sair");
        Console.Write("Escolha uma opção: ");
        Console.WriteLine();
        Console.WriteLine("-------------------------");
    }

    static void AdicionarProduto(ProdutoRepository produtoRepository)
    {
        Console.WriteLine("-------------------------");
        Console.Write("Nome do Produto: ");
        string nome = Console.ReadLine();

        Console.Write("Quantidade: ");
        int quantidade = int.Parse(Console.ReadLine());

        Console.Write("Preço: ");
        decimal preco = decimal.Parse(Console.ReadLine());

        Console.WriteLine("-------------------------");

        Produto novoProduto = new Produto
        {
            Nome = nome,
            Quantidade = quantidade,
            Preco = preco*quantidade
        };

        produtoRepository.AdicionarProduto(novoProduto);

        Console.WriteLine("Produto adicionado com sucesso!");
    }

    static void ListarProdutos(ProdutoRepository produtoRepository)
    {
        var produtos = produtoRepository.ObterTodosProdutos();

        Console.WriteLine("-------------------------");

        foreach (var produto in produtos)
        {
            Console.WriteLine($"{produto.ID} - {produto.Nome} - {produto.Quantidade} - {produto.Preco:C}");
        }
    }
}
