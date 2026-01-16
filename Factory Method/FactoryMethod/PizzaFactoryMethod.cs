

namespace FactoryMethod
{
    // creator
    public abstract class PizzaFactoryMethod
    {
        public Pizza MontaPizza(string tipo)
        {
            Pizza pizza = CriarPizza(tipo);

            return pizza;
        }

        protected abstract Pizza CriarPizza(string tipo);

    }
}
