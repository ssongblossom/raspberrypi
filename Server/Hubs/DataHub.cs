using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using blazorHub.Shared;


namespace blazorHub.Server.Hubs
{
    public class DataHub : Hub
    {
        public async Task SendData(ArduinoData data)
        {
            await Clients.All.SendAsync("ReceiveData", data);
        }
    }
}