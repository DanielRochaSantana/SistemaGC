using System.Data.SqlClient;
using static PrjGestaoClientes.Infrastructure.Factory.ObjectFactory;

namespace PrjGestaoClientes.Infrastructure.Interfaces.Context
{
    public interface IContext
    {
        SqlConnection Conectar();
        void Desconectar();
        Class? EncontrarPorCodigo<Class>(Guid Id, EntityEnum entityEnum, string sTableName, string sPropriedadeChave, string sQuery) where Class : class;
        void ExecuteCommand<Class>(string _sCommand, Class registro) where Class : class;
        IEnumerable<Class> ListarRegistros<Class>(string sTableName, string sQuery);
        IList<TYPE> ReturnQueryList<TYPE>(string sQuery) where TYPE : class;
    }
}
