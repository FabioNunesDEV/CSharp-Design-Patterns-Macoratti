namespace AbstractFactory.Domain.Products
{
    public sealed class Bolochocolate : Bolo
    {
        public Bolochocolate() : base("Bolo de Chocolate", Enums.TipoMassa.Bolo)
        {
            Ingredientes.Add("Chocolate");
            Ingredientes.Add("Farinha de trigo");
            Ingredientes.Add("Ovos");
            Ingredientes.Add("Manteiga");
            Ingredientes.Add("Açúcar");
        }
    }
}
