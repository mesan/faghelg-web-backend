using FaghelgWebBackend.Models;
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
        // GET: api/Message
        public IList<Message> Get()
        {
            return null;
        }

        // GET: api/Message/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Message
        public void Post(Message messsage)
        {
        }
    }
}
