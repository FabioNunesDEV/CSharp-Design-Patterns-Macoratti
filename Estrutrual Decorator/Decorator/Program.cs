using Decorator.Component;
using Decorator.ComponentConcrete;
using Decorator.Decorator;
using Decorator.DecoratorConcrete;

IPizza pizza = new Pizza();

Console.WriteLine(pizza.Opcionais());
Console.WriteLine($"Preço: R${pizza.Preco()}");
Console.WriteLine(new string('-', 40) + "\n\r");

pizza = new BordaRecheadaDecorator(pizza);
Console.WriteLine(pizza.Opcionais());
Console.WriteLine($"Preço: R${pizza.Preco()} \n\r");

pizza = new MassaEspecialDecorator(pizza);
Console.WriteLine(pizza.Opcionais());
Console.WriteLine($"Preço: R${pizza.Preco()} \n\r");

Console.ReadKey();