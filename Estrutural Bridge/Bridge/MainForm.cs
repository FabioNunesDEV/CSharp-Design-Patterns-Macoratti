using System.Drawing;
using Bridge.Abstraction;
using Bridge.Implementor;
using Bridge.Services;

namespace Bridge;

/// <summary>
/// Cliente do padrão Bridge.
/// A UI (Form) não contém regra de negócio: ela troca o dispositivo (Implementor) no controle (Abstraction)
/// e apenas reflete o estado (imagem, volume, opção e habilitação de botões).
/// </summary>
public partial class MainForm : Form
{
    // Abstraction do Bridge.
    private ControleRemoto? _controle;

    // Serviço de imagem com cache/lazy-loading.
    private readonly IImageProvider _imageProvider = new ResourceImageLoader();

    // Catálogo de dispositivos para popular o ComboBox sem strings duplicadas.
    private IReadOnlyList<DeviceDefinition> _devices = Array.Empty<DeviceDefinition>();

    public MainForm()
    {
        InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        // A UI descobre os dispositivos disponíveis no catálogo.
        _devices = DeviceCatalog.CreateAll(_imageProvider);

        cbDispositivos.DataSource = _devices.ToList();
        cbDispositivos.DisplayMember = nameof(DeviceDefinition.DisplayName);

        cbDispositivos.SelectedIndex = 0;
    }

    private void cbDispositivos_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cbDispositivos.SelectedItem is not DeviceDefinition selected)
            return;

        // Cria o implementor (TV/Rádio...) a partir da definição selecionada.
        var dispositivo = selected.Create();

        if (_controle is null)
            _controle = new ControleRemoto(dispositivo);
        else
            _controle.TrocarDispositivo(dispositivo);

        // Regra do estudo: ao trocar dispositivo, resetar e forçar desligado.
        _controle.Reset();
        _controle.Dispositivo.Ligado = false;

        AtualizarUiCompleta();
    }

    private void btnPower_Click(object sender, EventArgs e)
    {
        if (_controle is null)
            return;

        // Bridge: a UI chama o controle, que delega ao dispositivo.
        _controle.LigarDesligar();
        AtualizarEstadoBotoes();
        AtualizarPowerButton();
    }

    private void btnVolMais_Click(object sender, EventArgs e)
    {
        if (_controle is null || !_controle.Dispositivo.Ligado)
            return;

        _controle.AumentarVolume();
        AtualizarVolume();
    }

    private void btnVolMenos_Click(object sender, EventArgs e)
    {
        if (_controle is null || !_controle.Dispositivo.Ligado)
            return;

        _controle.AbaixarVolume();
        AtualizarVolume();
    }

    private void btnOptMais_Click(object sender, EventArgs e)
    {
        if (_controle is null || !_controle.Dispositivo.Ligado)
            return;

        _controle.OpcaoProxima();
        AtualizarOpcao();
    }

    private void btnOptMenos_Click(object sender, EventArgs e)
    {
        if (_controle is null || !_controle.Dispositivo.Ligado)
            return;

        _controle.OpcaoAnterior();
        AtualizarOpcao();
    }

    private void AtualizarUiCompleta()
    {
        // Mantém a UI sempre coerente com o estado atual do dispositivo.
        AtualizarImagem();
        AtualizarPowerButton();
        AtualizarEstadoBotoes();
        AtualizarVolume();
        AtualizarOpcao();
    }

    private void AtualizarImagem()
    {
        if (_controle is null)
            return;

        pbDispositivo.Image = _controle.Dispositivo.RetornarImagem();
    }

    private void AtualizarPowerButton()
    {
        if (_controle is null)
            return;

        if (_controle.Dispositivo.Ligado)
        {
            btnPower.BackColor = Color.Green;
            btnPower.ForeColor = Color.Black;
            btnPower.Text = "LIGADO";
        }
        else
        {
            btnPower.BackColor = Color.Red;
            btnPower.ForeColor = Color.Black;
            btnPower.Text = "DESLIGADO";
        }
    }

    private void AtualizarEstadoBotoes()
    {
        if (_controle is null)
            return;

        var enabled = _controle.Dispositivo.Ligado;

        btnVolMais.Enabled = enabled;
        btnVolMenos.Enabled = enabled;
        btnOptMais.Enabled = enabled;
        btnOptMenos.Enabled = enabled;
    }

    private void AtualizarVolume()
    {
        if (_controle is null)
            return;

        txtVolume.Text = _controle.Dispositivo.VolumeAtual.ToString();
    }

    private void AtualizarOpcao()
    {
        if (_controle is null)
            return;

        lblOpcao.Text = _controle.Dispositivo.OpcaoAtual;
    }

}
