using System;
using Gerenciadores;
using TrabObjetos;
using TrabObjetos.models;

namespace Menus;

public class MenuFornecedores : GerenciadorEnderecos
{

    public IRepositorio<Fornecedor> gerenciador;
    public void Menu()
    {
        int op;
        do
        {
            Console.WriteLine("--------Fornecedores--------");
            Console.WriteLine("1 - Inserir Fornecedor");
            Console.WriteLine("2 - Alterar Fornecedor");
            Console.WriteLine("3 - Listar Fornecedor");
            Console.WriteLine("4 - Excluir Fornecedor");
            Console.WriteLine("0 - Voltar ao menu principal");

            Console.Write("Escolha uma opção: ");

            while (!int.TryParse(Console.ReadLine(), out op))
            {
                Console.WriteLine("Entrada inválida! Digite um número:");
            }

            switch (op)
            {
                case 1:
                    InserirFornecedor();
                    break;
                case 2:
                    AlterarFornecedor();
                    break;
                case 3:
                    gerenciador.ListarItens("Lista de Fornecedores");
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

        gerenciador.SalvarDados(Path.Combine("dados","fornecedores.json"));
    }

    public MenuFornecedores(IRepositorio<Fornecedor> repo)
    {
        gerenciador = repo;
        gerenciador.CarregarDados(Path.Combine("dados","fornecedores.json"));
    }

    private void InserirFornecedor()
    {

        Console.WriteLine("-----------Cadastro de Fornecedor -----------");

        Console.WriteLine("Nome:");
        string nome = Console.ReadLine();

        Console.WriteLine("Descrição:");
        string descricao = Console.ReadLine();

        Console.WriteLine("Telefone:");
        string telefone = Console.ReadLine();

        Console.WriteLine("Email:");
        string email = Console.ReadLine();

        Console.WriteLine("Endereço:");
        Endereço endereco = InserirEndereco();

        Fornecedor f = new Fornecedor(nome, descricao, telefone, email, endereco);

        gerenciador.AdicionarItem(f);

        Console.WriteLine("Criado com sucesso");

    }

    private void AlterarFornecedor()
    {
        Console.WriteLine("-----------Alteração de Fornecedor -----------");


        Console.WriteLine("Nome do fornecedor a ser alterado:");
        string nome = Console.ReadLine();
        Fornecedor fatual;


        try
        {
            fatual = gerenciador.BuscarPorNome(nome);
        }
        catch (Exception ex)//exceão de item nao encontrado
        {
            Console.WriteLine(ex.Message + "\n");
            return;
        }

        Console.WriteLine("Se deseja que algum campo permanesça como esta, só aperte enter no campo");

        Console.WriteLine("Nome:");
        nome = Console.ReadLine();
        if (nome != "")
            fatual.Nome = nome;

        Console.WriteLine("Descrição:");
        string descricao = Console.ReadLine();
        if (descricao != "")
            fatual.Descricao = descricao;

        Console.WriteLine("Telefone:");
        string telefone = Console.ReadLine();
        if (telefone != "")
            fatual.Telefone = telefone;


        Console.WriteLine("Email:");
        string email = Console.ReadLine();
        if (email != "")
            fatual.Email = email;

        Console.WriteLine("Deseja alterar o endereço(s/n)?");
        string resp = Console.ReadLine();
        if (resp.ToLower() == "s")
        {
            fatual.Endereco = AlterarEndereco(fatual.Endereco);
        }

        Console.WriteLine("Alterado com sucesso");

    }
}
