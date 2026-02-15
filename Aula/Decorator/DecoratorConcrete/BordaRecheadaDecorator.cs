using Decorator.Component;
using Decorator.Decorator;

namespace Decorator.DecoratorConcrete;

public class BordaRecheadaDecorator : PizzaDecorator
{
    public BordaRecheadaDecorator(IPizza pizza) : base(pizza)
    {
    }
    public override string Opcionais()
    {
        var opcionais = base.Opcionais() + ", com borda recheada";
        return opcionais;
    }
    public override decimal Preco()
    {
        var preco = base.Preco() + 7.00M;
        return preco;
    }
}

