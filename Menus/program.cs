
using System.Security.Cryptography.X509Certificates;
using Menus;
using TrabObjetos;
using TrabObjetos.models;
public class Program
{

    public static void Main(String[] args)
    {

        Console.WriteLine("Deseja usar listas ou vetores?  ");
        string tipo = Console.ReadLine();
        InterfaceGrafica ig = new InterfaceGrafica(tipo);

    }
}