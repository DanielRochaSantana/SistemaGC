using PrjGestaoClientes.Infrastructure.Interfaces.Request;
using RestSharp;

namespace PrjGestaoClientes.Infrastructure.Request
{
    public class RequestOperation : IRequestOperation
    {
        public async Task<RestResponse> GetRequest(string urlAPI, string endPointAPI)
        {
            var options = new RestClientOptions(urlAPI);

            var client = new RestClient(options);

            var request = new RestRequest(endPointAPI);

            var response = await client.GetAsync(request);

            return response;
        }

        public RestResponse PostRequest(object obj, string urlAPI, string endPointAPI)
        {
            var client = new RestClient(urlAPI);

            var request = new RestRequest(endPointAPI);

            request.AddBody(obj);

            var response = client.ExecutePost(request);

            return response;
        }

        public RestResponse DeleteRequest(Guid Id, string urlAPI, string endPointAPI)
        {
            var client = new RestClient(urlAPI);
            var request = new RestRequest(endPointAPI + "/" + Id.ToString(), Method.Delete);
            var response = client.Execute(request);
            return response;
        }

        public RestResponse UpdateRequest(Guid Id, object obj, string urlAPI, string endPointAPI)
        {
            var client = new RestClient(urlAPI);

            var request = new RestRequest(endPointAPI + Id.ToString());

            request.AddBody(obj);

            var response = client.ExecutePut(request);

            return response;
        }
    }
}
