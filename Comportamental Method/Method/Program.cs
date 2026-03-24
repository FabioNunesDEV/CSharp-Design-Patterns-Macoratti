// =============================================================================
// Padrão Comportamental: Template Method
// =============================================================================
//
// Definição (GoF):
//   Define o esqueleto de um algoritmo em uma operação na classe base,
//   adiando algumas etapas para as subclasses. O Template Method permite que
//   subclasses redefinam certas etapas de um algoritmo sem alterar sua estrutura.
//
// Participantes:
//   - AbstractClass (VideoPlayer)  → Define o Template Method e o esqueleto do algoritmo.
//   - ConcreteClass (VideoMP4, VideoMKV) → Implementam as etapas específicas.
//
// Neste exemplo:
//   Um reprodutor de vídeo (VideoPlayer) define a sequência fixa de passos
//   para executar um vídeo: Carregar → Decodificar → Iniciar Execução.
//   Cada formato de vídeo (MP4, MKV) possui seu próprio decodificador,
//   implementado nas classes concretas.
//
// Diagrama simplificado:
//
//   ┌─────────────────────────┐
//   │     VideoPlayer         │  ← AbstractClass
//   │─────────────────────────│
//   │ + ExecutarVideo()       │  ← Template Method (define a ordem dos passos)
//   │ # CarregarVideo()       │  ← Etapa comum (implementação padrão)
//   │ # DecodificarFormato()  │  ← Etapa abstrata (delegada às subclasses)
//   │ # IniciarExecucao()     │  ← Etapa comum (implementação padrão)
//   └──────────┬──────────────┘
//              ┌┴──────────────────────┐
//   ┌──────────┴──────────┐  ┌────────┴────────────┐
//   │     VideoMP4        │  │     VideoMKV         │  ← ConcreteClasses
//   │─────────────────────│  │─────────────────────│
//   │ # DecodificarFormato│  │ # DecodificarFormato│
//   └─────────────────────┘  └─────────────────────┘
// =============================================================================

Console.WriteLine("============================================");
Console.WriteLine(" Exemplo: Padrão Template Method");
Console.WriteLine(" Reprodutor de Vídeo (Video Player)");
Console.WriteLine("============================================\n");

// --- Reproduzindo vídeo MP4 ---
// A variável é do tipo da classe abstrata (VideoPlayer),
// mas recebe uma instância da classe concreta (VideoMP4).
// Isso demonstra o polimorfismo: o cliente trabalha com a abstração.
Console.WriteLine("► Reproduzindo vídeo MP4:");
Console.WriteLine("--------------------------------------------");
VideoPlayer playerMP4 = new VideoMP4();
playerMP4.ExecutarVideo();

Console.WriteLine();

// --- Reproduzindo vídeo MKV ---
// Mesma estrutura, formato diferente.
// O Template Method garante que a sequência de passos é a mesma,
// apenas a decodificação muda conforme a classe concreta.
Console.WriteLine("► Reproduzindo vídeo MKV:");
Console.WriteLine("--------------------------------------------");
VideoPlayer playerMKV = new VideoMKV();
playerMKV.ExecutarVideo();

Console.WriteLine("\n============================================");
Console.WriteLine(" Observações sobre o padrão:");
Console.WriteLine("============================================");
Console.WriteLine(" • O fluxo (carregar → decodificar → executar) é fixo.");
Console.WriteLine(" • O cliente NÃO controla a ordem dos passos.");
Console.WriteLine(" • Cada formato implementa apenas o que é específico.");
Console.WriteLine(" • Código comum fica centralizado na classe abstrata.");
Console.WriteLine(" • Evita duplicação de código entre os formatos.");
Console.WriteLine("============================================");
