
using Menus;
public class Program
{

    public static void Main(String[] args)
    {
        Console.WriteLine("Deseja usar listas ou vetores?  ");
        string tipo = Console.ReadLine();
        InterfaceGrafica ig = new InterfaceGrafica(tipo);

    }
}