using RestSharp;

namespace PrjGestaoClientes.Application.Interfaces
{
    public interface IRequestService
    {
        Task<RestResponse> GetRequest(string urlAPI, string endPointAPI);
        RestResponse PostRequest(object obj, string urlAPI, string endPointAPI);
        RestResponse DeleteRequest(Guid Id, string urlAPI, string endPointAPI);
        RestResponse UpdateRequest(Guid Id, object obj, string urlAPI, string endPointAPI);
    }
}
