using FluentAssertions;
using PrjGestaoClientes.Application.Services;
using PrjGestaoClientes.Domain.Model.Entity;
using PrjGestaoClientes.Infrastructure.Utils;
using PrjGestaoClientes.UnitTests.Base;

namespace PrjGestaoClientes.UnitTests.Services
{
    public class ClienteServiceTest : BaseTest
    {
        [Fact(DisplayName = "Should create a ClienteService object and execute the Adicionar Mehod Passing a Valid Cliente")]
        [Trait("PrjGestaoClientes.Application.Services", "ClienteService")]
        public void ShouldCreateAClienteServiceObjectAndExecuteTheAdicionarMehodPassingAValidCliente()
        {
            // Arrange and act
            this.cliente = new Cliente()
            {
                CPF = "CPF",
                Nome = "Nome",
                RG = "RG",
                DataExpedicao = DateTime.Now.AddYears(-10),
                OrgaoExpedicao = "OrgaoExpedicao",
                DataNascimento = DateTime.Now.AddYears(-30),
                Sexo = "Sexo",
                EstadoCivil = "EstadoCivil",
                IdEnderecoCliente = Guid.NewGuid()
            };

            this._repositorioCli.Setup(item => item.Adicionar(this.cliente, Constants.ID, Constants.CLIENTE));

            this.clienteService = new ClienteService(_repositorioCli.Object,
                                                     _repositorioEndCli.Object,
                                                     _consultaCli.Object,
                                                     _consultaEndCli.Object);

            this.clienteService.Adicionar(this.cliente, Constants.ID, Constants.CLIENTE);

            // Asserts
            this.cliente.Should().NotBeNull();
            this._repositorioCli.Should().NotBeNull();
            this._repositorioEndCli.Should().NotBeNull();
            this._consultaCli.Should().NotBeNull();
            this._consultaEndCli.Should().NotBeNull();
            this.clienteService.Should().NotBeNull();
        }

        [Theory(DisplayName = "Should create a ClienteService object and execute the Adicionar Mehod Passing a Invalid Cliente")]
        [Trait("PrjGestaoClientes.Application.Services", "ClienteService")]
        [InlineData("")]
        [InlineData(" ")]
        public void ShouldCreateAClienteServiceObjectAndExecuteTheAdicionarMehodPassingAInvalidCliente(string parameter)
        {
            // Arrange and act
            this.cliente = new Cliente()
            {
                CPF = parameter,
                Nome = parameter,
                RG = parameter,
                DataExpedicao = DateTime.MinValue,
                OrgaoExpedicao = parameter,
                DataNascimento = DateTime.MinValue,
                Sexo = parameter,
                EstadoCivil = parameter,
                IdEnderecoCliente = Guid.Empty
            };

            this._repositorioCli.Setup(item => item.Adicionar(this.cliente, Constants.ID, Constants.CLIENTE));

            this.clienteService = new ClienteService(_repositorioCli.Object,
                                                     _repositorioEndCli.Object,
                                                     _consultaCli.Object,
                                                     _consultaEndCli.Object);

            this.clienteService.Adicionar(this.cliente, Constants.ID, Constants.CLIENTE);

            // Asserts
            this.cliente.Should().NotBeNull();
            this._repositorioCli.Should().NotBeNull();
            this._repositorioEndCli.Should().NotBeNull();
            this._consultaCli.Should().NotBeNull();
            this._consultaEndCli.Should().NotBeNull();
            this.clienteService.Should().NotBeNull();
        }

        [Fact(DisplayName = "Should create a ClienteService object and execute the Atualizar Mehod Passing a Valid Cliente")]
        [Trait("PrjGestaoClientes.Application.Services", "ClienteService")]
        public void ShouldCreateAClienteServiceObjectAndExecuteTheAtualizarMehodPassingAValidCliente()
        {
            // Arrange and act
            this.cliente = new Cliente()
            {
                CPF = "CPF",
                Nome = "Nome",
                RG = "RG",
                DataExpedicao = DateTime.Now.AddYears(-10),
                OrgaoExpedicao = "OrgaoExpedicao",
                DataNascimento = DateTime.Now.AddYears(-30),
                Sexo = "Sexo",
                EstadoCivil = "EstadoCivil",
                IdEnderecoCliente = Guid.NewGuid()
            };

            this._repositorioCli.Setup(item => item.Atualizar(this.cliente, Constants.ID, Constants.CLIENTE));

            this.clienteService = new ClienteService(_repositorioCli.Object,
                                                     _repositorioEndCli.Object,
                                                     _consultaCli.Object,
                                                     _consultaEndCli.Object);

            this.clienteService.Atualizar(this.cliente, Constants.ID, Constants.CLIENTE);

            // Asserts
            this.cliente.Should().NotBeNull();
            this._repositorioCli.Should().NotBeNull();
            this._repositorioEndCli.Should().NotBeNull();
            this._consultaCli.Should().NotBeNull();
            this._consultaEndCli.Should().NotBeNull();
            this.clienteService.Should().NotBeNull();
        }

        [Theory(DisplayName = "Should create a ClienteService object and execute the Atualizar Mehod Passing a Invalid Cliente")]
        [Trait("PrjGestaoClientes.Application.Services", "ClienteService")]
        [InlineData("")]
        [InlineData(" ")]
        public void ShouldCreateAClienteServiceObjectAndExecuteTheAtualizarMehodPassingAInvalidCliente(string parameter)
        {
            // Arrange and act
            this.cliente = new Cliente()
            {
                CPF = parameter,
                Nome = parameter,
                RG = parameter,
                DataExpedicao = DateTime.MinValue,
                OrgaoExpedicao = parameter,
                DataNascimento = DateTime.MinValue,
                Sexo = parameter,
                EstadoCivil = parameter,
                IdEnderecoCliente = Guid.Empty
            };

            this._repositorioCli.Setup(item => item.Atualizar(this.cliente, Constants.ID, Constants.CLIENTE));

            this.clienteService = new ClienteService(_repositorioCli.Object,
                                                     _repositorioEndCli.Object,
                                                     _consultaCli.Object,
                                                     _consultaEndCli.Object);

            this.clienteService.Atualizar(this.cliente, Constants.ID, Constants.CLIENTE);

            // Asserts
            this.cliente.Should().NotBeNull();
            this._repositorioCli.Should().NotBeNull();
            this._repositorioEndCli.Should().NotBeNull();
            this._consultaCli.Should().NotBeNull();
            this._consultaEndCli.Should().NotBeNull();
            this.clienteService.Should().NotBeNull();
        }

        [Fact(DisplayName = "Should create a ClienteService object and execute the Remover Mehod Passing a Valid Cliente")]
        [Trait("PrjGestaoClientes.Application.Services", "ClienteService")]
        public void ShouldCreateAClienteServiceObjectAndExecuteTheRemoverMehodPassingAValidCliente()
        {
            // Arrange and act
            this.cliente = new Cliente()
            {
                CPF = "CPF",
                Nome = "Nome",
                RG = "RG",
                DataExpedicao = DateTime.Now.AddYears(-10),
                OrgaoExpedicao = "OrgaoExpedicao",
                DataNascimento = DateTime.Now.AddYears(-30),
                Sexo = "Sexo",
                EstadoCivil = "EstadoCivil",
                IdEnderecoCliente = Guid.NewGuid()
            };

            this._repositorioCli.Setup(item => item.Remover(this.cliente.Id, Infrastructure.Factory.ObjectFactory.EntityEnum.Cliente, Constants.CLIENTE, Constants.ID));

            this.clienteService = new ClienteService(_repositorioCli.Object,
                                                     _repositorioEndCli.Object,
                                                     _consultaCli.Object,
                                                     _consultaEndCli.Object);

            this.clienteService.Remover(this.cliente.Id, Infrastructure.Factory.ObjectFactory.EntityEnum.Cliente, Constants.CLIENTE, Constants.ID);

            // Asserts
            this.cliente.Should().NotBeNull();
            this._repositorioCli.Should().NotBeNull();
            this._repositorioEndCli.Should().NotBeNull();
            this._consultaCli.Should().NotBeNull();
            this._consultaEndCli.Should().NotBeNull();
            this.clienteService.Should().NotBeNull();
        }

        [Theory(DisplayName = "Should create a ClienteService object and execute the Remover Mehod Passing a Invalid Cliente")]
        [Trait("PrjGestaoClientes.Application.Services", "ClienteService")]
        [InlineData("")]
        [InlineData(" ")]
        public void ShouldCreateAClienteServiceObjectAndExecuteTheRemoverMehodPassingAInvalidCliente(string parameter)
        {
            // Arrange and act
            this.cliente = new Cliente()
            {
                CPF = parameter,
                Nome = parameter,
                RG = parameter,
                DataExpedicao = DateTime.MinValue,
                OrgaoExpedicao = parameter,
                DataNascimento = DateTime.MinValue,
                Sexo = parameter,
                EstadoCivil = parameter,
                IdEnderecoCliente = Guid.Empty
            };

            this._repositorioCli.Setup(item => item.Remover(this.cliente.Id, Infrastructure.Factory.ObjectFactory.EntityEnum.Cliente, Constants.CLIENTE, Constants.ID));

            this.clienteService = new ClienteService(_repositorioCli.Object,
                                                     _repositorioEndCli.Object,
                                                     _consultaCli.Object,
                                                     _consultaEndCli.Object);

            this.clienteService.Remover(this.cliente.Id, Infrastructure.Factory.ObjectFactory.EntityEnum.Cliente, Constants.CLIENTE, Constants.ID);

            // Asserts
            this.cliente.Should().NotBeNull();
            this._repositorioCli.Should().NotBeNull();
            this._repositorioEndCli.Should().NotBeNull();
            this._consultaCli.Should().NotBeNull();
            this._consultaEndCli.Should().NotBeNull();
            this.clienteService.Should().NotBeNull();
        }

        [Fact(DisplayName = "Should create a ClienteService object and execute the ListarRegistros Mehod Passing a Valid Cliente")]
        [Trait("PrjGestaoClientes.Application.Services", "ClienteService")]
        public void ShouldCreateAClienteServiceObjectAndExecuteTheListarRegistrosMehodPassingAValidCliente()
        {
            this.clientes = new List<Cliente>();

            for (int i = 0; i <= 9; i++)
            {
                this.cliente = new Cliente()
                {
                    CPF = "CPF " + i,
                    Nome = "Nome " + i,
                    RG = "RG " + i,
                    DataExpedicao = DateTime.Now.AddYears(-10 - i),
                    OrgaoExpedicao = "OrgaoExpedicao",
                    DataNascimento = DateTime.Now.AddYears(-30 - i),
                    Sexo = "Sexo",
                    EstadoCivil = "EstadoCivil",
                    IdEnderecoCliente = Guid.NewGuid()
                };

                this.clientes.Add(this.cliente);
            }

            // Arrange and act

            this._consultaCli.Setup(item => item.ListarRegistros(Constants.CLIENTE)).Returns(this.clientes);

            this.clienteService = new ClienteService(_repositorioCli.Object,
                                                     _repositorioEndCli.Object,
                                                     _consultaCli.Object,
                                                     _consultaEndCli.Object);

            var result = this.clienteService.ListarRegistros(Constants.CLIENTE);

            // Asserts
            this.cliente.Should().NotBeNull();
            this._repositorioCli.Should().NotBeNull();
            this._repositorioEndCli.Should().NotBeNull();
            this._consultaCli.Should().NotBeNull();
            this._consultaEndCli.Should().NotBeNull();
            this.clienteService.Should().NotBeNull();
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(10);
        }

        [Theory(DisplayName = "Should create a ClienteService object and execute the ListarRegistros Mehod Passing a Invalid Cliente")]
        [Trait("PrjGestaoClientes.Application.Services", "ClienteService")]
        [InlineData("")]
        [InlineData(" ")]
        public void ShouldCreateAClienteServiceObjectAndExecuteTheListarRegistrosMehodPassingAInvalidCliente(string parameter)
        {
            this.clientes = new List<Cliente>();

            for (int i = 0; i <= 9; i++)
            {
                this.cliente = new Cliente()
                {
                    CPF = parameter,
                    Nome = parameter,
                    RG = parameter,
                    DataExpedicao = DateTime.MinValue,
                    OrgaoExpedicao = parameter,
                    DataNascimento = DateTime.MinValue,
                    Sexo = parameter,
                    EstadoCivil = parameter,
                    IdEnderecoCliente = Guid.Empty
                };

                this.clientes.Add(this.cliente);
            }

            // Arrange and act

            this._consultaCli.Setup(item => item.ListarRegistros(Constants.CLIENTE)).Returns(this.clientes);

            this.clienteService = new ClienteService(_repositorioCli.Object,
                                                     _repositorioEndCli.Object,
                                                     _consultaCli.Object,
                                                     _consultaEndCli.Object);

            var result = this.clienteService.ListarRegistros(Constants.CLIENTE);

            // Asserts
            this.cliente.Should().NotBeNull();
            this._repositorioCli.Should().NotBeNull();
            this._repositorioEndCli.Should().NotBeNull();
            this._consultaCli.Should().NotBeNull();
            this._consultaEndCli.Should().NotBeNull();
            this.clienteService.Should().NotBeNull();
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(10);
        }

        [Fact(DisplayName = "Should create a ClienteService object and execute the EncontrarPorCodigo Mehod Passing a Valid Cliente")]
        [Trait("PrjGestaoClientes.Application.Services", "ClienteService")]
        public void ShouldCreateAClienteServiceObjectAndExecuteTheEncontrarPorCodigoMehodPassingAValidCliente()
        {
            this.cliente = new Cliente()
            {
                CPF = "CPF",
                Nome = "Nome",
                RG = "RG",
                DataExpedicao = DateTime.Now.AddYears(-10),
                OrgaoExpedicao = "OrgaoExpedicao",
                DataNascimento = DateTime.Now.AddYears(-30),
                Sexo = "Sexo",
                EstadoCivil = "EstadoCivil",
                IdEnderecoCliente = Guid.NewGuid()
            };

            // Arrange and act

            this._consultaCli.Setup(item => item.EncontrarPorCodigo(cliente.Id, Infrastructure.Factory.ObjectFactory.EntityEnum.Cliente, Constants.CLIENTE, Constants.ID)).Returns(this.cliente);

            this.clienteService = new ClienteService(_repositorioCli.Object,
                                                     _repositorioEndCli.Object,
                                                     _consultaCli.Object,
                                                     _consultaEndCli.Object);

            var result = this.clienteService.EncontrarPorCodigo(cliente.Id, Infrastructure.Factory.ObjectFactory.EntityEnum.Cliente, Constants.CLIENTE, Constants.ID);

            // Asserts
            this.cliente.Should().NotBeNull();
            this._repositorioCli.Should().NotBeNull();
            this._repositorioEndCli.Should().NotBeNull();
            this._consultaCli.Should().NotBeNull();
            this._consultaEndCli.Should().NotBeNull();
            this.clienteService.Should().NotBeNull();
            result.Should().NotBeNull();
            result.Id.Should().Be(this.cliente.Id);
        }

        [Theory(DisplayName = "Should create a ClienteService object and execute the EncontrarPorCodigo Mehod Passing a Invalid Cliente")]
        [Trait("PrjGestaoClientes.Application.Services", "ClienteService")]
        [InlineData("")]
        [InlineData(" ")]
        public void ShouldCreateAClienteServiceObjectAndExecuteTheEncontrarPorCodigoMehodPassingAInvalidCliente(string parameter)
        {            
                this.cliente = new Cliente()
                {
                    CPF = parameter,
                    Nome = parameter,
                    RG = parameter,
                    DataExpedicao = DateTime.MinValue,
                    OrgaoExpedicao = parameter,
                    DataNascimento = DateTime.MinValue,
                    Sexo = parameter,
                    EstadoCivil = parameter,
                    IdEnderecoCliente = Guid.Empty
                };
                
            // Arrange and act

            this._consultaCli.Setup(item => item.EncontrarPorCodigo(cliente.Id, Infrastructure.Factory.ObjectFactory.EntityEnum.Cliente, Constants.CLIENTE, Constants.ID)).Returns(this.cliente);

            this.clienteService = new ClienteService(_repositorioCli.Object,
                                                     _repositorioEndCli.Object,
                                                     _consultaCli.Object,
                                                     _consultaEndCli.Object);

            var result = this.clienteService.EncontrarPorCodigo(cliente.Id, Infrastructure.Factory.ObjectFactory.EntityEnum.Cliente, Constants.CLIENTE, Constants.ID);

            // Asserts
            this.cliente.Should().NotBeNull();
            this._repositorioCli.Should().NotBeNull();
            this._repositorioEndCli.Should().NotBeNull();
            this._consultaCli.Should().NotBeNull();
            this._consultaEndCli.Should().NotBeNull();
            this.clienteService.Should().NotBeNull();
            result.Should().NotBeNull();
            result.Id.Should().Be(this.cliente.Id);
        }
    }
}