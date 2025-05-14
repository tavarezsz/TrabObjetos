using System;
using System.Security.AccessControl;

namespace TrabObjetos;

public class Admin:Usuario
{
    public string Acesso{get;set;}

    public Admin(int id, string nome,string senha){
        Id = id;
        Nome = nome;
        Senha = senha;
        Acesso = "admin";
    }
    public override string ObterDescricao(){
        return $"Administrador {Nome} - id: {Id} - senha: {Senha}";
    }
}
