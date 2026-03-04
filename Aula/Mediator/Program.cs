using Mediator;

IFacebookGroupMediator facebookGroupMediator = new ConcreteFacebookGroupMediator();

User macoratti = new ConcreteUser(facebookGroupMediator, "Macoratti");
User miriam = new ConcreteUser(facebookGroupMediator, "Miriam");
User jessica = new ConcreteUser(facebookGroupMediator, "Jessica");
User yuri = new ConcreteUser(facebookGroupMediator, "Yuri");

facebookGroupMediator.RegisterUser(macoratti);
facebookGroupMediator.RegisterUser(miriam);
facebookGroupMediator.RegisterUser(jessica);
facebookGroupMediator.RegisterUser(yuri);

macoratti.Send("Olá, pessoal! Bem-vindos ao grupo de estudos de Design Patterns!");
yuri.Send("Oi, Macoratti! Obrigado por criar este grupo. Estou animado para aprender sobre Design Patterns!");
macoratti.Send("Ótimo, Yuri! Vamos começar com o padrão Mediator. Ele é usado para reduzir as dependências entre objetos, promovendo um acoplamento mais fraco.");

Console.Read();
