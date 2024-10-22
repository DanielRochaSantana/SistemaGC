using static PrjGestaoClientes.Infrastructure.Factory.ObjectFactory;

namespace PrjGestaoClientes.Infrastructure.Interfaces.CommandSide
{
    public interface IRepositorioGenerico<Class> where Class : class
    {
        void Adicionar(Class registro, string sPropriedadeChave, string sTableName);
        void Remover(Guid Id, EntityEnum entityEnum, string sTableName, string sPropriedadeChave);
        void Atualizar(Class registro, string sPropriedadeChave, string sTableName);
    }
}
