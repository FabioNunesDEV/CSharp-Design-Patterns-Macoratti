using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSimpleFactory
{
    public class PizzaCalabreza : Pizza
    {
        public string Nome { get; set; }

        public PizzaCalabreza()
        {
            Nome = "Pizza de Calabresa";
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
