using System;
using TrabObjetos;
namespace TrabObjetos.models;

public class Transportadora : IEntidade
{
    public int Id {get;set;}
    public String Nome {get;set;}
    public double PrecoKm {get;set;}

    public Transportadora(String nome,double precoKm){
        Nome = nome;
        PrecoKm = precoKm;
    }

    public string ObterDescricao(){
        return $"{Id} - {Nome} - Preço por Km: R${PrecoKm}";
    }

}
