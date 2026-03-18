using System.Security.Cryptography.X509Certificates;

namespace Observer;

public class ConcreteSubject : ISubject
{
    private List<IObserver> observers = new List<IObserver>();  
    private string Produto {  get; set; }
    private int Preco { get; set; }  
    private string Disponibilidade { get; set; }

    public ConcreteSubject(string produto, int preco, string status)
    {
        Produto = produto;
        Preco = preco;
        Disponibilidade = status;   
    }

    public string GetDisponibilidade()
    {
        return Disponibilidade;
    }

    public void SetDisponibilidade(string status)
    {
        this.Disponibilidade = status;
        Console.WriteLine($"O produto {Produto} agora está {Disponibilidade}.");
        NotificarObservers();
    }

    public void NotificarObservers()
    {
        Console.WriteLine($"O Produto: {Produto} no valor de R$ {Preco} agora está disponivel.");

        Console.WriteLine();

        foreach (IObserver observer in observers)
        {
            observer.Atualiza(Disponibilidade);
        }
    }

    public void RegistrarObserver(IObserver observer)
    {
        Console.WriteLine("Observer Adcionado: " + ((ConcreteObserver)observer));
        observers.Add(observer);    
    }

    public void RemoverObserver(IObserver observer)
    {
        observers.Remove(observer);
    }
}
