using AbstractFactory.Domain.Enums;

namespace AbstractFactory.Domain.Products
{
    public abstract class Bolo : MassaBase
    {
        public Bolo(string nome, TipoMassa tipoMassa) : base(nome, tipoMassa)
        {
        }
    }
}
