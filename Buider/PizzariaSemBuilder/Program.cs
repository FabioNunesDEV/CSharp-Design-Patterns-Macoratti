using System;
using System.Collections.Generic;

namespace PizzariaSemBuilder;

class Program
{
    static void Main(string[] args)
    {
        Pizza pizza1 = new Pizza(TipoMassa.Fina, Tamanho.Media, TipoBorda.Recheada, new List<string> { "Calabresa", "Cebola", "Azeitona" });
        pizza1.PizzaConteudo();

        Pizza pizza2 = new Pizza(TipoMassa.Grossa, Tamanho.Grande, TipoBorda.Normal, new List<string> { "Frango", "Catupiry", "Milho", "Ervilha" });
        pizza2.PizzaConteudo();
    }
}
