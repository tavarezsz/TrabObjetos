using System;
using Microsoft.VisualBasic;

namespace TrabObjetos.models;

public interface IRepositorio<T> where T : IEntidade
{
    public int cont { get; set; }
    T BuscarPorNome(string nome);
    void AdicionarItem(T item);
    void ListarItens(string msg);
    bool ExcluirItem(int id);
    IList<T> Consulta(string keyword);
    void SalvarDados(string arquivo);
    void CarregarDados(string arquivo);

}
