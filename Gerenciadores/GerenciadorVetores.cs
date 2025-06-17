using System;
using System.Collections.Specialized;
using System.Text.Json;
using System.Xml.Schema;
using TrabObjetos;
using TrabObjetos.models;
namespace Gerenciadores;


public class GerenciadorVetores<T> : IRepositorio<T> where T : IEntidade
{

    private T[] vetor = new T[1];//começa com tamanho fixo, mas se exceder o limite de itens ajusta o tamanho dinamicamente
    public int cont { get; set; }

    public GerenciadorVetores()
    {
        cont = 0;
    }
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

        if (cont + 1 > vetor.Length)
            Array.Resize(ref vetor, cont + 1);

        item.Id = cont;
        vetor[cont++] = item;


    }

    public List<T> Consulta(string keyword, bool todos)
    {
        List<T> results = new List<T>();
        //retorna uma lista de produtos referentes a pesquisas
        if (todos)
        {
            foreach (var item in vetor)
            {
                if(item != null)
                    results.Add(item);
            }
        }
        foreach (var item in vetor)
        {
            if (item != null && item.Nome.Contains(keyword))
                results.Add(item);
        }
        return results;
    }

    public void SalvarDados(string arquivo)
    {
        if (cont == 0)//evita criar arquivo vazio
            return;

        string jsonData = JsonSerializer.Serialize<T[]>(vetor);
        File.WriteAllText(arquivo, jsonData);

    }
    public void CarregarDados(string arquivo)
    {
        if (!File.Exists(arquivo))
            return;

        string jsonData = File.ReadAllText(arquivo);

        using (JsonDocument doc = JsonDocument.Parse(jsonData))
        {
            int tam=0;
            // Verificar o tamanho do vetor no json para fazer resize se necessario
            if (doc.RootElement.ValueKind == JsonValueKind.Array)
            {
                tam = doc.RootElement.GetArrayLength();
            }
            cont = tam;
        }

        if (cont > vetor.Length)
            Array.Resize(ref vetor, cont + 1);

        vetor = JsonSerializer.Deserialize<T[]>(jsonData);
    }


}
