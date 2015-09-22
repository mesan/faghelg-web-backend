using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaghelgWebBackendWebSocket
{
    public class WSFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            WebSocketHost host = new WebSocketHost(serviceType, baseAddresses);
            host.AddWebSocketEndpoint();
            return host;
        }
    }
}