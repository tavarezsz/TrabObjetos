using System;
using Microsoft.VisualBasic;
using TrabObjetos;

namespace Gerenciadores;

public interface IRepositorio<T> where T: IEntidade
{
    
    T BuscarPorNome(string nome);
    void AdicionarItem(T item);
    void ListarItens(string msg);
    bool ExcluirItem(int id);
    List<T> Consulta(string keyword);

}
