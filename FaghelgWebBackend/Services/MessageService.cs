using FaghelgWebBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaghelgWebBackend.Services
{
    public class MessageService
    {
        public Message getMessage(Guid messageId)
        {
            return null;
        }

        public void storeMessage(Message message)
        {

        }

        public IList<Message> getMessagesToUser(Guid userId)
        {
            return null;
        }
    }
}