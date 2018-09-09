using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace MiscHelper.Hubs
{
    public class NotifyHub : Hub<ITypedHubClient>
    {
        public async Task SendMessage(string user, string message)
        {
            await this.Clients.All.BroadcastMessage("ReceiveMessage", message);
        }
    }
}