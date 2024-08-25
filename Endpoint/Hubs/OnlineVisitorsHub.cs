using Application.Interfaces;
using Microsoft.AspNetCore.SignalR;
namespace Endpoint.Hubs
{
    public class OnlineVisitorsHub:Hub
    {
        private readonly IVisitorOnlineService visitorOnlineService;
        public OnlineVisitorsHub(IVisitorOnlineService visitorOnlineService)
        {
            this.visitorOnlineService = visitorOnlineService;
            
        }
        public override Task OnConnectedAsync()
        {
            string VisitorId = Context.GetHttpContext().Request.Cookies["VisitorId"];
            visitorOnlineService.ConnectUser(VisitorId);
            var count=visitorOnlineService.GetCount();
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            string VisitorId = Context.GetHttpContext().Request.Cookies["VisitorId"];

            visitorOnlineService.DisconnectUser(VisitorId);
            var count = visitorOnlineService.GetCount();
            return base.OnDisconnectedAsync(exception);
        }
    }
}
