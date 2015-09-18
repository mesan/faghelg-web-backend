using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage.Table;
using FaghelgWebBackend.Models;
using System.Configuration;

namespace FaghelgWebBackend.Tests.Models
{
    [TestClass]
    public class TestStorageEmulator
    {
        [TestMethod]
        public void TestMethod1()
        {


            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                    ConfigurationManager.AppSettings["DevStorage"]);

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Create the table if it doesn't exist.
            CloudTable table = tableClient.GetTableReference("messages");

            TableOperation insertOp = TableOperation.Insert(new Message(new Guid(), new Guid(), "dette er en fin body"));

            var insert = table.Execute(insertOp);

            TableQuery<Message> getAllQuery = new TableQuery<Message>();

            var alledata = table.ExecuteQuery(getAllQuery);

        }
    }
}
