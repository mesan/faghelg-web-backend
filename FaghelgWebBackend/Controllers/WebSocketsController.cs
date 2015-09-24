using FaghelgWebBackend.Handlers;
using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace FaghelgWebBackend.Controllers
{
    public class WebSocketsController : ApiController
    {
        // GET: api/WebSockets
        public HttpResponseMessage Get()
        {
            HttpContext.Current.AcceptWebSocketRequest(new FaghelgWebsocketHandler());
            return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
        }
        
    }
}
