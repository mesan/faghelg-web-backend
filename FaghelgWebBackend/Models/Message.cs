using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaghelgWebBackend.Models
{
    public class Message : TableEntity
    {
        public Guid sender { get; set; }
        public Guid receiver { get; set; }
        public string body { get; set; }

        public Message() { }

        public Message(Guid sender, Guid receiver, string body)
        {
            this.sender = sender;
            this.receiver = receiver;
            this.body = body;
            RowKey = new Guid().ToString();
            PartitionKey = receiver.ToString();
        }

    }
}