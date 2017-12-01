using OAuth2.Client;
using OAuth2.Configuration;
using OAuth2.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OAuth2.Models;

namespace SlackAPI
{
    public class SlackClient : OAuth2Client
    {
        public SlackClient(IRequestFactory factory, IClientConfiguration configuration)
            : base(factory, configuration)
        {
        }

        public override string Name
        {
            get
            {
                return "Slack";
            }
        }

        //protected override Endpoint AccessCodeServiceEndpoint
        //{
        //    get
        //    {
        //        return new Endpoint
        //        {
        //            BaseUri = "https://slack.com/oauth/authorize"
        //        }
        //    }
        //}

        protected override Endpoint AccessTokenServiceEndpoint => throw new NotImplementedException();

        protected override Endpoint UserInfoServiceEndpoint => throw new NotImplementedException();

        protected override Endpoint AccessCodeServiceEndpoint => throw new NotImplementedException();

        protected override UserInfo ParseUserInfo(string content)
        {
            throw new NotImplementedException();
        }
    }

}
