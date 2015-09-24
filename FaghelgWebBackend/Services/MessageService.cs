using FaghelgWebBackend.Models;
using FaghelgWebBackend.Handlers;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

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

        public void storeAndEmitMessage(Message message)
        {

            emitMessage(message);
            storeMessage(message);

        }

        public void storeAndBroadcastMessage(Message message)
        {

            broadcastMessage(message);
            storeMessage(message);

        }
        private void storeMessage(Message message)
        {
            message.setPartitionKey();
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

        private void emitMessage (Message message)
        {
            FaghelgWebsocketHandler.getClients().Broadcast(message.RowKey);
        }

        private void broadcastMessage(Message message)
        {
            
        }
    }
}