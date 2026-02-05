using PizzaComBuilder.Builder;
using PizzaComBuilder.Product;  

namespace PizzaComBuilder.Director;

public class Pizzaria
{
    private readonly PizzaBuilder builder;

    public Pizzaria(PizzaBuilder builder)
    {
        this.builder = builder;
    }

    // Construct
    public void MontarPizza()
    {
        builder.CriaPizza();
        builder.PreparaMassa();
        builder.IncluirIngredientes();
    }
    public Pizza GetPizza()
    {
        return builder.GetPizza();
    }
}
