using System;
using Microsoft.Azure.NotificationHubs;

namespace SentNotificationToHub
{
    class Program
    {
        static void Main(string[] args)
        {
            SendNotificationAsync();
            Console.ReadLine();
        }

        private static async void SendNotificationAsync()
        {
            NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString("Endpoint=sb://ns-notification-hub-17.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=7JgMPUZd4coxOv17V0gGQ5Pyd62adkc8Uw5Sa5Kc0XY=", "notification-hub-17");
            await hub.SendGcmNativeNotificationAsync("{ \"data\" : {\"message\":\"Hello Evv Team!\"}}");
        }
    }
}
