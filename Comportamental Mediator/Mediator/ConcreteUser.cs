namespace Mediator
{
    public class ConcreteUser: User
    {
        public ConcreteUser(IFacebookGroupMediator mediator, string name) : base(mediator, name)
        {
        }
        public override void Receive(string message)
        {
            Console.WriteLine($"{Name}: recebida ==> {message}");
        }
        public override void Send(string message)
        {
            Console.WriteLine($"{Name}: enviada ==> {message}\n");
            Mediator.SendMessage(message, this);
        }
    }
}
