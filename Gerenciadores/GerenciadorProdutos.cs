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
        double preco;

        while (!double.TryParse(Console.ReadLine(), out preco))
        {
            Console.WriteLine("Entrada inválida! Digite um número:");
        }

        Produto p = new Produto(cont, nomeProduto, fornecedorProduto, preco, estoqueP);
        AdicionarItem(ref cont, p, listaProdutos);

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
                patual = BuscarPorNome(nome,listaProdutos);
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
                f = BuscarPorNome(nomeF, gerFor.listaFornecedores);
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
