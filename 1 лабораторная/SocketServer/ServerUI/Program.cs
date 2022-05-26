using System;
using System.Configuration;
using ServerLibrary;

namespace ServerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!int.TryParse(ConfigurationManager.AppSettings["ServerPort"], out var port))
            {
                Console.WriteLine("Неверный Port");
            }
            else
            {
                var server = new Server(ConfigurationManager.AppSettings["ServerIP"], port, new ConsoleControl());

                server.Connect();
            }
        }
    }

    class ConsoleControl : IControl
    {
        public string EnterLine()
        {
            throw new NotImplementedException();
        }

        public void PrintLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
