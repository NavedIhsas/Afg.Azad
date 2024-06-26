using Microsoft.AspNetCore.SignalR;
using ShopManagement.Infrastructure.EfCore.VisitorOnline;

namespace WebHost.Hubs
{
    public class OnlineVisitorHub : Hub
    {
        private readonly IVisitorOnlineService _service;

        public OnlineVisitorHub(IVisitorOnlineService service)
        {
            _service = service;
        }
        public override Task OnConnectedAsync()
        {
            var visitorId = Context.GetHttpContext()?.Request.Cookies["VisitorId"];
            _service.ConnectUser(visitorId);
            //var count = _service.GetCount();
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var visitorId = Context.GetHttpContext()?.Request.Cookies["VisitorId"];

            _service.DisconnectUser(visitorId);
            // var count = _service.GetCount();
            return base.OnDisconnectedAsync(exception);
        }
    }
}
