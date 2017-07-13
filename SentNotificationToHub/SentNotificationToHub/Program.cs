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
            var connectionString = appSettings["Microsoft.Azure.NotificationHubs.ConnectionString"]; 
            SendNotificationAsync(connectionString);

            Console.WriteLine("Notification with a note 'TAGS are broadcast-test-evv-provider-oxford' is sent.");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("PRESS ANY KEY TO EXIT.");
            Console.ReadLine();
        }

        private static async void SendNotificationAsync(string connectionString)
        {

            // Note: used to sent Notification to all registered devices
            //var jsonPayLoad = "{ \"data\" : {\"message\":\"Hello Evv!\"}}";
            //NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(connectionString, "notification-hub-17");
            //await hub.SendGcmNativeNotificationAsync(jsonPayLoad);

            var tags = new List<string>() { "broadcast", "test", "evv", "provider", "oxford" };
            var jsonPayLoadTags = "{ \"data\" : {\"message\":\"TAGS are broadcast-test-evv-provider-oxford \"}}";

            NotificationHubClient hubClient2 = NotificationHubClient.
                CreateClientFromConnectionString(connectionString, "notification-hub-17");
            await hubClient2.SendGcmNativeNotificationAsync(jsonPayLoadTags, tags);
        }
    }
}