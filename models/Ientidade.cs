using System;

namespace TrabObjetos.models;

public interface Ientidade
{
    int Id { get; set; }
    string Nome { get; set; }

    public string ObterDescricao()
    {
        return "";
    }
    public void AlterarCadastro()
    {
        
    }
}
