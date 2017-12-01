using OAuth2.Client;
using OAuth2.Configuration;
using OAuth2.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace SlackAPI
{
    public class Program
    {
        //must use async methods, model it after pokemon
        //ideas: auth method (returns bool re: if tokens are good) that gets the auth token and the access token
        //       then a if (!auth) in the main runasync to check if token is still good
        //       then calling postmessage in runasync using the accesstoken
        //       main is just the runasync
        //       redirecturi would be "localhost" or 127.0.0.1:port/
        
        //       it is sending the redirecturl to sign in
        //       need to open browser window from console, let me log in, and get the code
        //       similar to how the github sign in from commandline works

        public static string BearerToken { get; set; }
        private const string _apiUrl = "https://slack.com/";
        private const string _clientId = "252005972915.279953222963";
        private const string _clientSecret = "b0fca759029960ac2e214636da305f76";
        private const string _redirectUri = "http://localhost";
        private const string _scope = "chat:write:user";

        static HttpClient client = new HttpClient();

        static async Task<HttpResponseMessage> AuthAsync()
        {
            //full endpoint url
            string url = $"{_apiUrl}/oauth/authorize/?";

            //full request url params
            string requestString = $"client_id={_clientId}&scope={_scope}" +
                $"&redirect_uri={_redirectUri}";

            //the get request to the url with the query params
            var response = await client.GetAsync($"{url} + {requestString}");
            Console.WriteLine(response);

            //reading response as string
            var stringResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine(stringResponse);
            Console.ReadLine();

            //Process.Start($"{response}");


            return response;
        }

        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("" +
                "application/json"));

            var result = await AuthAsync();

        }

    }
}
