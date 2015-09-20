using FaghelgWebBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FaghelgWebBackend.Services
{
    public class MessageInterchangeController : ApiController
    {

        private MessageService messageService;

        MessageInterchangeController()
        {
            messageService = new MessageService();
        }


        // POST: api/MessageInterchange
        public void Post(Message message)
        {
            messageService.storeAndEmitMessage(message);
        }
    }
}
