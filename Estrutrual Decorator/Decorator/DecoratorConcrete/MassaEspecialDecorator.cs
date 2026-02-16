using Decorator.Component;
using Decorator.Decorator;

namespace Decorator.DecoratorConcrete;

public class MassaEspecialDecorator: PizzaDecorator
{
    public MassaEspecialDecorator(IPizza pizza) : base(pizza)
    {
    }
    public override string Opcionais()
    {
        var opcionais = base.Opcionais() + ", com massa especial";
        return opcionais;
    }
    public override decimal Preco()
    {
        var preco = base.Preco() + 8.00M;
        return preco;
    }


}
