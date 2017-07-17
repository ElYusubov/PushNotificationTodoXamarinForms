using System;
using Microsoft.Azure.NotificationHubs;
using System.Configuration;
using System.Collections.Generic;

namespace SentNotificationToHub
{
    class Program
    {
        static void Main(string[] args)
        {            
            var appSettings = ConfigurationSettings.AppSettings;
            //var connectionString = appSettings["Microsoft.Azure.NotificationHubs.ConnectionString"]; 

            var connectionString = appSettings["HubSendConnection"];
            var hubPath = appSettings["HubPath"];

            Console.Write("Please enter the tag name :");
            string inputTag = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(connectionString) || string.IsNullOrWhiteSpace(hubPath))
            {
                Console.WriteLine("ERROR - Notification connectionstring OR HubPath is not defined.");
                Console.WriteLine("--------------------------------------------------");
            }
            else if (string.IsNullOrWhiteSpace(inputTag))
            {
                Console.WriteLine("ERROR - 'tag name' entry is null OR empty.");
                Console.WriteLine("--------------------------------------------------");
            }
            else
            {
                SendNotificationAsync(connectionString, hubPath, inputTag.Trim());
                Console.WriteLine(string.Format("Notification with a tag {0} is sent.", inputTag.Trim()));
                Console.WriteLine("--------------------------------------------------");               
            }

            Console.WriteLine("PRESS ANY KEY TO EXIT.");
            Console.ReadKey();
        }

        private static async void SendNotificationAsync(string connectionString, string hubPath, string tag)
        {

            // Note: used to sent Notification to all registered devices
            //var jsonPayLoad = "{ \"data\" : {\"message\":\"Hello Evv!\"}}";
            //NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(connectionString, "notification-hub-17");
            //await hub.SendGcmNativeNotificationAsync(jsonPayLoad);

            // "broadcast", "test", "evv", "provider", "oxford"
            var tags = new List<string>() { tag };
            var jsonPayLoadTags = "{ \"data\" : {\"message\":\"TAGS are broadcast-test-evv-provider-oxford \"}}";

            NotificationHubClient hubClient2 = NotificationHubClient.
                CreateClientFromConnectionString(connectionString, hubPath);

            await hubClient2.SendGcmNativeNotificationAsync(jsonPayLoadTags, tags);
        }
    }
}