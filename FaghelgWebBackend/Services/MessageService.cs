using FaghelgWebBackend.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FaghelgWebBackend.Services
{
    public class MessageService
    {
        private CloudTable table;

        public MessageService()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                    ConfigurationManager.ConnectionStrings["AzureStorage"].ConnectionString);

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            table = tableClient.GetTableReference("messages");
        }

        public Message getMessage(Guid messageId)
        {
            TableQuery<Message> getAllQuery = new TableQuery<Message>();

            return table.ExecuteQuery(getAllQuery)
                .Where(m => m.RowKey.Equals(messageId.ToString()))
                .Single();
        }

        public void storeMessage(Message message)
        {
            TableOperation insertOp = TableOperation.Insert(message);

            table.Execute(insertOp);

        }

        public IList<Message> getMessagesToUser(Guid userId)
        {
            TableQuery<Message> getAllQuery = new TableQuery<Message>();

            return table.ExecuteQuery(getAllQuery)
                .Where(m => m.receiver == userId)
                .ToList();
        }
    }
}