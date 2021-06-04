/*
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using blazorHub.Server.Hubs;
using blazorHub.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;



namespace blazorHub.Server.Services
{
    internal class ArduinoCtrl : IHostedService, IDisposable
    {

        private readonly SerialPort _BSerialPort;
        private readonly ILogger<ArduinoCtrl> logger;
        private readonly IHubContext<ControlHub> _hubContext;

        public ArduinoCtrl(
            ILogger<ArduinoCtrl> logger,
            SerialPort BSerialPort,
            IHubContext<ControlHub> hubContext
            )
        {
            _hubContext = hubContext;
            this.logger = logger;
            _BSerialPort = BSerialPort;
            System.Console.WriteLine("Arduino Controller");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Arduino Controller is starting");

            try
            {
                if (!_BSerialPort.IsOpen) 
                    _BSerialPort.Open(); //만약 포트가 열려있지 않다면 엽시다.
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);//예외일 때 보여주기
            }

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _logger.LogDebug($"Arduino Controller is working: {DateTime.Now}");

            handleSwitchStatus += ReceiveSwitchStatus;
            hubConnection = new HubConnectionBuilder()
                    .WithUrl(NavigationManager.ToAbsoluteUri("/ctrlhub"))
                    .WithAutomaticReconnect()
                    .Build();
            hubConnection.On("ReceiveSwitchStatus", this.handleSwitchStatus);
            await hubConnection.StartAsync();

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Reading Arduino Data is stopping");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        Task ReceiveSwitchStatus(bool arg)
        {
            toggle = arg;
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
            return Task.CompletedTask;
        }
    }
}
*/