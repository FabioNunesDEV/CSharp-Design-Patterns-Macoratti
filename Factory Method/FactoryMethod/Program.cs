// Este código chama cada possibilidade de pizzaria concreta sem se preocupar com a criação dos objetos.
using System;

namespace FactoryMethod
{
    // Client
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo à Pizzaria Factory Method!");

            Pizza pizza;

            pizza = FazerPizza("SP", "C");
            ExibirDetalhes(pizza);

            pizza = FazerPizza("SP", "M");
            ExibirDetalhes(pizza);

            pizza = FazerPizza("RJ", "C");
            ExibirDetalhes(pizza);

            pizza = FazerPizza("RJ", "M");
            ExibirDetalhes(pizza);

            Pizza pizzaDesconhecida = FazerPizza("SP", "X");
            ExibirDetalhes(pizzaDesconhecida);

            Console.ReadKey();  
        }

        static Pizza FazerPizza(string local, string tipo)
        {
            PizzaFactoryMethod pizzaria = PizzaSimpleFactory.CriarPizzaria(local);
            var pizza = pizzaria.MontaPizza(tipo);

            return pizza;
        }

        static void ExibirDetalhes(Pizza pizza)
        {
            if (pizza != null)
            {
                Console.WriteLine(pizza.Preparar());
                Console.WriteLine(pizza.Cozinhar());
                Console.WriteLine(pizza.Cortar());
                Console.WriteLine(pizza.Embalar());
                Console.WriteLine("--------------------------------");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Tipo de pizza desconhecido.");
            }
        }
    }

}
