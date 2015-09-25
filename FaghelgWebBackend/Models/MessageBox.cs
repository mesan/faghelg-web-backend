using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaghelgWebBackend.Models
{
    public class MessageBox
    {
        Guid owner { get; set; }
        IEnumerable messages { get; set; }
        int messageCount { get; set; }
        int pages { get; set; }
    }
}