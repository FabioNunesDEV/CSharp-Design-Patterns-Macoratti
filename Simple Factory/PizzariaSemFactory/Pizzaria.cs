using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaSemFactory
{
    public class Pizzaria
    {
        public static void SolicitaPizza()
        {
            PizzaCalabreza pizzaCalabreza;
            PizzaMussarela pizzaMussarela;
            Console.WriteLine("Bem vindo a Pizzaria Sem Factory!");
            Console.WriteLine("Qual pizza deseja solicitar? (1 - Calabresa, 2 - Mussarela)");
            var pizzaEscolhida = Console.ReadLine();

            if (pizzaEscolhida == "1")
            {
                pizzaCalabreza = new PizzaCalabreza();
                pizzaCalabreza.Preparar();
                pizzaCalabreza.Assar(30);
                pizzaCalabreza.Embalar();
            }
            else if (pizzaEscolhida == "2")
            {
                pizzaMussarela = new PizzaMussarela();
                pizzaMussarela.Preparar();
                pizzaMussarela.Assar(25);
                pizzaMussarela.Embalar();
            }
            else
            {
                Console.WriteLine("Opção inválida. Por favor, escolha 1 ou 2.");
            }
        }
    }
}
