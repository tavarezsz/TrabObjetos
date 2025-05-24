using System;
using TrabObjetos.models;

namespace TrabObjetos;

public class Endereço
{
    public String Rua{get;set;}
    public String Número{get;set;}
    public String Complemento{get;set;}
    public String Bairro{get;set;}
    public String Cep{get;set;}
    public String Cidade{get;set;}
    public String Estado{get;set;}

    public Endereço(String rua, String numero, String complemento, String bairro, String cep, String cidade, String estado){
        this.Rua=rua;
        this.Número=numero;
        this.Complemento=complemento;
        this.Bairro=bairro;
        this.Cep=cep;
        this.Cidade=cidade;
        this.Estado=estado;
    }

    public String ObterDescricaoEndereço()
    {
        return $"Rua: {Rua}, Número: {Número}, Complemento: {Complemento}, CEP: {Cep}, Cidade: {Cidade}, Estado: {Estado}.";
    }
}
