using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Api2.Utils
{
    public class Utils
    {
        public string URIStringBuilder(string endpoint, string controller, string action)
        {
            return endpoint + "/" + controller.Replace("/", string.Empty) + "/" + action.Replace("/", string.Empty);
        }

        public async Task<T> CallRestAPI<T>(Enums.HttpMethodEnum method, string endpoint, object body = null, object query = null)
        {
            var client = new WebClient();
            var httpClient = new HttpClient();
            HttpResponseMessage response;
            switch (method)
            {
                case Enums.HttpMethodEnum.GET:
                    response = await httpClient.GetAsync(endpoint + query);
                    return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                case Enums.HttpMethodEnum.POST:
                    response = await httpClient.PostAsJsonAsync(endpoint, body);
                    return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                case Enums.HttpMethodEnum.PUT:
                    response = await httpClient.PutAsJsonAsync(endpoint, body);
                    return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                case Enums.HttpMethodEnum.DELETE:
                    response = await httpClient.PostAsJsonAsync(endpoint, body);
                    return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }

            throw new Exception("Invalid operation");
        }
    }
}
