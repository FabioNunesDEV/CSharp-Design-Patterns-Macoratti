using Decorator.Component;

namespace Decorator.ComponentConcrete;

public class Pizza : IPizza
{
    public string Opcionais()
    {
        string opcionais = "Pizza padrão ou normal";
        return opcionais;
    }

    public decimal Preco()
    {
        decimal preco = 10.00M;
        return preco; 
    }
}
