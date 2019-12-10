using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Auction.Hubs
{
    [Authorize]
    public class UpdateHub : Hub
    {
    }
}
