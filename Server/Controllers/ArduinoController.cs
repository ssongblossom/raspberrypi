/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR;
using blazorHub.Shared;
using System.IO.Ports;
using blazorHub.Server.Hubs;



namespace blazorHub.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArduinoController : ControllerBase
    {

        private readonly SerialPort _BSerialPort;
        private readonly ILogger<ArduinoController> logger;
        private readonly IHubContext<ControlHub> _hubContext;

        public ArduinoController(
            ILogger<ArduinoController> logger,
            SerialPort BSerialPort,
            IHubContext<ControlHub> hubContext
            )
        {
            _hubContext = hubContext;
            this.logger = logger;
            _BSerialPort = BSerialPort;
            System.Console.WriteLine("Arduino Controller");
        }


        [HttpGet]

        [HttpPost]
        public void Post([FromBody] bool toggle)
        {
            _hubContext.Clients.All.SendAsync("ReceiveSwitchStatus", toggle);
            System.Console.WriteLine("ArduinoController Post");
            if (toggle)
            {
                _BSerialPort.Write("1");
                System.Console.WriteLine("send 1");
            }
            else
            {
                _BSerialPort.Write("2");
                System.Console.WriteLine("send 2");
            }
        }
    }
}
*/