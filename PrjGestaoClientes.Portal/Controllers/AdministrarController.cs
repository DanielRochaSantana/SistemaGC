using Microsoft.AspNetCore.Mvc;
using PrjGestaoClientes.Application.Interfaces;
using PrjGestaoClientes.Domain.Model;
using PrjGestaoClientes.Domain.Model.Entity;
using PrjGestaoClientes.Infrastructure.Utils;
using PrjGestaoClientes.Portal.Models;
using System.Diagnostics;
using System.Text.Json;
using Factory = PrjGestaoClientes.Infrastructure.Factory;

namespace PrjGestaoClientes.Portal.Controllers
{
    public class AdministrarController : Controller
    {
        private readonly IRequestService _requestService;

        public AdministrarController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// Retorna para a view 'Index' listando os clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _requestService.GetRequest(Constants.URL_API, Constants.ENDPOINT_API);

                var response = JsonSerializer.Deserialize<List<ClienteModelView>>(result.Content!)!;

                IList<ClienteModelView> lstClientesMV = response != null ? response : new List<ClienteModelView>();

                IList<Cliente?> clientes = lstClientesMV.Select(c => c.Cliente)
                                                       .Where(c => c != null && c.IsAtivo).ToList();

                return View(clientes);
            }
            catch
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Adiciona ou atualiza registro
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> AdicionarOuAtualizarRegistro(Guid Id)
        {
            try
            {
                if (Id != Guid.Empty)
                {

                    var result = await _requestService.GetRequest(Constants.URL_API, Constants.ENDPOINT_API);

                    var response = JsonSerializer.Deserialize<List<ClienteModelView>>(result.Content!)!;

                    IList<ClienteModelView> lstClientesMV = response != null ? response : new List<ClienteModelView>();

                    var clienteMV = lstClientesMV.Where(c => c.Cliente.Id == Id).FirstOrDefault();

                    ClienteModel clienteModel = Factory.ObjectFactory.GetClientModel(clienteMV);

                    clienteModel.IsEdit = true;

                    return View(clienteModel);
                }
                else if (Id == Guid.Empty)
                {
                    return View(Factory.ObjectFactory.GetClientModel(default));
                }

                return NoContent();
            }
            catch
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Adiciona ou atualiza registro
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AdicionarOuAtualizarRegistro(ClienteModel model)
        {
            try
            {
                Cliente cliente = Factory.ObjectFactory.GetClientEntity(model);

                if (model.IsEdit)
                    _requestService.UpdateRequest(cliente.Id, cliente, Constants.URL_API, "?IdCliente=");

                else if (!model.IsEdit)
                    _requestService.PostRequest(cliente, Constants.URL_API, Constants.ENDPOINT_API);

                return RedirectToAction("Index", "Administrar");
            }
            catch
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Remove registro
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RemoverRegistro(Guid Id)
        {
            try
            {
                if (Id != Guid.Empty)
                {
                    _requestService.DeleteRequest(Id, Constants.URL_API, Constants.ENDPOINT_API);
                }

                return RedirectToAction("Index", "Administrar");

            }
            catch
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Retorna a View monstrando dados do erro
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet]
        public IActionResult Error()
        {
            string _RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            var errorVM = new ErrorViewModel
            {
                RequestId = _RequestId
            };

            return View(errorVM);
        }
    }
}
