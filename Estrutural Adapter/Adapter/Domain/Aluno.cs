namespace Adapter.Domain;

// Modelo de domínio utilizado pelo sistema de mensalidades (Adaptee).
// Repare que este é o formato "rico" em tipos (objeto), diferente do `string[]` do cliente.
public sealed record Aluno(string Nome, string Curso, decimal Mensalidade);
