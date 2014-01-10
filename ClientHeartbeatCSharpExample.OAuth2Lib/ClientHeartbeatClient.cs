namespace OAuth2Lib {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Web;
	using DotNetOpenAuth.Messaging;
	using DotNetOpenAuth.OAuth2;

	public class ClientHeartbeatClient : WebServerClient {
        private static readonly AuthorizationServerDescription ClientHeartbeatDescription = new AuthorizationServerDescription
        {
			TokenEndpoint = new Uri("https://clientheartbeat.com/oauth/token"),
			AuthorizationEndpoint = new Uri("https://clientheartbeat.com/oauth/authorize"),
		};

        public ClientHeartbeatClient() : base(ClientHeartbeatDescription)
        {
		}
	}
}
