namespace Flyweight;

// Flyweight (Interface)
// Define o contrato comum para os objetos que podem ser compartilhados.
// No padrão Flyweight, essa interface costuma receber (diretamente ou indiretamente)
// o estado extrínseco durante a execução.
public interface IForma
{
    // Operação do Flyweight.
    // No exemplo, o método usa o estado intrínseco (x, y, raio) armazenado no objeto
    // e o estado extrínseco (ex.: cor) fornecido/ajustado pelo cliente em tempo de execução.
    void Desenhar();
}
