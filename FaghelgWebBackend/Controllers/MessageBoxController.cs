using FaghelgWebBackend.Models;
using FaghelgWebBackend.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace FaghelgWebBackend.Controllers
{
    public class MessageBoxController : ApiController
    {
        private MessageService _messageService;


        MessageController()
        {
            _messageService = new MessageService();
        }

        // GET: api/MessageBox
        public IEnumerable<Message> Get(Guid id)
        {
            return _messageService.getMessagesToUser(id);
        }
        
    }
}
