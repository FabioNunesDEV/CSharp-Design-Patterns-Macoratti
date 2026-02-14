namespace Bridge
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // Controles principais (UI) do exemplo.
            pbDispositivo = new PictureBox();
            cbDispositivos = new ComboBox();
            btnPower = new Button();
            btnVolMenos = new Button();
            txtVolume = new TextBox();
            btnVolMais = new Button();
            btnOptMenos = new Button();
            lblOpcao = new Label();
            btnOptMais = new Button();
            ((System.ComponentModel.ISupportInitialize)pbDispositivo).BeginInit();
            SuspendLayout();
            // 
            // pbDispositivo
            // 
            // Exibe a imagem do dispositivo selecionado.
            pbDispositivo.Anchor = AnchorStyles.Top;
            pbDispositivo.Location = new Point(250, 12);
            pbDispositivo.Name = "pbDispositivo";
            pbDispositivo.Size = new Size(300, 300);
            pbDispositivo.SizeMode = PictureBoxSizeMode.Zoom;
            pbDispositivo.TabIndex = 0;
            pbDispositivo.TabStop = false;
            // 
            // cbDispositivos
            // 
            // Lista de dispositivos (TV/Radio...) vindos do catálogo.
            cbDispositivos.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDispositivos.FormattingEnabled = true;
            cbDispositivos.Location = new Point(275, 326);
            cbDispositivos.Name = "cbDispositivos";
            cbDispositivos.Size = new Size(250, 28);
            cbDispositivos.TabIndex = 1;
            cbDispositivos.SelectedIndexChanged += cbDispositivos_SelectedIndexChanged;
            // 
            // btnPower
            // 
            // Liga/desliga (toggle). Quando desligado, botões de volume/opção ficam desabilitados.
            btnPower.Location = new Point(275, 370);
            btnPower.Name = "btnPower";
            btnPower.Size = new Size(250, 45);
            btnPower.TabIndex = 2;
            btnPower.Text = "DESLIGADO";
            btnPower.UseVisualStyleBackColor = true;
            btnPower.Click += btnPower_Click;
            // 
            // btnVolMenos
            // 
            btnVolMenos.Location = new Point(275, 433);
            btnVolMenos.Name = "btnVolMenos";
            btnVolMenos.Size = new Size(45, 35);
            btnVolMenos.TabIndex = 3;
            btnVolMenos.Text = "-";
            btnVolMenos.UseVisualStyleBackColor = true;
            btnVolMenos.Click += btnVolMenos_Click;
            // 
            // txtVolume
            // 
            // Exibe o volume atual do dispositivo (somente leitura).
            txtVolume.Location = new Point(326, 437);
            txtVolume.Name = "txtVolume";
            txtVolume.ReadOnly = true;
            txtVolume.Size = new Size(148, 27);
            txtVolume.TabIndex = 4;
            txtVolume.TextAlign = HorizontalAlignment.Center;
            // 
            // btnVolMais
            // 
            btnVolMais.Location = new Point(480, 433);
            btnVolMais.Name = "btnVolMais";
            btnVolMais.Size = new Size(45, 35);
            btnVolMais.TabIndex = 5;
            btnVolMais.Text = "+";
            btnVolMais.UseVisualStyleBackColor = true;
            btnVolMais.Click += btnVolMais_Click;
            // 
            // btnOptMenos
            // 
            btnOptMenos.Location = new Point(275, 488);
            btnOptMenos.Name = "btnOptMenos";
            btnOptMenos.Size = new Size(45, 35);
            btnOptMenos.TabIndex = 6;
            btnOptMenos.Text = "-";
            btnOptMenos.UseVisualStyleBackColor = true;
            btnOptMenos.Click += btnOptMenos_Click;
            // 
            // lblOpcao
            // 
            // Exibe o canal/estação atual.
            lblOpcao.BorderStyle = BorderStyle.FixedSingle;
            lblOpcao.Location = new Point(326, 488);
            lblOpcao.Name = "lblOpcao";
            lblOpcao.Size = new Size(148, 35);
            lblOpcao.TabIndex = 7;
            lblOpcao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnOptMais
            // 
            btnOptMais.Location = new Point(480, 488);
            btnOptMais.Name = "btnOptMais";
            btnOptMais.Size = new Size(45, 35);
            btnOptMais.TabIndex = 8;
            btnOptMais.Text = "+";
            btnOptMais.UseVisualStyleBackColor = true;
            btnOptMais.Click += btnOptMais_Click;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 560);
            Controls.Add(btnOptMais);
            Controls.Add(lblOpcao);
            Controls.Add(btnOptMenos);
            Controls.Add(btnVolMais);
            Controls.Add(txtVolume);
            Controls.Add(btnVolMenos);
            Controls.Add(btnPower);
            Controls.Add(cbDispositivos);
            Controls.Add(pbDispositivo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bridge - Controle Remoto";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)pbDispositivo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbDispositivo;
        private ComboBox cbDispositivos;
        private Button btnPower;
        private Button btnVolMenos;
        private TextBox txtVolume;
        private Button btnVolMais;
        private Button btnOptMenos;
        private Label lblOpcao;
        private Button btnOptMais;
    }
}
