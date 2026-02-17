

namespace Flyweight;

// FlyweightFactory
// Responsável por criar e gerenciar o conjunto (cache) de Flyweights.
// Regra central do padrão: se um Flyweight com o mesmo estado intrínseco já existir,
// ele deve ser reutilizado ao invés de criar um novo objeto.
public class FormaFactory
{
    // Cache de Flyweights.
    // A chave representa o "tipo"/identidade do estado intrínseco que será compartilhado.
    public static Dictionary<string, IForma> formas = new Dictionary<string, IForma>();    

    // Retorna um Flyweight existente (se estiver no cache) ou cria, armazena e retorna.
    public static IForma GetForma(string chave)
    {
        IForma forma;
        if (formas.ContainsKey(chave))
        {
            return formas[chave];
        }
        else
        {
            if (chave == "circulo")
            {
                // Neste exemplo, o objeto criado (`Circulo`) contém o estado intrínseco.
                // As variações (estado extrínseco), como a cor, são atribuídas pelo cliente.
                forma = new Circulo();
                formas.Add(chave, forma);

            }
            else 
            {
                throw new Exception("Este tipo de objeto não pode ser criado");
            }
        }
        return forma;
    }
}