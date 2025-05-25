using System;
using TrabObjetos;
using TrabObjetos.models;
namespace Gerenciadores;

public class GerenciadorTransportadoras : GerenciadorListas
{
    private Transportadora[] listaTransportadoras = new Transportadora[max_itens];
    private int cont = 0;

    public GerenciadorTransportadoras()
    {
        Transportadora t = new Transportadora(cont, "Segalla", 0.50);
        AdicionarItem(ref cont, t, listaTransportadoras);
        Transportadora t2 = new Transportadora(cont, "Masswell", 0.33);
        AdicionarItem(ref cont, t2, listaTransportadoras);

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
                    ListarItens("Lista de Transportadoras", listaTransportadoras);
                    break;
                case 4:
                    ExcluirItem(ref cont, ref listaTransportadoras);
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


        Transportadora t = new Transportadora(cont, nomeTransportadora, kmPreco);

        AdicionarItem(ref cont, t, listaTransportadoras);
        Console.WriteLine("Criado com sucesso");
    }
    
    public void AlterarTransportadora()
    {
        Console.WriteLine("-----------Alteração de Transportadora -----------");


        Console.WriteLine("Nome da transportadora a ser alterado:");
        string nome = Console.ReadLine();

        Transportadora tatual = BuscarPorNome(nome, listaTransportadoras);

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
