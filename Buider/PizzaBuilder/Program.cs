using PizzaComBuilder.ConcreteBuilder;
using PizzaComBuilder.Director;

internal class Program
{
    private static void Main(string[] args)
    {
        var pizzaria = new Pizzaria(new PizzaMussarela());
        pizzaria.MontarPizza();
        var pizza1 = pizzaria.GetPizza();
        pizza1.PizzaConteudo();

        pizzaria = new Pizzaria(new PizzaCalabreza());
        pizzaria.MontarPizza();
        var pizza2 = pizzaria.GetPizza();
        pizza2.PizzaConteudo();

        Console.ReadKey();
    }
}