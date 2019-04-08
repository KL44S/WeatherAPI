using Business.Services.Abstractions;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class GenericRestService : IGenericRestService
    {
        public async Task<T> Get<T>(string url)
        {
            RestClient client = new RestClient(url);

            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");

            Task<IRestResponse> task = Task.Factory.StartNew(() => client.Execute(request));
            IRestResponse response = await task;

            T mappedResponse = JsonConvert.DeserializeObject<T>(response.Content);

            return mappedResponse;
        }
    }
}
