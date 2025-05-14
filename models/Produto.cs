using System;

namespace TrabObjetos;

public class Produto
{
    public int Id {get;set;}
    public String Nome {get;set;}
    private int QuantidadeEstoque {get;set;}
    public Fornecedor fornecedor {get;set;}

    public Produto(int id,String nome,Fornecedor fornecedor,int qtdEstoque=0){
        Id = id;
        Nome = nome;
        QuantidadeEstoque = qtdEstoque;
        this.fornecedor = fornecedor;
    }

    public void AlterarCadastro(String nome=null, int qtdEstoque=0, Fornecedor forn = null){
        if(nome != null)
            Nome=nome;
        if(qtdEstoque!=0)
            QuantidadeEstoque = qtdEstoque;
        if(forn!=null){
            fornecedor = forn;
        }
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
        return $"{Id} - {Nome} - {QuantidadeEstoque} em estoque - Fornecedor: {fornecedor.Nome}";
    }
}
