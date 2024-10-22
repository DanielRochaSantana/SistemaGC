using PrjGestaoClientes.Infrastructure.Interfaces.Context;
using PrjGestaoClientes.Infrastructure.Interfaces.QuerySide;
using static PrjGestaoClientes.Infrastructure.Factory.ObjectFactory;

namespace PrjGestaoClientes.Infrastructure.QuerySide
{
    public class ConsultaGenerica<Class> : IConsultaGenerica<Class> where Class : class
    {
        private readonly IContext context;

        public ConsultaGenerica(IContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Lista os registros
        /// </summary>       
        /// <param name="sTableName"></param>
        /// <returns></returns>
        public IEnumerable<Class> ListarRegistros(string sTableName)
        {
            string sQuery = " Select * from " + sTableName;

            return context.ListarRegistros<Class>(sTableName, sQuery);
        }

        /// <summary>
        /// Rertorna registro encontrado por código
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="entityEnum"></param>
        /// <param name="sTableName"></param>
        /// <param name="sPropriedadeChave"></param>
        /// <returns></returns>
        public Class? EncontrarPorCodigo(Guid Id, EntityEnum entityEnum, string sTableName, string sPropriedadeChave)
        {
            string sQuery = " Select * from " + sTableName + " " +
                            " Where " + sPropriedadeChave + " = @" + sPropriedadeChave + " ";

            return context.EncontrarPorCodigo<Class>(Id, entityEnum, sTableName, sPropriedadeChave, sQuery);
        }
    }
}
