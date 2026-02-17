using Flyweight;

// Client
// O cliente não cria `Circulo` diretamente. Ele solicita à `FormaFactory` um Flyweight
// (compartilhável) e fornece/ajusta o estado extrínseco (a cor) antes de chamar a operação.

Console.WriteLine("\n### Círculos Amarelos ");
for (int i = 0; i<3; i++)
{
    // Repare que `GetForma("circulo")` sempre retorna a MESMA instância cacheada.
    // O que muda a cada uso é o estado extrínseco (cor) definido abaixo.
    Circulo circulo = (Circulo)FormaFactory.GetForma("circulo");
    circulo.SetCor("Amarelo");
    circulo.Desenhar();
}

Console.WriteLine("\n### Círculos Vermelhos ");
for (int i = 0; i<3; i++)
{
    Circulo circulo = (Circulo)FormaFactory.GetForma("circulo");
    circulo.SetCor("Vermelho");
    circulo.Desenhar();
}

Console.WriteLine("\n### Círculos Verdes ");
for (int i = 0; i<3; i++)
{
    Circulo circulo = (Circulo)FormaFactory.GetForma("circulo");
    circulo.SetCor("Verde");
    circulo.Desenhar();
}

Console.WriteLine("\n### Círculos Azuis ");
for (int i = 0; i<3; i++)
{
    Circulo circulo = (Circulo)FormaFactory.GetForma("circulo");
    circulo.SetCor("Azul");
    circulo.Desenhar();
}

// Se o padrão estiver funcionando como esperado, apenas 1 Flyweight foi criado
// (um único `Circulo` no cache), mesmo após vários usos com cores diferentes.
Console.WriteLine("\n Quantidade de objetos criados: " + FormaFactory.formas.Count);