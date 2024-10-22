using PrjGestaoClientes.Application.Interfaces;
using PrjGestaoClientes.Domain.Model.Entity;
using PrjGestaoClientes.Infrastructure.Factory;
using PrjGestaoClientes.Infrastructure.Interfaces.CommandSide;
using PrjGestaoClientes.Infrastructure.Interfaces.QuerySide;

namespace PrjGestaoClientes.Application.Services
{
    public class ClienteService : IClienteService
    {
        protected readonly IRepositorioGenerico<Cliente> _repositorioCli;
        protected readonly IRepositorioGenerico<EnderecoCliente> _repositorioEndCli;
        protected readonly IConsultaGenerica<Cliente> _consultaCli;
        protected readonly IConsultaGenerica<EnderecoCliente> _consultaEndCli;

        public ClienteService(IRepositorioGenerico<Cliente> repositorioCli, 
                              IRepositorioGenerico<EnderecoCliente> repositorioEndCli, 
                              IConsultaGenerica<Cliente> consultaCli, 
                              IConsultaGenerica<EnderecoCliente> consultaEndCli)
        {
            _repositorioCli = repositorioCli;
            _repositorioEndCli = repositorioEndCli;
            _consultaCli = consultaCli;
            _consultaEndCli = consultaEndCli;
        }

        #region CommandSide
        public void Adicionar(Cliente registro, string sPropriedadeChave, string sTableName)
        {
            _repositorioCli.Adicionar(registro, sPropriedadeChave, sTableName);
        }

        public void Atualizar(Cliente registro, string sPropriedadeChave, string sTableName)
        {
            _repositorioCli.Atualizar(registro, sPropriedadeChave, sTableName);
        }

        public void Remover(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave)
        {
            _repositorioCli.Remover(Id, entityEnum, sTableName, sPropriedadeChave);
        }
        
        public void AdicionarEndCli(EnderecoCliente registro, string sPropriedadeChave, string sTableName)
        {
            _repositorioEndCli.Adicionar(registro, sPropriedadeChave, sTableName);
        }

        public void AtualizarEndCli(EnderecoCliente registro, string sPropriedadeChave, string sTableName)
        {
            _repositorioEndCli.Atualizar(registro, sPropriedadeChave, sTableName);
        }

        public void RemoverEndCli(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave)
        {
            _repositorioEndCli.Remover(Id, entityEnum, sTableName, sPropriedadeChave);
        }
        #endregion CommandSide

        #region QuerySide
        public IEnumerable<Cliente> ListarRegistros(string sTableName)
        {
            return _consultaCli.ListarRegistros(sTableName);
        }

        public Cliente? EncontrarPorCodigo(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave)
        {
            return _consultaCli.EncontrarPorCodigo(Id, entityEnum, sTableName, sPropriedadeChave);
        }

        public IEnumerable<EnderecoCliente> ListarRegistrosEndCli(string sTableName)
        {
            return _consultaEndCli.ListarRegistros(sTableName);
        }

        public EnderecoCliente? EncontrarPorCodigoEndCli(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave)
        {
            return _consultaEndCli.EncontrarPorCodigo(Id, entityEnum, sTableName, sPropriedadeChave);
        }
        #endregion QuerySide
    }
}
