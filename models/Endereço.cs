using System;

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

    public void AlterarEndereço(String NovaRua = null, String NovoNumero = null, String NovoComplemento = null, String NovoBairro = null, String NovoCep = null, String NovaCidade = null, String NovoEstado = null ){
        if(NovaRua!=null){
            this.Rua= NovaRua;    
        }
        if(NovoNumero!=null){
            this.Número=NovoNumero;
        }
        if(NovoComplemento!=null){
            this.Complemento=NovoComplemento;
        }
        if(NovoBairro!=null){
            this.Bairro=NovoBairro;
        }
        if(NovoCep!=null){
            this.Cep=NovoCep;
        }
        if(NovaCidade!=null){
            this.Cidade=NovaCidade;
        }
        if(NovoEstado!=null){
            this.Estado=NovoEstado;
        }
    }
    public String ObterDescricaoEndereço()
    {
        return $"Rua: {Rua}, Número: {Número}, Complemento: {Complemento}, CEP: {Cep}, Cidade: {Cidade}, Estado: {Estado}.";
    }
}
