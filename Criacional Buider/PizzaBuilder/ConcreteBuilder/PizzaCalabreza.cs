using PizzaComBuilder.Builder;
using PizzaComBuilder.Product;
using System.Collections.Generic;

namespace PizzaComBuilder.ConcreteBuilder;

public sealed class PizzaCalabreza : PizzaBuilder
{
    public override void PreparaMassa()
    {
        pizza.TipoMassa = TipoMassa.Grossa;
        pizza.TipoBorda = TipoBorda.Normal;
        pizza.Tamanho = Tamanho.Grande;
    }

    public override void IncluirIngredientes()
    {
        pizza.Ingredientes.Add("Fatias de calabreza");
        pizza.Ingredientes.Add("Molho de tomate");
        pizza.Ingredientes.Add("Fatias de cebola");
    }
}
