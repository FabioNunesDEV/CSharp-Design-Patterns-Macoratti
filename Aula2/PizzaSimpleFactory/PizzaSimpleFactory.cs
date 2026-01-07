using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSimpleFactory
{
    public class PizzaSimpleFactory
    {
        public static Pizza CriarPizza(string tipoPizza)
        {
            switch (tipoPizza)
            {
                case "1":
                    return new PizzaCalabreza();
                case "2":
                    return new PizzaMussarela();
                default:
                    throw new Exception("Tipo de pizza inválido.");
            }
        }
    }
}
