using FaghelgWebBackend.Models;
using FaghelgWebBackend.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace FaghelgWebBackend.Controllers
{
    public class MessageBoxController : ApiController
    {

        private MessageBoxService messageBoxService;


        MessageBoxController()
        {
            messageBoxService = new MessageBoxService();
        }

        // GET: api/MessageBox
        public MessageBox Get(Guid id)
        {
            return messageBoxService.getBoxByUserId(id);

        }


    }
}
