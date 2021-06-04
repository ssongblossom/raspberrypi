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

    internal class BluetoothPortService : IHostedService, IDisposable
    {
        private readonly SerialPort _BSerialPort;
        private readonly ILogger _logger;
        private Timer _timer;
        private readonly IHubContext<DataHub> _hubContext;
        internal static ArduinoData arduinoData = new ArduinoData();
        ArduinoData tempData = new ArduinoData();

        string[] strArr = new string[] {"DHT11", "DHT22", "DM460", "DM2007", "CO", "Alcohol", "CO2", "Tolueno", "NH4", "Acetona"};

        public BluetoothPortService(
            ILogger<BluetoothPortService> logger,
            SerialPort BSerialPort,
            IHubContext<DataHub> hubContext
            )
        {
            _hubContext = hubContext;
            _BSerialPort = BSerialPort;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Reading Arduino Data is starting");

            _BSerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

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
                TimeSpan.FromSeconds(2));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _logger.LogDebug($"Reading Arduino Data is working: {DateTime.Now}");
            var rng = new Random();

            _logger.LogDebug($"Read Success: {tempData.IsLastReadSuccessful}");
            if (tempData.IsLastReadSuccessful)
            {
                arduinoData = tempData;
                //DataPrint(arduinoData);
                _hubContext.Clients.All.SendAsync("ReceiveData", arduinoData);
            }

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

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort spl = (SerialPort)sender;
                string recievedData = spl.ReadLine();
                System.Console.WriteLine($"{recievedData}\n\n");
                DataProcessor(recievedData, tempData);
                
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                System.Console.WriteLine("Fail to recieve the data\n\r");
            }
        }

        public void DataPrint(ArduinoData data)
        {
            System.Console.WriteLine($"TEMP : DHT11 - {data.DHT11Temp}  DHT22 - {data.DHT22Temp}");
            System.Console.WriteLine($"Humidity: DHT11 - {data.DHT11Humid} DHT22 - {data.DHT22Humid}");
            System.Console.WriteLine($"Light Intensity: DM460 - {data.DM460LightIntensity} DM2007- {data.DM2007LightIntensity}");
            System.Console.WriteLine($"Air: CO - {data.CO} Alcohol- {data.Alcohol} CO2 - {data.CO2}");
            System.Console.WriteLine($"Tolueno: {data.Tolueno} NH4 - {data.NH4} Acetona - {data.Acetona}");
        }

        private void DataProcessor(string recievedData, ArduinoData data)
        {
            string result ="";
            string strData = recievedData.Substring(0,recievedData.Length); //개행문자 삭제
            int index = 0;

            //데이터를 ':'를 기준으로 split 0번째에는 센서이름, 1번째에는 센서 값
            string[] datas = strData.Split(':');

            //받은 데이터가 어떤 센서의 데이터인지 구하기 
            for(int i=0; i<10; i++)
            {
                string sensorName = strArr[i];
                if(datas[0].Equals(sensorName))
                {
                    index = i;
                    break;
                }
            }

            datas[1].Replace(" ",""); // 공백 제거
            
            //센서의 종류에 따라서 데이터 가공하기
            //dht11 or dht22 : (temp,humid)
            if(index ==0 || index ==1 )
            {
                string[] subs = datas[1].Split(','); //0: '(temp' /1: 'humid)'
                string temp = subs[0].Remove(0,1);    // '(' 제거
                string humid = subs[1].Remove(subs[1].Length-2); // ')' 제거

                if(index == 0)
                {
                    data.DHT11Temp = Convert.ToDouble(temp);
                    data.DHT11Humid = Convert.ToDouble(humid);
                }
                else if (index == 1)
                {
                    data.DHT22Temp = Convert.ToDouble(temp);
                    data.DHT22Humid = Convert.ToDouble(humid);
                }
            }
            //그 외 센서
            else 
            {
                switch (index)
                {
                    case 2:
                        data.DM460LightIntensity = Convert.ToInt32(datas[1]);
                        break;
                    case 3: 
                        data.DM2007LightIntensity = Convert.ToInt32(datas[1]);
                        break;
                    case 4:
                        data.CO = Convert.ToDouble(datas[1]);
                        break;
                    case 5: 
                        data.Alcohol = Convert.ToDouble(datas[1]);
                        break;
                    case 6:
                        data.CO2 = Convert.ToDouble(datas[1]);
                        break;
                    case 7:
                        data.Tolueno = Convert.ToDouble(datas[1]);
                        break;
                    case 8:
                        data.NH4 = Convert.ToDouble(datas[1]);
                        break;
                    case 9:
                        data.Acetona = Convert.ToDouble(datas[1]);
                        data.IsLastReadSuccessful = true;
                        break;
                    default:
                        break;
                }
            }
        }

    }


}