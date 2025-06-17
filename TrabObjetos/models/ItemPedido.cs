using System;

namespace TrabObjetos.models;

public class ItemPedido : IEntidade
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double PrecoTotal{ get; set; }
    public int Quantidade{ get; set; }

    public Produto ProdutoOriginal;


    public ItemPedido(Produto produto, int quantidade)
    {

        ProdutoOriginal = produto;
        Nome = ProdutoOriginal.Nome;
        
        PrecoTotal = produto.Preco * Quantidade;
        Quantidade = quantidade;
    }
    public string ObterDescricao()
    {
        return $"{Id} - {Nome}, {Quantidade} unidades, preço total R${PrecoTotal}";
    }

}