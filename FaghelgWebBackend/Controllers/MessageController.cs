using FaghelgWebBackend.Models;
using FaghelgWebBackend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FaghelgWebBackend.Controllers
{
    public class MessageController : ApiController
    {
        private MessageService _messageService;

        MessageController()
        {
            _messageService = new MessageService();
        }

        // GET: api/Message/5
        public Message Get(Guid id)
        {
            return _messageService.getMessage(id);
        }

        // POST: api/Message
        public void Post(Message messsage)
        {
            _messageService.storeMessage(messsage);
        }
    }
}
