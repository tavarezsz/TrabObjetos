using System;
using Gerenciadores;
using TrabObjetos.models;

namespace Menus;

public class MenuTransportadoras
{
    private GerenciadorListas<Transportadora> gerenciador = new GerenciadorListas<Transportadora>();
    public MenuTransportadoras()
    {
        Transportadora t = new Transportadora("Segalla", 0.50);
        gerenciador.AdicionarItem(t);
        Transportadora t2 = new Transportadora("Masswell", 0.33);
        gerenciador.AdicionarItem(t2);

    }

    public void Menu()
    {
        int op;
        do
        {
            Console.WriteLine("--------Transportadoras--------");
            Console.WriteLine("1 - Inserir Transportadora");
            Console.WriteLine("2 - Alterar Transportadora");
            Console.WriteLine("3 - Listar Transportadoras");
            Console.WriteLine("4 - Excluir Transportadora");
            Console.WriteLine("0 - Voltar ao menu principal");

            Console.Write("Escolha uma opção: ");

            while (!int.TryParse(Console.ReadLine(), out op))
            {
                Console.WriteLine("Entrada inválida! Digite um número:");
            }

            switch (op)
            {
                case 1:
                    InserirTransportadora();
                    break;
                case 2:
                    AlterarTransportadora();
                    break;
                case 3:
                    gerenciador.ListarItens("Lista de Transportadoras");
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

    }

    private void InserirTransportadora()
    {
        Console.WriteLine("---------- Cadastro de Transportadora ----------");

        Console.WriteLine("Nome da Transportadora: ");
        string nomeTransportadora = Console.ReadLine();

        Console.WriteLine("Preço cobrado para cada KM rodado: ");
        double kmPreco;

        while (!double.TryParse(Console.ReadLine(), out kmPreco))
        {
            Console.WriteLine("Entrada inválida! Digite um número:");
        }


        Transportadora t = new Transportadora( nomeTransportadora, kmPreco);

        gerenciador.AdicionarItem(t);
        Console.WriteLine("Criado com sucesso");
    }
    
    public void AlterarTransportadora()
    {
        Console.WriteLine("-----------Alteração de Transportadora -----------");


        Console.WriteLine("Nome da transportadora a ser alterado:");
        string nome = Console.ReadLine();

        Transportadora tatual;

            try
            {
                tatual = gerenciador.BuscarPorNome(nome);
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
        if(nome != "")
            tatual.Nome = nome;

        Console.WriteLine("Preço por km:");
        string strpreco = Console.ReadLine();
        if (strpreco != "")
        {
            double preco = double.Parse(strpreco);
            tatual.PrecoKm = preco;
        }

        Console.WriteLine("Alterado com sucesso");

    }
}