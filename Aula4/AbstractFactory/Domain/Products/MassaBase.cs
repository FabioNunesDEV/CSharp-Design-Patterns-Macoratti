using AbstractFactory.Domain.Enums;
using System.Collections;

namespace AbstractFactory.Domain.Products
{
    public abstract class MassaBase
    {
        public TipoMassa TipoMassa { get; set; }

        public string Nome { get; set; }

        public ArrayList Ingredientes = new ArrayList();

        public MassaBase(string nome, TipoMassa tipoMassa)
        {
            Nome = nome;
            TipoMassa = tipoMassa;
        }
    }
}
