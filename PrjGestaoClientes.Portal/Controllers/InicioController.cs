using Microsoft.AspNetCore.Mvc;
using PrjGestaoClientes.Application.Interfaces;
using PrjGestaoClientes.Domain.Model.Entity;
using PrjGestaoClientes.Infrastructure.Utils;
using PrjGestaoClientes.Portal.Models;
using System.Diagnostics;

namespace PrjGestaoClientes.Portal.Controllers
{
    public class InicioController : Controller
    {
        protected readonly IClienteService _clienteService;

        public InicioController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        /// <summary>
        /// Retorna para a view 'Index' listando os clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                IList<Cliente> clientes = _clienteService.ListarRegistros(Constants.CLIENTE)
                                                         .Where(c => c.IsAtivo)
                                                         .OrderByDescending(c => c.DataCadastro)
                                                         .ToList();

                return View(clientes);
            }
            catch
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Retorna para view 'Sobre'
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Sobre()
        {
            return View();
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
