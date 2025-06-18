using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Net.Cache;
using System.Text.Json;
using TrabObjetos;
using TrabObjetos.models;

namespace Gerenciadores;

public class GerenciadorListas<T> : IRepositorio<T> where T : IEntidade
{
    protected IList<T> repositorio { get; set; }
    public int cont { get; set; }

    public GerenciadorListas(IList<T> repo)
    {
        repositorio = repo;
    
    }
    public void AdicionarItem(T item)
    {
        if (repositorio.Count != 0)
        {
            if (repositorio.Contains(item))//se já existe esse nome na lista
            {
                throw new Exception("Um item com este nome já está cadastrado");
            }
        }
        item.Id = repositorio.Count;
        cont = repositorio.Count;
        repositorio.Add(item);
    }

    public T BuscarPorNome(string nome)
    {

        foreach (var item in repositorio)
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


    public IList<T> Consulta(string keyword) 
    {
        IList<T> resultado = new List<T>(); //ajustar depois
            
        foreach (var item in repositorio)
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
            repositorio.RemoveAt(id);
            cont = repositorio.Count;
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
        foreach (var item in repositorio)
        {
            Console.WriteLine("\n" + item.ObterDescricao() + "\n");
        }
    }

    public void SalvarDados(string arquivo)
    {
        if (repositorio.Count == 0) //para não criar um arquivo vazio
            return;

        string jsonData = JsonSerializer.Serialize<IList<T>>(repositorio);
        File.WriteAllText(arquivo, jsonData);
    }
    public void CarregarDados(string arquivo)
    {
        if (!File.Exists(arquivo))//o programa funciona sem dados previos, só não vai tentar ler o arquivo
            return;

        string jsonData = File.ReadAllText(arquivo);
        repositorio = JsonSerializer.Deserialize<List<T>>(jsonData);
    
    }

}
