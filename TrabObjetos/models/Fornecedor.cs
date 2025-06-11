using System;
using System.ComponentModel.DataAnnotations;
using TrabObjetos.models;

namespace TrabObjetos;

public class Fornecedor : IEntidade
{
    public int Id{get;set;}
    public String Nome { get; set; }
    public String Descricao{get;set;}
    public String Telefone{get;set;}
    public String Email{get;set;}
    public Endereço Endereco{get;set;}

    public Fornecedor(String nome, String descricao,String telefone, String email,Endereço endereco){
        Nome = nome;
        Descricao = descricao;
        Telefone = telefone;
        Email = email;
        Endereco = endereco;
    }


    public string ObterDescricao(){
        return $"{Id} - {Nome}\n{Descricao}\ndados de contado: {Telefone},{Email}\nEndereço: {Endereco.ObterDescricaoEndereço()}";
    }
} 
