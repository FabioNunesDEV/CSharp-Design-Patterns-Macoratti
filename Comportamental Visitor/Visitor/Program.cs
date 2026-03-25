// =============================================================================
// PADRÃO VISITOR - Program (Client)
// =============================================================================
// Papel no padrão : Client
// Correspondência : "Client" no diagrama UML do GoF
//
// O cliente cria os ConcreteElements, monta o ObjectStructure (Concessionaria)
// e aplica diferentes Visitors sobre a coleção. Toda a lógica das operações
// está nos Visitors — os elementos (Carro, Moto) permanecem inalterados.
//
// Diagrama de participantes neste projeto:
//
//   IVisitor          → Interface Visitor
//   ILoja             → Interface Element
//   Carro             → ConcreteElement A
//   Moto              → ConcreteElement B
//   PrecoVisitor      → ConcreteVisitor A  (calcula preço com desconto)
//   RelatorioVisitor  → ConcreteVisitor B  (gera relatório de inventário)
//   Concessionaria    → ObjectStructure
//   Program           → Client
//
// Referência: J.C. Macoratti - Padrões de Projeto GoF Comportamentais
// =============================================================================

Console.OutputEncoding = System.Text.Encoding.UTF8;

// ─── 1. Criando os ConcreteElements ──────────────────────────────────────────

// Carros (ConcreteElementA): nome, modelo e preço de tabela
var mercedes = new Carro("Mercedes", "Classe C 200",  250_000m);
var ferrari  = new Carro("Ferrari",  "F8 Tributo",  1_500_000m);
var porsche  = new Carro("Porsche",  "911 Carrera",   800_000m);

// Motos (ConcreteElementB): nome, modelo e preço de tabela
var honda    = new Moto("Honda",  "CBR 1000RR",  80_000m);
var yamaha   = new Moto("Yamaha", "MT-09",        55_000m);

// ─── 2. Montando o ObjectStructure (Concessionaria) ──────────────────────────

var concessionaria = new Concessionaria();
concessionaria.AdicionarVeiculo(mercedes);
concessionaria.AdicionarVeiculo(ferrari);
concessionaria.AdicionarVeiculo(porsche);
concessionaria.AdicionarVeiculo(honda);
concessionaria.AdicionarVeiculo(yamaha);

// ─── 3. Preços originais (sem Visitor) ───────────────────────────────────────

Console.WriteLine();
Console.WriteLine("==========================================================");
Console.WriteLine("          CONCESSIONARIA - PRECOS DE TABELA               ");
Console.WriteLine("==========================================================");

foreach (var veiculo in concessionaria.Veiculos)
{
    // Acesso direto às propriedades para exibição simples — sem visitor
    if (veiculo is Carro c)
        Console.WriteLine($"  Carro : {c.Nome,-10} {c.Modelo,-20} | Preco: {c.Preco:C}");
    else if (veiculo is Moto m)
        Console.WriteLine($"  Moto  : {m.Nome,-10} {m.Modelo,-20} | Preco: {m.Preco:C}");
}

// ─── 4. Aplicando ConcreteVisitor A: PrecoVisitor ────────────────────────────
// Nova operação: calcula e exibe preços com desconto.
// Carro e Moto NÃO foram alterados para suportar esta operação.

Console.WriteLine();
Console.WriteLine("==========================================================");
Console.WriteLine("    VISITOR A: PrecoVisitor - Precos com Desconto         ");
Console.WriteLine("    (Carros: 10% | Motos: 5%)                             ");
Console.WriteLine("==========================================================");

var precoVisitor = new PrecoVisitor(); // ConcreteVisitor A
concessionaria.AplicarVisitor(precoVisitor);

// ─── 5. Aplicando ConcreteVisitor B: RelatorioVisitor ────────────────────────
// Nova operação: gera relatório de inventário.
// Carro, Moto e Concessionaria NÃO foram alterados.

Console.WriteLine();
Console.WriteLine("==========================================================");
Console.WriteLine("    VISITOR B: RelatorioVisitor - Relatorio de Inventario ");
Console.WriteLine("==========================================================");

var relatorioVisitor = new RelatorioVisitor(); // ConcreteVisitor B
concessionaria.AplicarVisitor(relatorioVisitor);

// ─── Conclusão ───────────────────────────────────────────────────────────────

Console.WriteLine();
Console.WriteLine("----------------------------------------------------------");
Console.WriteLine("  OBSERVACAO:");
Console.WriteLine("  As classes Carro e Moto nao foram alteradas em nenhum");
Console.WriteLine("  momento. Cada nova operacao foi adicionada criando um");
Console.WriteLine("  novo ConcreteVisitor (Principio Aberto/Fechado - OCP).");
Console.WriteLine("----------------------------------------------------------");
Console.WriteLine();
