using System;
using TrabObjetos;
using TrabObjetos.models;
namespace Gerenciadores;

public class GerenciadorUsuarios : GerenciadorListas
{
    private Usuario[] listaUsers = new Usuario[max_itens];
    private int cont; //começa em 1 por causa do master

    public GerenciadorUsuarios()
    {
        Admin master = new Admin(0, "adm", "123");
        AdicionarItem(ref cont, master, listaUsers);

        Endereço e = new Endereço("Andradas", "378", "apto", "Nova Esperança", "91856", "Porto Alegre", "RS");
        Cliente c = new Cliente(cont, "João", "joao321", e);
        AdicionarItem(ref cont, c, listaUsers);

    }

    public void Menu()
    {
        int op;
        do
        {
            Console.WriteLine("--------Usuarios--------");
            Console.WriteLine("1 - Inserir Usuário");
            Console.WriteLine("2 - Alterar Usuário");
            Console.WriteLine("3 - Listar Usuários");
            Console.WriteLine("4 - Excluir Usuário");
            Console.WriteLine("0 - Voltar ao menu principal");

            Console.Write("Escolha uma opção: ");

            while (!int.TryParse(Console.ReadLine(), out op))
            {
                Console.WriteLine("Entrada inválida! Digite um número:");
            }

            switch (op)
            {
                case 1:
                    InserirUsuario();
                    break;
                case 2:
                    AlterarUsuario();
                    break;
                case 3:
                    ListarItens("Lista de Usuários", listaUsers);
                    break;
                case 4:
                    ExcluirItem(ref cont, ref listaUsers);
                    break;
            }
        } while (op != 0);

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
            Cliente c = new Cliente(cont, nome, senha, endereco);
            AdicionarItem(ref cont, c, listaUsers);

            Console.WriteLine("usuario criado com sucesso");
        }
        else if (acesso.ToLower() == "admin")
        {
            Admin a = new Admin(cont, nome, senha);
            AdicionarItem(ref cont, a, listaUsers);

            Console.WriteLine("usuario criado com sucesso");
        }

    }

    public void AlterarUsuario()
    {
        Console.WriteLine("-----------Alteração de Usuario -----------");


        Console.WriteLine("Nome do usuario a ser alterado:");
        string nome = Console.ReadLine();

        Usuario userAtual = BuscarPorNome(nome, listaUsers);

        Console.WriteLine("Se deseja que algum campo permaneça como esta, só aperte enter no campo");

        Console.WriteLine("Nome:");
        nome = Console.ReadLine();
        if (nome != "")
            userAtual.Nome = nome;

        Console.WriteLine("Senha:");
        string senha = Console.ReadLine();
        if (senha != "")
            userAtual.Senha = senha;


        if (userAtual is Cliente)
        {
            Cliente c = (Cliente)userAtual;

            Console.WriteLine("Deseja alterar o endereço(s/n)?");
            string resp = Console.ReadLine();
            if (resp.ToLower() == "s")
            {
                c.Endereco = AlterarEndereco(c.Endereco);
            }
        }

        Console.WriteLine("Alterado com sucesso");

    }

    public string Auth()
    {
        //se for bem sucedido retorna o nivel de acesso do usuario
        Console.WriteLine("----------Login----------");
        Console.WriteLine("Nome de usuario: ");

        try
        {
            string nome = Console.ReadLine();

            Usuario userAtual = BuscarPorNome(nome, listaUsers);

            Console.WriteLine("Senha: ");
            string senha = Console.ReadLine();


            if (userAtual.Login(senha))
            {
                Console.WriteLine("Login efetuado com sucesso");

                return userAtual.Acesso;
            }
            else
                Console.WriteLine("Senha incorreta, tente novamente");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Tente novamente");
        }

        return "erro";


    }


    
}
