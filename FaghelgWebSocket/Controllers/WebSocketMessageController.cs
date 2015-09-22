using FaghelgWebSocket.Handlers;
using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FaghelgWebSocket.Controllers
{
    public class WebSocketMessageController : ApiController
    {

        // POST: api/WebSocketMessage
        public void Post(string message)
        {
            FaghelgWebsocketHandler.getClients().Broadcast(message);
        }
    }
}
