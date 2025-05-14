using System;
using System.Collections;
using System.ComponentModel;
using System.Dynamic;
using System.Reflection.Metadata;

namespace TrabObjetos.models;

public class InterfaceGrafica
{
    private const int max_items=10;

    public Usuario[] listaUsers = new Usuario[max_items];
    private int contUser=1; //1 por causa do master
    public Fornecedor[] listaFornecedores = new Fornecedor[max_items];
    private int contFornecedor=0;
    public Produto[] listaProdutos = new Produto[max_items];
    private int contProduto=0;
    public Transportadora[] listaTransportadoras = new Transportadora[max_items];
    private int contTransportadora=0;

    public InterfaceGrafica(){

        Admin master = new Admin(0,"adm","123");
        listaUsers[0] = master;

    }

    public void InserirUsuario(){

        Console.WriteLine("-----------Cadastro de Usuario -----------");

        Console.WriteLine("Nivel de acesso do usuario(admin/cliente):");
        string acesso = Console.ReadLine();

        Console.WriteLine("Nome:");
        string nome = Console.ReadLine();

        Console.WriteLine("Senha:");
        string senha = Console.ReadLine();

       if(acesso.ToLower() == "cliente"){
            Console.WriteLine("Por favor cadastre o endreço do cliente");
            Endereço endereco = InserirEndereco();
            Cliente c = new Cliente(contUser,nome,senha,endereco);
            listaUsers[contUser++]= c;

            Console.WriteLine("usuario criado com sucesso");
       }
       else if(acesso.ToLower() == "admin"){
            Admin a = new Admin(contUser,nome,senha);
            listaUsers[contUser++] = a;
       }
        

    }

    public void ListarUsuarios(){
        foreach (var user in listaUsers) //ja fica meio pronto para listas
        {
            if(user!=null)
                Console.WriteLine(user.ObterDescricao());
        }
    }

    public Endereço InserirEndereco(){

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

        Endereço e = new Endereço(rua,numero,complemento,bairro,cep,cidade,estado);

        return e;
    }



}
