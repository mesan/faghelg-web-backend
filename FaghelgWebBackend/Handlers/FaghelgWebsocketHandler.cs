using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaghelgWebBackend.Handlers
{
    public class FaghelgWebsocketHandler : WebSocketHandler
    {

        private static WebSocketCollection clients = new WebSocketCollection();

        public static WebSocketCollection getClients()
        {
            return clients;
        }

        public void broadcastMessage(string message)
        {
            clients.Broadcast(message);
        }

        public override void OnOpen()
        {
            clients.Add(this);
            this.Send("Welcom from " + this.WebSocketContext.UserHostAddress);
            broadcastMessage("ny har joinet");
        }
        public override void OnMessage(string message)
        {
            string msgBack = string.Format(
                "You have sent {0} at {1}", message, DateTime.Now.ToLongTimeString());
            this.Send(msgBack);
        }
        public override void OnClose()
        {
            clients.Remove(this);
            base.OnClose();
        }
        public override void OnError()
        {
            base.OnError();
        }
    }
}