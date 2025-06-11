using System;
using System.Security.AccessControl;

namespace TrabObjetos;

public class Admin:Usuario
{
    public Admin(string nome,string senha){
        Nome = nome;
        Senha = senha;
        Acesso = "admin";
    }
    public override string ObterDescricao(){
        return $"Administrador {Nome} - id: {Id} - senha: {Senha}";
    }
}
