using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaSemFactory
{
    public class PizzaCalabreza
    {
        public string Nome { get; set; }

        public PizzaCalabreza()
        {
            Nome = "Pizza de Calabresa";
        }

        public void Preparar()
        {
            Console.WriteLine($"\nPreparando {Nome}...");
        }

        public void Assar(int tempo)
        {
            Console.WriteLine($"\n{Nome} assando por {tempo} min.");
        }

        public void Embalar()
        {
            Console.WriteLine($"\nEmbalando {Nome}...\n");
        }
    }
}
