using PizzaComBuilder.Builder;
using PizzaComBuilder.Product;
using System.Collections.Generic;

namespace PizzaComBuilder.ConcreteBuilder;

public sealed class PizzaMussarela : PizzaBuilder
{
    public override void PreparaMassa()
    {
        pizza.TipoMassa = TipoMassa.Fina;
        pizza.TipoBorda = TipoBorda.Recheada;
        pizza.Tamanho = Tamanho.Media;
    }
    public override void IncluirIngredientes()
    {
        pizza.Ingredientes.Add("Queijo mussarela");
        pizza.Ingredientes.Add("Molho de tomate");
        pizza.Ingredientes.Add("Orégano");

    }
}