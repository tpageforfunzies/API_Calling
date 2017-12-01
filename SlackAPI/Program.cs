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

        static string clientId = "252005972915.279953222963";
        static string clientSecret = "b0fca759029960ac2e214636da305f76";

        static string baseUrl = "https://slack.com/";

        static string accessToken = null;

        static void Main(string[] args)
        {

            DoIt().Wait();

        }

        private static async Task<int> DoIt()
        {
            accessToken = await GetAccessToken();
            Console.WriteLine(accessToken != null ? "Got Token" : "No Token found");
            return 0;
        }

        private static async Task<string> GetAccessToken()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("client_id", clientId));
                postData.Add(new KeyValuePair<string, string>("scope", "chat:write:user"));
                postData.Add(new KeyValuePair<string, string>("redirect_uri", "209.43.102.90"));

                FormUrlEncodedContent content = new FormUrlEncodedContent(postData);

                HttpResponseMessage response = await client.PostAsync("oauth/authorize", content);
                string jsonString = await response.Content.ReadAsStringAsync();
                object responseData = JsonConvert.DeserializeObject(jsonString);
                Console.WriteLine(((dynamic)responseData).code);
                return ((dynamic)responseData).code;
                
            }
        }

    }
}
