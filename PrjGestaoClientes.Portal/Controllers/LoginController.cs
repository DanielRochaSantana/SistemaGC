using Microsoft.AspNetCore.Mvc;
using PrjGestaoClientes.Application.Interfaces;
using PrjGestaoClientes.Domain.Model;
using PrjGestaoClientes.Domain.Model.Response;
using PrjGestaoClientes.Infrastructure.Utils;
using PrjGestaoClientes.Portal.Models;
using System.Diagnostics;
using System.Text.Json;

namespace PrjGestaoClientes.Portal.Controllers
{
    public class LoginController : Controller
    {
        protected readonly IClienteService _clienteService;
        protected readonly IRequestService _requestService;

        public LoginController(IClienteService clienteService, IRequestService requestService)
        {
            _clienteService = clienteService;
            _requestService = requestService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserModel model)
        {
            try
            {
                var result = _requestService.PostRequest(model, Constants.URL_API_LOGIN, Constants.ENDPOINT_API_LOGIN);

                var response = JsonSerializer.Deserialize<LoginResponse>(result.Content!)!;

                if (response == null || string.IsNullOrEmpty(response.token))
                {
                    HttpContext.Session.Remove("Token");
                    HttpContext.Session.Clear();
                    return View();
                }
                else
                {
                    HttpContext.Session.SetString(response.token, "Token");
                    var token = HttpContext.Session.GetString("Token");
                    return RedirectToAction("Index", "Inicio");
                }

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
