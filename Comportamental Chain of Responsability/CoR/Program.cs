using CoR;

// Cliente (Client) do padrão Chain of Responsibility.
// Conforme a aula, o cliente inicia a solicitação para um objeto handler.
// Aqui o cliente também monta a cadeia (define quem é o sucessor de quem).

// Instâncias dos handlers concretos (manipuladores).
GerenteProjeto gerenteProjeto = new GerenteProjeto();
SupervisorEquipe supervisorEquipe = new SupervisorEquipe();
SetorRH setorRH = new SetorRH();

// Montagem da cadeia de autorização:
// Gerente de Projeto -> Supervisor de Equipe -> Setor de RH.
gerenteProjeto.ProximoAutorizador(supervisorEquipe);
supervisorEquipe.ProximoAutorizador(setorRH);

// Envio das solicitações: sempre começa no primeiro handler da cadeia.
// Cada handler aprova dentro da sua alçada ou encaminha ao próximo.
gerenteProjeto.AutorizarLicenca("João", 3);
gerenteProjeto.AutorizarLicenca("Maria", 10);
gerenteProjeto.AutorizarLicenca("Pedro", 20);
gerenteProjeto.AutorizarLicenca("Fábio", 35);