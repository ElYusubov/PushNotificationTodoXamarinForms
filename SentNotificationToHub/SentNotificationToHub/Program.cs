using System;
using Microsoft.Azure.NotificationHubs;
using System.Configuration;

namespace SentNotificationToHub
{
    class Program
    {
        static void Main(string[] args)
        {

            var appSettings = ConfigurationSettings.AppSettings;

            var connectionString = appSettings["Microsoft.Azure.NotificationHubs.ConnectionString"]; 
            SendNotificationAsync(connectionString);
            Console.ReadLine();
        }

        private static async void SendNotificationAsync(string connectionString)
        {
            NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(connectionString, "notification-hub-17");
            await hub.SendGcmNativeNotificationAsync("{ \"data\" : {\"message\":\"Hello Evv Team!\"}}");
        }
    }
}
