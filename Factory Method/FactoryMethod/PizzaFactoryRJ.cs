
namespace FactoryMethod
{
    //Concrete Creator
    public class PizzaFactoryRJ: PizzaFactoryMethod
    {
        protected override Pizza CriarPizza(string tipo)
        {
            Pizza pizza = null;
            if (tipo == "C")
            {
                return pizza = new PizzaCalabrezaRJ();
            }
            if (tipo == "M")
            {
                return pizza = new PizzaMussarelaRJ();
            }
            else return null;

        }
    }
}
