using System;
using TrabObjetos;
namespace TrabObjetos.models;

public class Transportadora : Ientidade
{
    public int Id {get;set;}
    public String Nome {get;set;}
    public double PrecoKm {get;set;}

    public Transportadora(int id,String nome,double precoKm){
        Id = id;
        Nome = nome;
        PrecoKm = precoKm;
    }

    public string ObterDescricao(){
        return $"{Id} - {Nome} - Preço por Km: R${PrecoKm}";
    }

}
