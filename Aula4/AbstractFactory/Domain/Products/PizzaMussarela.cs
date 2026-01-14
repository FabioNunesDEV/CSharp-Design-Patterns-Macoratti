namespace AbstractFactory.Domain.Products
{
    public sealed class PizzaMussarela : Pizza
    {
        public PizzaMussarela() : base("Pizza Mussarela", Enums.TipoMassa.Pizza)
        {
            Ingredientes.Add("Molho de tomate");
            Ingredientes.Add("Queijo mussarela");
            Ingredientes.Add("Orégano");
        }    
    }
}
