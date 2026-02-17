namespace Flyweight;

// ConcreteFlyweight
// Armazena apenas o estado intrínseco (imutável/compartilhável) e expõe operações
// que usam também o estado extrínseco (variável) fornecido pelo cliente.
public class Circulo: IForma
{
    // Estado EXTRÍNSECO (não deve ser compartilhado): varia conforme o contexto de uso.
    // No exemplo, a mesma instância de `Circulo` é reutilizada no cache.
    // Por isso, a cor é atribuída toda vez antes de desenhar.
    public string Cor { get; set; }

    // Estado INTRÍNSECO (compartilhável): parte fixa do objeto.
    // Em um Flyweight real, esses dados deveriam ser tratados como imutáveis.
    // Aqui eles são campos privados inicializados uma única vez.
    private int x = 10;
    private int y = 20;
    private int raio = 30;

    // Ajusta o estado extrínseco para o contexto corrente.
    public void SetCor(string cor)
    {
        this.Cor = cor;
    }

    // Operação do Flyweight.
    // Usa o estado intrínseco (x, y, raio) armazenado no objeto
    // + o estado extrínseco (Cor) fornecido pelo cliente.
    public void Desenhar()
    {
        Console.WriteLine($"Circulo: Desenhar() [Cor: {Cor}, x: {x}, y: {y}, raio: {raio}]");
    }
}
