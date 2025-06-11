using System;

using TrabObjetos;

namespace TrabObjetos;

public interface IEntidade
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public string ObterDescricao()
    {
        return "";
    }

}
