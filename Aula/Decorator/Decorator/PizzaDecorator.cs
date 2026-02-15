using Decorator.Component;

namespace Decorator.Decorator;

public class PizzaDecorator: IPizza
{
    private readonly IPizza _pizza;

    public PizzaDecorator(IPizza pizza)
    {
        _pizza = pizza;
    }

    public virtual string Opcionais()
    {
        var opcionais = _pizza.Opcionais();
        return opcionais;
    }

    public virtual decimal Preco()
    {
        var preco = _pizza.Preco();         
        return preco;
    }
}