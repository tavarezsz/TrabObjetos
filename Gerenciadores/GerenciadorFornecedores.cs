using System;
using System.Collections.ObjectModel;
using TrabObjetos;
using TrabObjetos.models;
namespace Gerenciadores;

public class GerenciadorFornecedores : GerenciadorListas
{
    public Fornecedor[] listaFornecedores = new Fornecedor[max_itens];
    public int cont;

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
                    ListarItens("Lista de Fornecedores", listaFornecedores);
                    break;
                case 4:
                    ExcluirItem(ref cont, ref listaFornecedores);
                    break;
            }
        } while (op != 0);

    }

    public GerenciadorFornecedores()
    {
        //cadastrar alguns exemplos
        Endereço e = new Endereço("julio de castilhos", "555", "fabrica", "lourdes", "12443", "Caxias do sul", "RS");
        Fornecedor f = new Fornecedor(cont, "comp", "Fornecedor de alimentos em geral", "549938210", "comp@gmail.com", e);
        AdicionarItem(ref cont, f, listaFornecedores);
        Endereço e2 = new Endereço("rua das palmeiras", "1245", "comercial", "Laranjeiras", "22546", "Rio de janeiro", "RJ");
        Fornecedor f2 = new Fornecedor(cont, "Fabregas", "Fornecedor de alimento congelados", "549938210", "comp@gmail.com", e2);
        AdicionarItem(ref cont, f2, listaFornecedores);
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

        Fornecedor f = new Fornecedor(cont, nome, descricao, telefone, email, endereco);

        AdicionarItem(ref cont, f, listaFornecedores);

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
            fatual = BuscarPorNome(nome, listaFornecedores);
        }
        catch (Exception ex)//exceão de item nao encontrado
        {
            Console.WriteLine(ex.Message+"\n");
            return;
        }

        Console.WriteLine("Se deseja que algum campo permanesça como esta, só aperte enter no campo");

        Console.WriteLine("Nome:");
        nome = Console.ReadLine();
        if(nome !="")
            fatual.Nome = nome;

        Console.WriteLine("Descrição:");
        string descricao = Console.ReadLine();
        if(descricao != "")
            fatual.Descricao = descricao;

        Console.WriteLine("Telefone:");
        string telefone = Console.ReadLine();
        if(telefone != "")
            fatual.Telefone = telefone;


        Console.WriteLine("Email:");
        string email = Console.ReadLine();
        if(email!="")  
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
