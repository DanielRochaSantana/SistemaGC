using Moq;
using PrjGestaoClientes.Application.Services;
using PrjGestaoClientes.Domain.Model.Entity;
using PrjGestaoClientes.Infrastructure.Interfaces.CommandSide;
using PrjGestaoClientes.Infrastructure.Interfaces.QuerySide;
using PrjGestaoClientes.Infrastructure.Interfaces.Request;

namespace PrjGestaoClientes.UnitTests.Base
{
    public class BaseTest
    {
        public Cliente? cliente;
        public ClienteService? clienteService;
        public RequestService? requestService;
        public List<Cliente>? clientes;

        public Mock<IRepositorioGenerico<Cliente>> _repositorioCli;
        public Mock<IRepositorioGenerico<EnderecoCliente>> _repositorioEndCli;
        public Mock<IConsultaGenerica<Cliente>> _consultaCli;
        public Mock<IConsultaGenerica<EnderecoCliente>> _consultaEndCli;
        public Mock<IRequestOperation> _requestOperation;

        #region Constructor
        public BaseTest()
        {
            _repositorioCli = new();
            _repositorioEndCli = new();
            _consultaCli = new();
            _consultaEndCli = new();
            _requestOperation = new();
        }
        #endregion Constructor
    }
}
