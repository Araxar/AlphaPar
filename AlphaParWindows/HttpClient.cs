using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace AlphaParWindows
{
    public class HttpClient
    {
        private RestClient Client { get; set; }

        public HttpClient()
        {
            Client = new RestClient("http://localhost:64156/api");



            var request = new RestRequest("resource/{id}", Method.POST);
            request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
            request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource
            

            // execute the request
            IRestResponse response = Client.Execute(request);
            var content = response.Content; // raw content as string

            //// or automatically deserialize result
            //// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            //RestResponse<Person> response2 = Client.Execute<Person>(request);
            //var name = response2.Data.Name;

            //// easy async support
            //Client.ExecuteAsync(request, response => {
            //    Console.WriteLine(response.Content);
            //});

            //// async with deserialization
            //var asyncHandle = Client.ExecuteAsync<Person>(request, response => {
            //    Console.WriteLine(response.Data.Name);
            //});

            //// abort the request on demand
            //asyncHandle.Abort();
        }
        
    }
}
