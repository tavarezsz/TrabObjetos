using System;
using Gerenciadores;

namespace TrabObjetos.Gerenciadores;

public abstract class GerenciadorEnderecos : GerenciadorListas
{
    //Classe somente para as funções de endereços
     protected Endereço InserirEndereco()
    {

        Console.WriteLine("-----------Cadastro de endereço -----------");

        Console.WriteLine("Rua:");
        string rua = Console.ReadLine();

        Console.WriteLine("Numero:");
        string numero = Console.ReadLine();

        Console.WriteLine("Complemento:");
        string complemento = Console.ReadLine();

        Console.WriteLine("Bairro:");
        string bairro = Console.ReadLine();

        Console.WriteLine("Cep:");
        string cep = Console.ReadLine();

        Console.WriteLine("Estado:");
        string estado = Console.ReadLine();

        Console.WriteLine("Cidade:");
        string cidade = Console.ReadLine();

        Endereço e = new Endereço(rua, numero, complemento, bairro, cep, cidade, estado);

        return e;
    }

    protected Endereço AlterarEndereco(Endereço endereco)
    {
        Console.WriteLine("-----------Alteração de Endereço -----------");


        Console.WriteLine("Se deseja que algum campo permanesça como esta, só aperte enter no campo");

        Console.WriteLine("Rua:");
        string rua = Console.ReadLine();
        if(rua !="")
            endereco.Rua = rua;

        Console.WriteLine("Numero:");
        string numero = Console.ReadLine();
        if(numero !="")
            endereco.Número = numero;

        Console.WriteLine("Complemento:");
        string complemento = Console.ReadLine();
        if(complemento !="")
            endereco.Complemento = complemento;

        Console.WriteLine("Bairro:");
        string bairro = Console.ReadLine();
        if(bairro !="")
            endereco.Bairro = bairro;

        
        Console.WriteLine("Cep:");
        string cep = Console.ReadLine();
        if(cep !="")
            endereco.Cep = cep;

        Console.WriteLine("Estado:");
        string estado = Console.ReadLine();
        if(estado !="")
            endereco.Estado = estado;

        Console.WriteLine("Cidade:");
        string cidade = Console.ReadLine();
        if(cidade !="")
            endereco.Cidade = cidade;

        return endereco;


    }
}
