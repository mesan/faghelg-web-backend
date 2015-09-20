using FaghelgWebBackend.Exceptions;
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

        public Message() {
            RowKey = Guid.NewGuid().ToString();
        }

        public Message(Guid sender, Guid receiver, string body)
        {
            this.sender = sender;
            this.receiver = receiver;
            this.body = body;
            RowKey = Guid.NewGuid().ToString();
            setPartitionKey();
        }

        public void setPartitionKey()
        {
            var leftByteArray = sender.ToByteArray();
            var rightByteArray = receiver.ToByteArray();


            if (leftByteArray.Length != rightByteArray.Length)
                throw new IllegalLengthsInXorOperationException();

            PartitionKey =  String.Join(string.Empty, 
                (leftByteArray
                    .Select((b, i) => b ^ rightByteArray[i])
                    .ToArray()));

        }
    }
}