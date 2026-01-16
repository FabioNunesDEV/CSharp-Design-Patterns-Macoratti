
using AbstractFactory.Domain.Enums;
using AbstractFactory.Domain.Products;

namespace AbstractFactory.Factory.AbstractFactory
{
    // Abstract Factory for Massa products
    public abstract class MassaAbstractFactory
    {
        public abstract MassaBase CriaMassa(TipoMassa tipoMassa);

        public static MassaAbstractFactory CriaFabricaMassas (TipoMassa tipoMassa)
        {
            switch (tipoMassa)
            {   
                case TipoMassa.Pizza:
                    return new PizzaFactory();
                case TipoMassa.Bolo:
                    return new BoloFactory();
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipoMassa),tipoMassa,null);
            }
        }
    }
}
