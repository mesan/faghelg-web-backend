using FaghelgWebBackend.Models;
using FaghelgWebBackend.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaghelgWebBackend.Mappers
{
    public class MessageToEventMapper
    {
        private readonly string messageEndpoint = "/message/";

        public Event map(Message message) 
        {
            return new Event {
                eventType = EventType.NEW_MESSAGE,
                eventId = message.RowKey,
                eventEndpoint = messageEndpoint + message.RowKey};
        }
    }
}