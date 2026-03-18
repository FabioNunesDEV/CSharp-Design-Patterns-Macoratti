namespace Observer
{
    public class ConcreteObserver:IObserver
    {
        public string Usuario { get; set; }
        public ConcreteObserver(string nome, ISubject subject)
        {
            Usuario = nome;
            subject.RegistrarObserver(this);
        }

        public void Atualiza(string disponibilidade)
        {
            Console.WriteLine($"Olá {Usuario}, o produto agora está {disponibilidade}.");
        }
    }
}
