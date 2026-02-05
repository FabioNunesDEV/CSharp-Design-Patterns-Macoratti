using Prototype.DeepCopy;
using Prototype.ShallowCopy;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Padrão Prototype (GoF) - Exemplo (Shallow Copy vs Deep Copy)\n");

Console.WriteLine("=== Shallow Copy (cópia superficial) ===");
Console.WriteLine();
{


    var original = new Prototype.ShallowCopy.Soldado
    {
        Nome = "Soldado Original",
        Arma = "Fuzil",
        Acessorio = new Prototype.ShallowCopy.Acessorio { Nome = "Visão Noturna" }
    };

    var clone1 = (Prototype.ShallowCopy.Soldado)original.Clone();
    clone1.Nome = "Clone 1";
    clone1.Arma = "Fuzil Kalashnikov";
    clone1.Acessorio.Nome = "Colete Especial";

    var clone2 = (Prototype.ShallowCopy.Soldado)original.Clone();
    clone2.Nome = "Clone 2";
    clone2.Arma = "AK-105";
    clone2.Acessorio.Nome = "Arma Super Secreta";

    Console.WriteLine(original);
    Console.WriteLine(clone1);
    Console.WriteLine(clone2);
    Console.WriteLine("Observação: em Shallow Copy, o acessório é compartilhado (mesma referência).\n");
}

Console.WriteLine("=== Deep Copy (cópia profunda) ===");
Console.WriteLine();
{
    var original = new Prototype.DeepCopy.Soldado
    {
        Nome = "Soldado Original",
        Arma = "Fuzil",
        Acessorio = new Prototype.DeepCopy.Acessorio { Nome = "Visão Noturna" }
    };

    var clone1 = (Prototype.DeepCopy.Soldado)original.Clone();
    clone1.Nome = "Clone 1";
    clone1.Arma = "Fuzil Kalashnikov";
    clone1.Acessorio.Nome = "Colete Especial";

    var clone2 = (Prototype.DeepCopy.Soldado)original.Clone();
    clone2.Nome = "Clone 2";
    clone2.Arma = "AK-105";
    clone2.Acessorio.Nome = "Arma Mortal 2";

    Console.WriteLine(original);
    Console.WriteLine(clone1);
    Console.WriteLine(clone2);
    Console.WriteLine("Observação: em Deep Copy, cada clone possui seu próprio acessório (objetos independentes).");
}
