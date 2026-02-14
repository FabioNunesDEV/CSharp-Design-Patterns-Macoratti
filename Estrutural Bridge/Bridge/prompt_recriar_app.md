## Prompt (Copilot/Agent) — WinForms .NET 8 + Bridge (Controle Remoto x Dispositivos)

Objetivo: recriar uma aplicação **Windows Forms .NET 8** para estudo do padrão estrutural **Bridge**, simulando um **controle remoto** que opera diferentes aparelhos (inicialmente **TV** e **Rádio**). O foco é separar claramente:

- **Abstraction**: `ControleRemoto`
- **Implementor**: `IDispositivo`
- **ConcreteImplementor**: `Televisao`, `Radio`
- **Cliente**: `MainForm` (somente UI, sem regra de negócio)

### 1) Estrutura obrigatória de pastas/namespaces
Crie (se não existirem) as pastas, e garanta que o namespace de cada classe corresponda à pasta:

- `Abstraction/`
- `Implementor/`
- `ConcreteImplementor/`
- `Domain/`
- `Services/`
- `Resources/` (imagens)

### 2) Recursos (imagens)
As imagens devem estar em `Resources/` e serem copiadas para o output (bin) ao compilar:

- `Resources/TV.png` (ou `.jpg/.jpeg`)
- `Resources/Radio.png` (ou `.jpg/.jpeg`)

No `.csproj`, adicionar:

- `<Content Include="Resources\**\*.*">`
- `<CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>`

### 3) Implementor (ponte)
Crie `Implementor/IDispositivo.cs` com:

Propriedades:
- `Nome: string`
- `Step: int`
- `VolumeMin: int`
- `VolumeMax: int`
- `Opcoes: IReadOnlyList<string>`
- `Ligado: bool`
- `VolumeAtual: int`
- `OpcaoAtualIndex: int`
- `OpcaoAtual: string`

Métodos:
- `int AumentarVolume()` (step, respeitar max)
- `int AbaixarVolume()` (step, respeitar min)
- `string OpcaoAnterior()` (não antes do primeiro)
- `string OpcaoProxima()` (não depois do último)
- `bool LigarDesligar()` (toggle)
- `void Reset()` (volume=min, opção=primeira)
- `Image RetornarImagem()`

### 4) Domain (regras comuns)
Crie `Domain/DispositivoBase.cs` (classe abstrata) implementando `IDispositivo`.

- Construtor recebe: `nome`, `step`, `volumeMin`, `volumeMax`, `opcoes`, `Image imagem`
- Valida lista de opções não vazia
- Mantém estado:
  - `Ligado` inicia `false`
  - `Reset()` é chamado no construtor
- Implementa os métodos de volume/opções/toggle/reset.
- `RetornarImagem()` retorna a imagem recebida por injeção.

### 5) ConcreteImplementor (TV e Rádio)
Crie:

- `ConcreteImplementor/Televisao.cs : DispositivoBase`
  - `Nome = "TV"`
  - `Step = 5`, `VolumeMin=0`, `VolumeMax=100`
  - `Opcoes`: 10 canais (base SP capital; strings)
  - Construtor recebe `Image`

- `ConcreteImplementor/Radio.cs : DispositivoBase`
  - `Nome = "Radio"`
  - `Step = 2`, `VolumeMin=0`, `VolumeMax=50`
  - `Opcoes`: 15 estações FM (base SP capital; strings)
  - Construtor recebe `Image`

### 6) Abstraction (controle remoto)
Crie `Abstraction/ControleRemoto.cs`:

- Possui `IDispositivo Dispositivo { get; private set; }`
- Construtor recebe `IDispositivo`
- `TrocarDispositivo(IDispositivo)`
- Métodos delegam para `Dispositivo`:
  - `LigarDesligar`, `AumentarVolume`, `AbaixarVolume`, `OpcaoProxima`, `OpcaoAnterior`, `Reset`

### 7) Services (imagens + catálogo de dispositivos)
Crie em `Services/`:

#### 7.1 `IImageProvider`
- `Image Get(string key)`

#### 7.2 `ResourceImageLoader : IImageProvider`
- Carrega imagens de `AppContext.BaseDirectory/Resources/`
- Suporta `.png`, `.jpg`, `.jpeg`
- Usa cache em memória (ex.: `ConcurrentDictionary<string, Image>`)
- Lazy-load: só carrega quando solicitado
- Se não achar, retorna `new Bitmap(1,1)`

#### 7.3 `DeviceDefinition`
- Record/class com:
  - `Key: string`
  - `DisplayName: string`
  - `Func<IDispositivo> Create`

#### 7.4 `DeviceCatalog`
- Método `CreateAll(IImageProvider)` retornando lista de `DeviceDefinition`.
- Registra pelo menos `TV` e `Radio`.
- Ideia: ao adicionar novo dispositivo, mudar somente aqui (evitar mexer no Form).

### 8) UI (MainForm) — regras
Crie/ajuste `MainForm` com layout organizado:

Componentes (nomes obrigatórios):
- `PictureBox pbDispositivo` (topo, centralizado, height=300, `SizeMode=Zoom`)
- `ComboBox cbDispositivos` (TV/Radio via catálogo; `DropDownStyle=DropDownList`)
- `Button btnPower`
- Volume:
  - `Button btnVolMenos`, `TextBox txtVolume (ReadOnly=true)`, `Button btnVolMais`
- Opção:
  - `Button btnOptMenos`, `Label lblOpcao` (ou TextBox readonly), `Button btnOptMais`

Regras de comportamento:
- Ao carregar o form:
  - criar `_imageProvider = new ResourceImageLoader()`
  - `_devices = DeviceCatalog.CreateAll(_imageProvider)`
  - `cbDispositivos.DataSource = _devices.ToList()` e `DisplayMember = DisplayName`
  - `SelectedIndex = 0`

- Ao trocar o item no ComboBox:
  - criar o dispositivo pelo `DeviceDefinition.Create()`
  - se `_controle` é null: `_controle = new ControleRemoto(dispositivo)`
  - senão: `_controle.TrocarDispositivo(dispositivo)`
  - chamar `_controle.Reset()`
  - forçar `_controle.Dispositivo.Ligado = false`
  - atualizar UI inteira (imagem, textos e botões)

- `btnPower`:
  - toggle via `_controle.LigarDesligar()`
  - quando ligado: fundo verde, texto preto `LIGADO`
  - quando desligado: fundo vermelho, texto preto `DESLIGADO`
  - quando desligado: desabilitar botões de volume/opção

- Volume:
  - `btnVolMais` chama `AumentarVolume`
  - `btnVolMenos` chama `AbaixarVolume`
  - `txtVolume` sempre reflete `VolumeAtual`

- Opções:
  - `btnOptMais` chama `OpcaoProxima`
  - `btnOptMenos` chama `OpcaoAnterior`
  - `lblOpcao` sempre reflete `OpcaoAtual`

### 9) Comentários para estudo
Adicione comentários curtos explicando:
- onde está o Bridge (Abstraction vs Implementor)
- por que existe `Services` (SRP/OCP/DIP; lazy-load/cache)
- por que o Form não deve ter lógica de negócio

### 10) Final
- Garantir build OK (.NET 8 WinForms)
- Confirmar que ao alternar TV/Radio:
  - imagem muda
  - volume/opção resetam
  - começa desligado
