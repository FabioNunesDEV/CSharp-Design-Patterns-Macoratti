
namespace Mediator
{
    public abstract class User
    {
        protected IFacebookGroupMediator Mediator;
        protected string Name;

        public User(IFacebookGroupMediator mediator, string name)   
        {
            Mediator = mediator;
            Name = name;
        }

        public abstract void Send(string message);
        public abstract void Receive(string message);
    }
}
