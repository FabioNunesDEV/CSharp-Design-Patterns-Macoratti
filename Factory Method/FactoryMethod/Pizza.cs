
namespace FactoryMethod
{
    // Product
    public abstract class Pizza
    {
        protected string Nome { get; set; } 
        protected string Massa { get; set; }
        protected string Molho { get; set; }
        
        protected List<string> Ingredientes = new List<string>();

        public string Preparar()
        {
            return $"Preparando {Nome} \nMassa {Massa} \nMolho {Molho} \nIngredientes: {{ \n{string.Join(", ", Ingredientes)} \n}}";
        }

        public virtual string Cozinhar()
        {
            return "Cozinhar por 25 minutos a 350 graus.";
        }

        public virtual string Cortar()
        {
            return "Fatiar a pizza em 8 pedaços";
        }

        public virtual string Embalar()
        {
            return "Colocar a pizza na caixa oficial da pizzaria.";
        }
    }
}
