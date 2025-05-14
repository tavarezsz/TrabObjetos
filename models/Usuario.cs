using System;

namespace TrabObjetos;

public  abstract class Usuario
{
    public int Id {get;set;}
    public string Nome {get;set;}
    public string Senha{get;set;}

    public bool Login(string senhaTentada){
        if(this.Senha == senhaTentada)
            return true;
        return false;
    }

    public void AlterarCadastro(string novoNome = null,string novaSenha = null){
        if(novoNome != null)
            Nome = novoNome;

        if(novaSenha != null)
            Senha = novaSenha;
    }    
    public virtual string ObterDescricao(){
        return"so para herança";
    }
}
