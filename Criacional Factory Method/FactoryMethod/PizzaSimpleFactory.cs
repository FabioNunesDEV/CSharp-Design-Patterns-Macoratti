using System;

namespace FactoryMethod
{
    public class PizzaSimpleFactory
    {
        public static PizzaFactoryMethod CriarPizzaria(string local)
        {
            if (local == "SP")
            {
                return new PizzaFactorySP();
            }
            else if (local == "RJ")
            {
                return new PizzaFactoryRJ();
            }
            else
            {
                throw new ArgumentException("Localização desconhecida da pizzaria");
            }
        }
    }
}
