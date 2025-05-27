using System;
using System.Collections;
using System.ComponentModel;
using System.Dynamic;
using System.Reflection.Metadata;
using System.Collections.Generic;
using Gerenciadores;
using TrabObjetos.Gerenciadores;

namespace TrabObjetos.models;

public class InterfaceGrafica
{
    GerenciadorUsuarios GerenciadorU = new GerenciadorUsuarios();
    GerenciadorFornecedores GerenciadorF = new GerenciadorFornecedores();
    GerenciadorTransportadoras GerenciadorT = new GerenciadorTransportadoras();
    GerenciadorProdutos GerenciadorP = new GerenciadorProdutos();

    //GerenciadorPedidos GerenciadorPed = new GerenciadorPedidos(); 

    private Usuario userAtual { get; set; }

    public InterfaceGrafica()
    {
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
                    GerenciadorU.Menu();
                    break;
                case 2:
                    GerenciadorP.gerFor = GerenciadorF;
                    GerenciadorP.Menu();
                    break;
                case 3:
                    GerenciadorF.Menu();
                    break;
                case 4:
                    GerenciadorT.Menu();
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
            Console.WriteLine("1 - Meu Cadastro");
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
                    Console.WriteLine("Ainda não implementado\n");
                    break;
                case 2:
                    Console.WriteLine("Menu de Produtos ainda não implementado para Clientes\n");
                    //GerenciadorP.gerFor = GerenciadorF;
                    //GerenciadorP.Menu();
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

        string acesso = GerenciadorU.Auth();

        if (acesso == "cliente")
            MostrarMenuCliente();
        else if (acesso == "admin")
            MostrarMenuAdm();
        else
            Entrar();
    
    }

}
