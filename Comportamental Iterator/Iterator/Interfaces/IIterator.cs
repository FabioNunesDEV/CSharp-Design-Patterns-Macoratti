namespace Iterator.Interfaces;

/// <summary>
/// Iterator (GoF): contrato que define a navegação sequencial sem expor a estrutura interna da coleção.
/// </summary>
/// <typeparam name="T">Tipo de elemento percorrido.</typeparam>
public interface IIterator<T>
{
    /// <summary>
    /// Posiciona no primeiro elemento da coleção e o retorna. Útil para reiniciar a travessia.
    /// </summary>
    T? First();

    /// <summary>
    /// Avança para o próximo elemento e o retorna. Quando não houver próximo, deve retornar null.
    /// </summary>
    T? Next();

    /// <summary>
    /// Indica se a travessia alcançou o final da coleção, encerrando o ciclo de navegação.
    /// </summary>
    bool IsDone { get; }

    /// <summary>
    /// Retorna o elemento atualmente apontado pelo iterador sem alterar a posição.
    /// </summary>
    T? CurrentItem { get; }
}
