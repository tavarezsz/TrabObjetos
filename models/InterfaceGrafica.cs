using System;
using System.Collections;
using System.ComponentModel;
using System.Dynamic;
using System.Reflection.Metadata;
using System.Collections.Generic;

namespace TrabObjetos.models;

public class InterfaceGrafica
{
    private const int max_items = 10;

    public Usuario[] listaUsers = new Usuario[max_items];
    private int contUser = 1; //1 por causa do master
    public Fornecedor[] listaFornecedores = new Fornecedor[max_items];
    private int contFornecedor = 0;
    public Produto[] listaProdutos = new Produto[max_items];
    private int contProduto = 0;
    public Transportadora[] listaTransportadoras = new Transportadora[max_items];
    private int contTransportadora = 0;

    private Usuario userAtual { get; set; }

    public InterfaceGrafica()
    {

        Admin master = new Admin(0, "adm", "123");
        listaUsers[0] = master; 

    }

    public void MostrarMenuAdm()
    {
        int opcao;
        do
        {
            Console.WriteLine("\n========= MENU PRINCIPAL =========");
            Console.WriteLine("1 - Inserir Usuário");
            Console.WriteLine("2 - Alterar Usuário");
            Console.WriteLine("3 - Listar Usuários");
            Console.WriteLine("4 - Excluir Usuário");
            Console.WriteLine("5 - Inserir Fornecedor");
            //Console.WriteLine("6 - Alterar Fornecedor");
            Console.WriteLine("7 - Listar Fornecedores");
            Console.WriteLine("8 - Excluir Fornecedor");
            Console.WriteLine("9 - Inserir Produto");
            //Console.WriteLine("10 - Alterar Produto");
            Console.WriteLine("11 - Listar Produtos");
            Console.WriteLine("12 - Excluir Produto");
            Console.WriteLine("13 - Inserir Transportadora");
            //Console.WriteLine("14 - Alterar Transportadora");
            Console.WriteLine("15 - Listar Transportadoras");
            Console.WriteLine("16 - Excluir Transportadora");
            Console.WriteLine("17 - Logar novamente");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            while (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Entrada inválida! Digite um número:");
            }

            switch (opcao)
            {
                case 1:
                    InserirUsuario();
                    break;
                case 2:
                    AlterarUsuario();
                    break;
                case 3:
                    ListarItens("Lista de Usuarios", listaUsers);
                    break;
                case 4:
                    ExcluirItem(listaUsers);
                    break;
                case 5:
                    InserirFornecedor();
                    break;
                //case 6:
                //AlterarFornecedor();
                // break;
                case 7:
                    ListarItens("Lista de Fornecedores", listaFornecedores);
                    break;
                case 8:
                    ExcluirItem(listaFornecedores);
                    break;
                case 9:
                    InserirProduto();
                    break;
                //case 10:
                // AlterarProduto();
                // break;
                case 11:
                    ListarItens("Lista de Produtos",listaProdutos); //produtos
                    break;
                case 12:
                    ExcluirItem(listaProdutos);
                    break;
                case 13:
                    InserirTransportadora();
                    break;
                //case 14:
                //AlterarTransportadora();
                //break;
                case 15:
                    ListarItens("Lista de Transportadoras",listaTransportadoras); //transportadoras
                    break;
                case 16:
                    //ExcluirTransportadora(Transportadora transParaExcluir);
                    break;
                case 17:
                    Entrar();
                    opcao = 0;
                    break;

                case 0:
                    Console.WriteLine("Saindo do programa...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        } while (opcao != 0);
    }

    public void MostrarMenuCliente()
    {
        Console.WriteLine("AINDA NÃO IMPLEMENTADO");
    }


    public void InserirUsuario()
    {

        Console.WriteLine("-----------Cadastro de Usuario -----------");
        string acesso;
        while (true)
        {
            Console.WriteLine("Nivel de acesso do usuario(admin/cliente):");
            acesso = Console.ReadLine();

            if (acesso != "cliente" && acesso != "admin")
            {
                Console.WriteLine("nivel de acesso invalido, tente novamente");
            }
            else
                break;
        }


        Console.WriteLine("Nome:");
        string nome = Console.ReadLine();

        Console.WriteLine("Senha:");
        string senha = Console.ReadLine();

        if (acesso.ToLower() == "cliente")
        {
            Console.WriteLine("Por favor cadastre o endereço do cliente");
            Endereço endereco = InserirEndereco();
            Cliente c = new Cliente(contUser, nome, senha, endereco);
            listaUsers[contUser++] = c;

            Console.WriteLine("usuario criado com sucesso");
        }
        else if (acesso.ToLower() == "admin")
        {
            Admin a = new Admin(contUser, nome, senha);
            listaUsers[contUser++] = a;

            Console.WriteLine("usuario criado com sucesso");
        }

    }

    public void AlterarUsuario()
    {
        Console.WriteLine("-----------Alteração de Usuario -----------");


        Console.WriteLine("Nome do usuario a ser alterado:");
        string nome = Console.ReadLine();

        userAtual = BuscarPorNome(nome, listaUsers);

        Console.WriteLine("Se deseja que algum campo permanesça como esta, só aperte enter no campo\n");

        Console.WriteLine("Nome:");
        nome = Console.ReadLine();

        Console.WriteLine("Senha:");
        string senha = Console.ReadLine();

        userAtual.AlterarCadastro(nome, senha);
    }

    public void ListarUsuarios()
    {
        foreach (var user in listaUsers) //ja fica meio pronto para listas
        {
            if (user != null)
                Console.WriteLine(user.ObterDescricao());
        }
    }

    public static T BuscarPorNome<T>(string nome, T[] array) where T : Ientidade
    {
        //uma função generica, que procura um objeto por id em qualquer lista de classes que implementam a interface Ientidade
        //ex de chamada BuscarPorID("eduardo",listaUsers)
        foreach (var item in array)
        {
            if (item != null)
            {
                if (item.Nome == nome)
                {
                    return item;
                }
            }
        }

        throw new Exception("Item não encontrado");
    }

    private void ListarItens<T>(string msg, T[] array) where T : Ientidade
    {
        //função generica que mostra qualquer lista de entidades
        Console.WriteLine($"-----------{msg}-----------");
        foreach (var item in array)
        {
            if (item != null)
            {
                Console.WriteLine(item.ObterDescricao());
            }
        }
    }

    private void ExcluirItem<T>(T[] array) where T : Ientidade
    {
        Console.WriteLine("Id para exclusão: ");
        int id = int.Parse(Console.ReadLine());
        try
        {
            array[id] = default; //null
        }
        catch
        {
            Console.WriteLine("Não foi possível encontrar o item");
        }

        Console.WriteLine("Excluido com sucesso");
    }


    private Endereço InserirEndereco()
    {

        Console.WriteLine("-----------Cadastro de endereço -----------");

        Console.WriteLine("Rua:");
        string rua = Console.ReadLine();

        Console.WriteLine("Numero:");
        string numero = Console.ReadLine();

        Console.WriteLine("Complemento:");
        string complemento = Console.ReadLine();

        Console.WriteLine("Bairro:");
        string bairro = Console.ReadLine();

        Console.WriteLine("Cep:");
        string cep = Console.ReadLine();

        Console.WriteLine("Estado:");
        string estado = Console.ReadLine();

        Console.WriteLine("Cidade:");
        string cidade = Console.ReadLine();

        Endereço e = new Endereço(rua, numero, complemento, bairro, cep, cidade, estado);

        return e;
    }

    public void Entrar()
    {

        Console.WriteLine("----------Login----------");
        Console.WriteLine("Nome de usuario: ");

        try
        {
            string nome = Console.ReadLine();

            userAtual = BuscarPorNome(nome, listaUsers);
            
            Console.WriteLine("Senha: ");
            string senha = Console.ReadLine();


            if (userAtual.Login(senha))
            {
                Console.WriteLine("Login efetuado com sucesso");
                if (userAtual.Acesso == "admin")
                    MostrarMenuAdm();
                else
                    MostrarMenuCliente();
            }
            else
                Console.WriteLine("Senha incorreta, tente novamente");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Tente novamente");
        }


    }

    public void InserirFornecedor()
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

        Fornecedor f = new Fornecedor(contFornecedor, nome, descricao, telefone, email, endereco);
        listaFornecedores[contFornecedor++] = f;

    }
    private void InserirProduto()
    {
        Console.WriteLine("---------- Cadastro de Produto ----------");

        Console.WriteLine("Nome do Produto:");
        string nomeProduto = Console.ReadLine();

        Console.WriteLine("Nome do Fornecedor: ");
        string nomeFornecedor = Console.ReadLine();

        Fornecedor fornecedorProduto = BuscarPorNome(nomeFornecedor, listaFornecedores);
  
        Console.WriteLine("Quantidade em estoque:");
        int estoqueP;
        while (!int.TryParse(Console.ReadLine(), out estoqueP))
        {
            Console.WriteLine("Entrada inválida! Digite um número inteiro:");
        }

        Produto p = new Produto(contProduto, nomeProduto, fornecedorProduto, estoqueP);

        listaProdutos[contProduto++] = p;
    }

    private void InserirTransportadora()
    {
        Console.WriteLine("---------- Cadastro de Transportadora ----------");

        Console.WriteLine("Nome da Transportadora:");
        string nomeTransportadora = Console.ReadLine();

        Console.WriteLine("Preço cobrado para cada KM rodado:");
        double kmPreco = double.Parse(Console.ReadLine());

        Transportadora t = new Transportadora(contTransportadora, nomeTransportadora, kmPreco);

        listaTransportadoras[contTransportadora++] = t;

    }




}
