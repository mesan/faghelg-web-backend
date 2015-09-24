using Microsoft.Web.WebSockets;
using System;
using System.Web;

namespace FaghelgWebBackend.Handlers
{
    public class WebSocketsHTTPHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest || context.IsWebSocketRequestUpgrading)
                context.AcceptWebSocketRequest(new FaghelgWebsocketHandler());
                    
        }
    }
}
