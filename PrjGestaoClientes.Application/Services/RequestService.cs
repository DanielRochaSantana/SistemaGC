using PrjGestaoClientes.Application.Interfaces;
using PrjGestaoClientes.Infrastructure.Interfaces.Request;
using RestSharp;

namespace PrjGestaoClientes.Application.Services
{
    public class RequestService : IRequestService
    {
        protected readonly IRequestOperation requestOperation;

        public RequestService(IRequestOperation requestOperation)
        {
            this.requestOperation = requestOperation;
        }

        public async Task<RestResponse> GetRequest(string urlAPI, string endPointAPI)
        {
            return await requestOperation.GetRequest(urlAPI, endPointAPI);
        }

        public RestResponse PostRequest(object obj, string urlAPI, string endPointAPI)
        {
            return requestOperation.PostRequest(obj, urlAPI, endPointAPI);
        }
        
        public RestResponse DeleteRequest(Guid Id, string urlAPI, string endPointAPI)
        {
            return requestOperation.DeleteRequest(Id, urlAPI, endPointAPI);
        }
        
        public RestResponse UpdateRequest(Guid Id, object obj, string urlAPI, string endPointAPI)
        {
            return requestOperation.UpdateRequest(Id, obj, urlAPI, endPointAPI);
        }
    }
}
