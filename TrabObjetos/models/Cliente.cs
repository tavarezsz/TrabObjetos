using System;

namespace TrabObjetos;

public class Cliente:Usuario
{
    public Endereço Endereco{get;set;}
    public Pedido[] Pedidos = new Pedido[10];

    public Cliente(string nome,string senha,Endereço endereco){
        Nome = nome;
        Senha = senha;
        Acesso = "cliente";
        Endereco = endereco;
    }

    public override string ObterDescricao(){
        return $"Cliente {Nome} - id: {Id} - senha: {Senha}\n{Endereco.ObterDescricaoEndereço()}";
    }
}
