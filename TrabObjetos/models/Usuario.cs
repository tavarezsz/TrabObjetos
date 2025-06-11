using System;
using TrabObjetos.models;

namespace TrabObjetos;

public abstract class Usuario : IEntidade
{
    public int Id {get;set;}
    public string Nome {get;set;}
    public string Senha{get;set;}
    public string Acesso{ get; set;}

    public bool Login(string senhaTentada)
    {
        if (this.Senha == senhaTentada)
            return true;
        return false;
    }

    public virtual string ObterDescricao(){
        return"so para herança";
    }
}
