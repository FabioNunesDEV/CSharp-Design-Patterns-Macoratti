
namespace FactoryMethod
{
    // Concrete Product
    public class PizzaMussarelaRJ: Pizza
    {
        public PizzaMussarelaRJ()
        {
            Nome = "Pizza de Mussarela à Moda carioca";
            Massa = "Massa tradicional carioca";
            Molho = "Molho de tomate carioca";
            Ingredientes.Add("Queijo mussarela");
            Ingredientes.Add("Azeitonas pretas");
        }
    }
}
