using Gerenciadores;
using TrabObjetos;
using TrabObjetos.models;

namespace Menus;

public class InterfaceGrafica
{

    private MenuUsuarios MenuU;  
    MenuFornecedores MenuF;
    MenuTransportadoras MenuT;
    MenuProdutos MenuP;

    //GerenciadorPedidos GerenciadorPed = new GerenciadorPedidos(); 

    private Usuario userAtual { get; set; }

    public InterfaceGrafica(string tipoArmazenamento)
    {
        //inicializar os gerenciadores
        if (tipoArmazenamento.ToLower() == "lista")
        {
            MenuU = new MenuUsuarios(new GerenciadorListas<Admin>(new List<Admin>()),new GerenciadorListas<Cliente>(new List<Cliente>()));
            MenuF = new MenuFornecedores(new GerenciadorListas<Fornecedor>(new List<Fornecedor>()));
            MenuT = new MenuTransportadoras(new GerenciadorListas<Transportadora>(new List<Transportadora>()));
            MenuP = new MenuProdutos(new GerenciadorListas<Produto>(new List<Produto>()), MenuF.gerenciador);//produtos precisa acessar a lista de fornecedores

        }
        else
        {
            MenuU = new MenuUsuarios(new GerenciadorListas<Admin>(new Admin[1]),new GerenciadorListas<Cliente>(new Cliente[1]));
            MenuF = new MenuFornecedores(new GerenciadorListas<Fornecedor>(new Fornecedor[1]));
            MenuT = new MenuTransportadoras(new GerenciadorListas<Transportadora>(new Transportadora[1]));
            MenuP = new MenuProdutos(new GerenciadorListas<Produto>(new Produto[1]), MenuF.gerenciador);//produtos precisa acessar a lista de fornecedores

        }

        //carregar os dados dos json

        Entrar();
    }

    public void MostrarMenuAdm()
    {
        int opcao;
        do
        {
            Console.WriteLine("\n========= MENU PRINCIPAL =========");
            Console.WriteLine("1 - Menu de Usuário");
            Console.WriteLine("2 - Menu de Produtos");
            Console.WriteLine("3 - Menu de Fornecedores");
            Console.WriteLine("4 - Menu de Transportadoras");
            Console.WriteLine("5 - Logar novamente");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            while (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Entrada inválida! Digite um número:");
            }

            switch (opcao)
            {
                case 1:
                    MenuU.Menu();
                    break;
                case 2:
                    MenuP.Menu();
                    break;
                case 3:
                    MenuF.Menu();
                    break;
                case 4:
                    MenuT.Menu();
                    break;
                case 5:
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
        int opcao;
        do
        {
            Console.WriteLine("\n========= MENU PRINCIPAL CLIENTE =========");
            Console.WriteLine("1 - Meu Carrinho");
            Console.WriteLine("2 - Menu de Produtos");
            Console.WriteLine("3 - Menu de Pedidos");
            Console.WriteLine("4 - Logar novamente");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            while (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Entrada inválida! Digite um número:");
            }

            switch (opcao)
            {
                case 1:
                    //MenuU.MeusPedidos((Cliente)userAtual);
                    break;
                case 2:
                    //MenuP.CarrinhoCompras((Cliente)userAtual);
                    break;
                case 3:
                    Console.WriteLine("Menu de Pedidos ainda não implementado para Clientes\n");
                    //GerenciadorF.Menu();
                    break;
                case 4:
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


    public void Entrar()
    {

        userAtual = MenuU.Auth();

        if (userAtual.Acesso == "cliente")
            MostrarMenuCliente();
        else if (userAtual.Acesso == "admin")
            MostrarMenuAdm();
        else
            Entrar();
    
    }

}
