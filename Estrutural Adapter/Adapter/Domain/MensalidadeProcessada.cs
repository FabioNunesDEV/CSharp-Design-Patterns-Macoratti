namespace Adapter.Domain;

// Resultado do processamento feito pelo Adaptee.
public sealed record MensalidadeProcessada(string Nome, string Curso, decimal ValorMensalidade);
