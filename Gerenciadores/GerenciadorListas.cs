using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text.Json;
using TrabObjetos;
using TrabObjetos.models;

namespace Gerenciadores;

public class GerenciadorListas<T> : IRepositorio<T> where T : IEntidade
{
    private List<T> lista = new List<T>();
    public int cont { get; set; }

    public void AdicionarItem(T item)
    {
        if (lista.Count != 0)
        {
            if (lista.Exists(p => p.Nome == item.Nome))//se já existe esse nome na lista
            {
                throw new Exception("Um item com este nome já está cadastrado");
            }
        }
        item.Id = lista.Count;
        cont = lista.Count;
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


    public List<T> Consulta(string keyword,bool todos) //todos é uma flag para retornar a lista inteira
    {
        List<T> resultado = new List<T>();
        if (todos)
        {
            resultado = lista;
            return resultado;
        }
            
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
            cont = lista.Count;
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
            Console.WriteLine("\n" + item.ObterDescricao() + "\n");
        }
    }

    public void SalvarDados(string arquivo)
    {
        if (lista.Count == 0) //para não criar um arquivo vazio
            return;

        string jsonData = JsonSerializer.Serialize<List<T>>(lista);
        File.WriteAllText(arquivo, jsonData);
    }
    public void CarregarDados(string arquivo)
    {
        if (!File.Exists(arquivo))//o programa funciona sem dados previos, só não vai tentar ler o arquivo
            return;

        string jsonData = File.ReadAllText(arquivo);
        lista = JsonSerializer.Deserialize<List<T>>(jsonData);
    
    }
}
