using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using blazorHub.Shared;
using System.IO.Ports;

namespace blazorHub.Server.Hubs
{
    public class ControlHub : Hub
    {
        private readonly SerialPort _BSerialPort;
        public ControlHub(SerialPort BSerialPort)
        {
            _BSerialPort=BSerialPort;
        }

        public async Task ReceiveSwitchStatus(bool toggle)
        {
             if (!toggle)
            {
                _BSerialPort.Write("1");
                System.Console.WriteLine("send 1");
            }
            else
            {
                _BSerialPort.Write("2");
                System.Console.WriteLine("send 2");
            }
            await Clients.All.SendAsync("ReceiveSwitchStatus", !toggle);
        }
    }
}