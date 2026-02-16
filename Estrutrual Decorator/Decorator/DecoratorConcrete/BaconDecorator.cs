using Decorator.Component;
using Decorator.Decorator;

namespace Decorator.DecoratorConcrete;

public class BaconDecorator: PizzaDecorator
{
    public BaconDecorator(IPizza pizza) : base(pizza)
    {
    }
    public override string Opcionais()
    {
        var opcionais = base.Opcionais() + ", com bacon";
        return opcionais;
    }
    public override decimal Preco()
    {
        var preco = base.Preco() + 5.00M;         
        return preco;
    }

}
