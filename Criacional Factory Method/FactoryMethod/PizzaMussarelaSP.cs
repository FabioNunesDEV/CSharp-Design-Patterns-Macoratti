
namespace FactoryMethod
{
    // Concrete Product
    public class PizzaMussarelaSP : Pizza
    {
        public PizzaMussarelaSP()
        {
            Nome = "Pizza de Mussarela à Moda de São Paulo";
            Massa = "Massa fina crocante paulistana";
            Molho = "Molho de tomate italiano paulista";
            Ingredientes.Add("Queijo parmessão");
            Ingredientes.Add("Azeitonas verdes");
        }
    }
}
