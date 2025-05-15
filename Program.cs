using System.Runtime.CompilerServices;
using TrabObjetos;
using TrabObjetos.models;


Endereço e1 = new Endereço("julio","542","ap","lourdes","1234","Caxias","RS");
Fornecedor f1 = new Fornecedor(1,"comp","fornecedor alimentos","9999","c@gmail",e1);


Produto cafe = new Produto(1,"Café soluvel 300g",f1,10);

InterfaceGrafica ig = new InterfaceGrafica();


ig.InserirUsuario();

//Usuario u0 = InterfaceGrafica.BuscarPorID(0, ig.listaUsers);
var u1 = InterfaceGrafica.BuscarPorID(1, ig.listaUsers);

Console.WriteLine(u1.Nome);


