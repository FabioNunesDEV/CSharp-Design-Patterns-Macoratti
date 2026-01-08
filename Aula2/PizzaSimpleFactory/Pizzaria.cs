using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSimpleFactory
{
    public class Pizzaria
    {
        public static void SolicitaPizza()
        {
            Console.WriteLine("Bem vindo a Pizzaria Sem Factory!");
            Console.WriteLine("Qual pizza deseja solicitar? (1 - Calabresa, 2 - Mussarela)");
            var pizzaEscolhida = Console.ReadLine();

            try
            {
                Pizza pizza = PizzaSimpleFactory.CriarPizza(pizzaEscolhida);
                pizza.Preparar();
                pizza.Assar(30);
                pizza.Embalar();    
                Console.WriteLine("Pedido concluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }            
        }
    }
}
