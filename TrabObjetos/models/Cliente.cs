using System;

namespace TrabObjetos.models;

public class Cliente : Usuario
{
    public Endereço Endereco { get; set; }
    public IRepositorio<Pedido> Pedidos;

    public Cliente(string nome, string senha, Endereço endereco)
    {
        Nome = nome;
        Senha = senha;
        Acesso = "cliente";
        Endereco = endereco;
    }

    public override string ObterDescricao()
    {
        return $"Cliente {Nome} - id: {Id} - senha: {Senha}\n{Endereco.ObterDescricaoEndereço()}";
    }

    public void AdicionarPedido(Pedido pedido)
    {
        Pedidos.AdicionarItem(pedido);
    }

//    public List<Pedido> ObterPedidos() {
 //       return Pedidos.Consulta("asdf", true);
  //  }

    public void MeusPedidos()
    {

    }



}
