using Composite.Component;
using Composite.Composite;  
using Composite.Leaf;   

// Cliente do padrão Composite.
// Monta uma árvore (organização -> departamentos -> funcionários/subdepartamentos)
// e executa a mesma operação (GetHoraTrabalhada) em todos os nós.

// Nó raiz (composite): representa a organização principal.
Organizacao organizacao = new Organizacao() { Nome = "Secretária Administrativa" };

// Composite: departamento (pode conter funcionários e/ou outros departamentos).
Organizacao deptoTI = new Organizacao() { Nome = "Departamento de TI" };

// Folhas: funcionários do departamento de TI.
deptoTI.Add(new Funcionario() { Id = 1, Nome = "João", Horas = 8 });
deptoTI.Add(new Funcionario() { Id = 2, Nome = "Maria", Horas = 6 });
deptoTI.Add(new Funcionario() { Id = 3, Nome = "Pedro", Horas = 7 });

// Composite: outro departamento.
Organizacao deptoCompras = new Organizacao() { Nome = "Departamento de Compras" };

// Folhas: funcionários do departamento de Compras.
deptoCompras.Add(new Funcionario() { Id = 4, Nome = "Ana", Horas = 5 });
deptoCompras.Add(new Funcionario() { Id = 5, Nome = "Carlos", Horas = 4 });
deptoCompras.Add(new Funcionario() { Id = 6, Nome = "Luisa", Horas = 6 });
deptoCompras.Add(new Funcionario() { Id = 7, Nome = "Rafael", Horas = 3 });

// Composite: subdepartamento de TI.
Organizacao deptoRH = new Organizacao() { Nome = "Departamento de RH" };

// Folhas: funcionários do subdepartamento (RH).
deptoRH.Add(new Funcionario() { Id = 8, Nome = "Fernanda", Horas = 7 });
deptoRH.Add(new Funcionario() { Id = 9, Nome = "Ricardo", Horas = 6 });

// Montagem da árvore:
// RH é filho de TI, demonstrando que um composite pode conter outros composites.
deptoTI.Add(deptoRH);   

// TI e Compras são filhos da organização principal.
organizacao.Add(deptoTI);
organizacao.Add(deptoCompras);

// Dispara o cálculo recursivo:
// - Imprime horas das folhas
// - Soma nos composites intermediários
// - Exibe o total na raiz
organizacao.GetHoraTrabalhada();

// Pausa para visualizar a saída no console.
Console.ReadKey();