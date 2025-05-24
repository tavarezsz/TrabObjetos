using System;
using TrabObjetos;
using TrabObjetos.models;
namespace Gerenciadores;

public class GerenciadorProdutos : GerenciadorListas
{
    public GerenciadorFornecedores gerFor; //para fazer a busca
    public Produto[] listaProdutos = new Produto[max_itens];
    private int cont = 0;

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
                    ListarItens("Lista de Produtos", listaProdutos);
                    break;
                case 4:
                    ExcluirItem(ref cont, ref listaProdutos);
                    break;
            }
        } while (op != 0);

    }
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
            fornecedorProduto = BuscarPorNome(nomeFornecedor, gerFor.listaFornecedores);
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
        double preco = double.Parse(Console.ReadLine());

        Produto p = new Produto(cont, nomeProduto, fornecedorProduto, preco, estoqueP);
        AdicionarItem(ref cont, p, listaProdutos);

        Console.WriteLine("Criado com sucesso");

    }
    
    public void AlterarProduto()
    {
        Console.WriteLine("-----------Alteração de Produto -----------");


        Console.WriteLine("Nome do Produto a ser alterado:");
        string nome = Console.ReadLine();

        Produto patual = BuscarPorNome(nome, listaProdutos);

        Console.WriteLine("Se deseja que algum campo permanesça como esta, só aperte enter no campo\n");

        Console.WriteLine("Nome:");
        nome = Console.ReadLine();

        Console.WriteLine("quantidade de estoque:");
        int estoque = int.Parse(Console.ReadLine());

        Console.WriteLine("Nome do Fornecedor:");
        string nomeF = Console.ReadLine();
        Fornecedor f = BuscarPorNome(nomeF, gerFor.listaFornecedores);


        Console.WriteLine("Preço: ");
        double preco = double.Parse(Console.ReadLine());



        patual.Nome = nome;
        patual.QuantidadeEstoque = estoque;
        patual.Preco = preco;
        patual.fornecedor = f;


        Console.WriteLine("Alterado com sucesso");

    }
}
