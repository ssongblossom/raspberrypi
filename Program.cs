using System;
using System.IO.Ports;

namespace bluetoothPairing
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialPort BSerialPort = new SerialPort("/dev/rfcomm0");
            BSerialPort.BaudRate = 9600;
            BSerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            try
            {
                if (!BSerialPort.IsOpen) 
                    BSerialPort.Open(); //만약 포트가 열려있지 않다면 엽시다.
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);//예외일 때 보여주기
            }

            while(true)
            {
                System.Console.WriteLine("1.start 2.stop 3.SerialPortClose");
                string input = Console.ReadLine();
                if(input.Equals("3")) //3번이면 시리얼 포트를 닫음 -> exeption error 발생 프로그램 종료
                    BSerialPort.Close();
                BSerialPort.Write(input);
            }
        }
        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort spl = (SerialPort)sender;
                string recievedData = spl.ReadLine();
                System.Console.WriteLine($"{recievedData}");
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Fail to recieve the data\n\r");
            }
        }
    }
}
