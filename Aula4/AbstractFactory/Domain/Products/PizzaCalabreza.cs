namespace AbstractFactory.Domain.Products
{
    public sealed class PizzaCalabreza : Pizza
    {
        public PizzaCalabreza() : base("Pizza Calabresa", Enums.TipoMassa.Pizza)
        {
            Ingredientes.Add("Molho de tomate");
        }    
    }
}
