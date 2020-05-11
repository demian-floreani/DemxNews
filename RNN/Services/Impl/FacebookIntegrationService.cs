using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Services.Impl
{
    public class FacebookIntegrationService : IFacebookIntegrationService
    {
        private FacebookClient _client { get; set; }

        public FacebookIntegrationService()
        {
            //_client = new FacebookClient();

            //dynamic result = _client.Get("oauth/access_token", new
            //{
            //    client_id = "563553090853853",
            //    client_secret = "3e76bdcedf4d8cfba772a92b4820e102",
            //    grant_type = "client_credentials"
            //});

            //_client.AccessToken = result.access_token;
        }

        public async Task PostLink()
        {
            //// Post to user's wall
            //var postparameters = new Dictionary<string, object>();
            //postparameters["message"] = "Hello world!";
            //postparameters["name"] = "This is a name";
            //postparameters["link"] = "http://thisisalink.com";
            //postparameters["description"] = "This is a description";

            //try
            //{
            //    await _client.PostTaskAsync("/me/feed", postparameters);
            //}
            //catch (Exception ex)
            //{
            //    ;
            //}
        }
    }
}
