namespace push_notification_todo
{
    public static class Constants
	{
		// Replace strings with your Azure Mobile App endpoint.
		public static string ApplicationURL = @"https://push-notification-todo.azurewebsites.net";

        public static string SenderId = "763349422427";
        public static string[] Tags = new string[] {"broadcast", "test", "evv", "provider", "oxford"};
        public const string ListenConnectionString = "Endpoint=sb://ns-notification-hub-17.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=7JgMPUZd4coxOv17V0gGQ5Pyd62adkc8Uw5Sa5Kc0XY=";
        public const string NotificationHubName = "notification-hub-17";
    };
       
}