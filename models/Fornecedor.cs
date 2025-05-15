using System;
using System.ComponentModel.DataAnnotations;
using TrabObjetos.models;

namespace TrabObjetos;

public class Fornecedor : Ientidade
{
    public int Id{get;set;}
    public String Nome{get;set;}
    public String Descricao{get;set;}
    public String Telefone{get;set;}
    public String Email{get;set;}
    public Endereço Endereco{get;set;}

    public Fornecedor(int id,String nome, String descricao,String telefone, String email,Endereço endereco){
        Id = id;
        Nome = nome;
        Descricao = descricao;
        Telefone = telefone;
        Email = email;
        Endereco = endereco;
    }


    public void AlterarCadastro(String nome=null, String descricao=null,String telefone=null, String email=null, Endereço endereco = null){
        if(nome != null)
            Nome = nome;
        if(descricao != null)
            Descricao = descricao;
        if(telefone != null)
            Telefone = telefone;
        if(Email != null)
            Email = email;
        if(endereco != null){
            Endereco = endereco;
        }
    }

    public string ObterDescricao(){
        return $"{Id} - {Nome}\n{Descricao}\ndados de contado:\n{Telefone},{Email}\nEndereço:\n{Endereco.ObterDescricaoEndereço()}";
    }
} 
