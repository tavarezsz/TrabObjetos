using System;
using TrabObjetos;

namespace Gerenciadores;

public class GerenciadorPedidos : GerenciadorListas<Pedido>
{
    IList<Pedido> repositorio;
    public GerenciadorPedidos(IList<Pedido> repo) : base(repo)
    {
        repositorio = repo;
    }

    IList<Pedido> ConsultaPorData(DateTime inicio, DateTime fim)
    {
        IList<Pedido> results;

        if (repositorio is List<Pedido>)
            results = new List<Pedido>();
        else
            results = new Pedido[1];

        foreach (var item in repositorio)
        {
            if (DateTime.Compare(inicio, item.DataHoraEntrega) < 0 && DateTime.Compare(item.DataHoraEntrega, fim) > 0)
                results.Add(item);

        }
        return results;

    }
    Pedido Consulta(int id)
    {
        if (id > repositorio.Count)
            throw new Exception("Item não encontrado");
            
        return repositorio[id];
    }
}
