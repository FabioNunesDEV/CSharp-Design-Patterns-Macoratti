using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facade.Subsistemas;

namespace Facade.Facade;

/// <summary>
/// Facade (Fachada).
/// 
/// Fornece uma interface unificada/simplificada para um conjunto de classes do subsistema
/// (cadastro + consultas de restrição + validação de limite).
/// 
/// A intenção é reduzir o acoplamento do cliente com o subsistema e concentrar a orquestração
/// do fluxo em um único ponto.
/// </summary>
public class MeuFacade
{
    // Componentes do subsistema que são coordenados pela Facade.
    private LimiteCredito limite;
    private Cadastro cadastro;
    private Serasa serasa;
    private Cadin cadin;

    /// <summary>
    /// Inicializa a fachada e seus componentes.
    /// 
    /// Observação: em um cenário real, estes objetos poderiam vir de DI/IoC.
    /// </summary>
    public MeuFacade()
    {
        limite = new LimiteCredito();
        cadastro = new Cadastro();
        serasa = new Serasa();
        cadin = new Cadin();
    }

    /// <summary>
    /// Operação de alto nível oferecida ao cliente.
    /// 
    /// Este método esconde a sequência de chamadas e a ordem correta de execução
    /// dos componentes do subsistema.
    /// </summary>
    /// <param name="cliente">Cliente solicitante.</param>
    /// <param name="valor">Valor do empréstimo solicitado.</param>
    /// <returns><c>true</c> se o empréstimo for concedido; caso contrário <c>false</c>.</returns>
    public bool ConcederEmprestimo (Cliente cliente, double valor)
    {
        Console.WriteLine($"Concedendo empréstimo para o cliente {cliente.Nome} no valor de {valor}\n");

        // Etapa 1: cadastro (no exemplo, apenas registra no console)
        cadastro.CadastrarCliente(cliente);

        bool concederEmprestimo = true;

        // Etapa 2: consultas de restrição e validações.
        // Observação: a Facade decide a ordem e como combinar os resultados.
        if (serasa.EstaNoSerasa(cliente))
        {
            Console.WriteLine("Empréstimo negado: cliente está no Serasa.");
            concederEmprestimo = false;
        }
        else if (cadin.EstaNoCadin(cliente))
        {
            Console.WriteLine("Empréstimo negado: cliente está no Cadin.");
            concederEmprestimo = false;
        }
        else if (!limite.PossuiLimiteCredito(cliente,valor))
        {
            Console.WriteLine($"Empréstimo negado: valor solicitado ({valor}) excede o limite disponível.");
            concederEmprestimo = false;
        }

        // Entrega ao cliente um resultado final simples (sem expor detalhes do subsistema).
        return concederEmprestimo;
    }
}
