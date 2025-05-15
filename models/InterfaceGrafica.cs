using System;
using System.Collections;
using System.ComponentModel;
using System.Dynamic;
using System.Reflection.Metadata;

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
        Console.WriteLine("Se deseja que algum campo permanesça como esta, só aperte enter no campo\n");

        Console.WriteLine("Nome:");
        string nome = Console.ReadLine();
        Console.WriteLine("Senha:");
        string senha = Console.ReadLine();

        //userAtual = BuscarUsuario(null,nome);



    }

    public void ListarUsuarios()
    {
        foreach (var user in listaUsers) //ja fica meio pronto para listas
        {
            if (user != null)
                Console.WriteLine(user.ObterDescricao());
        }
    }

    private T BuscarPorID<T>(int id, T[] array) where T : Ientidade
    {
        //uma função generica, que procura um objeto por id em qualquer lista de classes que implementam a interface Ientidade
        //ex de chamada BuscarPorID(2,listaUsers)
        foreach (var item in array)
        {
            if (item != null)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
        }

        throw new Exception("Item não encontrado");
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
        Console.WriteLine("Nome do usuario: ");
        string nome = Console.ReadLine();
        Console.WriteLine("Senha: ");
        string senha = Console.ReadLine();

        foreach (var user in listaUsers)
        {
            if (user != null && user.Nome == nome)
                if (user.Login(senha))
                {
                    Console.WriteLine("Login efetuado com sucesso");
                    userAtual = user; //A função de mostrar o menu vai ser diferente dependendo do acesso
                }

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



}
