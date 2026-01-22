using System;
using System.Collections.Generic;

namespace PizzaComBuilder.Product;

public class Pizza
{
    public TipoMassa TipoMassa { get; set; }
    public TipoBorda TipoBorda { get; set; }
    public Tamanho Tamanho { get; set; }
    public List<string> Ingredientes { get; set; } = new List<string>();

    public void PizzaConteudo()
    {
        Console.WriteLine($"Pizza com massa: {TipoMassa}");
        Console.WriteLine($"Tamanho........: {Tamanho}");
        Console.WriteLine($"Tipo Borda.....: {TipoBorda}");
        Console.WriteLine($"Ingredientes...: ");
        foreach (var item in this.Ingredientes)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("---------------------------");
    }
}
