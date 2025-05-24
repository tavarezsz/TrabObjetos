using System;
using TrabObjetos;
using TrabObjetos.models;
namespace Gerenciadores;


public abstract class GerenciadorListas
{

    protected const int max_itens = 10;
    protected T BuscarPorNome<T>(string nome, T[] array) where T : Ientidade
    {
        //uma função generica, que procura um objeto por id em qualquer lista de classes que implementam a interface Ientidade
        //ex de chamada BuscarPorNome("eduardo",listaUsers)
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

    protected void ListarItens<T>(string msg, T[] array) where T : Ientidade
    {
        //função generica que mostra qualquer lista de entidades
        Console.WriteLine($"-----------{msg}-----------");

        int cont = 0;
        foreach (var item in array)
        {
            if (item != null)
            {
                cont++;
                Console.WriteLine("\n" + item.ObterDescricao() + "\n");
            }
        }
        if (cont == 0)
            Console.WriteLine("A lista está vazia\n");
    }

    protected void ExcluirItem<T>(ref int cont, ref T[] array) where T : Ientidade
    {
        Console.WriteLine("Id para exclusão: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        try
        {
            T[] novoVet = new T[array.Length]; // Usa o mesmo tamanho do array original
            int novoCont = 0;

            foreach (var item in array)
            {
                if (item != null && item.Id != id)
                {
                    item.Id = novoCont; // Atualiza o ID
                    novoVet[novoCont++] = item;
                }
            }

            cont = novoCont;
            array = novoVet;

            Console.WriteLine("Excluído com sucesso");
        }
        catch
        {
            Console.WriteLine("Não foi possível encontrar o item");
        }
    }

    protected void AdicionarItem<T>(ref int cont, T item, T[] array) where T : Ientidade
    {
        array[cont++] = item;
    }

    protected Endereço InserirEndereco()
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

    protected Endereço AlterarEndereco(Endereço endereco)
    {
        Console.WriteLine("-----------Alteração de Endereço -----------");


        Console.WriteLine("Se deseja que algum campo permanesça como esta, só aperte enter no campo");

        Console.WriteLine("Rua:");
        string rua = Console.ReadLine();
        if(rua !="")
            endereco.Rua = rua;

        Console.WriteLine("Numero:");
        string numero = Console.ReadLine();
        if(numero !="")
            endereco.Número = numero;

        Console.WriteLine("Complemento:");
        string complemento = Console.ReadLine();
        if(complemento !="")
            endereco.Complemento = complemento;

        Console.WriteLine("Bairro:");
        string bairro = Console.ReadLine();
        if(bairro !="")
            endereco.Bairro = bairro;

        
        Console.WriteLine("Cep:");
        string cep = Console.ReadLine();
        if(cep !="")
            endereco.Cep = cep;

        Console.WriteLine("Estado:");
        string estado = Console.ReadLine();
        if(estado !="")
            endereco.Estado = estado;

        Console.WriteLine("Cidade:");
        string cidade = Console.ReadLine();
        if(cidade !="")
            endereco.Cidade = cidade;

        return endereco;


    }

}
