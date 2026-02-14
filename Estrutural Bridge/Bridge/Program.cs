namespace Bridge
{
    internal static class Program
    {
        /// <summary>
        ///  Ponto de entrada da aplicação WinForms.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Abre a UI do exemplo Bridge (controle remoto x dispositivos).
            Application.Run(new MainForm());
        }
    }
}