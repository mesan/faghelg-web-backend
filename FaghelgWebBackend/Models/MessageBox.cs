using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaghelgWebBackend.Models
{
    public class MessageBox
    {
        public Guid owner { get; set; }
        public IEnumerable messages { get; set; }
        public int messageCount { get; set; }
        public int pages { get; set; }
    }
}