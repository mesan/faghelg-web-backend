using Microsoft.Web.WebSockets;
using System;
using System.Web;

namespace FaghelgWebBackendWebSocket
{
    public class ws : WebSocketHandler
    {
        private static WebSocketCollection clients = new WebSocketCollection();

        public override void OnOpen()
        {
            clients.Broadcast("Velkommen");

            base.OnOpen();
        }

        public override void OnClose()
        {
            base.OnClose();
        }

        public override void OnMessage(string message)
        {
            base.OnMessage(message);
        }

        public void brodcastMessage(string message)
        {
            clients.Broadcast("Heihei");
        } 
    }
}
