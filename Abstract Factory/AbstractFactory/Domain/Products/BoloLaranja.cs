namespace AbstractFactory.Domain.Products
{
    public sealed class BoloLaranja : Bolo
    {
        public BoloLaranja() : base("Bolo de Laranja", Enums.TipoMassa.Bolo)
        {
            Ingredientes.Add("Laranja");
            Ingredientes.Add("Farinha de trigo");
            Ingredientes.Add("Ovos");
            Ingredientes.Add("Manteiga");
            Ingredientes.Add("Açúcar");
        }
    }    
}
