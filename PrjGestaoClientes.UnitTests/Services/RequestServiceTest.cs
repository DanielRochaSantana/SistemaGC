using FluentAssertions;
using PrjGestaoClientes.Application.Services;
using PrjGestaoClientes.Domain.Model.Entity;
using PrjGestaoClientes.Infrastructure.Utils;
using PrjGestaoClientes.UnitTests.Base;

namespace PrjGestaoClientes.UnitTests.Services
{
    public class RequestServiceTest : BaseTest
    {
        [Fact(DisplayName = "Should create a RequestService object and execute the GetRequest Mehod Passing a Valid parameters")]
        [Trait("PrjGestaoClientes.Application.Services", "RequestService")]
        public void ShouldCreateARequestServiceObjectAndExecuteTheGetRequestMehodPassingAValidCliente()
        {
            // Arrange and act
            this._requestOperation.Setup(item => item.GetRequest(Constants.URL_API, Constants.ENDPOINT_API));

            this.requestService = new RequestService(_requestOperation.Object);

            var response = this.requestService.GetRequest(Constants.URL_API, Constants.ENDPOINT_API);

            // Asserts
            this._repositorioCli.Should().NotBeNull();
            this._repositorioEndCli.Should().NotBeNull();
            this._consultaCli.Should().NotBeNull();
            this._consultaEndCli.Should().NotBeNull();
            this.requestService.Should().NotBeNull();
            response.Should().NotBeNull();
        }

        [Theory(DisplayName = "Should create a RequestService object and execute the GetRequest Mehod Passing a Invalid parameters")]
        [Trait("PrjGestaoClientes.Application.Services", "RequestService")]
        [InlineData("")]
        [InlineData(" ")]
        public void ShouldCreateARequestServiceObjectAndExecuteTheGetRequestMehodPassingAInvalidCliente(string parameter)
        {
            // Arrange and act
            this._requestOperation.Setup(item => item.GetRequest(Constants.URL_API, Constants.ENDPOINT_API));

            this.requestService = new RequestService(_requestOperation.Object);

            var response = this.requestService.GetRequest(parameter, parameter);

            // Asserts
            this._repositorioCli.Should().NotBeNull();
            this._repositorioEndCli.Should().NotBeNull();
            this._consultaCli.Should().NotBeNull();
            this._consultaEndCli.Should().NotBeNull();
            this.requestService.Should().NotBeNull();
            response.Should().NotBeNull();
        }

        [Fact(DisplayName = "Should create a RequestService object and execute the PostRequest Mehod Passing a Valid parameters")]
        [Trait("PrjGestaoClientes.Application.Services", "RequestService")]
        public void ShouldCreateARequestServiceObjectAndExecuteThePostRequestMehodPassingAValidCliente()
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
            this._requestOperation.Setup(item => item.PostRequest(this.cliente, Constants.URL_API, Constants.ENDPOINT_API));

            this.requestService = new RequestService(_requestOperation.Object);

            var response = this.requestService.PostRequest(this.cliente, Constants.URL_API, Constants.ENDPOINT_API);

            // Asserts
            this.cliente.Should().NotBeNull();
            this._repositorioCli.Should().NotBeNull();
            this._repositorioEndCli.Should().NotBeNull();
            this._consultaCli.Should().NotBeNull();
            this._consultaEndCli.Should().NotBeNull();
            this.requestService.Should().NotBeNull();
        }

        [Theory(DisplayName = "Should create a RequestService object and execute the PostRequest Mehod Passing a Invalid parameters")]
        [Trait("PrjGestaoClientes.Application.Services", "RequestService")]
        [InlineData("")]
        [InlineData(" ")]
        public void ShouldCreateARequestServiceObjectAndExecuteThePostRequestMehodPassingAInvalidCliente(string parameter)
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
            this._requestOperation.Setup(item => item.PostRequest(this.cliente, Constants.URL_API, Constants.ENDPOINT_API));

            this.requestService = new RequestService(_requestOperation.Object);

            var response = this.requestService.PostRequest(this.cliente, parameter, parameter);

            // Asserts
            this.cliente.Should().NotBeNull();
            this._repositorioCli.Should().NotBeNull();
            this._repositorioEndCli.Should().NotBeNull();
            this._consultaCli.Should().NotBeNull();
            this._consultaEndCli.Should().NotBeNull();
            this.requestService.Should().NotBeNull();
        }

        [Fact(DisplayName = "Should create a RequestService object and execute the DeleteRequest Mehod Passing a Valid parameters")]
        [Trait("PrjGestaoClientes.Application.Services", "RequestService")]
        public void ShouldCreateARequestServiceObjectAndExecuteTheDeleteRequestMehodPassingAValidCliente()
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
            this._requestOperation.Setup(item => item.DeleteRequest(this.cliente.Id, Constants.URL_API, Constants.ENDPOINT_API));

            this.requestService = new RequestService(_requestOperation.Object);

            var response = this.requestService.DeleteRequest(this.cliente.Id, Constants.URL_API, Constants.ENDPOINT_API);

            // Asserts
            this.cliente.Should().NotBeNull();
            this._repositorioCli.Should().NotBeNull();
            this._repositorioEndCli.Should().NotBeNull();
            this._consultaCli.Should().NotBeNull();
            this._consultaEndCli.Should().NotBeNull();
            this.requestService.Should().NotBeNull();
        }

        [Theory(DisplayName = "Should create a RequestService object and execute the DeleteRequest Mehod Passing a Invalid parameters")]
        [Trait("PrjGestaoClientes.Application.Services", "RequestService")]
        [InlineData("")]
        [InlineData(" ")]
        public void ShouldCreateARequestServiceObjectAndExecuteTheDeleteRequestMehodPassingAInvalidCliente(string parameter)
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
            this._requestOperation.Setup(item => item.DeleteRequest(this.cliente.Id, Constants.URL_API, Constants.ENDPOINT_API));

            this.requestService = new RequestService(_requestOperation.Object);

            var response = this.requestService.DeleteRequest(this.cliente.Id, parameter, parameter);

            // Asserts
            this.cliente.Should().NotBeNull();
            this._repositorioCli.Should().NotBeNull();
            this._repositorioEndCli.Should().NotBeNull();
            this._consultaCli.Should().NotBeNull();
            this._consultaEndCli.Should().NotBeNull();
            this.requestService.Should().NotBeNull();
        }

        [Fact(DisplayName = "Should create a RequestService object and execute the UpdateRequest Mehod Passing a Valid parameters")]
        [Trait("PrjGestaoClientes.Application.Services", "RequestService")]
        public void ShouldCreateARequestServiceObjectAndExecuteTheDeleteUpdateRequestPassingAValidCliente()
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
            this._requestOperation.Setup(item => item.UpdateRequest(this.cliente.Id, this.cliente, Constants.URL_API, Constants.ENDPOINT_API));

            this.requestService = new RequestService(_requestOperation.Object);

            var response = this.requestService.UpdateRequest(this.cliente.Id, this.cliente, Constants.URL_API, Constants.ENDPOINT_API);

            // Asserts
            this.cliente.Should().NotBeNull();
            this._repositorioCli.Should().NotBeNull();
            this._repositorioEndCli.Should().NotBeNull();
            this._consultaCli.Should().NotBeNull();
            this._consultaEndCli.Should().NotBeNull();
            this.requestService.Should().NotBeNull();
        }

        [Theory(DisplayName = "Should create a RequestService object and execute the UpdateRequest Mehod Passing a Invalid parameters")]
        [Trait("PrjGestaoClientes.Application.Services", "RequestService")]
        [InlineData("")]
        [InlineData(" ")]
        public void ShouldCreateARequestServiceObjectAndExecuteTheUpdateRequestMehodPassingAInvalidCliente(string parameter)
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
            this._requestOperation.Setup(item => item.UpdateRequest(this.cliente.Id, this.cliente, Constants.URL_API, Constants.ENDPOINT_API));

            this.requestService = new RequestService(_requestOperation.Object);

            var response = this.requestService.UpdateRequest(Guid.Empty, this.cliente, parameter, parameter);

            // Asserts
            this.cliente.Should().NotBeNull();
            this._repositorioCli.Should().NotBeNull();
            this._repositorioEndCli.Should().NotBeNull();
            this._consultaCli.Should().NotBeNull();
            this._consultaEndCli.Should().NotBeNull();
            this.requestService.Should().NotBeNull();
        }
    }
}