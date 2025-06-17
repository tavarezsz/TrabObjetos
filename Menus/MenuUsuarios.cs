using System;
using Gerenciadores;
using TrabObjetos.models;
using TrabObjetos;

namespace Menus;

public class MenuUsuarios : GerenciadorEnderecos
{
    private IRepositorio<Admin> gerenciadorAdmin;
    private IRepositorio<Cliente> gerenciadorCliente;//tem que ter 2 gerenciadores por causa do json
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
                    gerenciadorAdmin.ListarItens("Admins");
                    gerenciadorCliente.ListarItens("Clientes");
                    break;
                case 4:

                    ExcluirUser();

                    break;
            }
        } while (op != 0);

        gerenciadorAdmin.SalvarDados(Path.Combine("dados", "admins.json"));
        gerenciadorCliente.SalvarDados(Path.Combine("dados", "clientes.json"));

    }

    public MenuUsuarios(IRepositorio<Admin> admin, IRepositorio<Cliente> cliente)
    {
        gerenciadorAdmin = admin;
        gerenciadorCliente = cliente;


        gerenciadorAdmin.CarregarDados(Path.Combine("dados", "admins.json"));
        gerenciadorCliente.CarregarDados(Path.Combine("dados", "clientes.json"));
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
            Cliente c = new Cliente(nome, senha, endereco);
            gerenciadorCliente.AdicionarItem(c);

            Console.WriteLine("usuario criado com sucesso");
        }
        else if (acesso.ToLower() == "admin")
        {
            Admin a = new Admin(nome, senha);
            gerenciadorAdmin.AdicionarItem(a);

            Console.WriteLine("usuario criado com sucesso");
        }

    }

    public void AlterarUsuario()
    {
        Console.WriteLine("-----------Alteração de Usuario -----------");

        string acesso;
        while (true)
        {
            Console.WriteLine("Nivel de acesso do usuario a ser exlcuido(admin/cliente):");
            acesso = Console.ReadLine();
            acesso = acesso.ToLower();

            if (acesso != "cliente" && acesso != "admin")
            {
                Console.WriteLine("nivel de acesso invalido, tente novamente");
            }
            else
                break;
        }

        Console.WriteLine("Nome do usuario a ser alterado:");
        string nome = Console.ReadLine();

        Usuario userAtual;

        try
        {
            if (acesso == "admin")
                userAtual = gerenciadorAdmin.BuscarPorNome(nome);
            else
                userAtual = gerenciadorCliente.BuscarPorNome(nome);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("tente novamente");
            return;
        }

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

    public Usuario Auth()
    {
        //se for bem sucedido retorna o nivel de acesso do usuario
        Console.WriteLine("----------Login----------");
        Console.WriteLine("Nome de usuario: ");

        try
        {
            string nome = Console.ReadLine();

            Usuario userAtual;

            try //tentar buscar nos dois
            {
                userAtual = gerenciadorAdmin.BuscarPorNome(nome);
            }
            catch
            {
                userAtual = gerenciadorCliente.BuscarPorNome(nome);
            }


            Console.WriteLine("Senha: ");
            string senha = Console.ReadLine();


            if (userAtual.Login(senha))
            {
                Console.WriteLine("Login efetuado com sucesso");

                return userAtual;
            }
            else
                Console.WriteLine("Senha incorreta, tente novamente");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Tente novamente");
        }

        return null;


    }

    public void ExcluirUser()
    {
        string acesso;
        while (true)
        {
            Console.WriteLine("Nivel de acesso do usuario a ser exlcuido(admin/cliente):");
            acesso = Console.ReadLine();
            acesso = acesso.ToLower();

            if (acesso != "cliente" && acesso != "admin")
            {
                Console.WriteLine("nivel de acesso invalido, tente novamente");
            }
            else
                break;
        }
        Console.WriteLine("Id a ser excluído: ");

        int id = int.Parse(Console.ReadLine());

        bool sucesso = false;
        if (acesso == "admin")
            sucesso = gerenciadorAdmin.ExcluirItem(id);
        if (acesso == "cliente")
            sucesso = gerenciadorCliente.ExcluirItem(id);
        if (sucesso)
            Console.WriteLine("Excluido com sucesso");
        else
            Console.WriteLine("Item não encontrado");
    }

    public void MeusPedidos(Cliente UserAtual)
    {
        int op;
        Console.WriteLine("----------Meus Pedidos----------");
        Console.WriteLine("1 - Consulta por numero do pedido");
        Console.WriteLine("2 - Consulta por data");
        Console.WriteLine("0 - Voltar ao menu principal");
        op = int.Parse(Console.ReadLine());

        List<Pedido> pedidosUser = UserAtual.ObterPedidos();

        if (op == 1)
        {
            Console.WriteLine("Numero do pedido: ");
            int num = int.Parse(Console.ReadLine());
            if (num > pedidosUser.Count)
                Console.WriteLine("Pedido não encontrado");
            else //precisa de ajustes
            {
                pedidosUser[num].ObterDescricao();
            }

        }
        else if (op == 2)
        {
            DateTime d1, d2;
            foreach (var pedido in pedidosUser)
            {
                if (DateTime.Compare(d1, pedido.DataHoraPedido) > 0 && DateTime.Compare(d2, pedido.DataHoraPedido) > 0)
                {
                    pedido.ObterDescricao();
                }
            }
        }


    }
}
