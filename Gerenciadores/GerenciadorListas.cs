using System;
using TrabObjetos;

namespace Gerenciadores;

public class GerenciadorListas<T> : IRepositorio<T> where T : IEntidade
{
    List<T> lista = new List<T>();

    public void AdicionarItem(T item)
    {
        if (lista.Exists(p => p.Nome == item.Nome))//se já existe esse nome na lista
        {
            throw new Exception("Um item com este nome já está cadastrado");
        }
        item.Id = lista.Count;
        lista.Add(item);
    }

    public T BuscarPorNome(string nome)
    {

        foreach (var item in lista)
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


    public List<T> Consulta(string keyword)
    {
        List<T> resultado = new List<T>();
        foreach (var item in lista)
        {
            if (item.Nome.Contains(keyword))
            {
                resultado.Add(item);
            }
        }
        return resultado;
    }

    public bool ExcluirItem(int id)
    {
        try
        {
            lista.RemoveAt(id);
        }
        catch
        {
            return false;
        }

        return true;

    }

    public void ListarItens(string msg)
    {

        Console.WriteLine($"--------{msg}--------");
        foreach (var item in lista)
        {

            Console.WriteLine(item.ObterDescricao());
        }
    }
}
