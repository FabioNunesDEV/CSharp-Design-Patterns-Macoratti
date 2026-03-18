using Observer;

ConcreteSubject IPhone11 = new ConcreteSubject("IPhone 11", 4900, "Sem estoque");
Console.WriteLine("IPhone 11 - estado atual: " + IPhone11.GetDisponibilidade());

Console.WriteLine("\nObservers inscritos para receber notificações sobre o produto IPhone 11\n");

// cria usuario Macoratti
ConcreteObserver Macoratti = new ConcreteObserver("Macoratti", IPhone11);
ConcreteObserver Maria = new ConcreteObserver("Maria", IPhone11);
ConcreteObserver Joao = new ConcreteObserver("João", IPhone11);

Console.WriteLine("\nPressione algo para alterar a disponibilidade noticar os observers\n");

Console.ReadKey();  

IPhone11.SetDisponibilidade("Em estoque");

Console.Read();
