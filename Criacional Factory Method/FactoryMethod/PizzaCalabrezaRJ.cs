
namespace FactoryMethod
{
    // Concrete Product
    public class PizzaCalabrezaRJ:Pizza
    {
        public PizzaCalabrezaRJ()
        {
            Nome = "Pizza de Calabresa à Moda do Rio de Janeiro";
            Massa = "Massa grossa e macia carioca";
            Molho = "Molho de tomate temperado à moda carioca";
            Ingredientes.Add("Calabresa em cubos");
            Ingredientes.Add("Cebolas brancas");
            Ingredientes.Add("Azeitonas pretas");
        }
    }
}
