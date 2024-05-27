using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.NotificationHubs;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Joshua_POE_CLDV.Models
{
    

    public class NotificationService
    {
        private readonly NotificationHubClient _hubClient;

        public NotificationService(IConfiguration configuration)
        {
            var connectionString = configuration["NotificationHub:ConnectionString"];
            var hubName = configuration["NotificationHub:HubName"];
            _hubClient = NotificationHubClient.CreateClientFromConnectionString(connectionString, hubName);
        }

        public async Task SendNotificationAsync(string message, string userTag)
        {
            var notification = new Dictionary<string, string>
        {
            {"message", message}
        };

            await _hubClient.SendTemplateNotificationAsync(notification, userTag);
        }
    }

}
