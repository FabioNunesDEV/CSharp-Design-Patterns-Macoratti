using Adapter.Client;

// Demonstração do padrão estrutural Adapter (Adaptador)
// ----------------------------------------------------
// Estrutura do exemplo (por participante):
// - `Client`: o código que consome o contrato `Target`
// - `Target`: a interface que o cliente espera
// - `Adaptee`: componente legado que queremos reutilizar
// - `Adapter`: faz a tradução entre `Target` e `Adaptee`
// - `Domain`: classes/records de domínio
//
// Observação:
// Mantivemos o `Program` apenas como ponto de entrada, para a leitura ficar clara.

ClientProgram.Run();
