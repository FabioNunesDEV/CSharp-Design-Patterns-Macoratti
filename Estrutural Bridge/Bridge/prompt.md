## Prompt para o Copilot (Visual Studio 2026) — Bridge + WinForms (.NET 8)

Você é um desenvolvedor sênior C# com domínio de **Design Patterns (GoF)**, **SOLID** e boas práticas de organização de projeto.

Quero criar uma aplicação **.NET 8 Windows Forms** para estudo do padrão estrutural **Bridge**, simulando um **controle remoto** que pode operar diferentes aparelhos (por enquanto: **TV** e **Rádio**). O objetivo é demonstrar claramente a separação entre **Abstraction (controle)** e **Implementor (aparelho)**, permitindo extender futuramente com novos aparelhos sem alterar o código do controle.

### Materiais de referência (obrigatório considerar)

Use como base os arquivos complementares abaixo (considere-os como referência de padrão/estrutura/ideia; não ignore):

* **[Padrão Estrutural Bridge.md]**
* **[ArefactoringGuru.md]**
* **[Transcricao_aula.txt]**

> Importante: ao responder, cite quais partes foram influenciadas pelos arquivos acima e mantenha o design compatível.

---

# 1) Estrutura do Projeto (obrigatório)

Organize as classes nas pastas abaixo (crie se não existirem):

* `Abstraction/`
* `Implementor/`
* `ConcreteImplementor/`
* `Domain/`

**Regra:** cada classe deve estar no namespace correspondente à pasta.

---

# 2) Objetivo de UI (Form Principal)

Crie o código no **Form principal** (`MainForm`) com layout organizado e agradável:

## 2.1 PictureBox (topo)

* Um `PictureBox` no topo, **centralizado horizontalmente**
* Altura fixa: **300 px**
* A imagem muda conforme o aparelho selecionado (TV ou Rádio)
* As imagens estão na pasta: `Resources/`

  * Usar exatamente as imagens de **TV** e **Radio** dessa pasta

## 2.2 ComboBox (seleção do aparelho)

Logo abaixo da imagem:

* `ComboBox` com as opções: **TV** e **Radio**
* Ao alterar a seleção:

  * atualizar a imagem no `PictureBox`
  * **reiniciar o estado** do controle e dos botões para o estado inicial (detalhado abaixo)

## 2.3 Botão Liga/Desliga

Abaixo do ComboBox:

* Um botão `btnPower` que alterna estado (toggle)
* Estado inicial: **DESLIGADO**
* Aparência:

  * **Ligado:** fundo **verde**, texto **preto**: `LIGADO`
  * **Desligado:** fundo **vermelho**, texto **preto**: `DESLIGADO`
* Clique executa o método: **LigarDesligar**
* Quando desligado:

  * botões de volume e opção/canal/estação devem ficar **desabilitados**
* Quando ligado:

  * botões de volume e opção/canal/estação devem ficar **habilitados**

## 2.4 Controle de Volume

Abaixo do botão Liga/Desliga:

* Dois botões: `btnVolMenos [-]` e `btnVolMais [+]`
* Entre eles um `TextBox`:

  * mostra volume numérico **VolumeMin a VolumeMax**
  * **ReadOnly = true**
* Regras:

  * `btnVolMais [+]` chama **AumentarVolume**
  * `btnVolMenos [-]` chama **AbaixarVolume**
  * volume respeita **VolumeMin / VolumeMax**
  * incremento/decremento usa a propriedade **Step**
  * se DESLIGADO → botões ficam desabilitados

## 2.5 Controle de Opção (canal/estação)

Abaixo do volume:

* Dois botões: `btnOptMenos [-]` e `btnOptMais [+]`
* Entre eles um `Label` (ou TextBox readonly) exibindo o texto do item atual:

  * Para TV: canal (string)
  * Para Rádio: estação (string)
* Regras:

  * `btnOptMais [+]` chama **OpcaoProxima**
  * `btnOptMenos [-]` chama **OpcaoAnterior**
  * não pode passar do primeiro/último item da lista
  * se DESLIGADO → botões ficam desabilitados

---

# 3) Modelo de Domínio do Aparelho (obrigatório)

Crie classes que representem os aparelhos com as propriedades abaixo:

### Propriedades (obrigatórias)

* `Nome` : `string` (TV ou Radio)
* `Step` : `int` (incremento/decremento do volume)
* `VolumeMin` : `int`
* `VolumeMax` : `int`
* `Opcoes` : `List<string>`

  * TV: **10 canais**
  * Rádio: **15 estações FM**
  * Baseie-se em canais e rádios de **São Paulo (capital)** (não precisa ser perfeito, mas realista)
* `Ligado` : `bool` (true ligado / false desligado)
* `Imagem` : `Image`

### Estado atual (você deve manter)

* `VolumeAtual` : `int`
* `OpcaoAtualIndex` : `int` (ou equivalente)
* `OpcaoAtual` : `string` (derivado do index)

---

# 4) Métodos (obrigatórios)

Implemente os métodos abaixo com as regras descritas:

* `int AumentarVolume()`

  * incrementa usando `Step`
  * não ultrapassa `VolumeMax`
  * retorna `VolumeAtual`

* `int AbaixarVolume()`

  * decrementa usando `Step`
  * não fica abaixo de `VolumeMin`
  * retorna `VolumeAtual`

* `string OpcaoAnterior()`

  * move seleção para trás
  * não passa antes do primeiro item
  * retorna a opção atual

* `string OpcaoProxima()`

  * move seleção para frente
  * não passa depois do último item
  * retorna a opção atual

* `bool LigarDesligar()`

  * alterna estado (`Ligado = !Ligado`)
  * quando mudar para **DESLIGADO**, manter estado coerente (botões desabilitam no form)
  * retorna o novo estado (`Ligado`)

* `void Reset()`

  * define `VolumeAtual = VolumeMin`
  * define opção atual para `Opcoes[0]`

* `Image RetornarImagem()`

  * retorna a imagem do aparelho (para o PictureBox)

---

# 5) Bridge (regra central do exercício)

A implementação precisa demonstrar explicitamente o **Bridge**:

* O **controle (Abstraction)** não pode conhecer detalhes concretos de TV/Rádio.
* O controle deve operar por meio de uma **interface Implementor** (ex: `IDispositivo`).
* TV e Rádio devem ser **ConcreteImplementor**.
* O Form não deve conter lógica de negócio; apenas:

  * instanciar o controle e trocar o implementor conforme ComboBox
  * chamar métodos e atualizar UI (volume/opção/imagem/estados)

Sugestão de classes (você pode ajustar nomes, mas mantenha a ideia):

* `Implementor/IDispositivo`
* `ConcreteImplementor/Televisao : IDispositivo`
* `ConcreteImplementor/Radio : IDispositivo`
* `Abstraction/ControleRemoto` (abstraction)
* `Abstraction/ControleRemotoAvancado` (opcional: se quiser mostrar extensão)
* `Domain/` para modelos/constantes se necessário

---

# 6) Regras extras importantes

* Ao trocar TV/Radio no ComboBox:

  * chamar `Reset()`
  * forçar `Ligado = false` (estado inicial)
  * atualizar UI inteira (imagem, botões, textos)
* Botões de volume/opções:

  * desabilitados quando desligado
* `TextBox` de volume:

  * sempre reflete `VolumeAtual`
* Exibir opção atual:

  * sempre reflete a opção selecionada

---

# 7) Entrega esperada

Gere:

1. Todas as classes nas pastas corretas
2. `MainForm` com os componentes e eventos configurados
3. Carregamento das imagens a partir de `Resources/`
4. Código limpo, nomes claros, e comentários curtos explicando onde está o Bridge

---

Se quiser, eu também posso te devolver **uma versão ainda mais “direta” (curtinha)**, do tipo “Copilot command”, que costuma funcionar bem no modo *Edit/Agent* (menos texto, mais instrução).
