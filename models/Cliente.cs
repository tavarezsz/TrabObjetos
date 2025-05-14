using System;

namespace TrabObjetos;

public class Cliente:Usuario
{
    public string Acesso{get;set;}
    public Endereço Endereco{get;set;}
    public Pedido[] Pedidos = new Pedido[10];

    public Cliente(int id, string nome,string senha,Endereço endereco){
        Id = id;
        Nome = nome;
        Senha = senha;
        Acesso = "cliente";
        Endereco = endereco;
    }

    public override string ObterDescricao(){
        return $"Cliente {Nome} - id: {Id} - senha: {Senha}\n{Endereco.ObterDescricaoEndereço()}";
    }
}
