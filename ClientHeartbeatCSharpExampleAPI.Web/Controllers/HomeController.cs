using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OAuth2Lib;
using System.Net;
using System.Configuration;
using DotNetOpenAuth.OAuth2;
using OAuth2Lib.ClientHeartbeat;

namespace ClientHeartbeatCSharpExampleAPI.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ClientHeartbeatClient client = new ClientHeartbeatClient
        {
            ClientIdentifier = ConfigurationManager.AppSettings["clientHeartbeatConsumerKey"],
            ClientCredentialApplicator = ClientCredentialApplicator.PostParameter(ConfigurationManager.AppSettings["clientHeartbeatConsumerSecret"]),
        };

        public ActionResult Index()
        {
            IAuthorizationState authorization = client.ProcessUserAuthorization();
            if (authorization == null)
            {
                client.RequestUserAuthorization();
            }
            else
            {
                HttpWebRequest request = WebRequest.Create("https://clientheartbeat.com/api/v1/pulses?access_token=" + Uri.EscapeDataString(authorization.AccessToken)) as HttpWebRequest;
                request.Accept = "application/json";
                using (var response = request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        ViewBag.Pulses = PulseResult.Deserialize(responseStream);
                    }
                }
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}