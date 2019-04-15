using Business.Exceptions;
using Business.Services.Abstractions;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class GenericRestService : IGenericRestService
    {
        private void ValidateStatusCode(HttpStatusCode httpStatusCode)
        {
            switch (httpStatusCode)
            {
                case HttpStatusCode.NotFound:
                    throw new NotFoundException();

                case HttpStatusCode.BadRequest:
                    throw new BadRequestException();

                case HttpStatusCode.InternalServerError:
                    throw new Exception();
            }
        }

        public async Task<T> Get<T>(string url)
        {
            IRestClient client = new RestClient(url);

            IRestRequest request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");

            Task<IRestResponse> task = Task.Factory.StartNew(() => client.Execute(request));
            IRestResponse response = await task;

            this.ValidateStatusCode(response.StatusCode);

            T mappedResponse = JsonConvert.DeserializeObject<T>(response.Content);

            return mappedResponse;
        }
    }
}
