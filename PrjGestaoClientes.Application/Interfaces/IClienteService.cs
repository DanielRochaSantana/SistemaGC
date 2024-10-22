using PrjGestaoClientes.Domain.Model.Entity;
using PrjGestaoClientes.Infrastructure.Factory;

namespace PrjGestaoClientes.Application.Interfaces
{
    public interface IClienteService
    {
        #region CommandSide
        public void Adicionar(Cliente registro, string sPropriedadeChave, string sTableName);
        public void Remover(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave);
        public void Atualizar(Cliente registro, string sPropriedadeChave, string sTableName);
        public void AdicionarEndCli(EnderecoCliente registro, string sPropriedadeChave, string sTableName);
        public void RemoverEndCli(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave);
        public void AtualizarEndCli(EnderecoCliente registro, string sPropriedadeChave, string sTableName);
        #endregion CommandSide

        #region QuerySide
        public IEnumerable<Cliente> ListarRegistros(string sTableName);
        public Cliente? EncontrarPorCodigo(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave);
        public IEnumerable<EnderecoCliente> ListarRegistrosEndCli(string sTableName);
        public EnderecoCliente? EncontrarPorCodigoEndCli(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave);
        #endregion QuerySide
    }
}
