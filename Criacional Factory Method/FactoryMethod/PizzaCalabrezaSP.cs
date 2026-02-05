
namespace FactoryMethod
{
    // Concrete Product
    public class PizzaCalabrezaSP:Pizza
    {
        public PizzaCalabrezaSP()
        {
            Nome = "Pizza de Calabresa à Moda de São Paulo";
            Massa = "Massa fina crocante paulistana";
            Molho = "Molho de tomate italiano paulista";
            Ingredientes.Add("Calabresa fatiada");
            Ingredientes.Add("Cebolas roxas");
            Ingredientes.Add("Orégano");
        }    
    }
}
