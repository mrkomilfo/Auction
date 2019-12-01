using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Auction.Hubs
{
    [Authorize]
    public class NotificationHub : Hub
    {
        //Just exist
    }
}