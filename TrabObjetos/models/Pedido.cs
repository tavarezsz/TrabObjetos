using System;
using System.ComponentModel;
using System.Reflection;
using TrabObjetos.models;

namespace TrabObjetos;

public class Pedido : IEntidade
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataHoraPedido;
    public DateTime DataHoraEntrega;
    public String Situação;
    public double PreçoFrete;

    private IRepositorio<ItemPedido> Itens;

    public Pedido(IRepositorio<ItemPedido> repo)
    {
        Itens = repo;
        
    }

    public Pedido(DateTime datapedido, String situacao, double preçofrete)
    {
        this.DataHoraPedido = datapedido;
        this.Situação = situacao;
        this.PreçoFrete = preçofrete;
    }

    public void AdicionarProduto(ItemPedido prod)
    {
        Itens.AdicionarItem(prod);
    }

    public void ObterDescricao()
    {
        Itens.ListarItens("Itens no pedido atual");
    }

    

}
