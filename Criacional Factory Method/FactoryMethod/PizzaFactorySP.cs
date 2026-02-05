
namespace FactoryMethod
{
    //Concrete Creator
    public class PizzaFactorySP:PizzaFactoryMethod
    {
        protected override Pizza CriarPizza(string tipo)
        {
            Pizza pizza = null;
            if (tipo == "C")
            {
                return pizza = new PizzaCalabrezaSP();
            }
            if (tipo == "M")
            {
                return pizza = new PizzaMussarelaSP();
            }
            else return null;

        }
    }
}
