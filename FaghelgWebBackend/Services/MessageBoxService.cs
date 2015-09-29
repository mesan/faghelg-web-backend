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
    public class MessageBoxService
    {
        private CloudTable table;

        public MessageBoxService()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                    ConfigurationManager.ConnectionStrings["AzureStorage"].ConnectionString);

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            table = tableClient.GetTableReference("messages");
        }

        public MessageBox getBoxByUserId(Guid userid, int pageSize = 50)
        {
            TableQuery<Message> getAllQuery = new TableQuery<Message>();

            return new MessageBox {
                owner = userid,
                messages = table.ExecuteQuery(getAllQuery)
                            .Where(m => m.receiver == userId)
                            .ToList(),
                messageCount = getAllQuery.Count,
                pages = Math.Ceiling( (double) ((double) getAllQuery.Count() / (double) pageSize))
            };
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