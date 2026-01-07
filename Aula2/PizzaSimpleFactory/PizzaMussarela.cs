using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSimpleFactory
{
    public class PizzaMussarela : Pizza
    {
        public string Nome { get; set; }

        public PizzaMussarela()
        {
            Nome = "Pizza de Mussarela";
        }

        public override void Preparar()
        {
            Console.WriteLine($"\nPreparando {Nome}...");
        }

        public override void Assar(int tempo)
        {
            Console.WriteLine($"\n{Nome} assando por {tempo} min.");
        }

        public override void Embalar()
        {
            Console.WriteLine($"\nEmbalando {Nome}...\n");
        }
    }
}
