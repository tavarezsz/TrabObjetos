using System;
using System.Reflection;
using System.Xml;
using Gerenciadores;
using TrabObjetos;
using TrabObjetos.models;

namespace Menus;

public class MenuProdutos
{
    
    private IRepositorio<Produto> gerenciador;
    private IRepositorio<Fornecedor> fornecedores;

    private Pedido PedidoAtual;

    public MenuProdutos(IRepositorio<Produto> repo, IRepositorio<Fornecedor> forn)
    {
        fornecedores = forn;
        gerenciador = repo;
        gerenciador.CarregarDados(Path.Combine("dados", "produtos.json"));

    }

    public void Menu()
    {

        int op;
        do
        {
            Console.WriteLine("--------Produtos--------");
            Console.WriteLine("1 - Inserir Produto");
            Console.WriteLine("2 - Alterar Produto");
            Console.WriteLine("3 - Listar Produtos");
            Console.WriteLine("4 - Excluir Produto");
            Console.WriteLine("0 - Voltar ao menu principal");

            Console.Write("Escolha uma opção: ");

            while (!int.TryParse(Console.ReadLine(), out op))
            {
                Console.WriteLine("Entrada inválida! Digite um número:");
            }

            switch (op)
            {
                case 1:
                    InserirProduto();
                    break;
                case 2:
                    AlterarProduto();
                    break;
                case 3:
                    gerenciador.ListarItens("Lista de Produtos");
                    break;
                case 4:

                    Console.WriteLine("Id a ser excluído: ");
                    int id = int.Parse(Console.ReadLine());
                    if (!gerenciador.ExcluirItem(id))
                        Console.WriteLine("Id não encontrado");
                    else
                        Console.WriteLine("Excluido com sucesso");
                    break;
            }
        } while (op != 0);

        gerenciador.SalvarDados(Path.Combine("dados","produtos.json"));

    }

    /*
    public void CarrinhoCompras(Cliente userAtual)
    {
        //cria um novo pedido sempre que entrar no carrinho, tem que ser finalizado antes de sair
        if (gerenciador is GerenciadorListas<Produto>)
            PedidoAtual = new Pedido(new GerenciadorListas<ItemPedido>());
        else
            PedidoAtual = new Pedido(new GerenciadorListas<ItemPedido>());


        Produto produtoSelecionado;
        string continuar = "s";

        while (continuar.ToLower() == "s")
        {
            Console.WriteLine("Digite o produto que deseja: ");
            string produto = Console.ReadLine();
            List<Produto> resultados = gerenciador.Consulta(produto,false);

            foreach (var prod in resultados)
            {
                Console.WriteLine(prod.ObterDescricao());
            }
            Console.WriteLine("Digite o ID do produto que deseja: ");
            int prodId = int.Parse(Console.ReadLine());

            try
            {
                produtoSelecionado = resultados[resultados.FindIndex(p => p.Id == prodId)];
            }
            catch
            {
                Console.WriteLine("Entrada inválida");
                return;
            }

            Console.WriteLine("Quantidade");
            int quantidade = int.Parse(Console.ReadLine());

            if (!produtoSelecionado.BaixaEstoque(quantidade))//ver se tem suficiente no estoque
            {
                Console.WriteLine($"Infelizmente só possuimos {produtoSelecionado.QuantidadeEstoque} unidades desse produto em estoque");
                Console.WriteLine("Deseja usar esta quantidade?(s/n): ");
                string opcao = Console.ReadLine().ToLower();
                if (opcao == "s")
                    quantidade = produtoSelecionado.QuantidadeEstoque;
                else
                    return;

            }


            Console.WriteLine($"Seu total ficou R${produtoSelecionado.Preco * quantidade}, deseja adicionar ao ser carrinho?(s/n): ");
            string escolha = Console.ReadLine();

            if (escolha.ToLower() == "s") //so faz a alteração de estoque quando o usuario tem certeza
            {
                Console.WriteLine(quantidade);
                ItemPedido itemAtual = new ItemPedido(produtoSelecionado, quantidade);
                Console.WriteLine(itemAtual.ObterDescricao());
                PedidoAtual.AdicionarProduto(itemAtual);
                Console.WriteLine("O produto foi adicionado ao seu carinho!");
            }

            Console.WriteLine("Adicionar mais produtos(s/n): ");
            continuar = Console.ReadLine();
        }
        Console.WriteLine("Deseja finalizar este pedido?(s/n): ");
        string finalizar = Console.ReadLine();

        if (finalizar.ToLower() == "s")
        {
            PedidoAtual.Situação = "Novo";
            userAtual.AdicionarPedido(PedidoAtual);
            return;
        }

        Console.WriteLine("O pedido será excluído");
        return;


    }
    */


    private void InserirProduto()
    {
        Console.WriteLine("---------- Cadastro de Produto ----------");

        Console.WriteLine("Nome do Produto:");
        string nomeProduto = Console.ReadLine();


        Console.WriteLine("Nome do Fornecedor: ");
        string nomeFornecedor = Console.ReadLine();

        Fornecedor fornecedorProduto;

        try
        {
            fornecedorProduto = fornecedores.BuscarPorNome(nomeFornecedor);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Tente novamente");
            return;
        }

        Console.WriteLine("Quantidade em estoque:");
        int estoqueP;

        while (!int.TryParse(Console.ReadLine(), out estoqueP))
        {
            Console.WriteLine("Entrada inválida! Digite um número inteiro:");
        }



        Console.WriteLine("Preço: ");
        double preco;

        while (!double.TryParse(Console.ReadLine(), out preco))
        {
            Console.WriteLine("Entrada inválida! Digite um número:");
        }

        Produto p = new Produto(nomeProduto, fornecedorProduto, preco, estoqueP);
        gerenciador.AdicionarItem(p);

        Console.WriteLine("Criado com sucesso");

    }

    public void AlterarProduto()
    {
        Console.WriteLine("-----------Alteração de Produto -----------");


        Console.WriteLine("Nome do Produto a ser alterado:");
        string nome = Console.ReadLine();

        Produto patual;

        try
        {
            patual = gerenciador.BuscarPorNome(nome);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("tente novamente");
            return;
        }

        Console.WriteLine("Se deseja que algum campo permaneça como esta, só aperte enter no campo\n");

        Console.WriteLine("Nome:");
        nome = Console.ReadLine();
        if (nome != "")
            patual.Nome = nome;

        Console.WriteLine("quantidade de estoque:");
        string strestoque = Console.ReadLine();
        if (strestoque != "")
        {
            int estoque = int.Parse(strestoque);
            patual.QuantidadeEstoque = estoque;
        }
        Console.WriteLine("Nome do Fornecedor:");
        string nomeF = Console.ReadLine();
        if (nomeF != "")
        {
            Fornecedor f;
            try
            {
                f = fornecedores.BuscarPorNome(nomeF);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("tente novamente");
                return;
            }
            patual.fornecedor = f;
        }
        Console.WriteLine("Preço: ");
        string strpreco = Console.ReadLine();
        if (strpreco != "")
        {
            double preco = double.Parse(strpreco);
            patual.Preco = preco;
        }

        Console.WriteLine("Alterado com sucesso");

    }

}
