using System;
using TrabObjetos.models;

namespace TrabObjetos;

public class Produto : Ientidade
{
    public int Id {get;set;}
    public String Nome {get;set;}
    public int QuantidadeEstoque {get;set;}
    public Fornecedor fornecedor {get;set;}
    public double Preco { get; set; }

    public Produto(int id, String nome, Fornecedor fornecedor, double preco = 0, int qtdEstoque = 0)
    {
        Id = id;
        Nome = nome;
        QuantidadeEstoque = qtdEstoque;
        this.fornecedor = fornecedor;
        Preco = preco;
    }


    public void BaixaEstoque(int qtd){
        if(qtd > QuantidadeEstoque)
            throw new Exception($"O estoque não tem a quantidade necessaria deste produto, {QuantidadeEstoque} em estoque");

        QuantidadeEstoque -= qtd;
    } 
    public void AdicionaEstoque(int qtd){
        QuantidadeEstoque += qtd;
    }

    public string ObterDescricao(){
        return $"{Id} - {Nome} - {QuantidadeEstoque} em estoque - Fornecedor: {fornecedor.Nome} - Preço R${Preco}";
    }
}
