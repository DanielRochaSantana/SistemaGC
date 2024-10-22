using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrjGestaoClientes.Application.Interfaces;
using PrjGestaoClientes.Domain.Model;
using PrjGestaoClientes.Domain.Model.Entity;
using PrjGestaoClientes.Infrastructure.Utils;
using System.Net;
using Factory = PrjGestaoClientes.Infrastructure.Factory;

namespace PrjGestaoClientes.GerenciarClientes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        protected readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        [Authorize]
        public HttpResponseMessage Adicionar([FromBody] ClienteModelView clienteMdlVw)
        {
            try
            {
                if (clienteMdlVw == null || clienteMdlVw.Cliente == null || clienteMdlVw.EnderecoCliente == null)
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);

                _clienteService.AdicionarEndCli(clienteMdlVw.EnderecoCliente, Constants.ID, Constants.ENDERECO_CLIENTE);
                clienteMdlVw.Cliente.IdEnderecoCliente = clienteMdlVw.EnderecoCliente.Id;
                _clienteService.Adicionar(clienteMdlVw.Cliente, Constants.ID, Constants.CLIENTE);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("{Id}")]
        [Authorize]
        public HttpResponseMessage Apagar(Guid Id)
        {
            try
            {
                if (Id == Guid.Empty)
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);

                _clienteService.Remover(Id, Factory.ObjectFactory.EntityEnum.Cliente, Constants.CLIENTE, Constants.ID);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        [Authorize]
        public HttpResponseMessage Atualizar(Guid IdCliente, [FromBody] ClienteModelView clienteMdlVw)
        {
            try
            {
                if (clienteMdlVw == null || clienteMdlVw.Cliente == null ||
                    clienteMdlVw.Cliente.Id == Guid.Empty ||
                    clienteMdlVw.Cliente.Id != IdCliente || clienteMdlVw.EnderecoCliente == null)
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);

                _clienteService.AtualizarEndCli(clienteMdlVw.EnderecoCliente, Constants.ID, Constants.ENDERECO_CLIENTE);
                _clienteService.Atualizar(clienteMdlVw.Cliente, Constants.ID, Constants.CLIENTE);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<ClienteModelView> ObterClientes()
        {
            try
            {
                IEnumerable<Cliente> clientes = _clienteService.ListarRegistros(Constants.CLIENTE);
                List<ClienteModelView> listaClientesMdlVw = new List<ClienteModelView>();

                foreach (Cliente cliente in clientes)
                {
                    EnderecoCliente? endereco = _clienteService
                                                    .EncontrarPorCodigoEndCli(cliente.IdEnderecoCliente,
                                                                              Factory.ObjectFactory.EntityEnum.EnderecoCliente,
                                                                              Constants.ENDERECO_CLIENTE,
                                                                              Constants.ID);

                    listaClientesMdlVw.Add(
                            Factory.ObjectFactory.GetClienteModelView(cliente, endereco)
                        );
                }

                return listaClientesMdlVw;
            }
            catch
            {
                return new List<ClienteModelView>();
            }
        }

        [HttpGet("{Id}")]
        [Authorize]
        public ClienteModelView ObterCliente(Guid Id)
        {
            try
            {
                Cliente? cliente = _clienteService.EncontrarPorCodigo(Id,
                                                                      Factory.ObjectFactory.EntityEnum.Cliente,
                                                                      Constants.CLIENTE,
                                                                      Constants.ID);
                EnderecoCliente? endereco = null;

                if (cliente?.IdEnderecoCliente != null)
                    endereco = _clienteService
                                      .EncontrarPorCodigoEndCli(cliente.IdEnderecoCliente,
                                                                Factory.ObjectFactory.EntityEnum.EnderecoCliente,
                                                                Constants.ENDERECO_CLIENTE,
                                                                Constants.ID);

                ClienteModelView? clienteMdVw = Factory.ObjectFactory.GetClienteModelView(cliente, endereco);

                return clienteMdVw;
            }
            catch
            {
                return default;
            }
        }
    }
}
