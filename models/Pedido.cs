using System;
using System.ComponentModel;
using TrabObjetos.models;

namespace TrabObjetos;

public class Pedido
{   
    public int Id { get; set; }
    public int NumeroPedido;
    public DateTime DataHoraPedido;
    public DateTime DataHoraEntrega;
    public String Situação;
    public double PreçoFrete;

    public Pedido(int numeropedido, DateTime datapedido, DateTime dataentrega, String situacao, double preçofrete){
        this.NumeroPedido=numeropedido;
        this.DataHoraEntrega=datapedido;
        this.DataHoraEntrega=dataentrega;
        this.Situação=situacao;
        this.PreçoFrete=preçofrete;
    }

    

}
