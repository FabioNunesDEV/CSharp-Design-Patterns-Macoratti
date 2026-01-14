using AbstractFactory.Domain.Enums;
using AbstractFactory.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Factory.AbstractFactory
{
    public sealed class PizzaFactory:MassaAbstractFactory
    {
        public override MassaBase CriaMassa(TipoMassa tipoMassa)
        {
            var tipoPizza = (TipoPizza)tipoMassa;
            switch (tipoPizza)
            {
                case TipoPizza.Mussarela:
                    return new PizzaMussarela();
                case TipoPizza.Calabresa:
                    return new PizzaCalabreza();
                default:
                    throw new ArgumentOutOfRangeException("Tipo não implementado");
            }
        }
    }
}
