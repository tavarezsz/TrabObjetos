using System;
using System.Collections.Specialized;
using TrabObjetos;
using TrabObjetos.models;
namespace Gerenciadores;


public class GerenciadorVetores<T> : IRepositorio<T> where T : IEntidade
{

    private T[] vetor = new T[max_itens];
    public int cont = 0;
    protected const int max_itens = 10;
    public T BuscarPorNome(string nome)
    {
        foreach (var item in vetor)
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

    public void ListarItens(string msg)
    {
        //função generica que mostra qualquer lista de entidades
        Console.WriteLine($"-----------{msg}-----------");

        int cont = 0;
        foreach (var item in vetor)
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

    public bool ExcluirItem(int id)
    {

        T[] novoVet = new T[vetor.Length]; // Usa o mesmo tamanho do array original
        int novoCont = 0;
        bool encontrado = false;

        foreach (var item in vetor)
        {
            if (item != null && item.Id != id)
            {
                item.Id = novoCont; // Atualiza o ID
                novoVet[novoCont++] = item;
            }
            else if (item.Id == id)
                encontrado = true;
        }

        if (encontrado)
        {
            cont = novoCont;
            vetor = novoVet;
            Console.WriteLine("Excluído com sucesso");
            return encontrado;
        }

        return encontrado;

    }

    public void AdicionarItem(T item)
    {

        if (cont + 1 > max_itens)
            throw new Exception("Limite de itens excedido");
        item.Id = cont;
        vetor[cont++] = item;


    }

    public List<T> Consulta(string keyword)
    {
        List<T> results = new List<T>();
        //retorna uma lista de produtos referentes a pesquisas
        foreach (var item in vetor)
        {
            if (item.Nome.Contains(keyword))
                results.Add(item);
        }
        return results;
    }


}
