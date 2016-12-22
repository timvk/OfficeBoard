using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace OfficeBoard.Web
{
    [HubName("notification")]
    public class NotificationHub : Hub
    {
        public void Notify()
        {
            Clients.All.sendNotification();
        }
    }
}