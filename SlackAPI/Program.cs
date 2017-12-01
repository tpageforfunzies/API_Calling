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

namespace SlackAPI
{
    class Program
    {
        //must use async methods, model it after pokemon
        //ideas: auth method (returns bool re: if tokens are good) that gets the auth token and the access token
        //       then a if (!auth) in the main runasync to check if token is still good
        //       then calling postmessage in runasync using the accesstoken
        //       main is just the runasync


        static HttpClient client = new HttpClient();

        public static void Auth()
        {
            client.BaseAddress = new Uri("https://slack.com/oauth/authorize");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("" +
                "application/json"));
        }

        public static void PostMessage()
        {

        }

        public static void Run()
        {

        }




        static void Main(string[] args)
        {



        }
    }
}
