using AbstractFactory.Domain.Enums;
using AbstractFactory.Domain.Products;
using AbstractFactory.Factory.AbstractFactory;

//Obtém as fábricas
var boloFactory = MassaAbstractFactory.CriaFabricaMassas(TipoMassa.Bolo);
var pizzaFactory = MassaAbstractFactory.CriaFabricaMassas(TipoMassa.Pizza);

// Cria os objetos com base no tipo : bolo
var bolo1= boloFactory.CriaMassa((TipoMassa)TipoBolo.Chocolate);
var bolo2= boloFactory.CriaMassa((TipoMassa)TipoBolo.Laranja);

// Cria os objetos com base no tipo : pizza
var pizza1= pizzaFactory.CriaMassa((TipoMassa)TipoPizza.Mussarela);
var pizza2= pizzaFactory.CriaMassa((TipoMassa)TipoPizza.Calabresa);

// Exibe os detalhes
ExibirDetalhes(bolo1);  
ExibirDetalhes(bolo2);
ExibirDetalhes(pizza1);
ExibirDetalhes(pizza2);

Console.ReadLine();

static void ExibirDetalhes (MassaBase massaBase)
{
    Console.WriteLine($"Tipo : {massaBase.TipoMassa}");
    Console.WriteLine(massaBase.Nome);
    foreach (var ingrediente in massaBase.Ingredientes)
        Console.WriteLine(ingrediente);
    Console.WriteLine("-------------------------");
    Console.WriteLine("\n");

}
